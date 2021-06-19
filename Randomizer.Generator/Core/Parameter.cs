using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomizer.Generator.Core
{
    public class Parameter
    {
        public String Value { get; set; }
        public String Display { get; set; }
        public List<String> Aliases { get; set; } = new List<String>();
        public ParameterTypes Type { get; set; }
        public ListOptionList Options { get; set; } = new ListOptionList();
    }
}
