using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomizer.Generator.Phonotactics
{
	/// <summary>
	/// A Phonotactic Pattern
	/// </summary>
    public class PhonotacticPattern
    {
        public PhonotacticPattern() { }
        public PhonotacticPattern(String pattern, UInt32 weight) => (Pattern, Weight) = (pattern, weight);

		/// <summary>The Phonotactic Pattern</summary>
        public String Pattern { get; set; }
        public String Key { get; set; }
		/// <summary>The weight this pattern carries when selecting a pattern at random</summary>
        public UInt32 Weight { get; set; } = 1;
    }
}
