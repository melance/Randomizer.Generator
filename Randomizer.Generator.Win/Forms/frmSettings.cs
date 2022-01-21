using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Randomizer.Generator.UI.Win.Forms
{
	public partial class frmSettings : Form
	{
		public frmSettings()
		{
			InitializeComponent();
			selGeneratorDirectory.Text = Properties.Settings.Default.GeneratorDirectory;
			selTextEditor.Text = Properties.Settings.Default.TextEditor;
			txtTextEditorArgs.Text = Properties.Settings.Default.TextEditorArgs;
			nudDefaultRepeat.Value = Properties.Settings.Default.DefaultRepeat;
		}

		private void btnOk_Click(Object sender, EventArgs e)
		{
			Properties.Settings.Default.GeneratorDirectory = selGeneratorDirectory.Text;
			Properties.Settings.Default.TextEditor = selTextEditor.Text;
			Properties.Settings.Default.TextEditorArgs = txtTextEditorArgs.Text;
			Properties.Settings.Default.DefaultRepeat = (Int32)nudDefaultRepeat.Value;
			Properties.Settings.Default.Save();
			DialogResult = DialogResult.OK;
			Close();
		}
	}
}
