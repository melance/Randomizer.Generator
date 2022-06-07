namespace Randomizer.Generator.UI.Win.Controls
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileSelector));
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.btnOpenDialog = new System.Windows.Forms.Button();
            this.dlgOpenFile = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // txtFilePath
            // 
            this.txtFilePath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFilePath.Location = new System.Drawing.Point(0, 0);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(99, 23);
            this.txtFilePath.TabIndex = 0;
            this.txtFilePath.TextChanged += new System.EventHandler(this.txtFilePath_TextChanged);
            // 
            // btnOpenDialog
            // 
            this.btnOpenDialog.BackColor = System.Drawing.SystemColors.Window;
            this.btnOpenDialog.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOpenDialog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenDialog.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenDialog.Image")));
            this.btnOpenDialog.Location = new System.Drawing.Point(99, 0);
            this.btnOpenDialog.Margin = new System.Windows.Forms.Padding(0);
            this.btnOpenDialog.Name = "btnOpenDialog";
            this.btnOpenDialog.Size = new System.Drawing.Size(24, 23);
            this.btnOpenDialog.TabIndex = 1;
            this.btnOpenDialog.UseVisualStyleBackColor = false;
            this.btnOpenDialog.Click += new System.EventHandler(this.btnOpenDialog_Click);
            // 
            // FileSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.btnOpenDialog);
            this.Name = "FileSelector";
            this.Size = new System.Drawing.Size(123, 23);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private TextBox txtFilePath;
		private Button btnOpenDialog;
		private OpenFileDialog dlgOpenFile;
	}
}
