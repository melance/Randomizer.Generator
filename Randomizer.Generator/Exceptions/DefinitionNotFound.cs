using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomizer.Generator.Exceptions
{
	public class DefinitionNotFoundException : Exception
	{
		public DefinitionNotFoundException(String name) : base($"Could not locate definition: {name}.") { }
	}
}
