using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;


namespace Randomizer.Generator.Utility
{
    static class Random 
    {
		public static Int32 RandomNumber() => RandomNumberGenerator.GetInt32(Int32.MaxValue);
		public static Int32 RandomNumber(Int32 maxValue) => RandomNumberGenerator.GetInt32(maxValue);
        public static Int32 RandomNumber(Int32 minValue, Int32 maxValue) => RandomNumberGenerator.GetInt32(minValue, maxValue + 1);
    }
}
