using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Randomizer.Generator.Utility;

namespace Randomizer.Generator.Win.Forms
{
	public partial class frmConvert : Form
	{
		public frmConvert()
		{
			InitializeComponent();			
		}

		private void btnConvert_Click(Object sender, EventArgs e)
		{
			try
			{
				Converter.Convert(selGenerator.Text, selDefinition.Text);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void selGenerator_TextChanged(Object sender, EventArgs e)
		{
			//if (String.IsNullOrWhiteSpace(selDefinition.Text))
				//selDefinition.Text = Path.Combine(Program.GeneratorDirectory, Path.ChangeExtension(Path.GetFileName(selGenerator.Text), "rgen.hjson"));
		}
	}
}
