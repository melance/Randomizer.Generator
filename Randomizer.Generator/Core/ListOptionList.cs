using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomizer.Generator.Core
{
    public class ListOptionList : List<ListOption>
    {
        public void Add(String value, String display)
        {
            Add(new ListOption(value, display));
        }
    }
}
