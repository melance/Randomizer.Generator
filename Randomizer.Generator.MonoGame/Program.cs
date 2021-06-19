using SadConsole;
using SadRogue.Primitives;
using System;
using System.Collections.Generic;
using SadConsole.UI.Themes;
using SadConsole.UI.Controls;

namespace Randomizer.Generator.MonoGame
{
    class Program
    {
        private const Int32 SCREEN_WIDTH = 132;
        private const Int32 SCREEN_HEIGHT = 60;
        private static readonly Dictionary<String, Point> SCREEN_RESOLUTIONS = new(StringComparer.CurrentCultureIgnoreCase)
        {
            { "MDA", new Point(80, 25) },
            { "CGA", new Point(80, 25) },
            { "EGA", new Point(80, 43) },
            { "VGA", new Point(80, 50) },
            { "SVGA", new Point(80, 60) }
        };

        private static Point Size { get; set; }

		public static MainConsole MainConsole { get; private set; }

        private static void Main(string resolution = "132x60")
        {
            Settings.WindowTitle = "Randomizer Generator Mono";
            Settings.UseDefaultExtendedFont = true;

            Library.Default.SetControlTheme(typeof(ScreenSurfaces.TextSurface), new SurfaceViewerTheme());
            Library.Default.SetControlTheme(typeof(FileDirectoryListbox), new ListBoxTheme(new ScrollBarTheme()));

            Size = GetResolution(resolution);
            Settings.WindowMinimumSize = Size;
            Game.Create(Size.X, Size.Y);
            Game.Instance.OnStart = Initialize;            
            Game.Instance.DestroyDefaultStartingConsole();
            Game.Instance.Run();
            Game.Instance.Dispose();
        }

        private static Point GetResolution(String resolution)
        {
            var parts = resolution.ToUpper().Split("X");
            if (parts.Length == 2 && Int32.TryParse(parts[0], out Int32 width) && Int32.TryParse(parts[1], out Int32 height))
            {
                return new Point(width, height);
            }
            else if (SCREEN_RESOLUTIONS.ContainsKey(resolution))
            {
                return SCREEN_RESOLUTIONS[resolution];
            }
            else
            {
                return new Point(SCREEN_WIDTH, SCREEN_HEIGHT);
            }
        }

        private static void Initialize()
        {
			MainConsole = new MainConsole(Size.X, Size.Y);
			Game.Instance.Screen = MainConsole;
            Settings.ResizeMode = Settings.WindowResizeOptions.Fit;
            Settings.WindowMinimumSize = Size;
        }
    }
}