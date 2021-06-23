using System;

namespace Randomizer.Generator.Core
{
	/// <summary>
	/// A class that holds a single option to include for a list type parameter
	/// </summary>
	public class ListOption
    {
		/// <summary>The value of the option used by the definition</summary>
        public String Value { get; set; }
		/// <summary>The text to display to the user of the definition</summary>
        public String Display { get; set; }

		/// <summary>Construct a <see cref="ListOption"/> with a <see cref="String.Empty"/> <see cref="Value"/> and <see cref="Display"/></summary>
        public ListOption() { }
		/// <summary>
		/// Contructs a <see cref="ListOption"/> with values for the Value and Display properties
		/// </summary>
		/// <param name="value">The value of the option used by the definition</param>
		/// <param name="display">The text to display to the user of the definition</param>
		public ListOption(String value, String display) => (Value, Display) = (value, display);

		/// <summary>
		/// Returns a string that represents the <see cref="ListOption"/>
		/// </summary>
		/// <returns>The <see cref="Display"/> of the <see cref="ListOption"/></returns>
        public override String ToString()
        {
            return Display;
        }
    }
}
