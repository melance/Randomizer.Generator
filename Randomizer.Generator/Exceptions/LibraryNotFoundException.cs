using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomizer.Generator.Exceptions
{
    /// <summary>
    /// Thrown when a request for library returns null
    /// </summary>
    public class LibraryNotFoundException : RandomizerGeneratorException
	{
        public LibraryNotFoundException(string name) : base($"Unable to locate the library named '{name}'")
        {
        }
    }
}
