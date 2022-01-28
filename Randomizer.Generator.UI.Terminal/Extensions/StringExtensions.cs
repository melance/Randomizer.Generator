using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomizer.Generator.UI.Terminal.Extensions
{
	static class StringExtensions
	{
		public static String ShortenPath(this String fullPath, Int32 length)
		{
			if (fullPath.Length < length)
				return fullPath;
			var parts = new List<String>(fullPath.Split(Path.DirectorySeparatorChar));
			var root = Path.GetPathRoot(fullPath);
			var shortPath = new StringBuilder($"{root}..");
			var insertIndex = shortPath.Length;

			do
			{
				shortPath.Insert(insertIndex, parts.Last());
				parts.RemoveAt(parts.Count - 1);
				if (parts.Count > 0)
					shortPath.Insert(insertIndex, Path.DirectorySeparatorChar);
			} while (parts.Count > 0 && shortPath.Length + parts.Last().Length < length - 2);

			return shortPath.ToString();
		}
	}
}
