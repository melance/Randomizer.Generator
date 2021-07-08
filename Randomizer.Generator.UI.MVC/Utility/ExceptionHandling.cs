using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Randomizer.Generator.UI.MVC.Utility
{
	public static class ExceptionHandling
	{
		public static String GetExceptionDetails(Exception ex, Boolean includeFullException = false)
		{
			var message = new StringBuilder();
			
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
}
