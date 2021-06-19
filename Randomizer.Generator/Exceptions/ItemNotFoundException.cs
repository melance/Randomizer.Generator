using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomizer.Generator.Exceptions
{
    public class ItemNotFoundException : Exception
    {
        public String ItemName { get; private set; }

        public ItemNotFoundException(String itemName) : base($"Item [{itemName}] not found")
        {
            ItemName = itemName;
        }
    }
}
