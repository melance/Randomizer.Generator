using NStack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;
using WenceyWang.FIGlet;

namespace Randomizer.Generator.UITerminal.Dialogs
{
	partial class About : Dialog
	{
		List<Key> keys = new();
		readonly List<Key> kk = new() { Key.CursorUp, Key.CursorUp, Key.CursorDown, Key.CursorDown, Key.CursorLeft, Key.CursorRight, Key.CursorLeft, Key.CursorRight, Key.Space | Key.B, Key.Space | Key.A, Key.Enter };
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
		readonly List<(Int32 Tone, Int32 Duration)> tones = new()
		{
			new (196, 200),
			new (262, 300),
			new (294, 600)
		};

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
		
		[SupportedOSPlatform("windows")]
		private void PlayTones()
		{
			foreach (var (Tone, Duration) in tones)
			{
				Console.Beep(Tone, duration: Duration);
			}
		}
	}
}
