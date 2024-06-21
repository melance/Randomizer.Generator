using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Randomizer.Generator.Win.Forms
{
	public partial class frmSettings : Form
	{
		public frmSettings()
		{
			InitializeComponent();
			lstDefinitionFolders.Items.AddRange(Properties.Settings.Default.GeneratorDirectory.Cast<String>().ToArray());
			selTextEditor.Text = Properties.Settings.Default.TextEditor;
			txtTextEditorArgs.Text = Properties.Settings.Default.TextEditorArgs;
			nudDefaultRepeat.Value = Properties.Settings.Default.DefaultRepeat;
		}

		private void btnOk_Click(Object sender, EventArgs e)
		{
			Properties.Settings.Default.GeneratorDirectory.Clear();
			Properties.Settings.Default.GeneratorDirectory.AddRange(lstDefinitionFolders.Items.Cast<String>().ToArray());
			Properties.Settings.Default.TextEditor = selTextEditor.Text;
			Properties.Settings.Default.TextEditorArgs = txtTextEditorArgs.Text;
			Properties.Settings.Default.DefaultRepeat = (Int32)nudDefaultRepeat.Value;
			Properties.Settings.Default.Save();
			DialogResult = DialogResult.OK;
			Close();
		}

		private void btnAddFolder_Click(Object sender, EventArgs e)
		{
			if (folderBrowserDialog.ShowDialog(this) == DialogResult.OK)
			{
				if (!lstDefinitionFolders.Items.Contains(folderBrowserDialog.SelectedPath))
					lstDefinitionFolders.Items.Add(folderBrowserDialog.SelectedPath);
			}
		}

		private void btnRemoveFolder_Click(Object sender, EventArgs e)
		{
			if (lstDefinitionFolders.SelectedIndex >= 0)
			{
				lstDefinitionFolders.Items.RemoveAt(lstDefinitionFolders.SelectedIndex);
			}
		}
	}
}
