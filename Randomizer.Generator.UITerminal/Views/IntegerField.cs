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
	class IntegerField : UpDownFieldBase
	{
		#region Members
		private readonly TextValidateField txtValue;
		#endregion

		#region Constructors
		public IntegerField(Int32 minValue = Int32.MinValue, Int32 maxValue = Int32.MaxValue)
		{
			MinValue = minValue;
			MaxValue = maxValue;
			Height = 1;
			
			txtValue = new(new TextIntegerProvider(minValue, maxValue))
			{
				X = 0,
				Y = 0,
				Width = Dim.Fill() - 3,
				Height = 1,
				TextAlignment = TextAlignment.Right,
			};
			Add(txtValue);
		}
		#endregion

		#region Properties
		public Int32 Value { get => txtValue.Text.IsEmpty ? MinValue : Int32.Parse(txtValue.Text.ToString()); set => txtValue.Text = value.ToString(); }
		public Int32 MaxValue { get; set; }
		public Int32 MinValue { get; set; }
		public Int32 Step { get; set; } = 1;
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

		#region Public Methods
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
