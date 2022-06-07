using NStack;
using System;
using Terminal.Gui;
using Randomizer.Generator.UI.Terminal.Utility;

namespace Randomizer.Generator.UI.Terminal.Dialogs
{
	class Settings : Dialog
	{

		#region Constructor
		public Settings() : base()
		{
			lblWorkingDirectory = new("Default Working Directory:")
			{
				X = 1,
				Y = 1,
				Width = 26,
				Height = 1
			};
			txtWorkingDirectory = new(UserSettings.Instance.WorkingDirectory)
			{
				X = Pos.Right(lblWorkingDirectory) + 1,
				Y = Pos.Y(lblWorkingDirectory),
				Width = Dim.Fill(7),
				Height = 1
			};
			btnWorkingDirectory = new("…")
			{
				X = Pos.Right(txtWorkingDirectory) + 1,
				Y = Pos.Y(txtWorkingDirectory)
			};
			chkRememberLastDirectory = new("Remember Last Working Directory")
			{
				X = 1,
				Y = Pos.Bottom(lblWorkingDirectory) + 1,
				Checked = UserSettings.Instance.RememberLastDirectory
			};
			chkShowFileNames = new("Show File Names in List")
			{
				X = 1,
				Y = Pos.Bottom(chkRememberLastDirectory) + 1,
				Checked = UserSettings.Instance.ShowFileNameInList
			};

			btnWorkingDirectory.Clicked += SelectDirectory;
			chkRememberLastDirectory.Toggled += RememberLastDirectory_Toggled;

			RememberLastDirectory_Toggled(chkRememberLastDirectory.Checked);

			var btnCancel = new Button("Cancel");
			btnCancel.Clicked += () => Application.RequestStop();
			var btnOk = new Button("Ok");
			btnOk.Clicked += () =>
			{
				UserSettings.Instance.WorkingDirectory = txtWorkingDirectory.Text.ToString();
				UserSettings.Instance.ShowFileNameInList = chkShowFileNames.Checked;
				Program.CurrentDirectory = txtWorkingDirectory.Text.ToString();
				UserSettings.Instance.Save();
				Application.RequestStop();
			};

			Add(lblWorkingDirectory);
			Add(txtWorkingDirectory);
			Add(btnWorkingDirectory);
			Add(chkRememberLastDirectory);
			Add(chkShowFileNames);
			AddButton(btnOk);
			AddButton(btnCancel);
		}
		#endregion

		#region Controls
		private readonly Label lblWorkingDirectory;
		private readonly TextField txtWorkingDirectory;
		private readonly Button btnWorkingDirectory;
		private readonly CheckBox chkRememberLastDirectory;
		private readonly CheckBox chkShowFileNames;
		#endregion

		#region Event Handlers
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
		#endregion

	}
}
