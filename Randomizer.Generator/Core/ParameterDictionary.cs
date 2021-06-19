using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Randomizer.Generator.Utility;

namespace Randomizer.Generator.Core
{
    public class ParameterDictionary : InsensitiveDictionary<Parameter>, IReadOnlyList<KeyValuePair<String, Parameter>>
    {
        private List<KeyValuePair<String, Parameter>> _list;

        public KeyValuePair<String, Parameter> this[Int32 index]
        {
            get
            {
                if (_list == null)
                {
                    _list = new List<KeyValuePair<String, Parameter>>();
                    foreach (var kvp in this)
                    {
                        _list.Add(kvp);
                    }
                }
                return _list[index];
            }
        }

        public new Parameter this[String name]
        {
            get
            {
                if (Count == 0)
                    throw new Exception($"Generator does not have any parameters.");

                if (ParameterExists(name))
                    return GetParameter(name);
                else
                    throw new KeyNotFoundException($"Could not find parameter \"{name}\".");
            }
        }

        /// <summary>
        /// Returns true if the parameter exists
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Boolean ParameterExists(String name)
        {
            return this.Any(kvp =>
            {
                return kvp.Key.Equals(name, StringComparison.CurrentCultureIgnoreCase) ||
                       kvp.Value.Aliases.Contains(name, StringComparer.CurrentCultureIgnoreCase);
            });
        }

        /// <summary>
        /// Returns the value of a parameter
        /// </summary>
        public String GetParameterValue(String name)
        {
            return this[name].Value;
        }

        /// <summary>
        /// Sets the value of a parameter
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void SetParameterValue(String name, String value)
        {
            this[name].Value = value;
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
