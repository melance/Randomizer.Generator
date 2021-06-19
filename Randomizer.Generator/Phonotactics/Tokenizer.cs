using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomizer.Generator.Phonotactics
{
    class Tokenizer
    {
        #region Constants
        private const Char OPTIONAL_IDENTIFIER = '^';
        #endregion

        #region Public Static Methods
        public static List<Token> Tokenize(String content)
        {
            var tokens = new List<Token>();
            var isOptional = false;

            foreach (var c in content)
            {
                switch (c)
                {
                    case OPTIONAL_IDENTIFIER:
                        isOptional = true;
                        break;
                    default:
                        tokens.Add(new Token() { TokenType = isOptional ? TokenTypes.Optional : TokenTypes.Key, Value = c });
                        isOptional = false;
                        break;
                }
            }

            return tokens;
        }
        #endregion
    }
}
