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
		/// <summary>An expression that evaluates to an <see cref="Int32"/> that modifies the dice roll</summary>
		public String Modifier { get; set; }
		/// <summary>The column used to calculate the row of the roll</summary>
		public String RollColumn { get; set; } = "Roll";
		#endregion

		/// <summary>
		/// Selects a row in the table using the <see cref="RollColumn"/>
		/// </summary>
		/// <returns>The results of the process</returns>
		protected override Dictionary<String, String> ProcessTableInternal()
		{
			var max = ParsedTable.Columns[RollColumn].Max(r => Int32.Parse(r.ToString()));
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
				while (index < ParsedTable.RowCount && !found)
				{
					if (value < Int32.Parse(ParsedTable[RollColumn, index].ToString()))
						found = true;
					else
						index++;
				}

				if (index >= ParsedTable.RowCount) index = ParsedTable.RowCount - 1;

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
