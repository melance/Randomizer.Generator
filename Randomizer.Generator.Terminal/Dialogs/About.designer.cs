using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;
using WenceyWang.FIGlet;
using Randomizer.Generator.UITerminal.Extensions;
using System.IO;

namespace Randomizer.Generator.UITerminal.Dialogs
{
	partial class About
	{
		public About() : base()
		{
			ColorScheme.Normal = new Terminal.Gui.Attribute(Color.Green, Color.Blue);

			const Int32 LABEL_WIDTH = 10;

			var assembly = System.Reflection.Assembly.GetExecutingAssembly();

			Title = $"About {AssemblyInfo.ProductName}";
			
			var details = new StringBuilder();
			var figletFont = new WenceyWang.FIGlet.FIGletFont(new MemoryStream(Properties.Resources.abountFont));
			var titleArt = new AsciiArt(AssemblyInfo.ProductName, figletFont);

			details.AppendLine($"{"Version:".PadRight(LABEL_WIDTH)}{assembly.GetName().Version.ToString(true)} {AssemblyInfo.ReleaseType}");
			details.AppendLine($"{"Author:".PadRight(LABEL_WIDTH)}Lance Boudreaux");
			details.AppendLine($"{"Built:".PadRight(LABEL_WIDTH)}{Randomizer.Generator.UITerminal.AssemblyInfo.CompilationTimestampUtc.ToLocalTime():yyyy.MM.dd hh:mm}");
						
			Add(new Label(String.Join('\n', titleArt.Result)) { X = 0, Y = 0, Width = Dim.Fill(), TextAlignment = TextAlignment.Centered, ColorScheme = new ColorScheme() { Normal = new Terminal.Gui.Attribute(Color.Green, Color.Black) } });

			Add(new Label(details.ToString()) { X = 1, Y = titleArt.Height, Width = Dim.Fill(), Height = Dim.Fill() });

			btnClose = new("Close");
			btnClose.ColorScheme = new ColorScheme()
			{
				HotNormal = new Terminal.Gui.Attribute(Color.Green, Color.Black),
				HotFocus = new Terminal.Gui.Attribute(Color.Green, Color.Black),
				Focus = new Terminal.Gui.Attribute(Color.Green, Color.Black),
				Disabled = new Terminal.Gui.Attribute(Color.Gray, Color.Black),
				Normal = new Terminal.Gui.Attribute(Color.Green, Color.Black)
			};
			btnClose.Clicked += () => Application.RequestStop();
			AddButton(btnClose);
		}

		private readonly Button btnClose;
	}
}
