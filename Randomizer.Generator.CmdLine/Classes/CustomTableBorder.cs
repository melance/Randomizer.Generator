using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;
using Spectre.Console.Rendering;

namespace Randomizer.Generator.CmdLine.Classes
{
    class CustomTableBorder : TableBorder
    {
        public override String GetPart(TableBorderPart part)
        {
            return part switch
            {
                TableBorderPart.HeaderTopLeft => "┌",
                TableBorderPart.HeaderTop => "─",
                TableBorderPart.HeaderTopSeparator => "┬",
                TableBorderPart.HeaderTopRight => "┐",
                TableBorderPart.HeaderLeft => "│",
                TableBorderPart.HeaderSeparator => "│",
                TableBorderPart.HeaderRight => "│",
                TableBorderPart.HeaderBottomLeft => "╞",
                TableBorderPart.HeaderBottom => "═",
                TableBorderPart.HeaderBottomSeparator => "╪",
                TableBorderPart.HeaderBottomRight => "╡",
                TableBorderPart.CellLeft => "│",
                TableBorderPart.CellSeparator => "│",
                TableBorderPart.CellRight => "│",
                TableBorderPart.FooterTopLeft => "├",
                TableBorderPart.FooterTop => "─",
                TableBorderPart.FooterTopSeparator => "┼",
                TableBorderPart.FooterTopRight => "┤",
                TableBorderPart.FooterBottomLeft => "└",
                TableBorderPart.FooterBottom => "─",
                TableBorderPart.FooterBottomSeparator => "┴",
                TableBorderPart.FooterBottomRight => "┘",
                _ => throw new InvalidOperationException("Unknown border part."),
            };
        }
    }
}
