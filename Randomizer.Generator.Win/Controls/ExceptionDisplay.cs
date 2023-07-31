using Randomizer.Generator.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Randomizer.Generator.Win.Controls
{
	public partial class ExceptionDisplay : UserControl
	{
		public ExceptionDisplay(GetDefinitionResponse exception)
		{
			InitializeComponent();
			lnkName.Text = Path.GetFileName(exception.FileName);
			lnkName.Tag = exception.FileName;
			txtException.Text = exception.Exception?.ToString();
		}
	}
}
