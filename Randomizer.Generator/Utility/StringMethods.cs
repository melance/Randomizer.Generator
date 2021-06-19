using Randomizer.Generator.Core;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomizer.Generator.Utility
{
    static class StringMethods
    {
        public static String ToCase(this String extended, TextCases textCase)
        {
            return textCase switch
            {
                TextCases.Lower => CultureInfo.CurrentCulture.TextInfo.ToLower(extended),
                TextCases.Upper => CultureInfo.CurrentCulture.TextInfo.ToUpper(extended),
                TextCases.Title => CultureInfo.CurrentCulture.TextInfo.ToTitleCase(extended),
                _ => extended,
            };
        }

        public static String LCase(this String extended)
        {
            return extended.ToCase(TextCases.Lower);
        }

        public static String UCase(this String extended)
        {
            return extended.ToCase(TextCases.Upper);
        }

        public static String TCase(this String extended)
        {
            return extended.ToCase(TextCases.Title);
        }
    }
}
