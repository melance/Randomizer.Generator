using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomizer.Generator.Core
{
    public class ListOption
    {
        private const char DELIMITER = ':';

        public String Value { get; set; }
        public String Display { get; set; }

        public ListOption() { }
        public ListOption(String value, String display) => (Value, Display) = (value, display);

        public static explicit operator ListOption(String value)
        {
            var parts = value.Split(DELIMITER);
            if (parts.Length == 2)
            {
                return new ListOption(parts[0].Trim(), parts[1].Trim());
            }
            else
            {
                throw new InvalidCastException($"Could not convert string {value} to type {typeof(ListOption).FullName}");
            }
        }

        public override String ToString()
        {
            return Display;
        }
    }
}
