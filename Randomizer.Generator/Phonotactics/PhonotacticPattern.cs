using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomizer.Generator.Phonotactics
{
    public class PhonotacticPattern
    {
        public PhonotacticPattern() { }
        public PhonotacticPattern(String pattern, Int32 weight) => (Pattern, Weight) = (pattern, weight);

        public String Pattern { get; set; }
        public String Key { get; set; }
        public Int32 Weight { get; set; } = 1;
    }
}
