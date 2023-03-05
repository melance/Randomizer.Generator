using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.ComponentModel;
using Hjson;
using System.Net.Mime;

namespace Randomizer.Generator.Assignment
{
	/// <summary>
	/// A line item in the definition
	/// </summary>
	public class LineItem
	{
		#region Properties
		/// <summary>The content of the line item used for the generation</summary>
		public String Content { get; set; }
		/// <summary>The next item key to seek after processing this one</summary>
		public String Next { get; set; }
		/// <summary>How many times to repeat this line item</summary>
		public String Repeat { get; set; }
		/// <summary>If given a value, the outcome of this line is stored in a variable instead of being output</summary>
		public String Variable { get; set; }
		/// <summary>A weight given to the random selection of this line item</summary>
		[DefaultValue(1)]
		public UInt32 Weight { get; set; } = 1;
		#endregion

		public static implicit operator String(LineItem lineItem)
		{
			return $"{lineItem.Content}|{lineItem.Next}|{lineItem.Repeat}|{lineItem.Variable}|{lineItem.Weight}";
		}
		
		public static implicit operator LineItem(String value)
		{
			var parts = value.Split('|');
			var lineItem = new LineItem();
			if (parts.Length > 0)
				lineItem.Content = parts[0];
			if (parts.Length > 1)
				lineItem.Next = parts[1];
			if (parts.Length > 2)
				lineItem.Repeat = parts[2];
			if (parts.Length > 3)
				lineItem.Variable = parts[3];
			if (parts.Length > 4)
			{
				if (UInt32.TryParse(parts[4], out var result))
					lineItem.Weight = result;
			}
			return lineItem;
		}
	}
}
