using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Randomizer.Generator.Utility;

namespace Randomizer.Generator.Test
{
    [TestClass]
    public class UtilityTests
    {
        /// <summary>
        /// Gets or sets the test context which provides
        /// information about and functionality for the current test run.
        /// </summary>
        public TestContext TestContext { get; set; }

        private readonly DiceRoller _roller = new();

        [TestMethod]
		[TestCategory("Dice")]
        public void RollD2()
        {
            var result = _roller.Roll(2);
            Assert.AreEqual(1, _roller.Rolls.Count);
            Assertions.IsBetween(1, 2, result);
        }

        [TestMethod]
		[TestCategory("Dice")]
		public void Roll2D2()
        {
            var result = _roller.Roll(2, 2);
            Assert.AreEqual(2, _roller.Rolls.Count);
            Assertions.IsBetween(2, 4, result);
        }

        [TestMethod]
		[TestCategory("Dice")]
		public void Roll2d2KeepHighest()
        {
            var result = _roller.Roll(2, 2, "KH");
            Assert.AreEqual(1, _roller.KeepHighest);
            Assert.AreEqual(1, _roller.Rolls.Count);
            Assertions.IsBetween(1, 2, result);
        }

        [TestMethod]
		[TestCategory("Dice")]
		public void Roll4d2KeepHighest2()
        {
            var result = _roller.Roll(4, 2, "KH(2)");
            Assert.AreEqual(2, _roller.KeepHighest);
            Assert.AreEqual(2, _roller.Rolls.Count);
            Assertions.IsBetween(2, 4, result);
        }

        [TestMethod]
		[TestCategory("Dice")]
		public void Roll1d2Exploding()
        {
            var result = _roller.Roll(1, 2, "EX");
            Assert.IsTrue(_roller.Exploding);
            Assert.AreEqual(1, _roller.Rolls.Count);
            Assertions.IsBetween(1, 4, result);
        }

        [TestMethod]
		[TestCategory("Dice")]
		public void Roll1d2CompoundExploding()
        {
            var result = _roller.Roll(1, 2, "CEX");
            Assert.IsTrue(_roller.CompoundExploding);
            Assert.AreEqual(1, _roller.Rolls.Count);            
            Assertions.IsBetween(1, Int32.MaxValue, result);
        }

        [TestMethod]
		[TestCategory("Dice")]
		public void Roll10d20GreaterThanExploding()
        {
            var result = _roller.Roll(10, 20, "GT(10), EX");
            Assert.IsTrue(_roller.Exploding);
            Assert.AreEqual(10, _roller.GreaterThan);
            Assertions.IsBetween(0, 10, result);
        }

        [TestMethod]
		[TestCategory("String Conversion")]
        public void ToOrdinalTest()
        {
            Assert.AreEqual("1st", 1.ToOrdinal());
            Assert.AreEqual("2nd", 2.ToOrdinal());
            Assert.AreEqual("3rd", 3.ToOrdinal());
            Assert.AreEqual("4th", 4.ToOrdinal());
            Assert.AreEqual("101st", 101.ToOrdinal());
        }

        [TestMethod]
		[TestCategory("String Conversion")]
		public void ToRomanNumeralTest()
        {            
            Assert.AreEqual("MM", 2000.ToRomanNumerals());
            Assert.AreEqual("CM", 900.ToRomanNumerals());
            Assert.AreEqual("CVII", 107.ToRomanNumerals());
            Assert.AreEqual("MMXXI", 2021.ToRomanNumerals());
            Assert.AreEqual("0", 0.ToRomanNumerals());
            Assert.AreEqual("4001", 4001.ToRomanNumerals());
        }

        [TestMethod]
		[TestCategory("String Conversion")]
		public void ToTextTest()
        {
            Assert.AreEqual("one", 1.ToText());
            Assert.AreEqual("Two", 2.ToText(Core.TextCases.Title));
            Assert.AreEqual("Negative Two", (-2).ToText(Core.TextCases.Title));
            Assert.AreEqual("one hundred", 100.ToText());
            Assert.AreEqual("NINETY", 90.ToText(Core.TextCases.Upper));
            Assert.AreEqual("two hundred six", 206.ToText());
            Assert.AreEqual("Eight Hundred Trillion One", 800000000000001.ToText(Core.TextCases.Title));
        }
    }
}
