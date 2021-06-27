using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;
using NStack;

namespace Randomizer.Generator.UITerminal.Dialogs
{
	partial class Settings : Dialog
	{
		private void SelectDirectory()
		{
			var dlg = new OpenDialog("Select a Directory", ustring.Empty)
			{
				DirectoryPath = txtWorkingDirectory.Text,
				CanChooseDirectories = true,
				CanChooseFiles = false
			};
			
			Application.Run(dlg);

			if (!dlg.Canceled)
				txtWorkingDirectory.Text = dlg.FilePath;
		}

		private void RememberLastDirectory_Toggled(Boolean selected)
		{
			txtWorkingDirectory.ReadOnly = chkRememberLastDirectory.Checked;
			btnWorkingDirectory.Visible = !chkRememberLastDirectory.Checked;
		}
	}
}
