using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;

namespace Randomizer.Generator.UITerminal.Dialogs
{
	partial class TagSelection
	{
		public TagSelection()
		{
			Title = "Tags";

			svTags = new(new Rect(0, 1, 60, 19))
			{
				ContentSize = new Size(58, 100)
			};
			var btnOk = new Button("Ok")
			{
				X = Pos.Center() - 8,
				Y = Pos.Bottom(this) - 6 
			};
			var btnCancel = new Button("Cancel")
			{
				X = Pos.Center() - 2,
				Y = Pos.Bottom(this) - 6
			};
			var btnSelectAll = new Button("Select All")
			{
				X = Pos.AnchorEnd(14),
				Y = 0
			};
			var btnSelectNone = new Button("Select None")
			{
				X = Pos.Left(btnSelectAll) - 15,
				Y = Pos.Top(btnSelectAll)
			};
			var btnToggle = new Button("Toggle All")
			{
				X = Pos.Left(btnSelectNone) - 14,
				Y = Pos.Top(btnSelectNone)
			};

			btnOk.Clicked += OK_Clicked;
			btnCancel.Clicked += Cancel_Clicked;
			btnSelectAll.Clicked += () => {
				foreach(var check in chkTags)
				{
					check.Checked = true;
					check.SetNeedsDisplay();
				}
			};
			btnSelectNone.Clicked += () => {
				foreach (var check in chkTags)
				{
					check.Checked = false;
					check.SetNeedsDisplay();
				}
			};
			btnToggle.Clicked += () => {
				foreach (var check in chkTags)
				{
					check.Checked = !check.Checked;
					check.SetNeedsDisplay();
				}
			};

			Add(btnOk);
			Add(btnCancel);
			Add(btnSelectAll);
			Add(btnSelectNone);
			Add(btnToggle);
			Add(svTags);

			PopulateTags();
		}

		private readonly ScrollView svTags;
	}
}
