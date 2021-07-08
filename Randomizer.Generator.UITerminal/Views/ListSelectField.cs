using NStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;

namespace Randomizer.Generator.UI.Terminal.Views
{
	class ListSelectField<T> : UpDownFieldBase
	{
		#region Members
		private readonly Label lblValue;
		private IList<T> _source;
		private Int32 _selectedIndex;
		#endregion

		#region Constructor
		public ListSelectField()
		{
			Height = 1;
			lblValue = new()
			{
				X = 0,
				Y = 0,
				Width = Dim.Fill() - 3,
				Height = 1,
				TabStop = true
			};
			Add(lblValue);
			ColorScheme = Colors.Dialog;
			TabStop = true;
		}
		#endregion

		#region Properties
		public IList<T> Source
		{
			get => _source;
			set
			{
				_source = value;
				SetSource();
			}
		}

		public override ustring Text
		{
			get => lblValue.Text;
			set
			{
				if (Source != null)
				{
					if (ustring.IsNullOrEmpty(value)) SelectedIndex = 0;
					for (var i = 0; i < Source.Count; i++)
					{
						var item = Source[i];
						if (item.ToString().Equals(value.ToString()))
						{
							SelectedIndex = i;
						}
					}
				}
			}
		}

		public T SelectedItem
		{
			get => _source[_selectedIndex];
		}

		public Int32 SelectedIndex
		{
			get => _selectedIndex;
			set
			{
				_selectedIndex = value;
				SetText();
			}
		}
		public new ColorScheme ColorScheme
		{
			get => base.ColorScheme;
			set
			{
				lblValue.ColorScheme = value;
				base.ColorScheme = value;
				SetNeedsDisplay();
			}
		}		
		#endregion

		#region Private Methods
		private void SetSource()
		{
			lblValue.Text = String.Empty;
			if (_source == null || !_source.Any()) return;
			lblValue.Text = _source.First().ToString();
		}

		private void SetText()
		{
			if (lblValue != null)
			{
				if (_source == null) lblValue.Text = String.Empty;
				lblValue.Text = _source[SelectedIndex].ToString();
			}
		}
		#endregion

		#region Protected Methods
		protected override void Up()
		{
			if (SelectedIndex > 0)
			{
				SelectedIndex--;
			}
		}

		protected override void Down()
		{
			if (SelectedIndex < _source.Count - 1)
			{
				SelectedIndex++;
			}
		} 
		#endregion
	}
}
