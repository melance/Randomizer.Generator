using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomizer.Generator.Test
{
    static class Assertions
    {
        public static void IsBetween(Int32 min, Int32 max, Int32 value)
        {
            Assert.IsTrue(value >= min && value <= max, $"Expected value between {min} and {max}.  Value was {value}.");
        }
    }
}
