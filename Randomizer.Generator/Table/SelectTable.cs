using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomizer.Generator.Table
{

	public class SelectTable : BaseTable
	{
		public String SelectValue { get; set; }
		public String SelectColumn { get; set; }

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
