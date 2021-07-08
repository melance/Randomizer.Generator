using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomizer.Generator.UI.Terminal.Utility
{
	static class HelperMethods
	{
		public static void OpenURL(String url)
		{
			Process.Start(new ProcessStartInfo()
			{
				UseShellExecute = true,
				FileName = url
			});
		}
	}
}
