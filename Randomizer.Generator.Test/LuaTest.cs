using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Randomizer.Generator.Lua;
using Randomizer.Generator.Core;

namespace Randomizer.Generator.Test
{
	[TestClass]
	public class LuaTest
	{
		/// <summary>
		/// Gets or sets the test context which provides
		/// information about and functionality for the current test run.
		/// </summary>
		public TestContext TestContext { get; set; }

		[TestMethod]
		[TestCategory("Serialization")]
		public void LuaSerializeTest()
		{
			var generator = new LuaDefinition()
			{
				Name = "Lua Test",
				Description = "Lua Test",
				Script = "print(\"Hello World\")",
				Parameters = new Core.ParameterDictionary()				
			};

			var result = BaseDefinition.Serialize(generator, true);
			TestContext.WriteLine(result);
		}

		[TestMethod]
		[TestCategory("Serialization")]
		public void LuaDeserializeTest()
		{
			var generator = BaseDefinition.Deserialize(Properties.Resources.Lua_Deserialize_rgen);
			var result = generator.Generate();

			Assert.AreEqual("Hello World", result);
		}
	}
}
