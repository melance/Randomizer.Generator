using Newtonsoft.Json;
using Randomizer.Generator.Core;
using System;
using System.Collections.Generic;

namespace Randomizer.Generator.List
{
	/// <summary>
	/// Selects a line from the provided list at random
	/// </summary>
	public class ListDefinition : BaseDefinition
    {
		/// <summary>
		/// The list of items to be selected from
		/// </summary>
		[JsonProperty(Order = 101)]
        public List<string> Items { get; set; }
		/// <summary>
		/// Should any leading or trailing whitespace be removed from the result.  Default is <see cref="false"/>
		/// </summary>
		[JsonProperty(Order = 100)]
        public bool KeepWhitespace { get; set; } = false;

		/// <summary>
		/// Parameters are not suppported in <see cref="ListDefinition"/>
		/// </summary>
        [JsonIgnore()]
        public override ParameterDictionary Parameters {
			get => throw new NotImplementedException($"{nameof(Parameters)} are not supported in {nameof(ListDefinition)}"); 
			set => throw new NotImplementedException($"{nameof(Parameters)} are not supported in {nameof(ListDefinition)}");
		}

		/// <summary>
		/// Generates content
		/// </summary>
		/// <returns>The generated content</returns>
        public override string Generate()
        {
            if (Items?.Count > 0)
            {
                var index = Utility.Random.RandomNumber(0, Items.Count - 1);
                var result = Items[index];
                if (!KeepWhitespace) result = result.Trim();
                return result;
            }
            return string.Empty;
        }
    }
}
