using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomizer.Generator.Table
{
	/// <summary>
	/// A list of <see cref="Column"/>
	/// </summary>
	public class ColumnList : List<Column>
	{
		/// <summary>
		/// Retrieves the column with the given name
		/// </summary>
		/// <param name="name">THe name of the column</param>
		/// <returns>The named column</returns>
		public Column this[String name] => this.Where(c => c.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

		/// <summary>
		/// The index of the named column
		/// </summary>
		/// <param name="name">The name of the column</param>
		/// <returns>The index of the column</returns>
		public Int32 IndexOf(String name)
		{
			return IndexOf(this[name]);
		}
	}
}
