using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Randomizer.Generator.Core;
using Randomizer.Generator.DataAccess;

namespace Randomizer.Generator.UI.MVC.Utility
{
	public class MVCDataAccess : FileSystemDataAccess
	{
		private const String FILE_EXTENSION = ".rgen.hjson";
		private const String DEFAULT_FILE_PATH = "..\\Definitions";

		internal static String DefinitionsPath { get; set; } = DEFAULT_FILE_PATH;

		public MVCDataAccess(String rootPath) : base(Path.Combine(rootPath, DefinitionsPath)) => SearchPattern = $"*{FILE_EXTENSION}";

		public static String FullPath(String path)
		{
			return Path.Combine(DefinitionsPath, path + FILE_EXTENSION);
		}

		public IEnumerable<Models.DefinitionInfo> GetDefinitionInfoList()
		{
			return GetDefinitionInfoList(null);
		}

		public IEnumerable<Models.DefinitionInfo> GetDefinitionInfoList(String tag)
		{
			var results = new List<Models.DefinitionInfo>();

			foreach (var definition in GetDefinitionList(db => db.Tags?.Count > 0  && 
															   db.ShowInList &&
															   (String.IsNullOrWhiteSpace(tag) || 															   
															   db.Tags.Contains(tag, StringComparer.CurrentCultureIgnoreCase))))
			{
				yield return definition;
			}
		}
	}
}
