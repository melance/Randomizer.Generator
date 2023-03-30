namespace Randomizer.Generator.Win
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
			components = new System.ComponentModel.Container();
			var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
			mnuMain = new MenuStrip();
			mnuFile = new ToolStripMenuItem();
			mnuImport = new ToolStripMenuItem();
			refreshGeneratorListToolStripMenuItem = new ToolStripMenuItem();
			toolStripSeparator1 = new ToolStripSeparator();
			mnuExit = new ToolStripMenuItem();
			mnuTools = new ToolStripMenuItem();
			mnuConvert = new ToolStripMenuItem();
			mnuSettings = new ToolStripMenuItem();
			mnuHelp = new ToolStripMenuItem();
			mnuOnlineHelp = new ToolStripMenuItem();
			mnuGithub = new ToolStripMenuItem();
			mnuAbout = new ToolStripMenuItem();
			lblGeneratorList = new Label();
			pnlSearch = new Panel();
			txtSearch = new TextBox();
			btnClearSearch = new Button();
			lstGenerators = new ListBox();
			pnlGeneratorList = new Panel();
			pnlGeneratorListTitle = new Panel();
			btnHideGeneratorList = new Button();
			splGeneratorList = new Splitter();
			toolTips = new ToolTip(components);
			btnSelectAllTags = new Button();
			btnDeselectAllTags = new Button();
			btnToggleSelectedTags = new Button();
			btnHideTags = new Button();
			btnShowTags = new Button();
			pnlWindowList = new FlowLayoutPanel();
			dlgImport = new OpenFileDialog();
			tagList = new Controls.TagList();
			pnlTagsLabel = new Panel();
			lblTags = new Label();
			btnShowGeneratorList = new Button();
			pnlShowGeneratorList = new Panel();
			lblGeneratorListShow = new Label();
			mnuMain.SuspendLayout();
			pnlSearch.SuspendLayout();
			pnlGeneratorList.SuspendLayout();
			pnlGeneratorListTitle.SuspendLayout();
			pnlTagsLabel.SuspendLayout();
			pnlShowGeneratorList.SuspendLayout();
			SuspendLayout();
			// 
			// mnuMain
			// 
			mnuMain.Items.AddRange(new ToolStripItem[] { mnuFile, mnuTools, mnuHelp });
			mnuMain.Location = new Point(0, 0);
			mnuMain.Name = "mnuMain";
			mnuMain.Size = new Size(1002, 24);
			mnuMain.TabIndex = 1;
			mnuMain.Text = "menuStrip1";
			// 
			// mnuFile
			// 
			mnuFile.DropDownItems.AddRange(new ToolStripItem[] { mnuImport, refreshGeneratorListToolStripMenuItem, toolStripSeparator1, mnuExit });
			mnuFile.Name = "mnuFile";
			mnuFile.Size = new Size(37, 20);
			mnuFile.Text = "&File";
			// 
			// mnuImport
			// 
			mnuImport.Name = "mnuImport";
			mnuImport.Size = new Size(189, 22);
			mnuImport.Text = "&Import";
			mnuImport.Click += mnuImport_Click;
			// 
			// refreshGeneratorListToolStripMenuItem
			// 
			refreshGeneratorListToolStripMenuItem.Name = "refreshGeneratorListToolStripMenuItem";
			refreshGeneratorListToolStripMenuItem.Size = new Size(189, 22);
			refreshGeneratorListToolStripMenuItem.Text = "&Refresh Generator List";
			refreshGeneratorListToolStripMenuItem.Click += refreshGeneratorListToolStripMenuItem_Click;
			// 
			// toolStripSeparator1
			// 
			toolStripSeparator1.Name = "toolStripSeparator1";
			toolStripSeparator1.Size = new Size(186, 6);
			// 
			// mnuExit
			// 
			mnuExit.Name = "mnuExit";
			mnuExit.ShortcutKeyDisplayString = "Alt+F4";
			mnuExit.Size = new Size(189, 22);
			mnuExit.Text = "E&xit";
			mnuExit.Click += mnuExit_Click;
			// 
			// mnuTools
			// 
			mnuTools.DropDownItems.AddRange(new ToolStripItem[] { mnuConvert, mnuSettings });
			mnuTools.Name = "mnuTools";
			mnuTools.Size = new Size(46, 20);
			mnuTools.Text = "Tools";
			// 
			// mnuConvert
			// 
			mnuConvert.Name = "mnuConvert";
			mnuConvert.Size = new Size(190, 22);
			mnuConvert.Text = "Con&vert Grammar File";
			mnuConvert.Click += mnuConvert_Click;
			// 
			// mnuSettings
			// 
			mnuSettings.Name = "mnuSettings";
			mnuSettings.Size = new Size(190, 22);
			mnuSettings.Text = "&Settings";
			mnuSettings.Click += mnuSettings_Click;
			// 
			// mnuHelp
			// 
			mnuHelp.DropDownItems.AddRange(new ToolStripItem[] { mnuOnlineHelp, mnuGithub, mnuAbout });
			mnuHelp.Name = "mnuHelp";
			mnuHelp.Size = new Size(44, 20);
			mnuHelp.Text = "&Help";
			// 
			// mnuOnlineHelp
			// 
			mnuOnlineHelp.Name = "mnuOnlineHelp";
			mnuOnlineHelp.ShortcutKeyDisplayString = "F1";
			mnuOnlineHelp.Size = new Size(193, 22);
			mnuOnlineHelp.Text = "View Online &Help";
			mnuOnlineHelp.Click += mnuOnlineHelp_Click;
			// 
			// mnuGithub
			// 
			mnuGithub.Name = "mnuGithub";
			mnuGithub.Size = new Size(193, 22);
			mnuGithub.Text = "Randomizer on &Github";
			mnuGithub.Click += mnuGithub_Click;
			// 
			// mnuAbout
			// 
			mnuAbout.Name = "mnuAbout";
			mnuAbout.Size = new Size(193, 22);
			mnuAbout.Text = "&About";
			mnuAbout.Click += mnuAbout_Click;
			// 
			// lblGeneratorList
			// 
			lblGeneratorList.BackColor = SystemColors.ControlDarkDark;
			lblGeneratorList.Dock = DockStyle.Fill;
			lblGeneratorList.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
			lblGeneratorList.ForeColor = SystemColors.ButtonFace;
			lblGeneratorList.Location = new Point(0, 0);
			lblGeneratorList.Name = "lblGeneratorList";
			lblGeneratorList.Size = new Size(200, 24);
			lblGeneratorList.TabIndex = 0;
			lblGeneratorList.Text = "Generator List";
			lblGeneratorList.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// pnlSearch
			// 
			pnlSearch.Controls.Add(txtSearch);
			pnlSearch.Controls.Add(btnClearSearch);
			pnlSearch.Dock = DockStyle.Top;
			pnlSearch.Location = new Point(0, 24);
			pnlSearch.Name = "pnlSearch";
			pnlSearch.Size = new Size(200, 24);
			pnlSearch.TabIndex = 1;
			// 
			// txtSearch
			// 
			txtSearch.BorderStyle = BorderStyle.FixedSingle;
			txtSearch.Dock = DockStyle.Fill;
			txtSearch.Location = new Point(0, 0);
			txtSearch.Name = "txtSearch";
			txtSearch.Size = new Size(176, 23);
			txtSearch.TabIndex = 2;
			toolTips.SetToolTip(txtSearch, "Search by Name");
			txtSearch.TextChanged += txtSearch_TextChanged;
			// 
			// btnClearSearch
			// 
			btnClearSearch.Dock = DockStyle.Right;
			btnClearSearch.Image = (Image)resources.GetObject("btnClearSearch.Image");
			btnClearSearch.Location = new Point(176, 0);
			btnClearSearch.Name = "btnClearSearch";
			btnClearSearch.Size = new Size(24, 24);
			btnClearSearch.TabIndex = 0;
			toolTips.SetToolTip(btnClearSearch, "Clear Search Text");
			btnClearSearch.UseVisualStyleBackColor = true;
			btnClearSearch.Click += btnClearSearch_Click;
			// 
			// lstGenerators
			// 
			lstGenerators.Dock = DockStyle.Fill;
			lstGenerators.FormattingEnabled = true;
			lstGenerators.IntegralHeight = false;
			lstGenerators.ItemHeight = 15;
			lstGenerators.Location = new Point(0, 48);
			lstGenerators.Name = "lstGenerators";
			lstGenerators.Size = new Size(200, 580);
			lstGenerators.TabIndex = 2;
			lstGenerators.DoubleClick += lstGenerators_DoubleClick;
			lstGenerators.MouseMove += lstGenerators_MouseMove;
			// 
			// pnlGeneratorList
			// 
			pnlGeneratorList.Controls.Add(lstGenerators);
			pnlGeneratorList.Controls.Add(pnlSearch);
			pnlGeneratorList.Controls.Add(pnlGeneratorListTitle);
			pnlGeneratorList.Dock = DockStyle.Left;
			pnlGeneratorList.Location = new Point(0, 72);
			pnlGeneratorList.Name = "pnlGeneratorList";
			pnlGeneratorList.Size = new Size(200, 628);
			pnlGeneratorList.TabIndex = 4;
			// 
			// pnlGeneratorListTitle
			// 
			pnlGeneratorListTitle.Controls.Add(btnHideGeneratorList);
			pnlGeneratorListTitle.Controls.Add(lblGeneratorList);
			pnlGeneratorListTitle.Dock = DockStyle.Top;
			pnlGeneratorListTitle.Location = new Point(0, 0);
			pnlGeneratorListTitle.Name = "pnlGeneratorListTitle";
			pnlGeneratorListTitle.Size = new Size(200, 24);
			pnlGeneratorListTitle.TabIndex = 3;
			// 
			// btnHideGeneratorList
			// 
			btnHideGeneratorList.BackColor = SystemColors.Control;
			btnHideGeneratorList.Dock = DockStyle.Right;
			btnHideGeneratorList.Image = (Image)resources.GetObject("btnHideGeneratorList.Image");
			btnHideGeneratorList.Location = new Point(176, 0);
			btnHideGeneratorList.Name = "btnHideGeneratorList";
			btnHideGeneratorList.Size = new Size(24, 24);
			btnHideGeneratorList.TabIndex = 5;
			toolTips.SetToolTip(btnHideGeneratorList, "Hide The Generator List");
			btnHideGeneratorList.UseVisualStyleBackColor = false;
			btnHideGeneratorList.Click += btnHideGeneratorList_Click;
			// 
			// splGeneratorList
			// 
			splGeneratorList.Location = new Point(200, 72);
			splGeneratorList.Name = "splGeneratorList";
			splGeneratorList.Size = new Size(3, 628);
			splGeneratorList.TabIndex = 5;
			splGeneratorList.TabStop = false;
			// 
			// btnSelectAllTags
			// 
			btnSelectAllTags.BackColor = SystemColors.Control;
			btnSelectAllTags.Dock = DockStyle.Right;
			btnSelectAllTags.Image = (Image)resources.GetObject("btnSelectAllTags.Image");
			btnSelectAllTags.Location = new Point(882, 0);
			btnSelectAllTags.Name = "btnSelectAllTags";
			btnSelectAllTags.Size = new Size(24, 24);
			btnSelectAllTags.TabIndex = 1;
			toolTips.SetToolTip(btnSelectAllTags, "Select All Tags");
			btnSelectAllTags.UseVisualStyleBackColor = false;
			btnSelectAllTags.Click += btnSelectAllTags_Click;
			// 
			// btnDeselectAllTags
			// 
			btnDeselectAllTags.BackColor = SystemColors.Control;
			btnDeselectAllTags.Dock = DockStyle.Right;
			btnDeselectAllTags.Image = (Image)resources.GetObject("btnDeselectAllTags.Image");
			btnDeselectAllTags.Location = new Point(906, 0);
			btnDeselectAllTags.Name = "btnDeselectAllTags";
			btnDeselectAllTags.Size = new Size(24, 24);
			btnDeselectAllTags.TabIndex = 2;
			toolTips.SetToolTip(btnDeselectAllTags, "Deselect All Tags");
			btnDeselectAllTags.UseVisualStyleBackColor = false;
			btnDeselectAllTags.Click += btnDeselectAllTags_Click;
			// 
			// btnToggleSelectedTags
			// 
			btnToggleSelectedTags.BackColor = SystemColors.Control;
			btnToggleSelectedTags.Dock = DockStyle.Right;
			btnToggleSelectedTags.Image = (Image)resources.GetObject("btnToggleSelectedTags.Image");
			btnToggleSelectedTags.Location = new Point(930, 0);
			btnToggleSelectedTags.Name = "btnToggleSelectedTags";
			btnToggleSelectedTags.Size = new Size(24, 24);
			btnToggleSelectedTags.TabIndex = 3;
			toolTips.SetToolTip(btnToggleSelectedTags, "Toggle Selected Tags");
			btnToggleSelectedTags.UseVisualStyleBackColor = false;
			btnToggleSelectedTags.Click += btnToggleSelectedTags_Click;
			// 
			// btnHideTags
			// 
			btnHideTags.BackColor = SystemColors.Control;
			btnHideTags.Dock = DockStyle.Right;
			btnHideTags.Image = (Image)resources.GetObject("btnHideTags.Image");
			btnHideTags.Location = new Point(954, 0);
			btnHideTags.Name = "btnHideTags";
			btnHideTags.Size = new Size(24, 24);
			btnHideTags.TabIndex = 4;
			toolTips.SetToolTip(btnHideTags, "Hide Tag List");
			btnHideTags.UseVisualStyleBackColor = false;
			btnHideTags.Click += btnHideTags_Click;
			// 
			// btnShowTags
			// 
			btnShowTags.BackColor = SystemColors.Control;
			btnShowTags.Dock = DockStyle.Right;
			btnShowTags.Image = (Image)resources.GetObject("btnShowTags.Image");
			btnShowTags.Location = new Point(978, 0);
			btnShowTags.Name = "btnShowTags";
			btnShowTags.Size = new Size(24, 24);
			btnShowTags.TabIndex = 5;
			toolTips.SetToolTip(btnShowTags, "Show Tag List");
			btnShowTags.UseVisualStyleBackColor = false;
			btnShowTags.Visible = false;
			btnShowTags.Click += btnShowTags_Click;
			// 
			// pnlWindowList
			// 
			pnlWindowList.AutoScroll = true;
			pnlWindowList.AutoSize = true;
			pnlWindowList.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			pnlWindowList.Dock = DockStyle.Top;
			pnlWindowList.Location = new Point(203, 72);
			pnlWindowList.Name = "pnlWindowList";
			pnlWindowList.Size = new Size(799, 0);
			pnlWindowList.TabIndex = 7;
			// 
			// dlgImport
			// 
			dlgImport.FileName = "openFileDialog1";
			dlgImport.Filter = "Randomizer Definitions (*.rnd.hjson)|*.rnd.hjson|All Files (*.*)|*.*";
			// 
			// tagList
			// 
			tagList.AutoScroll = true;
			tagList.AutoSize = true;
			tagList.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			tagList.Dock = DockStyle.Top;
			tagList.Location = new Point(0, 48);
			tagList.MaximumSize = new Size(100000, 94);
			tagList.MinimumSize = new Size(100, 24);
			tagList.Name = "tagList";
			tagList.Size = new Size(1002, 24);
			tagList.TabIndex = 11;
			tagList.TagSelectionChanged += tagList_TagSelectionChanged;
			// 
			// pnlTagsLabel
			// 
			pnlTagsLabel.Controls.Add(btnSelectAllTags);
			pnlTagsLabel.Controls.Add(btnDeselectAllTags);
			pnlTagsLabel.Controls.Add(btnToggleSelectedTags);
			pnlTagsLabel.Controls.Add(btnHideTags);
			pnlTagsLabel.Controls.Add(btnShowTags);
			pnlTagsLabel.Controls.Add(lblTags);
			pnlTagsLabel.Dock = DockStyle.Top;
			pnlTagsLabel.Location = new Point(0, 24);
			pnlTagsLabel.Name = "pnlTagsLabel";
			pnlTagsLabel.Size = new Size(1002, 24);
			pnlTagsLabel.TabIndex = 15;
			// 
			// lblTags
			// 
			lblTags.BackColor = SystemColors.ControlDarkDark;
			lblTags.Dock = DockStyle.Fill;
			lblTags.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
			lblTags.ForeColor = SystemColors.ButtonFace;
			lblTags.Location = new Point(0, 0);
			lblTags.Name = "lblTags";
			lblTags.Size = new Size(1002, 24);
			lblTags.TabIndex = 0;
			lblTags.Text = "Tags";
			lblTags.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// btnShowGeneratorList
			// 
			btnShowGeneratorList.Dock = DockStyle.Top;
			btnShowGeneratorList.Image = (Image)resources.GetObject("btnShowGeneratorList.Image");
			btnShowGeneratorList.Location = new Point(0, 0);
			btnShowGeneratorList.Name = "btnShowGeneratorList";
			btnShowGeneratorList.Size = new Size(18, 24);
			btnShowGeneratorList.TabIndex = 17;
			btnShowGeneratorList.UseVisualStyleBackColor = true;
			btnShowGeneratorList.Click += btnShowGeneratorList_Click;
			// 
			// pnlShowGeneratorList
			// 
			pnlShowGeneratorList.Controls.Add(lblGeneratorListShow);
			pnlShowGeneratorList.Controls.Add(btnShowGeneratorList);
			pnlShowGeneratorList.Dock = DockStyle.Left;
			pnlShowGeneratorList.Location = new Point(203, 72);
			pnlShowGeneratorList.Name = "pnlShowGeneratorList";
			pnlShowGeneratorList.Size = new Size(18, 628);
			pnlShowGeneratorList.TabIndex = 19;
			pnlShowGeneratorList.Visible = false;
			// 
			// lblGeneratorListShow
			// 
			lblGeneratorListShow.BackColor = SystemColors.ControlDarkDark;
			lblGeneratorListShow.Dock = DockStyle.Fill;
			lblGeneratorListShow.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
			lblGeneratorListShow.ForeColor = SystemColors.ButtonFace;
			lblGeneratorListShow.Location = new Point(0, 24);
			lblGeneratorListShow.Name = "lblGeneratorListShow";
			lblGeneratorListShow.Size = new Size(18, 604);
			lblGeneratorListShow.TabIndex = 18;
			lblGeneratorListShow.Text = "G\r\ne\r\nn\r\ne\r\nr\r\na\r\nt\r\no\r\nr\r\n \r\nL\r\ni\r\ns\r\nt";
			lblGeneratorListShow.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// frmMain
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1002, 700);
			Controls.Add(pnlShowGeneratorList);
			Controls.Add(pnlWindowList);
			Controls.Add(splGeneratorList);
			Controls.Add(pnlGeneratorList);
			Controls.Add(tagList);
			Controls.Add(pnlTagsLabel);
			Controls.Add(mnuMain);
			Icon = (Icon)resources.GetObject("$this.Icon");
			IsMdiContainer = true;
			MainMenuStrip = mnuMain;
			Name = "frmMain";
			Text = "The Randomizer";
			mnuMain.ResumeLayout(false);
			mnuMain.PerformLayout();
			pnlSearch.ResumeLayout(false);
			pnlSearch.PerformLayout();
			pnlGeneratorList.ResumeLayout(false);
			pnlGeneratorListTitle.ResumeLayout(false);
			pnlTagsLabel.ResumeLayout(false);
			pnlShowGeneratorList.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
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