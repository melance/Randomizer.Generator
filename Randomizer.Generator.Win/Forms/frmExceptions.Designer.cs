namespace Randomizer.Generator.Win.Forms
{
	partial class frmExceptions
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
			lblHeader = new Label();
			pnlLayout = new Panel();
			SuspendLayout();
			// 
			// lblHeader
			// 
			lblHeader.Dock = DockStyle.Top;
			lblHeader.Location = new Point(0, 0);
			lblHeader.Name = "lblHeader";
			lblHeader.Size = new Size(800, 20);
			lblHeader.TabIndex = 0;
			lblHeader.Text = "The following definitions failed to load:";
			// 
			// pnlLayout
			// 
			pnlLayout.Dock = DockStyle.Fill;
			pnlLayout.Location = new Point(0, 20);
			pnlLayout.Name = "pnlLayout";
			pnlLayout.Size = new Size(800, 430);
			pnlLayout.TabIndex = 1;
			// 
			// frmExceptions
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(pnlLayout);
			Controls.Add(lblHeader);
			FormBorderStyle = FormBorderStyle.SizableToolWindow;
			Name = "frmExceptions";
			Text = "Definition Load Errors";
			ResumeLayout(false);
		}

		#endregion

		private Label lblHeader;
		private Panel pnlLayout;
	}
}