using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomizer.Generator.Win.Controls
{
	public class TagList : FlowLayoutPanel
	{
		#region Events
		public delegate void TagSelectionChangedHandler(object sender, EventArgs e);
		[Category("Action")]
		public event TagSelectionChangedHandler TagSelectionChanged;
		#endregion

		#region Members
		private Boolean _raiseSelectEvent = true;
		#endregion

		#region Properties
		public IEnumerable<String> SelectedTags
		{
			get
			{
				var tags = Controls.OfType<CheckBox>().Where(c => c.Checked).Select(c => c.Text);
				if (!tags.Any())
					tags = Controls.OfType<CheckBox>().Select(c => c.Text);
				return tags;				
			}
		} 
		#endregion

		#region Public Methods
		public void SelectAll()
		{
			SetSelected(true);
		}

		public void DeselectAll()
		{
			SetSelected(false);
		}

		public void ToggleAll()
		{
			_raiseSelectEvent = false;
			foreach (var tag in Controls.OfType<CheckBox>())
			{
				tag.Checked = !tag.Checked;
			}
			_raiseSelectEvent = true;
			OnTagSelectionChanged();
		}

		public void LoadTags()
		{
			var tagList = Program.DataAccess.GetTagList(d => d.ShowInList);
			Controls.Clear();
			foreach (var tag in tagList)
			{
				var chkBox = new CheckBox()
				{
					Appearance = Appearance.Button,
					AutoSize = true,
					Text = tag,
					Name = tag,
					Checked = false,
					UseMnemonic = false
				};
				chkBox.CheckedChanged += TagSelected;
				Controls.Add(chkBox);
			}
		}
		#endregion

		#region Protected Methods
		protected void OnTagSelectionChanged()
		{
			TagSelectionChanged?.Invoke(this, EventArgs.Empty);
		} 
		#endregion

		#region Private Methods
		private void SetSelected(Boolean selected)
		{
			_raiseSelectEvent = false;
			foreach (var tag in Controls.OfType<CheckBox>())
			{
				tag.Checked = selected;
			}
			_raiseSelectEvent = true;
			OnTagSelectionChanged();
		}
		#endregion

		#region Event Handlers
		private void TagSelected(Object sender, EventArgs e)
		{
			if (_raiseSelectEvent)
				OnTagSelectionChanged();
		}
		#endregion
	}
}
