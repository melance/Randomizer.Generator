using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomizer.Generator.Table
{
	public class Row : List<Object>
	{
		public Boolean Equals(Row row)
		{
			if (row == null) return false;
			if (Count != row.Count) return false;
			for (var i = 0; i < Count; i++)
			{
				if (!this[i].Equals(row[i])) return false;
			}
			return true;
		}

		public override Int32 GetHashCode()
		{
			return base.GetHashCode();
		}

		//public static Boolean operator ==(Row op1, Row op2)
		//{
		//	if (op1 == null || op2 == null) return false;
		//	if (op1?.Count != op2?.Count) return false;
		//	for (var i = 0; i < op1.Count; i++)
		//	{
		//		if (!op1[i].Equals(op2[i])) return false;
		//	}
		//	return true;
		//}

		//public static Boolean operator !=(Row op1, Row op2)
		//{
		//	return !(op1 == op2);
		//}
	}
}
