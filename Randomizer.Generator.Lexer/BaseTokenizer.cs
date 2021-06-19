using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Randomizer.Generator.Lexer
{
    public abstract class BaseTokenizer<T> where T: Enum
    {
        protected List<TokenDefinition<T>> _tokenDefinitions;

        public IEnumerable<Token<T>> Tokenize(string text)
        {
            var tokenMatches = FindMatches(text);

            var groupByIndex = tokenMatches.GroupBy(tm => tm.Start).OrderBy(tm => tm.Key).ToList();

            TokenMatch<T> lastMatch = null;
            for (var i = 0; i < groupByIndex.Count; i++)
            {
                var bestMatch = groupByIndex[i].First();
                if (lastMatch != null && bestMatch.Start < lastMatch.End)
                    continue;

                yield return new Token<T>(bestMatch.TokenType, bestMatch.Value, bestMatch.Start, bestMatch.End);

                lastMatch = bestMatch;
            }

            yield return new Token<T>((T)Enum.Parse(typeof(T), "EOF"), String.Empty, 0, 0);

        }

        private List<TokenMatch<T>> FindMatches(string text)
        {
            var tokenMatches = new List<TokenMatch<T>>();

            foreach (var tokenDefinition in _tokenDefinitions)
            {
                tokenMatches.AddRange(tokenDefinition.Matches(text).ToList());
            }

            return tokenMatches;
        }
    }
}
