using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomizer.Generator.Phonotactics
{
    public class PatternList : List<PhonotacticPattern>
    {
        public void Add(String pattern, Int32 weight)
        {
            Add(new PhonotacticPattern(pattern, weight));
        }
    }
}
