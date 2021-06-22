using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomizer.Generator.Table
{
	public class RandomTable : BaseTable
	{

		#region Properties
		public String Modifier { get; set; } 
		public String RollColumn { get; set; }
		#endregion

		protected override Dictionary<String, String> ProcessTableInternal()
		{
			var max = Table.Columns[RollColumn].Max(r => Int32.Parse(r.ToString()));
			var value = 0;
			var results = new Dictionary<String, String>();
			var modifier = 0;
			var count = GetRepeat();

			for (var i = 1; i <= count; i++)
			{
				var index = 0;
				var found = false;

				modifier = GetModifier();

				value = Utility.Random.RandomNumber(max) + modifier;
				while (index < Table.RowCount && !found)
				{
					if (value < Int32.Parse(Table[RollColumn, index].ToString()))
						found = true;
					else
						index++;
				}

				if (index >= Table.RowCount) index = Table.RowCount - 1;

				ProcessRow(results, index);
			}

			return results;
		}

		#region Private Methods
		/// <summary>
		/// Gets or evaluates the value of the modifier property
		/// </summary>
		private Int32 GetModifier()
		{
			if (string.IsNullOrWhiteSpace(Modifier)) return 0;
			return OnEvaluate<Int32>(Modifier);
		}
		#endregion
	}
}
