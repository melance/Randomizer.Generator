using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Randomizer.Generator.UI.Win.Controls
{
	public partial class GeneratorWindowButton : UserControl
	{
		#region Members
		private Boolean _active = false;
		#endregion

		#region Constructor
		public GeneratorWindowButton()
		{
			InitializeComponent();
		}
		#endregion

		#region Events
		public delegate void ActivatedHandler(object sender, EventArgs e);
		public event ActivatedHandler Activated;
		public delegate void ClosingHandler(object sender, FormClosingEventArgs e);
		public event ClosingHandler Closing;
		public delegate void ClosedHandler(object sender, FormClosedEventArgs e);
		public event ClosedHandler Closed;
		#endregion

		#region Properties
		public override String Text { get => lblName.Text; set => lblName.Text = value; }
		public String Group { get; set; }
		public Forms.frmGenerator Form { get; set; }
		public Boolean Active
		{
			get => _active;
			set
			{
				_active = value;
				BorderStyle = _active ? BorderStyle.FixedSingle : BorderStyle.None;
				BackColor = _active ? SystemColors.Control : SystemColors.ControlDark;
				if (_active)
				{				
					if (Parent != null && Group != null)
					{
						foreach (var other in Parent.Controls.OfType<GeneratorWindowButton>().Where(gw => gw.Group.Equals(Group, StringComparison.InvariantCultureIgnoreCase)))
						{
							if (other != this) other.Active = false;
						}
					}
					OnActivated();
				}
			}
		}
		#endregion

		#region Protected Methods
		protected void OnActivated()
		{
			Activated?.Invoke(this, EventArgs.Empty);
		} 

		protected Boolean OnClosing()
		{
			var e = new FormClosingEventArgs(CloseReason.UserClosing, false);
			Closing?.Invoke(this, e);
			return !e.Cancel;
		}

		protected void OnClosed()
		{
			var e = new FormClosedEventArgs(CloseReason.UserClosing);
			Closed?.Invoke(this, e); 
		}
		#endregion

		#region Event Handlers

		private void lblName_Resize(Object sender, EventArgs e)
		{
			Width = btnClose.Width + 18 + lblName.Width;
		}

		private void GeneratorWindowButton_Click(Object sender, EventArgs e)
		{
			Active = true;
		}

		private void lblName_Click(Object sender, EventArgs e)
		{
			GeneratorWindowButton_Click(sender, e);
		}
		#endregion

		private void btnClose_Click(Object sender, EventArgs e)
		{
			if (OnClosing())
			{
				Form.Dispose();
				Dispose();
				OnClosed();
			}
		}
	}
}
