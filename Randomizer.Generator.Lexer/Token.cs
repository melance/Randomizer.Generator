using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomizer.Generator.Lexer
{      
    public class Token<T> where T: Enum
    {
        public T TokenType { get; private set; }

        public string TokenValue { get; private set; }
        public Int32 Start { get; private set; }
        public Int32 End { get; private set; }

        public Token(T tokenType, string token, Int32 start, Int32 end) => (TokenType, TokenValue, Start, End) = (tokenType, token, start, end);

        public Token(T tokenType) : this(tokenType, String.Empty, 0, 0) { }

        public override string ToString()
        {
            return $"{TokenType}: {TokenValue} ({Start},{End})";
        }

        public Token<T> Clone()
        {
            return new Token<T>(TokenType, TokenValue, Start, End);
        }
    }
}
