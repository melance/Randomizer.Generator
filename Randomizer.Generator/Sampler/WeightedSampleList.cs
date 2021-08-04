using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomizer.Generator.Sampler
{
	class WeightedSampleList : List<WeightedSample>
	{
		public void Upsert(String value, String next, Boolean isOpen)
		{
			var existing = this.Where(ws => ws.Value.Equals(value, StringComparison.CurrentCultureIgnoreCase) && (ws.Next?.Equals(next, StringComparison.CurrentCultureIgnoreCase)).GetValueOrDefault() && ws.IsOpen == isOpen).FirstOrDefault();
			if (existing == null)
			{
				existing = new WeightedSample()
				{
					IsOpen = isOpen,
					Value = value,
					Next = next,
					Weight = 0
				};
				Add(existing);
			}
			existing.Weight++;
		}
	}
}
