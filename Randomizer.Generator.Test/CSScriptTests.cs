using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Randomizer.Generator.DotNet;

namespace Randomizer.Generator.Test
{
	[TestClass]
	public class CSScriptTests
	{
		[TestMethod()]
		[TestCategory("DotNet")]
		public void SimpleTest()
		{
			var generator = new DotNetDefinition()
			{
				Name = "Simple Test",
				DLLPath = @"using System;
						   using System.Collections.Generic;
						   public Dictionary<String, Object> Parameters { get; set; }

						   public string Generate()
						   {
								return ""Generated"";
						   }"
			};

			var result = generator.Generate();
			Assert.AreEqual("Generated", result);
		}
	}
}
