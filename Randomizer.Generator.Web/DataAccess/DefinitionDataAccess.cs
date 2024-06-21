using Randomizer.Generator.DataAccess;

namespace Randomizer.Generator.Web.DataAccess
{
	public class DefinitionDataAccess : FileSystemDataAccess
	{
		
		public DefinitionDataAccess(IWebHostEnvironment environment) 
		{
			var paths = new List<String>() 
			{
				Path.Combine(environment.WebRootPath, "Definitions"),
				Path.Combine(environment.WebRootPath, "Definitions", "Libraries"),
				Path.Combine(environment.WebRootPath, "Definitions", "Sources")
			};
			((List<String>)RootPaths).Clear();
			((List<String>)RootPaths).AddRange(paths);
			SearchOption = SearchOption.AllDirectories;
			Generator.DataAccess.DataAccess.Instance = this;
		}
	}
}
