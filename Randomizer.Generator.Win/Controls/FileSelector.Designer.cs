namespace Randomizer.Generator.Win.Controls
{
	partial class FileSelector
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
			var resources = new System.ComponentModel.ComponentResourceManager(typeof(FileSelector));
			txtFilePath = new TextBox();
			btnOpenDialog = new Button();
			dlgOpenFile = new OpenFileDialog();
			SuspendLayout();
			// 
			// txtFilePath
			// 
			txtFilePath.Dock = DockStyle.Fill;
			txtFilePath.Location = new Point(0, 0);
			txtFilePath.Name = "txtFilePath";
			txtFilePath.Size = new Size(99, 23);
			txtFilePath.TabIndex = 0;
			txtFilePath.TextChanged += txtFilePath_TextChanged;
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
			// FileSelector
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			Controls.Add(txtFilePath);
			Controls.Add(btnOpenDialog);
			Name = "FileSelector";
			Size = new Size(123, 23);
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private TextBox txtFilePath;
		private Button btnOpenDialog;
		private OpenFileDialog dlgOpenFile;
	}
}
