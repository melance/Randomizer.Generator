using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomizer.Generator.Win.Helpers
{
	internal static class Extensions
	{
		public static String ToHTML(this Exception ex)
		{
			if (ex == null)
				return String.Empty;
			var template = new Templates.ExceptionTemplate(ex);
			return template.TransformText();
		}
	}
}
