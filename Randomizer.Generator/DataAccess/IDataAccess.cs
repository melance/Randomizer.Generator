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
		BaseDefinition GetDefinition(String name);
		String GetDefinitionRaw(String name);
		BaseDefinition GetLibrary(String name);
		String GetText(String name);

		IEnumerable<BaseDefinition> GetDefinitionList();
		IEnumerable<BaseDefinition> GetLibraryList();
		IEnumerable<String> GetTagList();

		Boolean DefinitionExists(String name);
		Boolean LibraryExists(String name);
	}
}
