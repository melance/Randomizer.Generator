using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Randomizer.Generator.Core;
using Newtonsoft.Json;

namespace Randomizer.Generator.Converters
{
    public class JsonListOptionConverter : JsonConverter
    {
		public override Boolean CanConvert(Type objectType)
		{
			return objectType == typeof(ListOption);
		}

		public override Object ReadJson(JsonReader reader, Type objectType, Object existingValue, JsonSerializer serializer)
		{
			var text = reader.Value.ToString().Split(':');
			return text.Length switch
			{
				1 => new ListOption(text[0], text[0]),
				2 => new ListOption(text[0], text[1]),
				_ => null
			};
		}

		public override void WriteJson(JsonWriter writer, Object value, JsonSerializer serializer)
		{
			if (value is ListOption list)
			{
				if (!String.IsNullOrEmpty(list.Display))
					writer.WriteValue($"{list.Value}:{list.Display}");
				else
					writer.WriteValue($"{list.Value}");
			}
		}
	}
}
