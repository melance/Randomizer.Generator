using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomizer.Generator.Table
{
	public class ColumnList : List<Column>
	{
		public Column this[String name] => this.Where(c => c.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

		public Int32 IndexOf(String name)
		{
			return IndexOf(this[name]);
		}
	}
}
