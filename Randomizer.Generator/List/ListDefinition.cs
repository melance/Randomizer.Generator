using Newtonsoft.Json;
using Randomizer.Generator.Core;
using Randomizer.Generator.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace Randomizer.Generator.List
{
	/// <summary>
	/// Selects a line from the provided list at random
	/// </summary>
	public class ListDefinition : BaseDefinition
    {
		
		#region Properties
		public override Boolean SupportsParameters => false;
		/// <summary>
		/// The list of items to be selected from
		/// </summary>
		[JsonProperty(Order = 101)]
		public List<string> Items {
			get => GetProperty(new List<String>());
			set => SetProperty(value);
		}
		/// <summary>
		/// Should any leading or trailing whitespace be removed from the result.  Default is <see cref="false"/>
		/// </summary>
		[JsonProperty(Order = 100)]
		public bool KeepWhitespace {
			get => GetProperty(false);
			set => SetProperty(value);
		}
		/// <summary>
		/// Parameters are not suppported in <see cref="ListDefinition"/>
		/// </summary>
		[JsonIgnore()]
        public override ParameterDictionary Parameters {
			get => throw new NotImplementedException($"{nameof(Parameters)} are not supported in {nameof(ListDefinition)}"); 
			set => throw new NotImplementedException($"{nameof(Parameters)} are not supported in {nameof(ListDefinition)}");
		}
		#endregion

		#region Public Methods
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

		public override String Analyze(AnalyzeOptions options)
		{
			var analysis = new AnalysisWriter(base.Analyze(options));

			analysis.AppendHeader(GeneratorTypes.List);

			analysis.AppendItemValue("Item Count", $"{Items.Count:#,##0}");
			analysis.AppendItemValue("Keep Whitespace", KeepWhitespace);

			if (options.HasFlag(AnalyzeOptions.IterateItems))
			{
				analysis.AppendHeader("Items");
				analysis.Level++;
				foreach (var item in Items)
				{
					analysis.AppendLine(item);
					analysis.AppendLine();
				}
				analysis.Level--;
			}

			return analysis.ToString();
		}
		#endregion
	}
}
