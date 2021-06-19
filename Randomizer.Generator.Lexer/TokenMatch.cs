using System;
using System.Collections.Generic;
using System.Text;

namespace Randomizer.Generator.Lexer
{
    public class TokenMatch<T> where T: Enum
    {
        public TokenMatch() { }
        public TokenMatch(Boolean isMatch) => IsMatch = isMatch;

        public Boolean IsMatch { get; set; }
        public T TokenType { get; set; }
        public String Value { get; set; }
        public String RemainingText { get; set; }
        public Int32 Start { get; set; }
        public Int32 End { get; set; }
    }
}
