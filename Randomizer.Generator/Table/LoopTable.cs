using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomizer.Generator.Table
{
	/// <summary>
	/// A table that returns a result for each row in the table
	/// </summary>
	public class LoopTable : BaseTable
	{
		/// <summary>The column used as the name for the result</summary>
		public String KeyColumn { get; set; }

		/// <summary>
		/// Loops through each row in the table and constructs a result with the name "KeyColumnValue.ColumnName"
		/// </summary>
		/// <returns></returns>
		protected override Dictionary<String, String> ProcessTableInternal()
		{
			var results = new Dictionary<String, String>();
			var count = GetRepeat();
			var idIndex = Table.Columns.IndexOf(KeyColumn);

			// Repeat as requested
			for (var i = 1; i <= count; i++)
			{
				// Loop through each row of the table
				foreach (var row in Table.Rows)
				{
					// Get the id for the column property
					var id = row[idIndex].ToString();
					for (var k = 0; k < Table.Columns.Count; k++)
					{
						// Create the key for the result
						var key = $"{id}.{Table.Columns[k].Name}";
						// Get and evaluate the expression
						var expression = row[k].ToString();
						var value = OnEvaluate<Object>(expression);
						// Store the results from the expression in teh results dictionary
						if (results.ContainsKey(key))
							results[key] += $"{RepeatJoin}{value}";
						else
							results.Add(key, value.ToString());
					}
				}
			}
			return results;
		}
	}
}
