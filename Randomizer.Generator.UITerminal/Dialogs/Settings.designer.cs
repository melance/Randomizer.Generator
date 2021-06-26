using Randomizer.Generator.UITerminal.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;

namespace Randomizer.Generator.UITerminal.Dialogs
{
	partial class Settings
	{
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
			chkShowFileNames = new("Show File Names in List")
			{
				X = 1,
				Y = Pos.Bottom(lblWorkingDirectory) + 1,
				Checked = UserSettings.Instance.ShowFileNameInList
			};

			btnWorkingDirectory.Clicked += SelectDirectory;

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
			Add(chkShowFileNames);
			AddButton(btnOk);
			AddButton(btnCancel);
		}

		private readonly Label lblWorkingDirectory;
		private readonly TextField txtWorkingDirectory;
		private readonly Button btnWorkingDirectory;
		private readonly CheckBox chkShowFileNames;
	}
}
