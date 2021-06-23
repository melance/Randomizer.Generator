using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomizer.Generator.Assignment
{
	/// <summary>
	/// A token from <see cref="AssignmentDefinition"/> content
	/// </summary>
    class Token
    {
        #region Properties
		/// <summary>The type of token</summary>
        public TokenTypes TokenType { get; set; }
		/// <summary>The value of the token</summary>
        public String Value { get; set; }
        #endregion

        #region Public Methods
		/// <summary>A <see cref="String"/> representation of the <see cref="Token"/></summary>
		/// <returns><see cref="TokenType"/>: <see cref="Value"/>Value</returns>
        public override String ToString()
        {
            return $"{TokenType}: {Value}";
        }
        #endregion
    }
}
