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
			var response = DataAccess.DataAccess.Instance.GetDefinition(name);

			if (response.Definition != null)
			{

				Text = $"{response.Definition.Name} - Details";
				lblName.Text = response.Definition.Name;
				txtPath.Text = ((DataAccess.FileSystemDataAccess)DataAccess.DataAccess.Instance).GetDefinitionPath(name);
				txtAuthor.Text = response.Definition.Author;
				txtOutputFormat.Text = response.Definition.OutputFormat.ToString();
				txtTags.Text = String.Join(", ", response.Definition.Tags.ToArray());
				txtDescription.Text = !String.IsNullOrEmpty(response.Definition.Description) ? response.Definition.Description : "No description";
				lnkURL.Text = response.Definition.URL;
			}
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
