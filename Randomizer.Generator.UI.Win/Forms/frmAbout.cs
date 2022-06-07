using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Randomizer.Generator.UI.Win.Forms
{
	partial class frmAbout : Form
	{
		public frmAbout()
		{
			InitializeComponent();
			Text = String.Format("About {0}", AssemblyInfo.Name);
			labelProductName.Text = AssemblyInfo.Name;
			labelVersion.Text = $"Version {AssemblyInfo.Version}";
			labelCopyright.Text = AssemblyInfo.Copyright;
			textBoxDescription.Text = AssemblyInfo.Description;
		}
	}
}
