using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomizer.Generator.Exceptions
{
	class InvalidPropertyValueException : RandomizerGeneratorException
	{
		public String PropertyName { get; }

		public InvalidPropertyValueException() : base() { }
		public InvalidPropertyValueException(String message) : base(message) { }
		public InvalidPropertyValueException(String propertyName, String message) : base($"{propertyName}: {message}") => PropertyName = PropertyName;
	}
}
