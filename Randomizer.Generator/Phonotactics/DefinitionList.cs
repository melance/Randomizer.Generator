using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomizer.Generator.Phonotactics
{
    public class DefinitionList : List<String>
    {
		public DefinitionList() : base() { }
		public DefinitionList(IEnumerable<String> source) : base(source) { }

        public String SelectRandomValue()
        {
            var index = Utility.Random.RandomNumber(0, Count - 1);
            return this[index];
        }
    }
}
