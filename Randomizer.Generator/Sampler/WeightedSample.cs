using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomizer.Generator.Sampler
{
	public class WeightedSample
	{
		public Int32 Weight { get; set; }
		public String Value { get; set; }
		public String Next { get; set; }
		public Boolean IsOpen { get; set; }

		public override String ToString()
		{
			var value = $"{Value}: {Weight}";
			if (String.IsNullOrWhiteSpace(Next)) value += $" Next = {Next}";
			if (IsOpen) value += " IsOpen";
			return value;
		}
	}
}
