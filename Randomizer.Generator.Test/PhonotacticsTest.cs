using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Randomizer.Generator.Phonotactics;
using Randomizer.Generator.Core;

namespace Randomizer.Generator.Test
{
    [TestClass]
    public class PhonotacticsTest
    {
        /// <summary>
        /// Gets or sets the test context which provides
        /// information about and functionality for the current test run.
        /// </summary>
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void SimpleTest()
        {
            var generator = new PhonotacticsDefinition();
            generator.Definitions.Add('C', new DefinitionList() { "TEST" });
            generator.Patterns.Add("C", new PatternList() { { "C", 1 } });
            var result = generator.Generate();
            Assert.AreEqual("TEST", result);
        }

        [TestMethod]
        public void SerializeTest()
        {
            var generator = new PhonotacticsDefinition();
            generator.Definitions.Add('C', new DefinitionList() { "B", "C", "D", "F", "G", "H", "J", "K", "L", "M", "N", "P", "Q", "R", "S", "T", "V", "W", "X", "Y", "Z" });
            generator.Definitions.Add('V', new DefinitionList() { "A", "E", "I", "O", "U" });
            generator.Patterns.Add("Only", new PatternList() { { "CVC", 50 }, { "CCV", 50 } });
            TestContext.WriteLine(BaseDefinition.Serialize(generator));
        }

        [TestMethod]
        public void DeserializeTest()
        {
            var generator = BaseDefinition.Deserialize<PhonotacticsDefinition>(Properties.Resources.PhonotacticsTest_rgen);
            var value = generator.Generate();
            TestContext.WriteLine($"Value = {value}");
            Assert.AreNotEqual(String.Empty, value);
        }

        [TestMethod]
        public void TokenizerTest()
        {
            var tokens = Tokenizer.Tokenize("AB^CD");
            Assert.AreEqual(TokenTypes.Key, tokens[0].TokenType);
            Assert.AreEqual(TokenTypes.Key, tokens[1].TokenType);
            Assert.AreEqual(TokenTypes.Optional, tokens[2].TokenType);
            Assert.AreEqual(TokenTypes.Key, tokens[3].TokenType);

            Assert.AreEqual('A', tokens[0].Value);
            Assert.AreEqual('B', tokens[1].Value);
            Assert.AreEqual('C', tokens[2].Value);
            Assert.AreEqual('D', tokens[3].Value);
        }
    }
}
