using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomizer.Generator.Exceptions
{
	public class ParameterValidationException : Exception
	{
		public ParameterValidationException(String message) : base(message) { }
	}
}
