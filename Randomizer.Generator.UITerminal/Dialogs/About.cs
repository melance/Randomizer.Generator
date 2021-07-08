using NStack;
using Randomizer.Generator.UI.Terminal.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Versioning;
using System.Text;
using Terminal.Gui;
using WenceyWang.FIGlet;

namespace Randomizer.Generator.UI.Terminal.Dialogs
{
	class About : Dialog
	{

		#region Constants
		const String contra = @"              #                         
             ## ###&&&&&#&&&&& # #                
          # ###&#&%#&&###&#%##&&&&& ,,#           
         ##########   #### /#####&&&&&&#          
       # ###### #              #%#&&%#            
      .####### #                                  
     .*#*#*#                                      
     .**#*# #                                     
     ###*#**#                                     
        #*##                                      
       # *.                                       
          *** ***#                                
           / *******,**///    //**,,./**          
                    ** .* ** ** ,##               
                    #   // . 

";
		#endregion

		#region Members
		List<Key> keys = new();
		readonly List<Key> kk = new() { Key.CursorUp, Key.CursorUp, Key.CursorDown, Key.CursorDown, Key.CursorLeft, Key.CursorRight, Key.CursorLeft, Key.CursorRight, Key.Space | Key.B, Key.Space | Key.A, Key.Enter }; 
		readonly List<(Int32 Tone, Int32 Duration)> tones = new()
		{
			new (196, 200),
			new (262, 300),
			new (294, 600)
		};
		#endregion

		#region Constructor
		public About() : base()
		{
			KeyUp += HandleKeyDown;
			const Int32 LABEL_WIDTH = 10;

			var assembly = System.Reflection.Assembly.GetExecutingAssembly();

			Title = $"About {AssemblyInfo.ProductName}";

			var details = new StringBuilder();
			var figletFont = new WenceyWang.FIGlet.FIGletFont(new MemoryStream(Properties.Resources.bulbhead));
			var titleArt = new AsciiArt(AssemblyInfo.ProductName, figletFont);

			details.AppendLine($"{"Version:".PadRight(LABEL_WIDTH)}{assembly.GetName().Version.ToString(true)} {AssemblyInfo.ReleaseType}");
			details.AppendLine($"{"Author:".PadRight(LABEL_WIDTH)}Lance Boudreaux");
			details.AppendLine($"{"Built:".PadRight(LABEL_WIDTH)}{Randomizer.Generator.UI.Terminal.AssemblyInfo.CompilationTimestampUtc.ToLocalTime():yyyy.MM.dd hh:mm}");

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
				Y = Pos.Bottom(lblTitleArt) + 1,
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
			AddButton(btnClose);
		}
		#endregion

		#region Controls
		private readonly Button btnClose;
		#endregion

		#region Event Handlers
		private void HandleKeyDown(KeyEventEventArgs e)
		{
			var good = true;

			keys.Add(e.KeyEvent.Key);
			for (var i = 0; i < keys.Count; i++)
			{
				if (keys[i] != kk[i])
				{
					good = false;
				}
			}

			if (!good)
			{
				keys = new();
			}
			else if (good && keys.Count == kk.Count)
			{
				if (OperatingSystem.IsWindows())
					PlayTones();
				MessageBox.Query("Kode", contra, new ustring[] { "Ok" });
			}
		}
		#endregion

		#region Private Methods
		[SupportedOSPlatform("windows")]
		private void PlayTones()
		{
			foreach (var (Tone, Duration) in tones)
			{
				Console.Beep(Tone, duration: Duration);
			}
		} 
		#endregion
	}
}
