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
		public ColumnList Columns { get; private set; } = new();

		public Object this[String column, Int32 row] => Columns[column][row];

		public Object this[Int32 column, Int32 row] => Columns[column][row];
		
		public List<Object> this[Int32 row]
		{
			get
			{
				var result = new List<Object>();
				foreach (var column in Columns)
				{
					result.Add(column[row]);
				}
				return result;
			}
		}

		public Int32 RowCount => (Int32)Columns.FirstOrDefault()?.Count;

		public IEnumerable<List<Object>> Rows
		{
			get
			{
				for (var i = 0; i < RowCount; i++)
				{
					yield return this[i];
				}
			}
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
	}
}
