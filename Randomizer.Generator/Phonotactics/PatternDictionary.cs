using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Randomizer.Generator.Exceptions;
using Randomizer.Generator.Utility;

namespace Randomizer.Generator.Phonotactics
{
	/// <summary>
	/// A dictionary of Phonotactic Patterns
	/// </summary>
    public class PatternDictionary : InsensitiveDictionary<PatternList>
    {
        /// <summary>
        /// Selects a random pattern from the dictionary
        /// </summary>
        public String SelectRandomPattern()
        {
            return SelectRandomPattern(String.Empty);
        }

        /// <summary>
        /// Selects a random pattern from the dictionary
        /// </summary>
        public String SelectRandomPattern(String key)
        {
            var selectedPatterns = String.IsNullOrEmpty(key) ? this.First().Value : this[key];
            var totalWeight = (Int32)selectedPatterns.Sum(kvp => kvp.Weight);
            var patternValue = String.Empty;
            var keyValue = String.Empty;

            if (!selectedPatterns.Any())
            {
                throw new ItemNotFoundException(key);
            }
            else if (selectedPatterns.Count == 1)
            {
                patternValue = selectedPatterns.First().Pattern;
                keyValue = selectedPatterns.First().Key;
            }
            else
            {
                var value = Utility.Random.RandomNumber(0, totalWeight);
                var sum = 0u;
                var values = this.AsEnumerable().ToList();
                var i = 0;

                PhonotacticPattern item = null;

                do
                {
                    item = selectedPatterns[i];
                    i++;
                    sum += item.Weight;
                } while (sum < value);

                patternValue = item.Pattern;
                keyValue = item.Key;
            }

            return String.IsNullOrEmpty(keyValue) ? patternValue : SelectRandomPattern(keyValue);
        }
    }
}
