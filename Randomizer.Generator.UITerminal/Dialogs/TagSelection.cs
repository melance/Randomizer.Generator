using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;

namespace Randomizer.Generator.UITerminal.Dialogs
{
	partial class TagSelection : Window
	{
		private readonly List<CheckBox> chkTags = new();

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
	}
}
