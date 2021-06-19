using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Randomizer.Generator.MonoGame.Utility;
using SadConsole.UI.Controls;
using SadRogue.Primitives;

namespace Randomizer.Generator.MonoGame.Dialogs
{
	partial class FileDialogConsole
	{
		private const String OK_TEXT = "Ok";
		private const String CANCEL_TEXT = "Cancel";
		private const String HEADER_TEXT = "Save File";
		private const String DEFAULT_FILE_NAME = "content.txt";

		public FileDialogConsole(String directory, Int32 x, Int32 y, Int32 width, Int32 height, String fileName = null) : base(width, height)
		{
			Position = new Point(x, y);
			this.DrawWindowBorder(HEADER_TEXT);
			this.DrawWindowHorizontalDivider(height - 5);

			lblCurrentDirectory = new(width - 4)
			{
				Position = new Point(2, 3),
				TextColor = Styles.LabelColor
			};
			lstFileList = new(width - 4, height - 10)
			{
				Position = new Point(2, 5)
			};
			txtFileName = new(width - 4)
			{
				Position = new Point(2, Height - 4),
				Text = fileName ?? DEFAULT_FILE_NAME
			};
			btnOk = new(OK_TEXT.Length + 2)
			{
				Text = OK_TEXT,
				Position = new Point(Width - OK_TEXT.Length - 3, Height - 2)
			};
			btnCancel = new(CANCEL_TEXT.Length + 2)
			{
				Text = CANCEL_TEXT,
				Position = new Point(btnOk.Position.X - CANCEL_TEXT.Length - 3, btnOk.Position.Y)
			};

			btnCancel.Click += btnCancel_Click;
			btnOk.Click += btnOk_Click;
			lstFileList.SelectedItemExecuted += lstFileList_SelectedItemExecuted;

			Controls.Add(lblCurrentDirectory);
			Controls.Add(btnCancel);
			Controls.Add(btnOk);
			Controls.Add(lstFileList);
			Controls.Add(txtFileName);

			CurrentDirectory = directory;
			LoadFiles();
		}

		private Label lblCurrentDirectory { get; set; }
		private ListBox lstFileList { get; }
		private TextBox txtFileName { get; }
		private Button btnCancel { get; }
		private Button btnOk { get; }
	}
}
