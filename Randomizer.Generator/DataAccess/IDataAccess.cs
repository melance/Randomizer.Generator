using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Randomizer.Generator.Core;

namespace Randomizer.Generator.DataAccess
{
	public interface IDataAccess
	{
		GetDefinitionResponse GetDefinition(String name);
		String GetDefinitionRaw(String name);
		GetDefinitionResponse GetLibrary(String name);
		String GetText(String name);

		GetDefinitionListResponse GetDefinitionList();
		GetDefinitionListResponse GetLibraryList();
		IEnumerable<String> GetTagList();

		Boolean DefinitionExists(String name);
		Boolean LibraryExists(String name);
	}
}
