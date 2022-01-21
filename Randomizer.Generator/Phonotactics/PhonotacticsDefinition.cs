using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using NCalc;
using Randomizer.Generator.Core;
using Randomizer.Generator.Utility;

namespace Randomizer.Generator.Phonotactics
{
	/// <summary>
	/// Generates a value based on a phonotactics definition
	/// </summary>
	/// <remarks><a href="https://en.wikipedia.org/wiki/Phonotactics">https://en.wikipedia.org/wiki/Phonotactics</a></remarks>
	public class PhonotacticsDefinition : BaseDefinition
    {

        #region Properties
        /// <summary>The list of definitions for each pattern key</summary>
        public DefinitionDictionary Definitions {
			get => GetProperty(new DefinitionDictionary());
			set => SetProperty(value);
		}
        /// <summary>The patterns used to construct content</summary>
        public PatternDictionary Patterns {
			get => GetProperty(new PatternDictionary());
			set => SetProperty(value);
		}
		/// <summary>The case to apply to the result</summary>
        public TextCases TextCase {
			get => GetProperty(TextCases.None);
			set => SetProperty(value);
		}
		public override Boolean SupportsParameters => true;
		#endregion

		#region Public Methods
		/// <summary>
		/// Generates content based on the definitions and patterns
		/// </summary>
		/// <returns>The generated content</returns>
		public override String Generate()
        {
			if (ValidateParameters())
			{
				var key = Parameters.Any() ? Parameters.First().Value.Value : String.Empty;
				var pattern = Patterns.SelectRandomPattern(key);
				var tokens = Tokenizer.Tokenize(pattern);
				var result = new StringBuilder();

				foreach (var token in tokens)
				{
					var generate = true;

					if (token.TokenType == TokenTypes.Optional && Utility.Random.RandomNumber(1, 100) < 50)
					{
						generate = false;
					}
					if (generate)
					{
						if (Definitions.ContainsKey(token.Value))
							result.Append(Definitions[token.Value].SelectRandomValue());
						else
							result.Append(token.Value);
					}
				}
				return result.ToString().ToCase(TextCase); 
			}
			return String.Empty;
        }

		public override String Analyze(AnalyzeOptions options)
		{
			var analysis = new AnalysisWriter(base.Analyze(options));

			analysis.AppendHeader("Phonotactics");
			analysis.AppendItemValue("TextCase", TextCase);

			analysis.AppendHeader("Definitions");

			foreach (var definition in Definitions)
			{
				analysis.AppendItemValue(definition.Key.ToString(), String.Join(", ", definition.Value));
			}

			analysis.AppendLine();
			analysis.AppendHeader("Patterns");

			foreach (var item in Patterns)
			{
				analysis.AppendLine(item.Key);
				foreach (var pattern in item.Value)
				{
					analysis.AppendItemValue(pattern.Pattern, $"Weight: {pattern.Weight}");
				}
				analysis.AppendLine();
			}

			return analysis.ToString();
		}
		#endregion

	}
}
