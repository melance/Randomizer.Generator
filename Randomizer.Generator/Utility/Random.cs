using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomizer.Generator.Utility
{
	/// <summary>
	/// Static methods for <see cref="System.Random"/> that allows a single instance of the class because if we recreate the 
	/// instance too quickly we continuously get the same results
	/// </summary>
    static class Random 
    {
        private static System.Random _random;

		public static Int32 RandomNumber() => Randomizer.Next();

		public static Int32 RandomNumber(Int32 maxValue) => Randomizer.Next(maxValue);

        public static Int32 RandomNumber(Int32 minValue, Int32 maxValue) => Randomizer.Next(minValue, maxValue);

        static System.Random Randomizer
        {
            get
            {
                if (_random == null) _random = new System.Random();
                return _random;
            }
        }
    }
}
