using Randomizer.Generator.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Runtime.ExceptionServices;

namespace Randomizer.Generator.DataAccess
{
	/// <summary>
	/// Data access that relies on the File System to store definition files.  
	/// </summary>
	public class FileSystemDataAccess : IDataAccess
	{

		#region Constants
		private const String DEFAULT_SEARCH_PATTERN = "*.rgen.hjson";
		private const String DEFAULT_LIBRARY_SEARCH_PATTERN = "*.rlib.hjson";
		#endregion

		#region Properties
		public String SearchPattern { get; set; } = DEFAULT_SEARCH_PATTERN;
		public String LibrarySearchPattern { get; set; } = DEFAULT_LIBRARY_SEARCH_PATTERN;

		public virtual String RootPath { get; }
		#endregion

		#region Public Methods
		public FileSystemDataAccess() => RootPath = Assembly.GetExecutingAssembly().Location;

		public FileSystemDataAccess(String rootPath) => RootPath = rootPath;

		public virtual string ExpandFilePath(String path)
		{
			if (Path.IsPathRooted(path)) return path;
			return Path.Combine(RootPath, path);
		}

		public virtual String GetText(String path)
		{
			if (!Path.IsPathRooted(path)) path = Path.Combine(RootPath, path);
			return File.ReadAllText(path);
		}

		public virtual Boolean DefinitionExists(String name)
		{
			return GetDefinitionList(bd => !String.IsNullOrWhiteSpace(bd.Name) && bd.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase)).Any();
		}

		public virtual GetDefinitionResponse GetDefinition(String name)
		{
			return GetDefinitionList(bd => !String.IsNullOrWhiteSpace(bd.Name) && bd.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
		}

		public virtual String GetDefinitionRaw(String name)
		{
			return GetDefinitionsRaw(SearchPattern, bd => bd.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
		}

		public virtual String GetDefinitionPath(String name)
		{
			return GetDefinitionPaths(SearchPattern, bd => bd.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
		}

		public virtual GetDefinitionListResponse GetDefinitionList()
		{
			return GetDefinitionList(null);
		}

		public virtual GetDefinitionListResponse GetDefinitionList(Func<BaseDefinition, Boolean> filter)
		{
			return GetDefinitions(SearchPattern, filter);
		}

		public virtual Boolean LibraryExists(String name)
		{
			return GetLibraryList(bd => !String.IsNullOrWhiteSpace(bd.Name) && bd.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase)).Any();
		}

		public virtual GetDefinitionResponse GetLibrary(String name)
		{
			return GetLibraryList(bd => !String.IsNullOrWhiteSpace(bd.Name) && bd.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
		}

		public virtual GetDefinitionListResponse GetLibraryList()
		{
			return GetLibraryList(null);
		}

		public virtual GetDefinitionListResponse GetLibraryList(Func<BaseDefinition, Boolean> filter)
		{
			return GetDefinitions(LibrarySearchPattern, filter);
		}

		public virtual IEnumerable<String> GetTagList()
		{
			return GetDefinitionList().Select(d => d.Definition.Tags).SelectMany(t => t).Distinct().OrderBy(t => t);
		}

		public virtual IEnumerable<String> GetTagList(Func<BaseDefinition, Boolean> filter)
		{
			return GetDefinitionList(filter).Select(d => d.Definition.Tags).SelectMany(t => t).Distinct().OrderBy(t => t);
		}
		#endregion

		#region Private Methods
		private GetDefinitionListResponse GetDefinitions(String searchPattern, Func<BaseDefinition, Boolean> filter)
		{
			var response = new GetDefinitionListResponse();
			var fullPath = Path.GetFullPath(RootPath);
			foreach (var file in Directory.GetFiles(fullPath, searchPattern))
			{
				try
				{
					BaseDefinition definition = null;
					definition = BaseDefinition.Deserialize(File.ReadAllText(file));					
					if (filter == null || filter.Invoke(definition))
						response.Add(definition);
				}
				catch (Exception ex)
				{
					response.Add(file, ex);
				}
			}
			return response;
		}

		private IEnumerable<String> GetDefinitionsRaw(String searchPattern, Func<BaseDefinition, Boolean> filter)
		{
			var fullPath = Path.GetFullPath(RootPath);
			foreach (var file in Directory.GetFiles(fullPath, searchPattern))
			{
				BaseDefinition definition = null;
				ExceptionDispatchInfo exi = null;
				try
				{
					definition = BaseDefinition.Deserialize(File.ReadAllText(file));
				}
				catch (Exception ex)
				{
					exi = ExceptionDispatchInfo.Capture(ex);
					ex.Data.Add("File", file);
				}
				if (exi != null) exi.Throw();
				if (filter == null || filter.Invoke(definition))
					yield return File.ReadAllText(file);
			}
		}

		private IEnumerable<String> GetDefinitionPaths(String searchPattern, Func<BaseDefinition, Boolean> filter)
		{
			var fullPath = Path.GetFullPath(RootPath);
			foreach (var file in Directory.GetFiles(fullPath, searchPattern))
			{
				BaseDefinition definition = null;
				ExceptionDispatchInfo exi = null;
				try
				{
					definition = BaseDefinition.Deserialize(File.ReadAllText(file));
				}
				catch (Exception ex)
				{
					exi = ExceptionDispatchInfo.Capture(ex);
					ex.Data.Add("File", file);
				}
				if (exi != null) exi.Throw();
				if (filter == null || filter.Invoke(definition))
					yield return file;
			}
		}
	}
		#endregion
}
