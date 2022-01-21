namespace Randomizer.Generator.UI.Win
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuImport = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshGeneratorListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTools = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuConvert = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOnlineHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGithub = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.lblGeneratorList = new System.Windows.Forms.Label();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnClearSearch = new System.Windows.Forms.Button();
            this.lstGenerators = new System.Windows.Forms.ListBox();
            this.pnlGeneratorList = new System.Windows.Forms.Panel();
            this.pnlGeneratorListTitle = new System.Windows.Forms.Panel();
            this.btnHideGeneratorList = new System.Windows.Forms.Button();
            this.splGeneratorList = new System.Windows.Forms.Splitter();
            this.toolTips = new System.Windows.Forms.ToolTip(this.components);
            this.btnSelectAllTags = new System.Windows.Forms.Button();
            this.btnDeselectAllTags = new System.Windows.Forms.Button();
            this.btnToggleSelectedTags = new System.Windows.Forms.Button();
            this.btnHideTags = new System.Windows.Forms.Button();
            this.btnShowTags = new System.Windows.Forms.Button();
            this.pnlWindowList = new System.Windows.Forms.FlowLayoutPanel();
            this.dlgImport = new System.Windows.Forms.OpenFileDialog();
            this.tagList = new Randomizer.Generator.UI.Win.Controls.TagList();
            this.pnlTagsLabel = new System.Windows.Forms.Panel();
            this.lblTags = new System.Windows.Forms.Label();
            this.btnShowGeneratorList = new System.Windows.Forms.Button();
            this.pnlShowGeneratorList = new System.Windows.Forms.Panel();
            this.lblGeneratorListShow = new System.Windows.Forms.Label();
            this.mnuMain.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.pnlGeneratorList.SuspendLayout();
            this.pnlGeneratorListTitle.SuspendLayout();
            this.pnlTagsLabel.SuspendLayout();
            this.pnlShowGeneratorList.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuTools,
            this.mnuHelp});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(1002, 24);
            this.mnuMain.TabIndex = 1;
            this.mnuMain.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuImport,
            this.refreshGeneratorListToolStripMenuItem,
            this.toolStripSeparator1,
            this.mnuExit});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(37, 20);
            this.mnuFile.Text = "&File";
            // 
            // mnuImport
            // 
            this.mnuImport.Name = "mnuImport";
            this.mnuImport.Size = new System.Drawing.Size(189, 22);
            this.mnuImport.Text = "&Import";
            this.mnuImport.Click += new System.EventHandler(this.mnuImport_Click);
            // 
            // refreshGeneratorListToolStripMenuItem
            // 
            this.refreshGeneratorListToolStripMenuItem.Name = "refreshGeneratorListToolStripMenuItem";
            this.refreshGeneratorListToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.refreshGeneratorListToolStripMenuItem.Text = "&Refresh Generator List";
            this.refreshGeneratorListToolStripMenuItem.Click += new System.EventHandler(this.refreshGeneratorListToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(186, 6);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.ShortcutKeyDisplayString = "Alt+F4";
            this.mnuExit.Size = new System.Drawing.Size(189, 22);
            this.mnuExit.Text = "E&xit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // mnuTools
            // 
            this.mnuTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuConvert,
            this.mnuSettings});
            this.mnuTools.Name = "mnuTools";
            this.mnuTools.Size = new System.Drawing.Size(46, 20);
            this.mnuTools.Text = "Tools";
            // 
            // mnuConvert
            // 
            this.mnuConvert.Name = "mnuConvert";
            this.mnuConvert.Size = new System.Drawing.Size(190, 22);
            this.mnuConvert.Text = "Con&vert Grammar File";
            this.mnuConvert.Click += new System.EventHandler(this.mnuConvert_Click);
            // 
            // mnuSettings
            // 
            this.mnuSettings.Name = "mnuSettings";
            this.mnuSettings.Size = new System.Drawing.Size(190, 22);
            this.mnuSettings.Text = "&Settings";
            this.mnuSettings.Click += new System.EventHandler(this.mnuSettings_Click);
            // 
            // mnuHelp
            // 
            this.mnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOnlineHelp,
            this.mnuGithub,
            this.mnuAbout});
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new System.Drawing.Size(44, 20);
            this.mnuHelp.Text = "&Help";
            // 
            // mnuOnlineHelp
            // 
            this.mnuOnlineHelp.Name = "mnuOnlineHelp";
            this.mnuOnlineHelp.ShortcutKeyDisplayString = "F1";
            this.mnuOnlineHelp.Size = new System.Drawing.Size(193, 22);
            this.mnuOnlineHelp.Text = "View Online &Help";
            this.mnuOnlineHelp.Click += new System.EventHandler(this.mnuOnlineHelp_Click);
            // 
            // mnuGithub
            // 
            this.mnuGithub.Name = "mnuGithub";
            this.mnuGithub.Size = new System.Drawing.Size(193, 22);
            this.mnuGithub.Text = "Randomizer on &Github";
            this.mnuGithub.Click += new System.EventHandler(this.mnuGithub_Click);
            // 
            // mnuAbout
            // 
            this.mnuAbout.Name = "mnuAbout";
            this.mnuAbout.Size = new System.Drawing.Size(193, 22);
            this.mnuAbout.Text = "&About";
            this.mnuAbout.Click += new System.EventHandler(this.mnuAbout_Click);
            // 
            // lblGeneratorList
            // 
            this.lblGeneratorList.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblGeneratorList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGeneratorList.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblGeneratorList.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblGeneratorList.Location = new System.Drawing.Point(0, 0);
            this.lblGeneratorList.Name = "lblGeneratorList";
            this.lblGeneratorList.Size = new System.Drawing.Size(200, 24);
            this.lblGeneratorList.TabIndex = 0;
            this.lblGeneratorList.Text = "Generator List";
            this.lblGeneratorList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlSearch
            // 
            this.pnlSearch.Controls.Add(this.txtSearch);
            this.pnlSearch.Controls.Add(this.btnClearSearch);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearch.Location = new System.Drawing.Point(0, 24);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(200, 24);
            this.pnlSearch.TabIndex = 1;
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearch.Location = new System.Drawing.Point(0, 0);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(176, 23);
            this.txtSearch.TabIndex = 2;
            this.toolTips.SetToolTip(this.txtSearch, "Search by Name");
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnClearSearch
            // 
            this.btnClearSearch.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClearSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnClearSearch.Image")));
            this.btnClearSearch.Location = new System.Drawing.Point(176, 0);
            this.btnClearSearch.Name = "btnClearSearch";
            this.btnClearSearch.Size = new System.Drawing.Size(24, 24);
            this.btnClearSearch.TabIndex = 0;
            this.toolTips.SetToolTip(this.btnClearSearch, "Clear Search Text");
            this.btnClearSearch.UseVisualStyleBackColor = true;
            this.btnClearSearch.Click += new System.EventHandler(this.btnClearSearch_Click);
            // 
            // lstGenerators
            // 
            this.lstGenerators.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstGenerators.FormattingEnabled = true;
            this.lstGenerators.ItemHeight = 15;
            this.lstGenerators.Location = new System.Drawing.Point(0, 48);
            this.lstGenerators.Name = "lstGenerators";
            this.lstGenerators.Size = new System.Drawing.Size(200, 580);
            this.lstGenerators.TabIndex = 2;
            this.lstGenerators.DoubleClick += new System.EventHandler(this.lstGenerators_DoubleClick);
            this.lstGenerators.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lstGenerators_MouseMove);
            // 
            // pnlGeneratorList
            // 
            this.pnlGeneratorList.Controls.Add(this.lstGenerators);
            this.pnlGeneratorList.Controls.Add(this.pnlSearch);
            this.pnlGeneratorList.Controls.Add(this.pnlGeneratorListTitle);
            this.pnlGeneratorList.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlGeneratorList.Location = new System.Drawing.Point(0, 72);
            this.pnlGeneratorList.Name = "pnlGeneratorList";
            this.pnlGeneratorList.Size = new System.Drawing.Size(200, 628);
            this.pnlGeneratorList.TabIndex = 4;
            // 
            // pnlGeneratorListTitle
            // 
            this.pnlGeneratorListTitle.Controls.Add(this.btnHideGeneratorList);
            this.pnlGeneratorListTitle.Controls.Add(this.lblGeneratorList);
            this.pnlGeneratorListTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlGeneratorListTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlGeneratorListTitle.Name = "pnlGeneratorListTitle";
            this.pnlGeneratorListTitle.Size = new System.Drawing.Size(200, 24);
            this.pnlGeneratorListTitle.TabIndex = 3;
            // 
            // btnHideGeneratorList
            // 
            this.btnHideGeneratorList.BackColor = System.Drawing.SystemColors.Control;
            this.btnHideGeneratorList.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnHideGeneratorList.Image = ((System.Drawing.Image)(resources.GetObject("btnHideGeneratorList.Image")));
            this.btnHideGeneratorList.Location = new System.Drawing.Point(176, 0);
            this.btnHideGeneratorList.Name = "btnHideGeneratorList";
            this.btnHideGeneratorList.Size = new System.Drawing.Size(24, 24);
            this.btnHideGeneratorList.TabIndex = 5;
            this.toolTips.SetToolTip(this.btnHideGeneratorList, "Hide The Generator List");
            this.btnHideGeneratorList.UseVisualStyleBackColor = false;
            this.btnHideGeneratorList.Click += new System.EventHandler(this.btnHideGeneratorList_Click);
            // 
            // splGeneratorList
            // 
            this.splGeneratorList.Location = new System.Drawing.Point(200, 72);
            this.splGeneratorList.Name = "splGeneratorList";
            this.splGeneratorList.Size = new System.Drawing.Size(3, 628);
            this.splGeneratorList.TabIndex = 5;
            this.splGeneratorList.TabStop = false;
            // 
            // btnSelectAllTags
            // 
            this.btnSelectAllTags.BackColor = System.Drawing.SystemColors.Control;
            this.btnSelectAllTags.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSelectAllTags.Image = ((System.Drawing.Image)(resources.GetObject("btnSelectAllTags.Image")));
            this.btnSelectAllTags.Location = new System.Drawing.Point(882, 0);
            this.btnSelectAllTags.Name = "btnSelectAllTags";
            this.btnSelectAllTags.Size = new System.Drawing.Size(24, 24);
            this.btnSelectAllTags.TabIndex = 1;
            this.toolTips.SetToolTip(this.btnSelectAllTags, "Select All Tags");
            this.btnSelectAllTags.UseVisualStyleBackColor = false;
            this.btnSelectAllTags.Click += new System.EventHandler(this.btnSelectAllTags_Click);
            // 
            // btnDeselectAllTags
            // 
            this.btnDeselectAllTags.BackColor = System.Drawing.SystemColors.Control;
            this.btnDeselectAllTags.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDeselectAllTags.Image = ((System.Drawing.Image)(resources.GetObject("btnDeselectAllTags.Image")));
            this.btnDeselectAllTags.Location = new System.Drawing.Point(906, 0);
            this.btnDeselectAllTags.Name = "btnDeselectAllTags";
            this.btnDeselectAllTags.Size = new System.Drawing.Size(24, 24);
            this.btnDeselectAllTags.TabIndex = 2;
            this.toolTips.SetToolTip(this.btnDeselectAllTags, "Deselect All Tags");
            this.btnDeselectAllTags.UseVisualStyleBackColor = false;
            this.btnDeselectAllTags.Click += new System.EventHandler(this.btnDeselectAllTags_Click);
            // 
            // btnToggleSelectedTags
            // 
            this.btnToggleSelectedTags.BackColor = System.Drawing.SystemColors.Control;
            this.btnToggleSelectedTags.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnToggleSelectedTags.Image = ((System.Drawing.Image)(resources.GetObject("btnToggleSelectedTags.Image")));
            this.btnToggleSelectedTags.Location = new System.Drawing.Point(930, 0);
            this.btnToggleSelectedTags.Name = "btnToggleSelectedTags";
            this.btnToggleSelectedTags.Size = new System.Drawing.Size(24, 24);
            this.btnToggleSelectedTags.TabIndex = 3;
            this.toolTips.SetToolTip(this.btnToggleSelectedTags, "Toggle Selected Tags");
            this.btnToggleSelectedTags.UseVisualStyleBackColor = false;
            this.btnToggleSelectedTags.Click += new System.EventHandler(this.btnToggleSelectedTags_Click);
            // 
            // btnHideTags
            // 
            this.btnHideTags.BackColor = System.Drawing.SystemColors.Control;
            this.btnHideTags.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnHideTags.Image = ((System.Drawing.Image)(resources.GetObject("btnHideTags.Image")));
            this.btnHideTags.Location = new System.Drawing.Point(954, 0);
            this.btnHideTags.Name = "btnHideTags";
            this.btnHideTags.Size = new System.Drawing.Size(24, 24);
            this.btnHideTags.TabIndex = 4;
            this.toolTips.SetToolTip(this.btnHideTags, "Hide Tag List");
            this.btnHideTags.UseVisualStyleBackColor = false;
            this.btnHideTags.Click += new System.EventHandler(this.btnHideTags_Click);
            // 
            // btnShowTags
            // 
            this.btnShowTags.BackColor = System.Drawing.SystemColors.Control;
            this.btnShowTags.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnShowTags.Image = ((System.Drawing.Image)(resources.GetObject("btnShowTags.Image")));
            this.btnShowTags.Location = new System.Drawing.Point(978, 0);
            this.btnShowTags.Name = "btnShowTags";
            this.btnShowTags.Size = new System.Drawing.Size(24, 24);
            this.btnShowTags.TabIndex = 5;
            this.toolTips.SetToolTip(this.btnShowTags, "Show Tag List");
            this.btnShowTags.UseVisualStyleBackColor = false;
            this.btnShowTags.Visible = false;
            this.btnShowTags.Click += new System.EventHandler(this.btnShowTags_Click);
            // 
            // pnlWindowList
            // 
            this.pnlWindowList.AutoScroll = true;
            this.pnlWindowList.AutoSize = true;
            this.pnlWindowList.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlWindowList.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlWindowList.Location = new System.Drawing.Point(203, 72);
            this.pnlWindowList.Name = "pnlWindowList";
            this.pnlWindowList.Size = new System.Drawing.Size(799, 0);
            this.pnlWindowList.TabIndex = 7;
            // 
            // dlgImport
            // 
            this.dlgImport.FileName = "openFileDialog1";
            this.dlgImport.Filter = "Randomizer Definitions (*.rnd.hjson)|*.rnd.hjson|All Files (*.*)|*.*";
            // 
            // tagList
            // 
            this.tagList.AutoScroll = true;
            this.tagList.AutoSize = true;
            this.tagList.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tagList.Dock = System.Windows.Forms.DockStyle.Top;
            this.tagList.Location = new System.Drawing.Point(0, 48);
            this.tagList.MaximumSize = new System.Drawing.Size(100000, 94);
            this.tagList.MinimumSize = new System.Drawing.Size(100, 24);
            this.tagList.Name = "tagList";
            this.tagList.Size = new System.Drawing.Size(1002, 24);
            this.tagList.TabIndex = 11;
            this.tagList.TagSelectionChanged += new Randomizer.Generator.UI.Win.Controls.TagList.TagSelectionChangedHandler(this.tagList_TagSelectionChanged);
            // 
            // pnlTagsLabel
            // 
            this.pnlTagsLabel.Controls.Add(this.btnSelectAllTags);
            this.pnlTagsLabel.Controls.Add(this.btnDeselectAllTags);
            this.pnlTagsLabel.Controls.Add(this.btnToggleSelectedTags);
            this.pnlTagsLabel.Controls.Add(this.btnHideTags);
            this.pnlTagsLabel.Controls.Add(this.btnShowTags);
            this.pnlTagsLabel.Controls.Add(this.lblTags);
            this.pnlTagsLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTagsLabel.Location = new System.Drawing.Point(0, 24);
            this.pnlTagsLabel.Name = "pnlTagsLabel";
            this.pnlTagsLabel.Size = new System.Drawing.Size(1002, 24);
            this.pnlTagsLabel.TabIndex = 15;
            // 
            // lblTags
            // 
            this.lblTags.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblTags.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTags.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTags.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblTags.Location = new System.Drawing.Point(0, 0);
            this.lblTags.Name = "lblTags";
            this.lblTags.Size = new System.Drawing.Size(1002, 24);
            this.lblTags.TabIndex = 0;
            this.lblTags.Text = "Tags";
            this.lblTags.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnShowGeneratorList
            // 
            this.btnShowGeneratorList.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnShowGeneratorList.Image = ((System.Drawing.Image)(resources.GetObject("btnShowGeneratorList.Image")));
            this.btnShowGeneratorList.Location = new System.Drawing.Point(0, 0);
            this.btnShowGeneratorList.Name = "btnShowGeneratorList";
            this.btnShowGeneratorList.Size = new System.Drawing.Size(18, 24);
            this.btnShowGeneratorList.TabIndex = 17;
            this.btnShowGeneratorList.UseVisualStyleBackColor = true;
            this.btnShowGeneratorList.Click += new System.EventHandler(this.btnShowGeneratorList_Click);
            // 
            // pnlShowGeneratorList
            // 
            this.pnlShowGeneratorList.Controls.Add(this.lblGeneratorListShow);
            this.pnlShowGeneratorList.Controls.Add(this.btnShowGeneratorList);
            this.pnlShowGeneratorList.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlShowGeneratorList.Location = new System.Drawing.Point(203, 72);
            this.pnlShowGeneratorList.Name = "pnlShowGeneratorList";
            this.pnlShowGeneratorList.Size = new System.Drawing.Size(18, 628);
            this.pnlShowGeneratorList.TabIndex = 19;
            this.pnlShowGeneratorList.Visible = false;
            // 
            // lblGeneratorListShow
            // 
            this.lblGeneratorListShow.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblGeneratorListShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGeneratorListShow.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblGeneratorListShow.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblGeneratorListShow.Location = new System.Drawing.Point(0, 24);
            this.lblGeneratorListShow.Name = "lblGeneratorListShow";
            this.lblGeneratorListShow.Size = new System.Drawing.Size(18, 604);
            this.lblGeneratorListShow.TabIndex = 18;
            this.lblGeneratorListShow.Text = "G\r\ne\r\nn\r\ne\r\nr\r\na\r\nt\r\no\r\nr\r\n \r\nL\r\ni\r\ns\r\nt";
            this.lblGeneratorListShow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 700);
            this.Controls.Add(this.pnlShowGeneratorList);
            this.Controls.Add(this.pnlWindowList);
            this.Controls.Add(this.splGeneratorList);
            this.Controls.Add(this.pnlGeneratorList);
            this.Controls.Add(this.tagList);
            this.Controls.Add(this.pnlTagsLabel);
            this.Controls.Add(this.mnuMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnuMain;
            this.Name = "frmMain";
            this.Text = "The Randomizer";
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.pnlGeneratorList.ResumeLayout(false);
            this.pnlGeneratorListTitle.ResumeLayout(false);
            this.pnlTagsLabel.ResumeLayout(false);
            this.pnlShowGeneratorList.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

		#endregion
		private MenuStrip mnuMain;
		private ToolStripMenuItem mnuFile;
		private ToolStripMenuItem mnuImport;
		private ToolStripMenuItem refreshGeneratorListToolStripMenuItem;
		private ToolStripSeparator toolStripSeparator1;
		private ToolStripMenuItem mnuExit;
		private ToolStripMenuItem mnuTools;
		private ToolStripMenuItem mnuConvert;
		private ToolStripMenuItem mnuSettings;
		private ToolStripMenuItem mnuHelp;
		private ToolStripMenuItem mnuOnlineHelp;
		private ToolStripMenuItem mnuGithub;
		private ToolStripMenuItem mnuAbout;
		private Label lblGeneratorList;
		private Panel pnlSearch;
		private Button btnClearSearch;
		private TextBox txtSearch;
		private ListBox lstGenerators;
		private Panel pnlGeneratorList;
		private Splitter splGeneratorList;
		private ToolTip toolTips;
		private FlowLayoutPanel pnlWindowList;
		private OpenFileDialog dlgImport;
		private Controls.TagList tagList;
		private Panel pnlTagsLabel;
		private Label lblTags;
		private Button btnSelectAllTags;
		private Button btnDeselectAllTags;
		private Button btnToggleSelectedTags;
		private Button btnHideTags;
		private Button btnShowTags;
		private Panel pnlGeneratorListTitle;
		private Button btnHideGeneratorList;
		private Button btnShowGeneratorList;
		private Panel pnlShowGeneratorList;
		private Label lblGeneratorListShow;
	}
}