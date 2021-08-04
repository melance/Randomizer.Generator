using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomizer.Generator.Exceptions
{
    class MaxLoopCountException : RandomizerGeneratorException
	{
        /// <summary>
        /// Thrown when an assignment generator enters the Evaluate method too many times
        /// </summary>
        /// <param name="max">Maximum number of evaluations allowed</param>
        public MaxLoopCountException(Int32 max) : base($"The maximum number of loops ({max}) through items has been reached.  Please check that your generator does not have an infinite loop.")
        {
        }
    }
}
