using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Randomizer.Generator.Win.Forms
{
	public partial class Details : Form
	{
		public Details(String name)
		{
			InitializeComponent();
			var def = DataAccess.DataAccess.Instance.GetDefinition(name);
			Text = $"{def.Name} - Details";
			lblName.Text = def.Name;
			txtPath.Text = ((DataAccess.FileSystemDataAccess)DataAccess.DataAccess.Instance).GetDefinitionPath(name);
			txtAuthor.Text = def.Author;
			txtOutputFormat.Text = def.OutputFormat.ToString();
			txtTags.Text = String.Join(", ", def.Tags.ToArray());
			txtDescription.Text = !String.IsNullOrEmpty(def.Description) ? def.Description : "No description";
			lnkURL.Text = def.URL;
		}

		private void btnOk_Click(Object sender, EventArgs e)
		{
			Close();
		}

		private void lnkPath_LinkClicked(Object sender, LinkLabelLinkClickedEventArgs e)
		{
			try
			{
				LB.Utility.StaticMethods.SelectInExplorer(txtPath.Text);
			}
			catch (ArgumentException ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void lnkURL_LinkClicked(Object sender, LinkLabelLinkClickedEventArgs e)
		{
			try
			{
				LB.Utility.StaticMethods.OpenURL(lnkURL.Text);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
	}
}
