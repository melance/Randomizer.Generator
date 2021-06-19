using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;

namespace Randomizer.Generator.UITerminal.Views
{
	abstract class UpDownFieldBase : View
	{
		
		public UpDownFieldBase()
		{
			Height = 1;			
		}

		public override Boolean MouseEvent(MouseEvent e)
		{
			if (e.X == Bounds.Right - 2 && e.Y == Bounds.Top && e.Flags == MouseFlags.Button1Clicked)
			{
				Up();
				return true;
			}
			else if (e.X == Bounds.Right - 1 && e.Y == Bounds.Top && e.Flags == MouseFlags.Button1Clicked)
			{
				Down();
				return true;
			}
			return false;
		}

		public override void Redraw(Rect bounds)
		{
			base.Redraw(bounds);

			Move(Bounds.Right - 3, 0);
			Driver.AddStr(" ");
			Move(Bounds.Right - 2, 0);
			Driver.AddRune(Driver.UpArrow);
			Move(Bounds.Right - 1, 0);
			Driver.AddRune(Driver.DownArrow);
		}

		public override Boolean ProcessKey(KeyEvent keyEvent)
		{
			if (keyEvent.Key == Key.CursorUp)
			{
				Up();
				return true;
			}
			if (keyEvent.Key == Key.CursorDown)
			{
				Down();
				return true;
			}
			return base.ProcessKey(keyEvent);
		}

		protected abstract void Up();
		protected abstract void Down();
	}
}
