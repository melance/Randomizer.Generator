using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SadConsole.UI;
using SadConsole.UI.Controls;
using static SadConsole.UI.Controls.ListBox;
using Randomizer.Generator.MonoGame.ListItems;
using Randomizer.Generator.MonoGame.Utility;

namespace Randomizer.Generator.MonoGame.Dialogs
{
	partial class FileDialogConsole : DialogControlConsole
	{
		#region Constants
		private const String DEFAULT_FILE_FILTER = "*.*";
		#endregion

		#region Members
		private MessageBoxConsole _fileExistsDialog;
		private String _fileFilter = DEFAULT_FILE_FILTER;
		private String _currentDirectory;
		#endregion

		#region Properties
		public String CurrentDirectory 
		{
			get => _currentDirectory;
			set 
			{
				_currentDirectory = value;
				lblCurrentDirectory.DisplayText = _currentDirectory.ShortenPath(lblCurrentDirectory.Width);
				LoadFiles();
			}
		}

		public String FileName 
		{
			get => txtFileName.Text;
			set => txtFileName.Text = value;
		}

		public String FilePath
		{
			get => Path.Combine(CurrentDirectory, FileName);
		}

		public Boolean DialogResult { get; set; } = false;

		public String FileFilter
		{
			get => _fileFilter;
			set
			{
				if (String.IsNullOrWhiteSpace(value))
					_fileFilter = DEFAULT_FILE_FILTER;
				else
					_fileFilter = value;
				LoadFiles();
			}
		}
		#endregion

		#region Methods
		public void LoadFiles()
		{
			lstFileList.Items.Clear();
			if (Path.GetPathRoot(CurrentDirectory) != CurrentDirectory) lstFileList.Items.Add(new FileListItem(Constants.UP_ONE_DIRECTORY));
			foreach (var directory in Directory.GetDirectories(CurrentDirectory))
			{
				lstFileList.Items.Add(new DirectoryListItem(directory));
			}
			foreach (var file in Directory.GetFiles(CurrentDirectory, FileFilter))
			{
				lstFileList.Items.Add(new FileListItem(file));
			}
		}

		public void FileSelected()
		{
			var filePath = Path.Combine(CurrentDirectory, FileName);
			if (File.Exists(filePath))
			{
				_fileExistsDialog = MessageBoxConsole.MessageBox("Overwrite File",
																 $"File {FileName} exists.  Would you like to overwrite it?",
																 Program.MainConsole.Width / 2,
																 Program.MainConsole,
																 Styles.MessageBoxStyles.Warning,
																 MessageBoxConsole.MessageBoxButtons.Yes | MessageBoxConsole.MessageBoxButtons.No);
				_fileExistsDialog.Close += FileExistsDialog_Close;	
			}
			else
			{
				DialogResult = true;
				OnClose();
			}
		}

		public void FileExistsDialog_Close(Object sender, EventArgs e)
		{
			if (_fileExistsDialog.DialogResult == MessageBoxConsole.DialogResults.Yes)
			{
				DialogResult = true;
				OnClose();
			}
		}
		#endregion

		#region Event Handlers
		private void btnOk_Click(Object sender, EventArgs e)
		{
			DialogResult = true;
			FileSelected();
		}

		private void btnCancel_Click(Object sender, EventArgs e)
		{
			OnClose();
		}

		private void lstFileList_SelectedItemExecuted(Object sender, SelectedItemEventArgs e)
		{
			if (((IOListItemBase)e.Item).Name == Constants.UP_ONE_DIRECTORY)
			{
				CurrentDirectory = Directory.GetParent(CurrentDirectory).FullName;
			}
			else if (e.Item.GetType() == typeof(DirectoryListItem))
			{
				CurrentDirectory = ((DirectoryListItem)e.Item).Path;
			}
			else
			{
				FileName = ((FileListItem)e.Item).Path;
				FileSelected();
			}
		}
		#endregion
	}
}
