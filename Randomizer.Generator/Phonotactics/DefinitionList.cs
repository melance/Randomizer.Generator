using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomizer.Generator.Phonotactics
{
	/// <summary>
	/// List of replacements for a definition
	/// </summary>
    public class DefinitionList : List<String>
    {
		public DefinitionList() : base() { }
		public DefinitionList(IEnumerable<String> source) : base(source) { }

		/// <summary>
		/// Selects one of the items in the list at random
		/// </summary>
		/// <returns>The selected item</returns>
        public String SelectRandomValue()
        {
            var index = Utility.Random.RandomNumber(0, Count - 1);
            return this[index];
        }
    }
}
