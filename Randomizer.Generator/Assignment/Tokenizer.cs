using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Randomizer.Generator.Assignment
{
    class Tokenizer
    {
        #region Constants
        private const String START_IDENTIFIER = @"(?<!\\)\[";
        private const String END_IDENTIFIER = @"(?<!\\)\]";
        private const char EXPRESSION_TOKEN = '=';
        private const char VARIABLE_TOKEN = '@';
        #endregion

        #region Public Static Methods
        public static List<Token> Tokenize(String content)
        {
            var remaining = content;
            var tokens = new List<Token>();

            do
            {
                var startMatch = Regex.Match(remaining, START_IDENTIFIER);
                var endMatch = Regex.Match(remaining, END_IDENTIFIER);
                if (startMatch.Success && endMatch.Success && startMatch.Index < endMatch.Index)
                {
					var endIndex = startMatch.Index + 1;
                    if (!String.IsNullOrEmpty(startMatch.Value))
                    {
                        tokens.Add(new Token() { TokenType = TokenTypes.Text, Value = remaining[..startMatch.Index] });
						var identifierCount = 1;
						var i = endIndex;
						var escape = false;
						do
						{
							switch (remaining[i])
							{
								case '[':
									if (!escape) identifierCount++;
									escape = false;
									break;
								case ']':
									if (!escape) identifierCount--;
									escape = false;
									break;
								case '\\':
									escape = true;
									break;
							}
							endIndex++;
							i++;
						} while (identifierCount > 0);
                    }
                    var value = remaining[(startMatch.Index + 1)..(endIndex - 1)];
                    var token = new Token();

                    remaining = remaining[endIndex..];
                    switch (value[0])
                    {
                        case EXPRESSION_TOKEN:
                            token.TokenType = TokenTypes.Equation;
                            token.Value = value[1..];
                            break;
                        case VARIABLE_TOKEN:
                            token.TokenType = TokenTypes.Variable;
                            token.Value = value[1..];
                            break;
                        default:
                            token.TokenType = TokenTypes.Item;
                            token.Value = value;
                            break;
                    }
                    tokens.Add(token);
                }
                else
                {
                    tokens.Add(new Token() { TokenType = TokenTypes.Text, Value = remaining });
                    remaining = String.Empty;
                }
            } while (!String.IsNullOrEmpty(remaining));

            return tokens;
        }
        #endregion
    }
}
