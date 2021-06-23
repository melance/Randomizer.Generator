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
		public String SelectColumn { get; set; }

		/// <summary>
		/// Find a row based on <see cref="SelectValue"/>
		/// </summary>
		protected override Dictionary<String, String> ProcessTableInternal()
		{
			Object value;
			var result = new Dictionary<String, String>();
			var colIndex = Table.Columns.IndexOf(Table.Columns[SelectColumn]);
			var index = 0;

			value = OnEvaluate<Object>(SelectValue);

			var row = Table.Rows.Where(o => o[colIndex].Equals(value));

			while (!Table[SelectColumn, index].Equals(value) && index < Table.RowCount)
			{
				index++;
			}

			if (row != null)
				ProcessRow(result, index--);

			return result;
		}
	}
}
