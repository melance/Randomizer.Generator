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
			return new ListOption(text.First(), text.Length == 1 ? String.Empty : text[1]);
		}

		public override void WriteJson(JsonWriter writer, Object value, JsonSerializer serializer)
		{
			var list = value as ListOption;
			if (list != null)
			{
				if (!String.IsNullOrEmpty(list.Display))
					writer.WriteValue($"{list.Value}:{list.Display}");
				else
					writer.WriteValue($"{list.Value}");
			}
		}
	}
}
