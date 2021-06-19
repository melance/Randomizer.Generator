using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Randomizer.Generator.Converters
{
    public class JsonVersionConverter : JsonConverter<Version>
    {        
        public override Version Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) => Version.Parse(reader.GetString());

        public override void Write(Utf8JsonWriter writer, Version value, JsonSerializerOptions options) => writer.WriteStringValue(value.ToString());        
    }
}
