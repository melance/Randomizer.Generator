using Randomizer.Generator.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomizer.Generator.Phonotactics
{
    public class DefinitionDictionary : Dictionary<Char, DefinitionList>
    {
        public DefinitionDictionary() : base(new InsensitiveCharComparer()) { }
    }
}
