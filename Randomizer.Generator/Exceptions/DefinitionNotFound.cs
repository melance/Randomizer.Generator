using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomizer.Generator.Exceptions
{
	public class DefinitionNotFoundException : RandomizerGeneratorException
	{
		public DefinitionNotFoundException(String name) : base("Could not locate definition.") { Data.Add("Name", name); }
	}
}
