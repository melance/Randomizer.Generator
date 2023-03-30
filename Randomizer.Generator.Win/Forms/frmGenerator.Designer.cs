namespace Randomizer.Generator.Win.Forms
{
	partial class frmGenerator
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
			var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGenerator));
			lblName = new Label();
			spcMain = new SplitContainer();
			pnlParameters = new Panel();
			panel1 = new Panel();
			btnOpenDialog = new Button();
			btnReload = new Button();
			btnEdit = new Button();
			btnGenerate = new Button();
			webBrowser = new WebBrowser();
			pnlCommands = new Panel();
			btnSelectAll = new Button();
			btnClear = new Button();
			btnCopy = new Button();
			btnSave = new Button();
			toolTip = new ToolTip(components);
			btnInfo = new Button();
			errorProvider = new ErrorProvider(components);
			((System.ComponentModel.ISupportInitialize)spcMain).BeginInit();
			spcMain.Panel1.SuspendLayout();
			spcMain.Panel2.SuspendLayout();
			spcMain.SuspendLayout();
			panel1.SuspendLayout();
			pnlCommands.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
			SuspendLayout();
			// 
			// lblName
			// 
			lblName.BackColor = SystemColors.ControlDarkDark;
			lblName.Dock = DockStyle.Top;
			lblName.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
			lblName.ForeColor = SystemColors.ButtonFace;
			lblName.Location = new Point(0, 0);
			lblName.Name = "lblName";
			lblName.Size = new Size(800, 24);
			lblName.TabIndex = 0;
			lblName.Text = "label1";
			lblName.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// spcMain
			// 
			spcMain.BorderStyle = BorderStyle.FixedSingle;
			spcMain.Cursor = Cursors.VSplit;
			spcMain.Dock = DockStyle.Fill;
			spcMain.Location = new Point(0, 24);
			spcMain.Name = "spcMain";
			// 
			// spcMain.Panel1
			// 
			spcMain.Panel1.Controls.Add(pnlParameters);
			spcMain.Panel1.Controls.Add(panel1);
			spcMain.Panel1.Cursor = Cursors.Default;
			// 
			// spcMain.Panel2
			// 
			spcMain.Panel2.Controls.Add(webBrowser);
			spcMain.Panel2.Controls.Add(pnlCommands);
			spcMain.Panel2.Cursor = Cursors.Default;
			spcMain.Size = new Size(800, 569);
			spcMain.SplitterDistance = 266;
			spcMain.TabIndex = 1;
			// 
			// pnlParameters
			// 
			pnlParameters.Dock = DockStyle.Fill;
			pnlParameters.Location = new Point(0, 0);
			pnlParameters.Name = "pnlParameters";
			pnlParameters.Padding = new Padding(6, 6, 16, 6);
			pnlParameters.Size = new Size(264, 531);
			pnlParameters.TabIndex = 3;
			// 
			// panel1
			// 
			panel1.Controls.Add(btnReload);
			panel1.Controls.Add(btnEdit);
			panel1.Controls.Add(btnGenerate);
			panel1.Dock = DockStyle.Bottom;
			panel1.Location = new Point(0, 531);
			panel1.Name = "panel1";
			panel1.Size = new Size(264, 36);
			panel1.TabIndex = 4;
			// 
			// btnOpenDialog
			// 
			btnOpenDialog.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			btnOpenDialog.BackColor = SystemColors.ControlDarkDark;
			btnOpenDialog.FlatAppearance.BorderSize = 0;
			btnOpenDialog.FlatStyle = FlatStyle.Flat;
			btnOpenDialog.Image = (Image)resources.GetObject("btnOpenDialog.Image");
			btnOpenDialog.Location = new Point(745, 0);
			btnOpenDialog.Name = "btnOpenDialog";
			btnOpenDialog.Size = new Size(24, 24);
			btnOpenDialog.TabIndex = 5;
			toolTip.SetToolTip(btnOpenDialog, "Open the generator in a seperate window");
			btnOpenDialog.UseVisualStyleBackColor = false;
			btnOpenDialog.Click += btnOpenDialog_Click;
			// 
			// btnReload
			// 
			btnReload.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			btnReload.Image = (Image)resources.GetObject("btnReload.Image");
			btnReload.Location = new Point(33, 6);
			btnReload.Name = "btnReload";
			btnReload.Size = new Size(24, 24);
			btnReload.TabIndex = 4;
			toolTip.SetToolTip(btnReload, "Reload the definition");
			btnReload.UseVisualStyleBackColor = true;
			btnReload.Click += btnReload_Click;
			// 
			// btnEdit
			// 
			btnEdit.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			btnEdit.Image = (Image)resources.GetObject("btnEdit.Image");
			btnEdit.Location = new Point(3, 6);
			btnEdit.Name = "btnEdit";
			btnEdit.Size = new Size(24, 24);
			btnEdit.TabIndex = 3;
			toolTip.SetToolTip(btnEdit, "Open the definition in an editor.");
			btnEdit.UseVisualStyleBackColor = true;
			btnEdit.Click += btnEdit_Click;
			// 
			// btnGenerate
			// 
			btnGenerate.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			btnGenerate.Image = (Image)resources.GetObject("btnGenerate.Image");
			btnGenerate.Location = new Point(237, 6);
			btnGenerate.Name = "btnGenerate";
			btnGenerate.Size = new Size(24, 24);
			btnGenerate.TabIndex = 2;
			toolTip.SetToolTip(btnGenerate, "Generate");
			btnGenerate.UseVisualStyleBackColor = true;
			btnGenerate.Click += btnGenerate_Click;
			// 
			// webBrowser
			// 
			webBrowser.AllowWebBrowserDrop = false;
			webBrowser.Dock = DockStyle.Fill;
			webBrowser.Location = new Point(0, 0);
			webBrowser.Name = "webBrowser";
			webBrowser.Size = new Size(528, 531);
			webBrowser.TabIndex = 1;
			webBrowser.WebBrowserShortcutsEnabled = false;
			// 
			// pnlCommands
			// 
			pnlCommands.Controls.Add(btnSelectAll);
			pnlCommands.Controls.Add(btnClear);
			pnlCommands.Controls.Add(btnCopy);
			pnlCommands.Controls.Add(btnSave);
			pnlCommands.Dock = DockStyle.Bottom;
			pnlCommands.Location = new Point(0, 531);
			pnlCommands.Name = "pnlCommands";
			pnlCommands.Size = new Size(528, 36);
			pnlCommands.TabIndex = 0;
			// 
			// btnSelectAll
			// 
			btnSelectAll.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			btnSelectAll.Image = (Image)resources.GetObject("btnSelectAll.Image");
			btnSelectAll.Location = new Point(441, 7);
			btnSelectAll.Name = "btnSelectAll";
			btnSelectAll.Size = new Size(24, 24);
			btnSelectAll.TabIndex = 6;
			toolTip.SetToolTip(btnSelectAll, "Select All");
			btnSelectAll.UseVisualStyleBackColor = true;
			btnSelectAll.Click += btnSelectAll_Click;
			// 
			// btnClear
			// 
			btnClear.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			btnClear.Image = (Image)resources.GetObject("btnClear.Image");
			btnClear.Location = new Point(411, 7);
			btnClear.Name = "btnClear";
			btnClear.Size = new Size(24, 24);
			btnClear.TabIndex = 5;
			toolTip.SetToolTip(btnClear, "Clear Results");
			btnClear.UseVisualStyleBackColor = true;
			btnClear.Click += btnClear_Click;
			// 
			// btnCopy
			// 
			btnCopy.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			btnCopy.Image = (Image)resources.GetObject("btnCopy.Image");
			btnCopy.Location = new Point(471, 7);
			btnCopy.Name = "btnCopy";
			btnCopy.Size = new Size(24, 24);
			btnCopy.TabIndex = 4;
			toolTip.SetToolTip(btnCopy, "Copy");
			btnCopy.UseVisualStyleBackColor = true;
			btnCopy.Click += btnCopy_Click;
			// 
			// btnSave
			// 
			btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			btnSave.Image = (Image)resources.GetObject("btnSave.Image");
			btnSave.Location = new Point(501, 7);
			btnSave.Name = "btnSave";
			btnSave.Size = new Size(24, 24);
			btnSave.TabIndex = 3;
			toolTip.SetToolTip(btnSave, "Save As");
			btnSave.UseVisualStyleBackColor = true;
			btnSave.Click += btnSave_Click;
			// 
			// btnInfo
			// 
			btnInfo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			btnInfo.BackColor = SystemColors.ControlDarkDark;
			btnInfo.FlatAppearance.BorderSize = 0;
			btnInfo.FlatStyle = FlatStyle.Flat;
			btnInfo.Image = (Image)resources.GetObject("btnInfo.Image");
			btnInfo.Location = new Point(775, 0);
			btnInfo.Name = "btnInfo";
			btnInfo.Size = new Size(24, 24);
			btnInfo.TabIndex = 6;
			toolTip.SetToolTip(btnInfo, "View the definition information");
			btnInfo.UseVisualStyleBackColor = false;
			btnInfo.Click += btnInfo_Click;
			// 
			// errorProvider
			// 
			errorProvider.ContainerControl = this;
			// 
			// frmGenerator
			// 
			AcceptButton = btnGenerate;
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 593);
			ControlBox = false;
			Controls.Add(btnOpenDialog);
			Controls.Add(btnInfo);
			Controls.Add(spcMain);
			Controls.Add(lblName);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Name = "frmGenerator";
			Text = "Generator";
			spcMain.Panel1.ResumeLayout(false);
			spcMain.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)spcMain).EndInit();
			spcMain.ResumeLayout(false);
			panel1.ResumeLayout(false);
			pnlCommands.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private Label lblName;
		private SplitContainer spcMain;
		private Button btnGenerate;
		private Panel pnlParameters;
		private Panel pnlCommands;
		private Panel panel1;
		private Button btnSelectAll;
		private Button btnClear;
		private Button btnCopy;
		private Button btnSave;
		private Button btnEdit;
		private WebBrowser webBrowser;
		private Button btnReload;
		private ToolTip toolTip;
		private ErrorProvider errorProvider;
		private Button btnOpenDialog;
		private Button btnInfo;
	}
}