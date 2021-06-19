using System;
using System.Collections.Generic;
using System.Text;

namespace Randomizer.Generator.Lexer.Phonotactics
{
    public class PhonotacticsTokenizer : BaseTokenizer<PhonotacticsTokenTypes>
    {
        public PhonotacticsTokenizer()
        {
            _tokenDefinitions = new List<TokenDefinition<PhonotacticsTokenTypes>>
            {
                new TokenDefinition<PhonotacticsTokenTypes>(PhonotacticsTokenTypes.Optional, @"(?<!\\)\[\w{1}(?<!\\)\]"),
                new TokenDefinition<PhonotacticsTokenTypes>(PhonotacticsTokenTypes.Whitespace, @"\s+"),
                new TokenDefinition<PhonotacticsTokenTypes>(PhonotacticsTokenTypes.Character, @"\w{1}")
            };
        }
    }
}
