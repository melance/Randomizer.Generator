using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Randomizer.Generator.UI.MVC.Utility
{
	public static class Extensions
	{
		public static void LogError<T>(this ILogger<T> extended, Exception ex)
		{
			var iex = ex;

			while (iex != null)
			{
				extended.LogError(iex.ToString());
				foreach (var key in iex.Data.Keys)				
				{
					extended.LogError($"{key}: {iex.Data[key]}");
				}
				iex = iex.InnerException;
			}
		}
	}
}
