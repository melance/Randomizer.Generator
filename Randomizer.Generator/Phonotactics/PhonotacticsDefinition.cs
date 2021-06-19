using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Randomizer.Generator.Core;
using Randomizer.Generator.Utility;

namespace Randomizer.Generator.Phonotactics
{
    /// <summary>
    /// Generates a value based on a phonotactics definition
    /// </summary>
    /// <remarks>https://en.wikipedia.org/wiki/Phonotactics</remarks>
    public class PhonotacticsDefinition : BaseDefinition
    {

        #region Properties
        /// <summary>The list of definitions for each pattern key</summary>
        public DefinitionDictionary Definitions { get; set; } = new();
        /// <summary>The patterns used to construct content</summary>
        public PatternDictionary Patterns { get; set; } = new();
        public TextCases TextCase { get; set; } = TextCases.None;
        #endregion

        #region Public Methods
        /// <summary>
        /// Generates content based on the definitions and patterns
        /// </summary>
        public override String Generate()
        {
            var key = Parameters.Any() ? Parameters[0].Value.Value : String.Empty;
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
        #endregion
    }
}
