using NStack;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;

namespace Randomizer.Generator.UITerminal.Views
{
	class LinkLabel : Label
	{
		public LinkLabel() : base() { }
		public LinkLabel(ustring text) : base(text) { }
		public LinkLabel(ustring text, ustring url) : base(text) => (URL) = (url);

		public ustring URL { get; set; }

		public override Boolean MouseEvent(MouseEvent e)
		{
			if (!URL.IsEmpty)
			{
				if (e.Flags == MouseFlags.Button1Clicked)
				{
					Process.Start(new ProcessStartInfo()
					{
						UseShellExecute = true,
						FileName = URL.ToString()
					});
					return true;
				}
			}
			return false;
		}
	}
}
