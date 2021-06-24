using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;
using WenceyWang.FIGlet;
using Randomizer.Generator.UITerminal.Extensions;
using System.IO;
using Randomizer.Generator.UITerminal.Views;

namespace Randomizer.Generator.UITerminal.Dialogs
{
	partial class About
	{
		public About() : base()
		{
			const Int32 LABEL_WIDTH = 10;
						
			var assembly = System.Reflection.Assembly.GetExecutingAssembly();

			Title = $"About {AssemblyInfo.ProductName}";
			
			var details = new StringBuilder();
			var figletFont = new WenceyWang.FIGlet.FIGletFont(new MemoryStream(Properties.Resources.abountFont));
			var titleArt = new AsciiArt(AssemblyInfo.ProductName, figletFont);

			details.AppendLine($"{"Version:".PadRight(LABEL_WIDTH)}{assembly.GetName().Version.ToString(true)} {AssemblyInfo.ReleaseType}");
			details.AppendLine($"{"Author:".PadRight(LABEL_WIDTH)}Lance Boudreaux");
			details.AppendLine($"{"Built:".PadRight(LABEL_WIDTH)}{Randomizer.Generator.UITerminal.AssemblyInfo.CompilationTimestampUtc.ToLocalTime():yyyy.MM.dd hh:mm}");

			var lblTitleArt = new Label(String.Join('\n', titleArt.Result))
			{ 
				X = 0, 
				Y = 0, 
				Width = Dim.Fill(), 
				TextAlignment = TextAlignment.Centered
			};

			var lblDetails = new Label(details.ToString())
			{
				X = 2,
				Y = Pos.Bottom(lblTitleArt),
				AutoSize = true

			};
			var licenseFrame = new FrameView("License")
			{
				X = 1,
				Y = Pos.Bottom(lblDetails),
				Width = Dim.Fill(2),
				Height = Dim.Fill(2)
			};
			var licenseView = new ScrollView(new Rect(0, 0, 82, 6))
			{
				ContentSize = new Size(80, 40),
				ShowHorizontalScrollIndicator = true,
				ShowVerticalScrollIndicator = true
			};
			var licenseText = new Label(Properties.Resources.License)
			{
				X = 0,
				Y = 0,
				Height = Dim.Fill(),
				Width = Dim.Fill()
			};
			
			licenseView.Add(licenseText);
			licenseFrame.Add(licenseView);
			
			btnClose = new("Close")
			{
				X = Pos.Center(),
				Y = Pos.Bottom(this) - 7,
				Height = 1,
				Width = 9
			};
			btnClose.Clicked += () => Application.RequestStop();

			Add(lblTitleArt);
			Add(lblDetails);
			Add(licenseFrame);
			//Add(btnClose);
			AddButton(btnClose);
		}		

		private readonly Button btnClose;
	}
}
