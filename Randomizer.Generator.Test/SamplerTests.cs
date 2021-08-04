using Microsoft.VisualStudio.TestTools.UnitTesting;
using Randomizer.Generator.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomizer.Generator.Test
{
	[TestClass]
	public class SamplerTests
	{

		public TestContext TestContext { get; set; }

		[TestMethod]
		[TestCategory("Serialization")]
		public void SamplerSerializeTest()
		{
			var definition = new Sampler.SamplerDefinition();
			definition.Samples.Add("Test", new Sampler.Sample() { Content = "List\nof\nnames" });
			TestContext.WriteLine(BaseDefinition.Serialize(definition));
		}
	}
}
