using Microsoft.VisualStudio.TestTools.UnitTesting;
using Randomizer.Generator.Core;
using Randomizer.Generator.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomizer.Generator.Test
{
	[TestClass]
	public class TableTests
	{
		/// <summary>
		/// Gets or sets the test context which provides
		/// information about and functionality for the current test run.
		/// </summary>
		public TestContext TestContext { get; set; }

		[TestMethod]
		[TestCategory("Table")]
		public void BuildTableTest()
		{
			var table = new Table.Table();
			table.AddColumn("Test");
			table.AddColumn("Blue");
			table.AddRow("Value 1", 2);

			Assert.AreEqual("Value 1", table[0, 0]);
			Assert.AreEqual(2, table["Blue", 0]);
		}

		[TestMethod]
		[TestCategory("Serialization")]
		public void TableSerialize()
		{
			var generator = new TableDefinition()
			{
				Name = "Table Test"
			};
			var lTable = new LoopTable()
			{
				KeyColumn = "Key",
				Value = @"Key | Value
						  1   | Test"
			};
			generator.Tables.Add("LoopTable", lTable);
			var result = BaseDefinition.Serialize(generator);
			TestContext.WriteLine(result);
		}

		[TestMethod]
		[TestCategory("Serialization")]
		public void TableDeserialize()
		{
			var generator = BaseDefinition.Deserialize(Properties.Resources.TD_DeserializeTest_rgen);
			Assert.AreEqual(typeof(TableDefinition), generator.GetType());
			var value = generator.Generate();
			TestContext.WriteLine($"Value = {value}");
			Assert.AreNotEqual(String.Empty, value);
		}
	}
}
