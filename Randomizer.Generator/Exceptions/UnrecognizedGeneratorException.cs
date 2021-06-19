using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomizer.Generator.Exceptions
{
    public class UnrecognizedGeneratorException : Exception
    {
        public UnrecognizedGeneratorException(String generatorTypeName) : base($"Unrecognized generator type: {generatorTypeName}") { }
    }
}
