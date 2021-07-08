using Randomizer.Generator.UI.Terminal.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;
using Terminal.Gui.TextValidateProviders;

namespace Randomizer.Generator.UI.Terminal.Views
{
	class FloatField : UpDownFieldBase
	{
		#region Members
		private readonly TextValidateField txtValue;
		#endregion

		#region Constructors
		public FloatField(Double minValue = Double.MinValue, Double maxValue = Double.MaxValue)
		{
			MinValue = minValue;
			MaxValue = maxValue;
			Height = 1;
			
			txtValue = new(new TextFloatProvider(minValue, maxValue))
			{
				X = 0,
				Y = 0,
				Width = Dim.Fill() - 3,
				Height = 1,
				TextAlignment = TextAlignment.Right
			};
			Add(txtValue);
		}
		#endregion

		#region Properties
		public Double Value { get => Int32.Parse(txtValue.Text.ToString()); set => txtValue.Text = value.ToString(); }
		public Double MaxValue { get; set; }
		public Double MinValue { get; set; }
		public Double Step { get; set; } = 1;
		public new ColorScheme ColorScheme
		{
			get => base.ColorScheme;
			set
			{
				txtValue.ColorScheme = value;
				base.ColorScheme = value;
				SetNeedsDisplay();
			}
		}
		#endregion

		#region Private Methods
		protected override void Up()
		{
			if (Value + Step <= MaxValue)
				Value += Step;
			else
				Value = MaxValue;
		}

		protected override void Down()
		{
			if (Value - Step >= MinValue)
				Value -= Step;
			else
				Value = MinValue;
		}
		#endregion
	}
}
