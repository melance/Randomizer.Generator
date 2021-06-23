using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomizer.Generator.Utility
{
	/// <summary>
	/// A dictionary of <see cref="KeyValuePair[String, VType]"/> that is case insensitive
	/// </summary>
	public class InsensitiveDictionary<VType> : Dictionary<String, VType>
    {
        public InsensitiveDictionary() : base(StringComparer.CurrentCultureIgnoreCase) { }
    }
}
