using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Randomizer.Generator.Core;
using System.Runtime.ExceptionServices;
using System.Reflection;

namespace Randomizer.Generator.DotNet
{
	public class DotNetDefinition : BaseDefinition
	{
		public String DLLPath { get; set; }
		public String ClassName { get; set; }
		public String MethodName { get; set; }

		public override String Generate()
		{
			ExceptionDispatchInfo edi;
			try
			{
				base.Generate();
				var dll = Assembly.LoadFile(DLLPath);

				
				
				foreach (Type type in dll.ExportedTypes)
				{
					if (type.FullName.Equals(ClassName))
					{
						foreach (var method in type.GetMethods())
						{
							if (method.Name.Equals(GetMethodName()))
							{
								var args = new List<Object>();								
								foreach (var parameter in method.GetParameters())
								{
									args.Add(Convert.ChangeType(Parameters[parameter.Name].TypedValue, parameter.ParameterType));
								}
								return method.Invoke(null, args.ToArray()).ToString();
							}
						}
					}
				}
				throw new Exception("Could not locate the class.");
			}
			catch (Exception ex)
			{
				edi = ExceptionDispatchInfo.Capture(ex);
				ex.Data.Add(nameof(DLLPath), DLLPath);
				ex.Data.Add(nameof(ClassName), ClassName);
				ex.Data.Add(nameof(MethodName), MethodName);
			}
			if (edi != null) edi.Throw();
			return String.Empty;
		}

		private String GetMethodName()
		{
			if (MethodName.StartsWith('[') && MethodName.EndsWith(']'))
			{
				return Parameters[MethodName[1..^1]].Value;
			}
			return MethodName;
		}
	}
}
