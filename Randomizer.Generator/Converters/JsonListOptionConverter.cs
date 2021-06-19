using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Randomizer.Generator.Core;

namespace Randomizer.Generator.Converters
{
    public class JsonListOptionConverter : JsonConverter<ListOption>
    {
        public override ListOption Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) => (ListOption)reader.GetString();

        public override void Write(Utf8JsonWriter writer, ListOption value, JsonSerializerOptions options) => writer.WriteStringValue(value.ToString());
    }
}
