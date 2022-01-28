using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomizer.Generator.UI.Terminal.Extensions
{
	static class VersionExtensions
	{
		public static String ToString(this Version extended, Boolean includeRevision = true)
		{
			if (includeRevision)
				return $"{extended.Major}.{extended.Minor}.{extended.Build:0000}:{extended.Revision:0000}";
			else
				return $"{extended.Major}.{extended.Minor}.{extended.Build:0000}";
		}
	}
}
