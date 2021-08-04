using Randomizer.Generator.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomizer.Generator.Table
{
	public class Table
	{
		#region Indexers
		public List<Object> this[String column]
		{
			get
			{
				var values = new List<Object>();
				foreach (var row in Rows)
				{
					values.Add(row[Columns.IndexOf(column)]);
				}
				return values;
			}
		}
		public Object this[String column, Int32 row] => Columns[column][row];
		public Object this[Int32 column, Int32 row] => Columns[column][row]; 
		public Row this[Int32 row]
		{
			get
			{
				var result = new Row();
				foreach (var column in Columns)
				{
					result.Add(column[row]);
				}
				return result;
			}
		}
		#endregion


		#region Properties
		public ColumnList Columns { get; private set; } = new();
		public Int32 RowCount => (Int32)Columns.FirstOrDefault()?.Count;
		public IEnumerable<Row> Rows
		{
			get
			{
				for (var i = 0; i < RowCount; i++)
				{
					yield return this[i];
				}
			}
		}
		#endregion

		#region Public Methods
		public Int32 RowIndex(Row row)
		{
			var rowList = Rows.ToList();
			for (var i = 0; i < Rows.Count(); i++)
			{
				if (rowList[i].Equals(row)) return i;
			}
			return -1;
		}

		public void AddColumn(String name)
		{
			var size = 0;

			if (Columns?.Count > 0)
				size = Columns.First().Count;

			Columns.Add(new Column(name, size));
		}

		public void RemoveColumn(String name)
		{
			var column = Columns.Where(c => c.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
			if (column == null) throw new ArgumentException($"Unknown column: {name}");
			Columns.Remove(column);
		}

		public void AddRow()
		{
			foreach (var column in Columns)
			{
				column.Add(null);
			}
		}

		public void AddRow(params Object[] values)
		{
			if (values != null && values.Length != Columns.Count) throw new ArgumentException($"Expected {Columns.Count} values for new row received {values.Length}");

			if (values != null)
			{
				for (var i = 0; i < Columns.Count; i++)
				{
					Columns[i].Add(values[i]);
				}
			}
			else
				AddRow();
		}

		public void RemoveRow(Int32 index)
		{
			if (index >= Columns.FirstOrDefault()?.Count) throw new ArgumentOutOfRangeException(nameof(index));
			foreach (var column in Columns)
			{
				column.RemoveAt(index);
			}
		}

		public void ClearRows()
		{
			foreach (var column in Columns)
			{
				column.Clear();
			}
		}

		public void Clear()
		{
			Columns = new();
		} 
		#endregion
	}
}
