using System.Collections.Generic;
using System.Linq;
using Terminal.Gui;

namespace Randomizer.Generator.UI.Terminal.Dialogs
{
	class TagSelection : Window
	{

		#region Members
		private readonly List<CheckBox> chkTags = new();
		#endregion

		#region Constructors
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
			btnSelectAll.Clicked += () =>
			{
				foreach (var check in chkTags)
				{
					check.Checked = true;
					check.SetNeedsDisplay();
				}
			};
			btnSelectNone.Clicked += () =>
			{
				foreach (var check in chkTags)
				{
					check.Checked = false;
					check.SetNeedsDisplay();
				}
			};
			btnToggle.Clicked += () =>
			{
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
		#endregion

		#region Controls
		private readonly ScrollView svTags;
		#endregion

		#region Event Handlers
		private void OK_Clicked()
		{
			foreach (var chkTag in chkTags)
			{
				var tag = Program.TagList.Where(t => t.Text == chkTag.Text).First();
				tag.Selected = chkTag.Checked;
			}
			Program.RefreshGeneratorList?.Invoke();
			Application.RequestStop();
		}

		private void Cancel_Clicked()
		{
			Application.RequestStop();
		}
		#endregion

		#region Private Methods
		private void PopulateTags()
		{
			var x = 0;
			foreach (var tag in Program.TagList)
			{
				var chkTag = new CheckBox(tag.Text, tag.Selected)
				{
					X = x
				};
				x += chkTag.Bounds.Width + 1;
				chkTags.Add(chkTag);
				svTags.Add(chkTag);

			}
		} 
		#endregion
	}
}
