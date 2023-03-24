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
	public partial class FileSelector : UserControl
	{
		#region Events
		[Browsable(true)]
		[Category("Action")]
		public event EventHandler DialogOpened;
		
		[Browsable(true)]
		[Category("Action")]
		public new event EventHandler TextChanged;
		#endregion

		#region Properties
		public Boolean AllowManualEntry
		{
			get => !txtFilePath.ReadOnly;
			set => txtFilePath.ReadOnly = !value;
		}

		public Boolean CheckFileExists 
		{ 
			get => dlgOpenFile.CheckFileExists; 
			set => dlgOpenFile.CheckFileExists = value; 
		}

		public String DefaultExtension
		{
			get => dlgOpenFile.DefaultExt;
			set => dlgOpenFile.DefaultExt = value;
		}

		public String FileName
		{
			get => Text;
			set => Text = value;
		}

		public String Filter
		{
			get => dlgOpenFile.Filter;
			set => dlgOpenFile.Filter = value;
		}

		public override String Text
		{
			get => txtFilePath.Text;
			set
			{
				txtFilePath.Text = value;
				OnTextChanged(EventArgs.Empty);
			}
		}
		#endregion

		#region Constructor
		public FileSelector()
		{
			InitializeComponent();
		}
		#endregion

		#region Protected Methods
		protected void OnDialogOpened()
		{
			DialogOpened?.Invoke(this, EventArgs.Empty);
		}

		protected void OnTextChanged()
		{
			TextChanged?.Invoke(this, EventArgs.Empty);
		}
		#endregion

		#region Event Handlers
		private void btnOpenDialog_Click(Object sender, EventArgs e)
		{
			dlgOpenFile.FileName = FileName;
			OnDialogOpened();
			if (dlgOpenFile.ShowDialog() == DialogResult.OK)
			{
				FileName = dlgOpenFile.FileName;
			}
		} 

		private void txtFilePath_TextChanged(Object sender, EventArgs e)
		{
			OnTextChanged();
		}
		#endregion
	}
}
