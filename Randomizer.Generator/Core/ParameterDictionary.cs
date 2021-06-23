using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Randomizer.Generator.Utility;

namespace Randomizer.Generator.Core
{
	/// <summary>
	/// A dictionary containing the name of a parameter and it's details
	/// </summary>
    public class ParameterDictionary : InsensitiveDictionary<Parameter>
    {
		/// <summary>
		/// Returns the <see cref="Parameter"/> for the given <paramref name="name"/>
		/// </summary>
		/// <param name="name">The name of the <see cref="Parameter"/> to find</param>
		/// <returns>The <see cref="Parameter"/> for the given <paramref name="name"/></returns>
		/// <exception cref="KeyNotFoundException">Thrown when the <paramref name="name"/> does not exist in the dictionary</exception>
		public new Parameter this[String name]
        {
            get
            {                
                if (ParameterExists(name))
                    return GetParameter(name);
                else
                    throw new KeyNotFoundException($"Could not find parameter: \"{name}\".");
            }
        }

        /// <summary>
        /// Returns true if the parameter exists
        /// </summary>
        /// <param name="name">Looks for a parameter with the name <paramref name="name"/></param>
        /// <returns><see cref="true"/> if the parameter exists, otherwise <see cref="false"/></returns>
        public Boolean ParameterExists(String name)
        {
            return this.Any(kvp =>
            {
                return kvp.Key.Equals(name, StringComparison.CurrentCultureIgnoreCase) ||
                       kvp.Value.Aliases.Contains(name, StringComparer.CurrentCultureIgnoreCase);
            });
        }

        /// <summary>
        /// Gets the named parameter
        /// </summary>
        protected Parameter GetParameter(String name)
        {
            return this.Where(kvp =>
            {
                return kvp.Key.Equals(name, StringComparison.CurrentCultureIgnoreCase) ||
                       kvp.Value.Aliases.Contains(name, StringComparer.CurrentCultureIgnoreCase);
            }).First().Value;
        }
    }
}
