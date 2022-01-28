namespace Randomizer.Generator.UI.Win.Forms
{
	partial class frmSettings
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
            this.lblGeneratorDirectory = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTextEditorArgs = new System.Windows.Forms.TextBox();
            this.lblTextEditorArgs = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.nudDefaultRepeat = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.selTextEditor = new Randomizer.Generator.UI.Win.Controls.FileSelector();
            this.selGeneratorDirectory = new Randomizer.Generator.UI.Win.Controls.FolderSelector();
            ((System.ComponentModel.ISupportInitialize)(this.nudDefaultRepeat)).BeginInit();
            this.SuspendLayout();
            // 
            // lblGeneratorDirectory
            // 
            this.lblGeneratorDirectory.AutoSize = true;
            this.lblGeneratorDirectory.Location = new System.Drawing.Point(12, 9);
            this.lblGeneratorDirectory.Name = "lblGeneratorDirectory";
            this.lblGeneratorDirectory.Size = new System.Drawing.Size(110, 15);
            this.lblGeneratorDirectory.TabIndex = 0;
            this.lblGeneratorDirectory.Text = "Generator Directory";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Text Editor";
            // 
            // txtTextEditorArgs
            // 
            this.txtTextEditorArgs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTextEditorArgs.Location = new System.Drawing.Point(128, 64);
            this.txtTextEditorArgs.Name = "txtTextEditorArgs";
            this.txtTextEditorArgs.Size = new System.Drawing.Size(262, 23);
            this.txtTextEditorArgs.TabIndex = 7;
            this.toolTip.SetToolTip(this.txtTextEditorArgs, "Arguments to send to the Text Editor.  {filename} will be replaced with the name " +
        "of the definition file.");
            // 
            // lblTextEditorArgs
            // 
            this.lblTextEditorArgs.AutoSize = true;
            this.lblTextEditorArgs.Location = new System.Drawing.Point(12, 67);
            this.lblTextEditorArgs.Name = "lblTextEditorArgs";
            this.lblTextEditorArgs.Size = new System.Drawing.Size(89, 15);
            this.lblTextEditorArgs.TabIndex = 6;
            this.lblTextEditorArgs.Text = "Text Editor Args";
            // 
            // nudDefaultRepeat
            // 
            this.nudDefaultRepeat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudDefaultRepeat.Location = new System.Drawing.Point(128, 93);
            this.nudDefaultRepeat.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudDefaultRepeat.Name = "nudDefaultRepeat";
            this.nudDefaultRepeat.Size = new System.Drawing.Size(262, 23);
            this.nudDefaultRepeat.TabIndex = 8;
            this.nudDefaultRepeat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudDefaultRepeat.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "Default Repeat";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(315, 122);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 10;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(234, 122);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            this.openFileDialog.Filter = "Executable (*.exe)|*.exe|All Files (*.*)|*.*";
            // 
            // selTextEditor
            // 
            this.selTextEditor.AllowManualEntry = true;
            this.selTextEditor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.selTextEditor.CheckFileExists = true;
            this.selTextEditor.DefaultExtension = "";
            this.selTextEditor.FileName = "";
            this.selTextEditor.Filter = "";
            this.selTextEditor.Location = new System.Drawing.Point(128, 34);
            this.selTextEditor.Name = "selTextEditor";
            this.selTextEditor.Size = new System.Drawing.Size(262, 23);
            this.selTextEditor.TabIndex = 12;
            // 
            // selGeneratorDirectory
            // 
            this.selGeneratorDirectory.AllowManualEntry = true;
            this.selGeneratorDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.selGeneratorDirectory.Location = new System.Drawing.Point(129, 7);
            this.selGeneratorDirectory.Name = "selGeneratorDirectory";
            this.selGeneratorDirectory.SelectedFolder = "";
            this.selGeneratorDirectory.ShowNewFolderButton = true;
            this.selGeneratorDirectory.Size = new System.Drawing.Size(261, 23);
            this.selGeneratorDirectory.TabIndex = 13;
            // 
            // frmSettings
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(396, 152);
            this.Controls.Add(this.selGeneratorDirectory);
            this.Controls.Add(this.selTextEditor);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nudDefaultRepeat);
            this.Controls.Add(this.txtTextEditorArgs);
            this.Controls.Add(this.lblTextEditorArgs);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblGeneratorDirectory);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSettings";
            this.Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)(this.nudDefaultRepeat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private Label lblGeneratorDirectory;
		private Label label1;
		private TextBox txtTextEditorArgs;
		private Label lblTextEditorArgs;
		private ToolTip toolTip;
		private NumericUpDown nudDefaultRepeat;
		private Label label2;
		private Button btnOk;
		private Button btnCancel;
		private OpenFileDialog openFileDialog;
		private FolderBrowserDialog folderBrowserDialog;
		private Controls.FileSelector selTextEditor;
		private Controls.FolderSelector selGeneratorDirectory;
	}
}