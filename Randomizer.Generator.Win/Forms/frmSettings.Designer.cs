namespace Randomizer.Generator.Win.Forms
{
	partial class frmSettings
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettings));
			lblGeneratorDirectory = new Label();
			label1 = new Label();
			txtTextEditorArgs = new TextBox();
			lblTextEditorArgs = new Label();
			toolTip = new ToolTip(components);
			nudDefaultRepeat = new NumericUpDown();
			label2 = new Label();
			btnOk = new Button();
			btnCancel = new Button();
			openFileDialog = new OpenFileDialog();
			folderBrowserDialog = new FolderBrowserDialog();
			selTextEditor = new Controls.FileSelector();
			lstDefinitionFolders = new ListBox();
			btnAddFolder = new Button();
			btnRemoveFolder = new Button();
			((System.ComponentModel.ISupportInitialize)nudDefaultRepeat).BeginInit();
			SuspendLayout();
			// 
			// lblGeneratorDirectory
			// 
			lblGeneratorDirectory.AutoSize = true;
			lblGeneratorDirectory.Location = new Point(12, 9);
			lblGeneratorDirectory.Name = "lblGeneratorDirectory";
			lblGeneratorDirectory.Size = new Size(118, 15);
			lblGeneratorDirectory.TabIndex = 0;
			lblGeneratorDirectory.Text = "Definition Directories";
			// 
			// label1
			// 
			label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			label1.AutoSize = true;
			label1.Location = new Point(12, 86);
			label1.Name = "label1";
			label1.Size = new Size(62, 15);
			label1.TabIndex = 3;
			label1.Text = "Text Editor";
			// 
			// txtTextEditorArgs
			// 
			txtTextEditorArgs.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			txtTextEditorArgs.Location = new Point(136, 112);
			txtTextEditorArgs.Name = "txtTextEditorArgs";
			txtTextEditorArgs.Size = new Size(310, 23);
			txtTextEditorArgs.TabIndex = 7;
			toolTip.SetToolTip(txtTextEditorArgs, "Arguments to send to the Text Editor.  {filename} will be replaced with the name of the definition file.");
			// 
			// lblTextEditorArgs
			// 
			lblTextEditorArgs.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			lblTextEditorArgs.AutoSize = true;
			lblTextEditorArgs.Location = new Point(12, 115);
			lblTextEditorArgs.Name = "lblTextEditorArgs";
			lblTextEditorArgs.Size = new Size(89, 15);
			lblTextEditorArgs.TabIndex = 6;
			lblTextEditorArgs.Text = "Text Editor Args";
			// 
			// nudDefaultRepeat
			// 
			nudDefaultRepeat.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			nudDefaultRepeat.BorderStyle = BorderStyle.FixedSingle;
			nudDefaultRepeat.Location = new Point(136, 141);
			nudDefaultRepeat.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
			nudDefaultRepeat.Name = "nudDefaultRepeat";
			nudDefaultRepeat.Size = new Size(310, 23);
			nudDefaultRepeat.TabIndex = 8;
			nudDefaultRepeat.TextAlign = HorizontalAlignment.Right;
			nudDefaultRepeat.ThousandsSeparator = true;
			nudDefaultRepeat.Value = new decimal(new int[] { 1, 0, 0, 0 });
			// 
			// label2
			// 
			label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			label2.AutoSize = true;
			label2.Location = new Point(12, 143);
			label2.Name = "label2";
			label2.Size = new Size(84, 15);
			label2.TabIndex = 9;
			label2.Text = "Default Repeat";
			// 
			// btnOk
			// 
			btnOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			btnOk.Location = new Point(370, 170);
			btnOk.Name = "btnOk";
			btnOk.Size = new Size(75, 23);
			btnOk.TabIndex = 10;
			btnOk.Text = "Ok";
			btnOk.UseVisualStyleBackColor = true;
			btnOk.Click += btnOk_Click;
			// 
			// btnCancel
			// 
			btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			btnCancel.Location = new Point(289, 170);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new Size(75, 23);
			btnCancel.TabIndex = 11;
			btnCancel.Text = "Cancel";
			btnCancel.UseVisualStyleBackColor = true;
			// 
			// openFileDialog
			// 
			openFileDialog.FileName = "openFileDialog";
			openFileDialog.Filter = "Executable (*.exe)|*.exe|All Files (*.*)|*.*";
			// 
			// selTextEditor
			// 
			selTextEditor.AllowManualEntry = true;
			selTextEditor.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			selTextEditor.CheckFileExists = true;
			selTextEditor.DefaultExtension = "";
			selTextEditor.FileName = "";
			selTextEditor.Filter = "";
			selTextEditor.Location = new Point(136, 82);
			selTextEditor.Name = "selTextEditor";
			selTextEditor.Size = new Size(310, 23);
			selTextEditor.TabIndex = 12;
			// 
			// lstDefinitionFolders
			// 
			lstDefinitionFolders.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			lstDefinitionFolders.BorderStyle = BorderStyle.FixedSingle;
			lstDefinitionFolders.FormattingEnabled = true;
			lstDefinitionFolders.IntegralHeight = false;
			lstDefinitionFolders.ItemHeight = 15;
			lstDefinitionFolders.Location = new Point(136, 9);
			lstDefinitionFolders.Name = "lstDefinitionFolders";
			lstDefinitionFolders.Size = new Size(287, 67);
			lstDefinitionFolders.TabIndex = 13;
			// 
			// btnAddFolder
			// 
			btnAddFolder.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			btnAddFolder.FlatStyle = FlatStyle.Flat;
			btnAddFolder.Image = (Image)resources.GetObject("btnAddFolder.Image");
			btnAddFolder.Location = new Point(422, 9);
			btnAddFolder.Name = "btnAddFolder";
			btnAddFolder.Size = new Size(24, 23);
			btnAddFolder.TabIndex = 14;
			btnAddFolder.UseVisualStyleBackColor = true;
			btnAddFolder.Click += btnAddFolder_Click;
			// 
			// btnRemoveFolder
			// 
			btnRemoveFolder.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			btnRemoveFolder.FlatStyle = FlatStyle.Flat;
			btnRemoveFolder.Image = (Image)resources.GetObject("btnRemoveFolder.Image");
			btnRemoveFolder.Location = new Point(422, 31);
			btnRemoveFolder.Name = "btnRemoveFolder";
			btnRemoveFolder.Size = new Size(24, 23);
			btnRemoveFolder.TabIndex = 15;
			btnRemoveFolder.UseVisualStyleBackColor = true;
			btnRemoveFolder.Click += btnRemoveFolder_Click;
			// 
			// frmSettings
			// 
			AcceptButton = btnOk;
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			CancelButton = btnCancel;
			ClientSize = new Size(451, 199);
			Controls.Add(btnRemoveFolder);
			Controls.Add(btnAddFolder);
			Controls.Add(lstDefinitionFolders);
			Controls.Add(selTextEditor);
			Controls.Add(btnCancel);
			Controls.Add(btnOk);
			Controls.Add(label2);
			Controls.Add(nudDefaultRepeat);
			Controls.Add(txtTextEditorArgs);
			Controls.Add(lblTextEditorArgs);
			Controls.Add(label1);
			Controls.Add(lblGeneratorDirectory);
			FormBorderStyle = FormBorderStyle.SizableToolWindow;
			MaximizeBox = false;
			MinimizeBox = false;
			MinimumSize = new Size(450, 225);
			Name = "frmSettings";
			Text = "Settings";
			((System.ComponentModel.ISupportInitialize)nudDefaultRepeat).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label lblGeneratorDirectory;
		private Label label1;
		private TextBox txtTextEditorArgs;
		private Label lblTextEditorArgs;
		private ToolTip toolTip;
		private NumericUpDown nudDefaultRepeat;
		private Label label2;
		private Button btnOk;
		private Button btnCancel;
		private OpenFileDialog openFileDialog;
		private FolderBrowserDialog folderBrowserDialog;
		private Controls.FileSelector selTextEditor;
		private ListBox lstDefinitionFolders;
		private Button btnAddFolder;
		private Button btnRemoveFolder;
	}
}