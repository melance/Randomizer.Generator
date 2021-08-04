using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomizer.Generator.Utility
{
	public class AnalysisWriter 
	{
		#region Constants
		private const Int32 LABEL_WIDTH = 18;
		#endregion

		#region Members
		private readonly StringBuilder StringBuilder;
		#endregion

		#region Constructors
		public AnalysisWriter() => StringBuilder = new();
		public AnalysisWriter(String value) => StringBuilder = new(value);
		#endregion

		#region Properties
		public Int32 Level { get; set; } = 0;
		#endregion

		#region Public Methods
		public void Append(String value) => StringBuilder.Append(value);
		public void EndLine(String value) => StringBuilder.AppendLine(value);
		public void EndLine() => StringBuilder.AppendLine();
		public void AppendSeparator(Int32 width = 80)
		{
			StringBuilder.AppendLine(new String(GlobalConstants.BOX_EW_SINGLE, width));
		}
		public void AppendHeader(Object value)
		{
			AppendLine();
			AppendLine(value.ToString().ToUpper());
			AppendSeparator();
		}
		public void StartLine(String value)
		{
			AppendTabs();
			StringBuilder.Append(value);
		}
		public void AppendLine(String value)
		{
			AppendTabs();
			StringBuilder.AppendLine(value);
		}
		public void AppendLine(Int32 count = 1)
		{
			if (count <= 0) throw new ArgumentOutOfRangeException(nameof(count), count, "count must be greater than 0");
			for (var i = 1; i <= count; i++)
				StringBuilder.AppendLine();
		}
		public void AppendItemValue(String label, Object value, Int32 labelWidth = LABEL_WIDTH)
		{
			AppendTabs();
			label += ':';
			AppendLine($"{label.PadRight(labelWidth)}{value}");
		}		

		public override String ToString()
		{
			return StringBuilder.ToString();
		}
		#endregion

		#region Private Methods
		private void AppendTabs()
		{
			if (Level > 0) StringBuilder.Append(new String('\t', Level));
		}
		#endregion
	}
}
