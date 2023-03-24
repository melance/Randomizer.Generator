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
	public partial class FolderSelector : UserControl
	{
		#region Events
		public delegate void DialogOpenedEventHandler(object sender, EventArgs e);
		public event DialogOpenedEventHandler DialogOpened;
		#endregion

		#region Properties
		public Boolean AllowManualEntry
		{
			get => !txtFolder.ReadOnly;
			set => txtFolder.ReadOnly = !value;
		}

		public String SelectedFolder
		{
			get => Text;
			set => Text = value;
		}

		public Boolean ShowNewFolderButton
		{
			get => dlgFolderBrowser.ShowNewFolderButton;
			set => dlgFolderBrowser.ShowNewFolderButton = value;
		}

		public override String Text
		{
			get => txtFolder.Text;
			set
			{
				txtFolder.Text = value;
				OnTextChanged(EventArgs.Empty);
			}
		}
		#endregion

		#region Constructor
		public FolderSelector()
		{
			InitializeComponent();
		}
		#endregion

		#region Protected Methods
		protected void OnDialogOpened()
		{
			DialogOpened?.Invoke(this, EventArgs.Empty);
		}
		#endregion

		#region Event Handlers
		private void btnOpenDialog_Click(Object sender, EventArgs e)
		{
			dlgFolderBrowser.SelectedPath = txtFolder.Text;
			OnDialogOpened();
			if (dlgFolderBrowser.ShowDialog() == DialogResult.OK)
			{
				SelectedFolder = dlgFolderBrowser.SelectedPath;
			}
		} 
		#endregion
	}
}
