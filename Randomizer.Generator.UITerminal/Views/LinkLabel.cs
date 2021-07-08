using NStack;
using Randomizer.Generator.UI.Terminal.Utility;
using System;
using Terminal.Gui;

namespace Randomizer.Generator.UI.Terminal.Views
{
	class LinkLabel : Label
	{
		public LinkLabel() : this(String.Empty, String.Empty) { }

		public LinkLabel(ustring text) : this(text, String.Empty) { }
		public LinkLabel(ustring text, ustring url) : base(text)
		{
			URL = url;
			this.ColorScheme = new ColorScheme() { Normal = Colors.Dialog.HotNormal };
		}

		public ustring URL { get; set; }

		public override Boolean MouseEvent(MouseEvent e)
		{
			if (!URL.IsEmpty)
			{
				if (e.Flags == MouseFlags.Button1Clicked)
				{
					HelperMethods.OpenURL(URL.ToString());					
					return true;
				}
			}
			return false;
		}
	}
}
