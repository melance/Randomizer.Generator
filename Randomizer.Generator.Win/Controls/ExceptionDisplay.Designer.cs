namespace Randomizer.Generator.Win.Controls
{
	partial class ExceptionDisplay
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			lnkName = new LinkLabel();
			txtException = new TextBox();
			SuspendLayout();
			// 
			// lnkName
			// 
			lnkName.BackColor = Color.White;
			lnkName.Dock = DockStyle.Top;
			lnkName.Location = new Point(0, 0);
			lnkName.Name = "lnkName";
			lnkName.Size = new Size(887, 23);
			lnkName.TabIndex = 0;
			lnkName.TabStop = true;
			lnkName.Text = "linkLabel1";
			// 
			// txtException
			// 
			txtException.BorderStyle = BorderStyle.FixedSingle;
			txtException.Dock = DockStyle.Fill;
			txtException.Location = new Point(0, 23);
			txtException.Multiline = true;
			txtException.Name = "txtException";
			txtException.ReadOnly = true;
			txtException.ScrollBars = ScrollBars.Vertical;
			txtException.Size = new Size(887, 117);
			txtException.TabIndex = 1;
			// 
			// ExceptionDisplay
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			Controls.Add(txtException);
			Controls.Add(lnkName);
			Name = "ExceptionDisplay";
			Size = new Size(887, 140);
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private LinkLabel lnkName;
		private TextBox txtException;
	}
}
