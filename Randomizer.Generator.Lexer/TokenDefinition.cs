using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Randomizer.Generator.Lexer
{
    public class TokenDefinition<T> where T : Enum
    {
        private readonly Regex _regex;
        private readonly T _returnsToken;

        public TokenDefinition(T returnsToken, string regexPattern) => (_regex, _returnsToken) = (new Regex(regexPattern, RegexOptions.IgnoreCase|RegexOptions.Compiled), returnsToken);
            
        public IEnumerable<TokenMatch<T>> Matches(string inputString)
        {
            var matches = _regex.Matches(inputString);
            for (Int32 i = 0; i < matches.Count; i++)
            {
                var match = matches[i];

                yield return new TokenMatch<T>()
                {
                    Start = match.Index,
                    End = match.Index + match.Length,
                    TokenType = _returnsToken,
                    Value = match.Value
                };
            }            
        }
    }
}
