using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Randomizer.Generator.Core;
using Randomizer.Generator.Utility;
using Random = Randomizer.Generator.Utility.Random;

namespace Randomizer.Generator.Sampler
{
	public class SamplerDefinition : BaseDefinition
	{
		[JsonProperty(Order = 110)]
		public InsensitiveDictionary<Sample> Samples { get; set; } = new();
		[JsonProperty(Order = 100)]
		public Int32 SampleSize { get; set; }
		[JsonProperty(Order = 102)]
		public TextCases TextCase { get; set; }
		public override Boolean SupportsParameters => true;

		public override String Generate()
		{
			if (ValidateParameters())
			{
				Sample chosenSample;

				if (SampleSize <= 0) throw new ArgumentException("SampleSize must be greater than 1");

				if (Parameters.Any())
				{
					var value = Parameters.First().Value.Value;
					if (value.StartsWith('='))
						value = Calculate(value[1..]);
					chosenSample = Samples[value];
				}
				else
				{
					chosenSample = Samples.RandomItem().Value;
				}

				var parser = new SampleParser();
				var content = chosenSample.Content;

				if (!String.IsNullOrWhiteSpace(chosenSample.Path))
				{
					content = DataAccess.DataAccess.Instance.GetText(chosenSample.Path);
				}
				var definition = parser.ParseString(chosenSample.Content, SampleSize);

				return definition.Generate().ToCase(TextCase); 
			}
			return String.Empty;
		}	
	}
}
