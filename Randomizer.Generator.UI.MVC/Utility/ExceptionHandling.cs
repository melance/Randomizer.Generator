using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NLog;

namespace Randomizer.Generator.UI.MVC.Utility
{
	public static class ExceptionHandling
	{
		public static String GetExceptionDetails(Exception ex, Boolean includeFullException = false)
		{
			var message = new StringBuilder();
			var rngGenEx = GetRndGenException(ex);

			if (rngGenEx != null)
			{
				message.AppendLine(rngGenEx.Message);
				message.AppendLine();
				if (rngGenEx.Data != null && rngGenEx.Data.Count > 0)
				{
					message.AppendLine("Data:");

					foreach (var key in rngGenEx.Data.Keys)
					{
						if (rngGenEx.Data[key].GetType().IsValueType)
							message.AppendLine($"{key} = {rngGenEx.Data[key]}");
						else
							message.AppendLine($"{key} = {System.Text.Json.JsonSerializer.Serialize(rngGenEx.Data[key], new System.Text.Json.JsonSerializerOptions() { WriteIndented = true })}");
					}
				}
				return message.ToString();
			}
			else
			{
				if (includeFullException)
				{
					message.Append(ex.ToString());
				}
				else
				{
					message.AppendLine(ex.Message);
					var iex = ex.InnerException;
					while (iex != null)
					{
						message.AppendLine(iex.Message);
						iex = iex.InnerException;
					}
				}

				message.AppendLine();

				if (ex.Data != null && ex.Data.Count > 0)
				{
					message.AppendLine("Data:");

					foreach (var key in ex.Data.Keys)
					{
						if (ex.Data[key].GetType().IsValueType)
							message.AppendLine($"{key} = {ex.Data[key]}");
						else
							message.AppendLine($"{key} = {System.Text.Json.JsonSerializer.Serialize(ex.Data[key], new System.Text.Json.JsonSerializerOptions() { WriteIndented = true })}");
					}
				}
				return message.ToString();
			}
		}

		/// <summary>
		/// Looks through the inner exceptions to see if one of the Randomizer.Generator exceptions is buries and returns that exception
		/// </summary>
		private static Exception GetRndGenException(Exception ex)
		{
			if (ex.GetType().IsSubclassOf(typeof(Randomizer.Generator.Exceptions.RandomizerGeneratorException)))
				return ex;
			else if (ex.InnerException != null)
				return GetRndGenException(ex.InnerException);
			else
				return null;				
		}

		
	}
}
