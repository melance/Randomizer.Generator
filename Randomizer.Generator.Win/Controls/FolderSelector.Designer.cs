namespace Randomizer.Generator.Win.Controls
{
	partial class FolderSelector
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
			var resources = new System.ComponentModel.ComponentResourceManager(typeof(FolderSelector));
			txtFolder = new TextBox();
			btnOpenDialog = new Button();
			dlgFolderBrowser = new FolderBrowserDialog();
			SuspendLayout();
			// 
			// txtFolder
			// 
			txtFolder.Dock = DockStyle.Fill;
			txtFolder.Location = new Point(0, 0);
			txtFolder.Name = "txtFolder";
			txtFolder.Size = new Size(99, 23);
			txtFolder.TabIndex = 0;
			// 
			// btnOpenDialog
			// 
			btnOpenDialog.BackColor = SystemColors.Window;
			btnOpenDialog.Dock = DockStyle.Right;
			btnOpenDialog.FlatStyle = FlatStyle.Flat;
			btnOpenDialog.Image = (Image)resources.GetObject("btnOpenDialog.Image");
			btnOpenDialog.Location = new Point(99, 0);
			btnOpenDialog.Margin = new Padding(0);
			btnOpenDialog.Name = "btnOpenDialog";
			btnOpenDialog.Size = new Size(24, 23);
			btnOpenDialog.TabIndex = 1;
			btnOpenDialog.UseVisualStyleBackColor = false;
			btnOpenDialog.Click += btnOpenDialog_Click;
			// 
			// FolderSelector
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			Controls.Add(txtFolder);
			Controls.Add(btnOpenDialog);
			Name = "FolderSelector";
			Size = new Size(123, 23);
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private TextBox txtFolder;
		private Button btnOpenDialog;
		private FolderBrowserDialog dlgFolderBrowser;
	}
}
