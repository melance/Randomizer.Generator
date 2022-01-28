namespace Randomizer.Generator.UI.Win.Forms
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGenerator));
            this.lblName = new System.Windows.Forms.Label();
            this.spcMain = new System.Windows.Forms.SplitContainer();
            this.pnlParameters = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnReload = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.pnlCommands = new System.Windows.Forms.Panel();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).BeginInit();
            this.spcMain.Panel1.SuspendLayout();
            this.spcMain.Panel2.SuspendLayout();
            this.spcMain.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlCommands.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblName.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblName.Location = new System.Drawing.Point(0, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(800, 24);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "label1";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // spcMain
            // 
            this.spcMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.spcMain.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.spcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcMain.Location = new System.Drawing.Point(0, 24);
            this.spcMain.Name = "spcMain";
            // 
            // spcMain.Panel1
            // 
            this.spcMain.Panel1.Controls.Add(this.pnlParameters);
            this.spcMain.Panel1.Controls.Add(this.panel1);
            this.spcMain.Panel1.Cursor = System.Windows.Forms.Cursors.Default;
            // 
            // spcMain.Panel2
            // 
            this.spcMain.Panel2.Controls.Add(this.webBrowser);
            this.spcMain.Panel2.Controls.Add(this.pnlCommands);
            this.spcMain.Panel2.Cursor = System.Windows.Forms.Cursors.Default;
            this.spcMain.Size = new System.Drawing.Size(800, 569);
            this.spcMain.SplitterDistance = 266;
            this.spcMain.TabIndex = 1;
            // 
            // pnlParameters
            // 
            this.pnlParameters.Cursor = System.Windows.Forms.Cursors.Default;
            this.pnlParameters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlParameters.Location = new System.Drawing.Point(0, 0);
            this.pnlParameters.Name = "pnlParameters";
            this.pnlParameters.Padding = new System.Windows.Forms.Padding(6, 6, 16, 6);
            this.pnlParameters.Size = new System.Drawing.Size(264, 531);
            this.pnlParameters.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnReload);
            this.panel1.Controls.Add(this.btnEdit);
            this.panel1.Controls.Add(this.btnGenerate);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 531);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(264, 36);
            this.panel1.TabIndex = 4;
            // 
            // btnReload
            // 
            this.btnReload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReload.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnReload.Image = ((System.Drawing.Image)(resources.GetObject("btnReload.Image")));
            this.btnReload.Location = new System.Drawing.Point(33, 6);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(24, 24);
            this.btnReload.TabIndex = 4;
            this.toolTip.SetToolTip(this.btnReload, "Reload the definition");
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEdit.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.Location = new System.Drawing.Point(3, 6);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(24, 24);
            this.btnEdit.TabIndex = 3;
            this.toolTip.SetToolTip(this.btnEdit, "Open the definition in an editor.");
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerate.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnGenerate.Image = ((System.Drawing.Image)(resources.GetObject("btnGenerate.Image")));
            this.btnGenerate.Location = new System.Drawing.Point(237, 6);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(24, 24);
            this.btnGenerate.TabIndex = 2;
            this.toolTip.SetToolTip(this.btnGenerate, "Generate");
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // webBrowser
            // 
            this.webBrowser.AllowWebBrowserDrop = false;
            this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser.Location = new System.Drawing.Point(0, 0);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(528, 531);
            this.webBrowser.TabIndex = 1;
            this.webBrowser.WebBrowserShortcutsEnabled = false;
            // 
            // pnlCommands
            // 
            this.pnlCommands.Controls.Add(this.btnSelectAll);
            this.pnlCommands.Controls.Add(this.btnClear);
            this.pnlCommands.Controls.Add(this.btnCopy);
            this.pnlCommands.Controls.Add(this.btnSave);
            this.pnlCommands.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlCommands.Location = new System.Drawing.Point(0, 531);
            this.pnlCommands.Name = "pnlCommands";
            this.pnlCommands.Size = new System.Drawing.Size(528, 36);
            this.pnlCommands.TabIndex = 0;
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectAll.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnSelectAll.Image = ((System.Drawing.Image)(resources.GetObject("btnSelectAll.Image")));
            this.btnSelectAll.Location = new System.Drawing.Point(441, 7);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(24, 24);
            this.btnSelectAll.TabIndex = 6;
            this.toolTip.SetToolTip(this.btnSelectAll, "Select All");
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.Location = new System.Drawing.Point(411, 7);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(24, 24);
            this.btnClear.TabIndex = 5;
            this.toolTip.SetToolTip(this.btnClear, "Clear Results");
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopy.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnCopy.Image = ((System.Drawing.Image)(resources.GetObject("btnCopy.Image")));
            this.btnCopy.Location = new System.Drawing.Point(471, 7);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(24, 24);
            this.btnCopy.TabIndex = 4;
            this.toolTip.SetToolTip(this.btnCopy, "Copy");
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(501, 7);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(24, 24);
            this.btnSave.TabIndex = 3;
            this.toolTip.SetToolTip(this.btnSave, "Save As");
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // frmGenerator
            // 
            this.AcceptButton = this.btnGenerate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 593);
            this.ControlBox = false;
            this.Controls.Add(this.spcMain);
            this.Controls.Add(this.lblName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmGenerator";
            this.Text = "Generator";
            this.spcMain.Panel1.ResumeLayout(false);
            this.spcMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).EndInit();
            this.spcMain.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.pnlCommands.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

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
	}
}