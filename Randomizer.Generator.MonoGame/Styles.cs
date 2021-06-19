using SadConsole;
using SadConsole.UI.Themes;
using SadRogue.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomizer.Generator.MonoGame
{
    class Styles
    {
        public static ColoredGlyph BorderColor { get => new(Color.White); }
        public static Color TitleColor { get => Color.Cyan; }
        public static Color LabelColor { get => Color.White; }

        public enum MessageBoxStyles
        {
            Information,
            Warning,
            Error
        }
    }
}
