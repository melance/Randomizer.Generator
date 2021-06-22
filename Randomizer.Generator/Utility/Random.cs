using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomizer.Generator.Utility
{
    class Random 
    {
        private static System.Random _random;

		public static Int32 RandomNumber() => Randomizer.Next();

		public static Int32 RandomNumber(Int32 maxValue) => Randomizer.Next(maxValue);

        public static Int32 RandomNumber(Int32 minValue, Int32 maxValue) => Randomizer.Next(minValue, maxValue);

        protected static System.Random Randomizer
        {
            get
            {
                if (_random == null) _random = new System.Random();
                return _random;
            }
        }
    }
}
