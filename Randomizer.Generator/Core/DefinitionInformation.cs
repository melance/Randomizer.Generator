using Hjson;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Randomizer.Generator.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomizer.Generator.Core
{
	public class DefinitionInformation : BaseClass
	{
		#region Static Methods
		/// <summary>
		/// Deserializes an HJSON byte array into a definition
		/// </summary>
		/// <param name="value">A byte array in the default encoding</param>
		/// <returns>A definition instance</returns>
		public static DefinitionInformation Deserialize(Byte[] value)
		{
			return Deserialize(Encoding.Default.GetString(value));
		}

		/// <summary>
		/// Deserializes an HJSON string into a definition
		/// </summary>
		/// <param name="value">An HJSON formatted string</param>
		/// <returns>A definition instance</returns>
		public static DefinitionInformation Deserialize(String value)
		{
			try
			{
				var json = HjsonValue.Parse(value).ToString();
				var serializer = JsonSerializer.Create(SerializerSettings);
				using var sReader = new StringReader(json);
				using var reader = new JsonTextReader(sReader);
				return serializer.Deserialize<DefinitionInformation>(reader);
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.ToString());
				throw;
			}
		}
		#endregion

		#region Proeprties
		/// <summary>Name of the generator definition</summary>
		[JsonProperty(Order = 0)]
		public String Name
		{
			get => GetProperty(String.Empty);
			set => SetProperty(value);
		}
		[JsonProperty(Order = 1)]
		/// <summary>Author of the generator definition</summary>
		public String Author
		{
			get => GetProperty(String.Empty);
			set => SetProperty(value);
		}
		/// <summary>Description of the generator definition</summary>
		[JsonProperty(Order = 2)]
		public String Description
		{
			get => GetProperty(String.Empty);
			set => SetProperty(value);
		}
		/// <summary>Remarks for the definition</summary>
		[JsonProperty(Order = 2)]
		public String Remarks
		{
			get => GetProperty(String.Empty);
			set => SetProperty(value);
		}
		/// <summary>Version of the generator definition</summary>
		[JsonProperty(Order = 3)]
		public Version Version
		{
			get => GetProperty(new Version(1, 0));
			set => SetProperty(value);
		}
		/// <summary>URL for more information about the generator definition</summary>
		[JsonProperty(Order = 4)]
		public String URL
		{
			get => GetProperty(String.Empty);
			set => SetProperty(value);
		}
		/// <summary>A list of tags for the generator definition</summary>
		[JsonProperty(Order = 5)]
		public List<String> Tags
		{
			get => GetProperty(new List<String>());
			set => SetProperty(value);
		}
		/// <summary>The format that the generator outputs</summary>
		[JsonProperty(Order = 6)]
		public OutputFormats OutputFormat
		{
			get => GetProperty(OutputFormats.Text);
			set => SetProperty(value);
		}
		/// <summary>If true, show in the list of generators</summary>
		[JsonProperty(Order = 7)]
		[DefaultValue(true)]
		public Boolean ShowInList
		{
			get => GetProperty(true);
			set => SetProperty(value);
		}

		/// <summary>
		/// The settings used to serialize and deserialize definitions
		/// </summary>
		protected static JsonSerializerSettings SerializerSettings => new()
		{
			Formatting = Formatting.Indented,
			Converters =
					{
						new StringEnumConverter(),
						new JsonVersionConverter(),
						new JsonListOptionConverter()
					},
			NullValueHandling = NullValueHandling.Ignore,
			DefaultValueHandling = DefaultValueHandling.Ignore
		};
		#endregion
	}
}
