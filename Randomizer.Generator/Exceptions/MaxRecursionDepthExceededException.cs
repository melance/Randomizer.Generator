using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomizer.Generator.Exceptions
{
    /// <summary>
    /// Thrown if the assignment generator gets to too deep a level of recursion
    /// </summary>
    public class MaxRecursionDepthExceededException : RandomizerGeneratorException
	{
        public MaxRecursionDepthExceededException(Int32 maxRecursionDepth) : base($"The generator has exceeded the maximum allowed recursion depth of {maxRecursionDepth}")
        {
        }
    }
}
