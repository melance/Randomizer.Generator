using System;
using System.Linq;
using System.Collections.Generic;

namespace Randomizer.Generator.Core
{
	/// <summary>
	/// A <see cref="System.Collections.Generic.List"/> of <see cref="ListOption"/> used to populate a <see cref="ParameterTypes.List"/> parameter
	/// </summary>
	public class ListOptionList : List<ListOption>
    {
		public ListOption this[String value]
		{
			get
			{
				return this.Where(li => li.Value.Equals(value)).FirstOrDefault();
			}
		}

		/// <summary>
		/// Add a <see cref="ListOption"/> with the provided Value and Display
		/// </summary>
		/// <param name="value">The value of the option used by the definition</param>
		/// <param name="display">The text to display to the user of the definition</param>
		public void Add(String value, String display)
        {
            Add(new ListOption(value, display));
        }
    }
}
