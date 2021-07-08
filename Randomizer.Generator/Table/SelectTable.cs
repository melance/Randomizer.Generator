using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomizer.Generator.Table
{
	/// <summary>
	/// Selects a row based on the SelectValue and SelectColumn
	/// </summary>
	public class SelectTable : BaseTable
	{
		/// <summary>The value to look for in <see cref="SelectColumn"/></summary>
		public String SelectValue { get; set; }
		/// <summary>The column to look for <see cref="SelectValue"/></summary>
		public String SelectColumn { get; set; } = "Select";

		/// <summary>
		/// Find a row based on <see cref="SelectValue"/>
		/// </summary>
		protected override Dictionary<String, String> ProcessTableInternal()
		{
			Object value;
			var result = new Dictionary<String, String>();
			var colIndex = ParsedTable.Columns.IndexOf(ParsedTable.Columns[SelectColumn]);

			value = OnEvaluate<Object>(SelectValue);

			var rows = ParsedTable.Rows.Where(o => o[colIndex].Equals(value));

			if (rows != null && rows.Any())
			{
				foreach (var row in rows)
					ProcessRow(result, row);
			}

			return result;
		}
	}
}
