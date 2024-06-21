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
	public class SerializationTests
	{
		[TestMethod]
		public void BaseInformationSerialization()
		{
			var hjson = Properties.Resources.AD_DeserializeTest_rgen;
			var information = DefinitionInformation.Deserialize(hjson);
			Assert.IsNotNull(information);
			Assert.IsTrue(String.IsNullOrEmpty(information.Name));
		}
	}
}
