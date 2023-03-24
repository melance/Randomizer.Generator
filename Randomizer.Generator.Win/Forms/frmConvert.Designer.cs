namespace Randomizer.Generator.Win.Forms
{
	partial class frmConvert
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
            this.lblGenerator = new System.Windows.Forms.Label();
            this.selGenerator = new Randomizer.Generator.Win.Controls.FileSelector();
            this.selDefinition = new Randomizer.Generator.Win.Controls.FileSelector();
            this.lblDefinition = new System.Windows.Forms.Label();
            this.btnConvert = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblGenerator
            // 
            this.lblGenerator.AutoSize = true;
            this.lblGenerator.Location = new System.Drawing.Point(12, 16);
            this.lblGenerator.Name = "lblGenerator";
            this.lblGenerator.Size = new System.Drawing.Size(80, 15);
            this.lblGenerator.TabIndex = 0;
            this.lblGenerator.Text = "Generator File";
            // 
            // selGenerator
            // 
            this.selGenerator.AllowManualEntry = true;
            this.selGenerator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.selGenerator.CheckFileExists = true;
            this.selGenerator.DefaultExtension = "";
            this.selGenerator.FileName = "";
            this.selGenerator.Filter = "Randomizer Generators (*.rgen; *.rgen.xml)|*.rgen;*.rgen.xml|All Files (*.*)|*.*";
            this.selGenerator.Location = new System.Drawing.Point(98, 12);
            this.selGenerator.Name = "selGenerator";
            this.selGenerator.Size = new System.Drawing.Size(290, 23);
            this.selGenerator.TabIndex = 1;
            this.selGenerator.TextChanged += new System.EventHandler(this.selGenerator_TextChanged);
            // 
            // selDefinition
            // 
            this.selDefinition.AllowManualEntry = true;
            this.selDefinition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.selDefinition.CheckFileExists = false;
            this.selDefinition.DefaultExtension = "rgen.hjson";
            this.selDefinition.FileName = "";
            this.selDefinition.Filter = "Randomizer Definitions (*.rgen.hjson)|*.rgen.hjson|All Files (*.*)|*.*";
            this.selDefinition.Location = new System.Drawing.Point(98, 41);
            this.selDefinition.Name = "selDefinition";
            this.selDefinition.Size = new System.Drawing.Size(290, 23);
            this.selDefinition.TabIndex = 3;
            // 
            // lblDefinition
            // 
            this.lblDefinition.AutoSize = true;
            this.lblDefinition.Location = new System.Drawing.Point(12, 45);
            this.lblDefinition.Name = "lblDefinition";
            this.lblDefinition.Size = new System.Drawing.Size(80, 15);
            this.lblDefinition.TabIndex = 2;
            this.lblDefinition.Text = "Definition File";
            // 
            // btnConvert
            // 
            this.btnConvert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConvert.Location = new System.Drawing.Point(313, 70);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(75, 23);
            this.btnConvert.TabIndex = 4;
            this.btnConvert.Text = "Convert";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // frmConvert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 103);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.selDefinition);
            this.Controls.Add(this.lblDefinition);
            this.Controls.Add(this.selGenerator);
            this.Controls.Add(this.lblGenerator);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmConvert";
            this.Text = "Convert Generator";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private Label lblGenerator;
		private Controls.FileSelector selGenerator;
		private Controls.FileSelector selDefinition;
		private Label lblDefinition;
		private Button btnConvert;
	}
}