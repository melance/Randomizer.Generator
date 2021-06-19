using SadConsole;
using SadRogue.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Randomizer.Generator.MonoGame.Utility
{
    static class Extensions
    {
        public static IEnumerable<ColoredGlyph> DrawHorizontalLine(this ICellSurface surface, Int32 x1, Int32 x2, Int32 y, Color? foreground = null, Color? background = null)
        {
            return surface.DrawLine(new Point(x1, y), new Point(x2, y), (Int32?)GlyphNames.BoxHorizontal, foreground, background);
        }

        public static void DrawWindowBorder(this ICellSurface surface, String title = null, ColoredGlyph border = null)
        {
            if (border == null) border = Styles.BorderColor;

            // Draw the outer border
            surface.DrawBox(surface.Area, border, null, ICellSurface.ConnectedLineThick);

            // Draw the divider
            surface.DrawHorizontalLine(1, surface.Area.Width - 2, 2, border.Foreground);

            // Connect the outer border and divider
            surface.SetGlyph(0, 2, (Int32)GlyphNames.BoxVerticalDoubleAndRightSingle);
            surface.SetGlyph(surface.Area.Width - 1, 2, (Int32)GlyphNames.BoxVerticalDoubleAndLeftSingle);

            if (title != null)
            {
                surface.Print(2, 1, title, new ColoredGlyph(Styles.TitleColor));
            }
        }

		public static void DrawWindowHorizontalDivider(this ICellSurface surface, Int32 y, ColoredGlyph border = null)
		{
			if (border == null) border = Styles.BorderColor;
			// Draw the divider
			surface.DrawHorizontalLine(1, surface.Area.Width - 2, y, border.Foreground);

			// Connect the outer border and divider
			surface.SetGlyph(0, y, (Int32)GlyphNames.BoxVerticalDoubleAndRightSingle);
			surface.SetGlyph(surface.Area.Width - 1, y, (Int32)GlyphNames.BoxVerticalDoubleAndLeftSingle);

		}

        public static IEnumerable<String> WordWrap(this String text, Int32 width)
        {
            var paragraphs = text.Split("\n");
            var lines = new List<String>();

            foreach (var paragraph in paragraphs)
            {
                var currentLine = new StringBuilder();
                foreach (var word in paragraph.Split(" "))
                {
                    if (currentLine.Length + word.Length > width)
                    {
                        lines.Add(currentLine.ToString());
                        currentLine = new StringBuilder();
                    }
                    currentLine.Append(word + " ");
                }
                lines.Add(currentLine.ToString().Trim());
            }
            return lines;
        }

        public static String WordWrap(this String text, String separator, Int32 width)
        {
            var paragraphs = text.Split("\n");
            var lines = new List<String>();

            foreach (var paragraph in paragraphs)
            {
                var currentLine = new StringBuilder();
                foreach (var word in paragraph.Split(" "))
                {
                    if (currentLine.Length + word.Length > width)
                    {
                        lines.Add(currentLine.ToString());
                        currentLine = new StringBuilder();
                    }
                    currentLine.Append(word + " ");
                }
                lines.Add(currentLine.ToString().Trim());
            }
            return String.Join(separator, lines);
        }

		public static String ShortenPath(this String fullPath, Int32 length)
		{
			if (fullPath.Length < length)
				return fullPath;
			var parts = new List<String>(fullPath.Split(Path.DirectorySeparatorChar));
			var root = Path.GetPathRoot(fullPath);
			var shortPath = new StringBuilder($"{root}..");
			var insertIndex = shortPath.Length;

			do
			{
				shortPath.Insert(insertIndex, parts.Last());
				parts.RemoveAt(parts.Count - 1);
				if (parts.Count > 0)
					shortPath.Insert(insertIndex, Path.DirectorySeparatorChar);
			} while (parts.Count > 0 && shortPath.Length + parts.Last().Length < length - 2);

			return shortPath.ToString();
		}
	}
}

