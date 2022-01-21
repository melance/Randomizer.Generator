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
		#region Properties
		public String DLLPath
		{
			get => GetProperty(String.Empty);
			set => SetProperty(value);
		}
		public String ClassName
		{
			get => GetProperty(String.Empty);
			set => SetProperty(value);
		}
		public String MethodName
		{
			get => GetProperty(String.Empty);
			set => SetProperty(value);
		}
		public override Boolean SupportsParameters => true;
		#endregion

		#region Public Methods
		public override String Generate()
		{
			ExceptionDispatchInfo edi = null;
			if (ValidateParameters())
			{
				try
				{

					var dll = Assembly.LoadFile(((DataAccess.FileSystemDataAccess)DataAccess.DataAccess.Instance).ExpandFilePath(DLLPath));
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
										if (Parameters.ContainsKey(parameter.Name))
											args.Add(Convert.ChangeType(Parameters[parameter.Name].TypedValue, parameter.ParameterType));
										else if (parameter.IsOptional)
											args.Add(null);
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
			}
			if (edi != null) edi.Throw();
			return String.Empty;
		}
		#endregion

		#region Private Methods
		private String GetMethodName()
		{
			if (MethodName.StartsWith('[') && MethodName.EndsWith(']'))
			{
				return Parameters[MethodName[1..^1]].Value;
			}
			return MethodName;
		} 
		#endregion
	}
}
