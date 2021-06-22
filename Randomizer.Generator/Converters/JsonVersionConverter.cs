using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Threading.Tasks;

namespace Randomizer.Generator.Converters
{
    public class JsonVersionConverter : JsonConverter
    {
		public override Boolean CanConvert(Type objectType)
		{
			return objectType == typeof(Version);
		}

		public override Object ReadJson(JsonReader reader, Type objectType, Object existingValue, JsonSerializer serializer)
		{
			if (reader.Value == null) return new Version(0, 0, 0, 0);
			if (objectType == typeof(String)) return Version.Parse(reader.Value.ToString());
			return new Version(1, 0);
		}

		public override void WriteJson(JsonWriter writer, Object value, JsonSerializer serializer)
		{
			writer.WriteValue(value.ToString());
		}
	}
}
