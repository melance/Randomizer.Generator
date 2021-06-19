using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Randomizer.Generator.Core;
using Randomizer.Generator.Utility;

namespace Randomizer.Generator.List
{
    public class ListDefinition : BaseDefinition
    {
        public List<string> Items { get; set; }
        public bool KeepWhitespace { get; set; } = false;

        [JsonIgnore()]
        public override ParameterDictionary Parameters { get; set; } = null;

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

        public static implicit operator ListDefinition(string json) => Deserialize<ListDefinition>(json);
        public static implicit operator string(ListDefinition definition) => Serialize(definition);

    }
}
