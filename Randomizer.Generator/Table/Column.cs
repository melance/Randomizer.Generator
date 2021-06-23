using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomizer.Generator.Table
{
	/// <summary>
	/// A column in a <see cref="Table"/>
	/// </summary>
	public class Column : List<Object>
	{
		/// <summary>The column name</summary>
		public String Name { get; set; }

		public Column(String name) => Name = name;
		public Column(String name, Int32 size) : this(name)
		{
			for (var i = 0; i < size; i++)
			{
				Add(null);
			}
		}

	}
}
