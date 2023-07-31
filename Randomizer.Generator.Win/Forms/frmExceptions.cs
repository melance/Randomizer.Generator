using Randomizer.Generator.DataAccess;
using Randomizer.Generator.Win.Controls;
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
	public partial class frmExceptions : Form
	{
		public frmExceptions(GetDefinitionResponse exception) : this(new List<GetDefinitionResponse>() { exception }) { }

		public frmExceptions(IEnumerable<GetDefinitionResponse> exceptions)
		{
			InitializeComponent();
			foreach (var exception in exceptions)
			{
				var control = new ExceptionDisplay(exception)
				{
					Dock = DockStyle.Top
				};
				pnlLayout.Controls.Add(new Splitter() { Dock = DockStyle.Top, Width = 3 });
				pnlLayout.Controls.Add(control);
			}
		}
	}
}
