using System;
using System.Collections.Generic;
using System.Text;

namespace Randomizer.Generator.Lexer.Assignment
{
    public class AssignmentTokenizer : BaseTokenizer<AssignmentTokenTypes>
    {
        public AssignmentTokenizer()
        {
            _tokenDefinitions = new List<TokenDefinition<AssignmentTokenTypes>>
            {
                new TokenDefinition<AssignmentTokenTypes>(AssignmentTokenTypes.Equation, @"(?<!\\)\[(?<!\\)=.*(?<!\\)\]"),
                new TokenDefinition<AssignmentTokenTypes>(AssignmentTokenTypes.Variable, @"(?<!\\)\[(?<!\\)@.*(?<!\\)\]"),
                new TokenDefinition<AssignmentTokenTypes>(AssignmentTokenTypes.Item, @"(?<!\\)\[.*(?<!\\)\]"),
                new TokenDefinition<AssignmentTokenTypes>(AssignmentTokenTypes.String, @".+")
            };
        }
        
    }
}
