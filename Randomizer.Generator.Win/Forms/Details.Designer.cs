namespace Randomizer.Generator.Win.Forms
{
	partial class Details
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
			lblName = new Label();
			tableLayoutPanel1 = new TableLayoutPanel();
			lnkPath = new LinkLabel();
			lblTags = new Label();
			txtTags = new TextBox();
			txtPath = new TextBox();
			txtOutputFormat = new TextBox();
			lblOutputFormat = new Label();
			lblURL = new Label();
			txtAuthor = new TextBox();
			txtDescription = new TextBox();
			lblAuthor = new Label();
			lnkURL = new LinkLabel();
			btnOk = new Button();
			toolTip1 = new ToolTip(components);
			tableLayoutPanel1.SuspendLayout();
			SuspendLayout();
			// 
			// lblName
			// 
			lblName.AutoSize = true;
			lblName.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
			lblName.Location = new Point(9, 9);
			lblName.Name = "lblName";
			lblName.Size = new Size(64, 25);
			lblName.TabIndex = 0;
			lblName.Text = "Name";
			// 
			// tableLayoutPanel1
			// 
			tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			tableLayoutPanel1.ColumnCount = 2;
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 24.2346935F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 75.7653046F));
			tableLayoutPanel1.Controls.Add(lnkPath, 0, 4);
			tableLayoutPanel1.Controls.Add(lblTags, 0, 5);
			tableLayoutPanel1.Controls.Add(txtTags, 1, 5);
			tableLayoutPanel1.Controls.Add(txtPath, 1, 4);
			tableLayoutPanel1.Controls.Add(txtOutputFormat, 1, 3);
			tableLayoutPanel1.Controls.Add(lblOutputFormat, 0, 3);
			tableLayoutPanel1.Controls.Add(lblURL, 0, 2);
			tableLayoutPanel1.Controls.Add(txtAuthor, 1, 1);
			tableLayoutPanel1.Controls.Add(txtDescription, 0, 0);
			tableLayoutPanel1.Controls.Add(lblAuthor, 0, 1);
			tableLayoutPanel1.Controls.Add(lnkURL, 1, 2);
			tableLayoutPanel1.Location = new Point(12, 37);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 6;
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
			tableLayoutPanel1.Size = new Size(392, 161);
			tableLayoutPanel1.TabIndex = 2;
			// 
			// lnkPath
			// 
			lnkPath.Dock = DockStyle.Fill;
			lnkPath.Location = new Point(3, 121);
			lnkPath.Name = "lnkPath";
			lnkPath.Size = new Size(89, 20);
			lnkPath.TabIndex = 11;
			lnkPath.TabStop = true;
			lnkPath.Text = "Path";
			lnkPath.TextAlign = ContentAlignment.MiddleLeft;
			toolTip1.SetToolTip(lnkPath, "Open the containing folder");
			lnkPath.LinkClicked += lnkPath_LinkClicked;
			// 
			// lblTags
			// 
			lblTags.Dock = DockStyle.Fill;
			lblTags.Location = new Point(3, 141);
			lblTags.Name = "lblTags";
			lblTags.Size = new Size(89, 20);
			lblTags.TabIndex = 10;
			lblTags.Text = "Tags";
			lblTags.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// txtTags
			// 
			txtTags.BorderStyle = BorderStyle.None;
			txtTags.Dock = DockStyle.Fill;
			txtTags.Location = new Point(98, 144);
			txtTags.Name = "txtTags";
			txtTags.ReadOnly = true;
			txtTags.Size = new Size(291, 16);
			txtTags.TabIndex = 9;
			txtTags.TabStop = false;
			// 
			// txtPath
			// 
			txtPath.BorderStyle = BorderStyle.None;
			txtPath.Dock = DockStyle.Fill;
			txtPath.Location = new Point(98, 124);
			txtPath.Name = "txtPath";
			txtPath.ReadOnly = true;
			txtPath.Size = new Size(291, 16);
			txtPath.TabIndex = 8;
			txtPath.TabStop = false;
			// 
			// txtOutputFormat
			// 
			txtOutputFormat.BorderStyle = BorderStyle.None;
			txtOutputFormat.Dock = DockStyle.Fill;
			txtOutputFormat.Location = new Point(98, 104);
			txtOutputFormat.Name = "txtOutputFormat";
			txtOutputFormat.ReadOnly = true;
			txtOutputFormat.Size = new Size(291, 16);
			txtOutputFormat.TabIndex = 6;
			txtOutputFormat.TabStop = false;
			// 
			// lblOutputFormat
			// 
			lblOutputFormat.Dock = DockStyle.Fill;
			lblOutputFormat.Location = new Point(3, 101);
			lblOutputFormat.Name = "lblOutputFormat";
			lblOutputFormat.Size = new Size(89, 20);
			lblOutputFormat.TabIndex = 5;
			lblOutputFormat.Text = "Output Format";
			lblOutputFormat.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// lblURL
			// 
			lblURL.Dock = DockStyle.Fill;
			lblURL.Location = new Point(3, 81);
			lblURL.Name = "lblURL";
			lblURL.Size = new Size(89, 20);
			lblURL.TabIndex = 3;
			lblURL.Text = "URL";
			lblURL.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// txtAuthor
			// 
			txtAuthor.BorderStyle = BorderStyle.None;
			txtAuthor.Dock = DockStyle.Fill;
			txtAuthor.Location = new Point(98, 64);
			txtAuthor.Name = "txtAuthor";
			txtAuthor.ReadOnly = true;
			txtAuthor.Size = new Size(291, 16);
			txtAuthor.TabIndex = 2;
			txtAuthor.TabStop = false;
			// 
			// txtDescription
			// 
			txtDescription.BorderStyle = BorderStyle.FixedSingle;
			tableLayoutPanel1.SetColumnSpan(txtDescription, 2);
			txtDescription.Dock = DockStyle.Fill;
			txtDescription.Location = new Point(3, 3);
			txtDescription.Multiline = true;
			txtDescription.Name = "txtDescription";
			txtDescription.ReadOnly = true;
			txtDescription.Size = new Size(386, 55);
			txtDescription.TabIndex = 0;
			txtDescription.TabStop = false;
			// 
			// lblAuthor
			// 
			lblAuthor.Dock = DockStyle.Fill;
			lblAuthor.Location = new Point(3, 61);
			lblAuthor.Name = "lblAuthor";
			lblAuthor.Size = new Size(89, 20);
			lblAuthor.TabIndex = 1;
			lblAuthor.Text = "Author";
			lblAuthor.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// lnkURL
			// 
			lnkURL.Dock = DockStyle.Fill;
			lnkURL.Location = new Point(98, 81);
			lnkURL.Name = "lnkURL";
			lnkURL.Size = new Size(291, 20);
			lnkURL.TabIndex = 4;
			lnkURL.TabStop = true;
			lnkURL.Text = "URL";
			lnkURL.LinkClicked += lnkURL_LinkClicked;
			// 
			// btnOk
			// 
			btnOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			btnOk.Location = new Point(329, 204);
			btnOk.Name = "btnOk";
			btnOk.Size = new Size(75, 23);
			btnOk.TabIndex = 3;
			btnOk.Text = "Ok";
			btnOk.UseVisualStyleBackColor = true;
			btnOk.Click += btnOk_Click;
			// 
			// Details
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(416, 239);
			Controls.Add(btnOk);
			Controls.Add(tableLayoutPanel1);
			Controls.Add(lblName);
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "Details";
			ShowIcon = false;
			ShowInTaskbar = false;
			Text = "Details";
			tableLayoutPanel1.ResumeLayout(false);
			tableLayoutPanel1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label lblName;
		private TableLayoutPanel tableLayoutPanel1;
		private TextBox txtDescription;
		private Label lblAuthor;
		private TextBox txtAuthor;
		private Label lblURL;
		private LinkLabel lnkURL;
		private TextBox txtPath;
		private TextBox txtOutputFormat;
		private Label lblOutputFormat;
		private Button btnOk;
		private Label lblTags;
		private TextBox txtTags;
		private LinkLabel lnkPath;
		private ToolTip toolTip1;
	}
}