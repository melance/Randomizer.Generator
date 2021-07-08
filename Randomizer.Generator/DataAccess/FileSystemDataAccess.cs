using Randomizer.Generator.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Randomizer.Generator.DataAccess
{
	/// <summary>
	/// Data access that relies on the File System to store definition files.  
	/// </summary>
	public class FileSystemDataAccess : IDataAccess
	{
		private const String DEFAULT_SEARCH_PATTERN = "*.rgen.hjson";
		private const String DEFAULT_LIBRARY_SEARCH_PATTERN = "*.rlib.hjson";

		public String SearchPattern { get; set; } = DEFAULT_SEARCH_PATTERN;
		public String LibrarySearchPattern { get; set; } = DEFAULT_LIBRARY_SEARCH_PATTERN;

		public String RootPath { get; }

		public FileSystemDataAccess() => RootPath = Assembly.GetExecutingAssembly().Location;

		public FileSystemDataAccess(String rootPath) => RootPath = rootPath;

		public Boolean DefinitionExists(String name)
		{
			return GetDefinitionList(bd => !String.IsNullOrWhiteSpace(bd.Name) && bd.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase)).Any();
		}
		
		public BaseDefinition GetDefinition(String name)
		{
			return GetDefinitionList(bd => !String.IsNullOrWhiteSpace(bd.Name) && bd.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
		}

		public IEnumerable<BaseDefinition> GetDefinitionList()
		{
			return GetDefinitionList(null);
		}

		public IEnumerable<BaseDefinition> GetDefinitionList(Func<BaseDefinition, Boolean> filter)
		{
			return GetDefinitions(SearchPattern, filter);
		}

		public Boolean LibraryExists(String name)
		{
			return GetLibraryList(bd => !String.IsNullOrWhiteSpace(bd.Name) && bd.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase)).Any();
		}

		public BaseDefinition GetLibrary(String name)
		{
			return GetLibraryList(bd => !String.IsNullOrWhiteSpace(bd.Name) && bd.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
		}

		public IEnumerable<BaseDefinition> GetLibraryList()
		{
			return GetLibraryList(null);
		}

		public IEnumerable<BaseDefinition> GetLibraryList(Func<BaseDefinition, Boolean> filter)
		{
			return GetDefinitions(LibrarySearchPattern, filter);
		}

		public IEnumerable<String> GetTagList()
		{
			return GetDefinitionList().Select(d => d.Tags).SelectMany(t => t).Distinct().OrderBy(t => t);
		}

		private IEnumerable<BaseDefinition> GetDefinitions(String searchPattern, Func<BaseDefinition, Boolean> filter)
		{
			var fullPath = Path.GetFullPath(RootPath);
			foreach (var file in Directory.GetFiles(fullPath, searchPattern))
			{
				var definition = BaseDefinition.Deserialize(File.ReadAllText(file));
				if (filter == null || filter.Invoke(definition))
					yield return definition;
			}
		}
	}
}
