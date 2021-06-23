using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomizer.Generator.Phonotactics
{
	/// <summary>
	/// A list of patterns for a pattern dictionary
	/// </summary>
    public class PatternList : List<PhonotacticPattern>
    {
		/// <summary>
		/// Adds a pattern to the dictionary
		/// </summary>
		/// <param name="pattern">The Phonotactic Pattern</param>
		/// <param name="weight">The weight of the pattern used when selecting one at random</param>
        public void Add(String pattern, UInt32 weight)
        {
            Add(new PhonotacticPattern(pattern, weight));
        }
    }
}
