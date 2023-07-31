using Randomizer.Generator.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomizer.Generator.Assignment
{
    /// <summary>
    /// Contains a key and list of line items to select from
    /// </summary>
    public class LineItemDictionary : InsensitiveDictionary<LineItemList>
    {
		public Boolean Contains(String name) => this.Any(i => i.Key.Equals(name, StringComparison.InvariantCultureIgnoreCase));
    }
}
