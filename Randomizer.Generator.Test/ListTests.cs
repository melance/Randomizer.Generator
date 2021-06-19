using Microsoft.VisualStudio.TestTools.UnitTesting;
using Randomizer.Generator.List;
using Randomizer.Generator.Core;
using System.Collections.Generic;

namespace Randomizer.Generator.Test
{
    [TestClass]
    public class ListTests
    {
        /// <summary>
        /// Gets or sets the test context which provides
        /// information about and functionality for the current test run.
        /// </summary>
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void ZeroItemGenerator()
        {
            var generator = new ListDefinition()
            {
                Name = "Test"
            };
            var result = generator.Generate();
            Assert.AreEqual(result, string.Empty);
        }

        [TestMethod]
        public void OneItemGenerator()
        {
            const string ITEM_ONE = "Item One";
            var generator = new ListDefinition()
            {
                Name = "Test",
                Items = new List<string> { ITEM_ONE }
            };
            var result = generator.Generate();
            Assert.AreEqual(result, ITEM_ONE);
        }

        [TestMethod]
        public void KeepWhitespace()
        {
            const string ITEM_ONE = "Item One ";
            var generator = new ListDefinition()
            {
                Name = "Test",
                Items = new List<string> { ITEM_ONE },
                KeepWhitespace = true
            };
            var result = generator.Generate();
            Assert.AreEqual(result, ITEM_ONE);
        }

        [TestMethod]
        public void MultiItemGenerator()
        {
            var items = new List<string>() { "Item One", "Item Two", "Item Three" };
            var generator = new ListDefinition()
            {
                Name = "Test",
                Items = items
            };
            var result = generator.Generate();
            TestContext.WriteLine(result);
            Assert.IsTrue(items.Contains(result));
        }

        [TestMethod]
        public void Serialize()
        {
            var items = new List<string>() { "Item One", "Item Two", "Item Three" };
            var generator = new ListDefinition()
            {
                Name = "Test",
                Author = "Lance",
                Description = "Testing Serialization",
                GeneratorType = GeneratorTypes.List,
                KeepWhitespace = false,
                OutputFormat = OutputFormats.Text,
                Tags = new List<string>() { "Test" },
                URL = "https://www.google.com",
                Version = new System.Version(1,0,0,0),
                Items = items
            };
            TestContext.WriteLine(generator);
        }

        [TestMethod]
        public void Deserialize()
        {
            var items = new List<string>() { "Item One", "Item Two", "Item Three" };
            var json = "{\"Items\":[\"Item One\",\"Item Two\",\"Item Three\"],\"KeepWhitespace\":false,\"Name\":\"Test\",\"Author\":\"Lance\",\"Description\":\"Testing Serialization\",\"Version\":{\"Major\":1,\"Minor\":0,\"Build\":0,\"Revision\":0,\"MajorRevision\":0,\"MinorRevision\":0},\"URL\":\"https://www.google.com\",\"Tags\":[\"Test\"],\"GeneratorType\":\"List\",\"OutputFormat\":\"Text\"}";
            var generator = (ListDefinition)json;
            var result = generator.Generate();
            Assert.IsTrue(items.Contains(result));
        }
    }
}