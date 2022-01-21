using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Randomizer.Generator.Core;

namespace Randomizer.Generator.UI.Win.Classes
{
	internal class ParameterControlList : List<Control>
	{
		public Control Add(String name, Parameter parameter)
		{
			var control = CreateControl(name, parameter);
			Add(control);
			return control;
		}

		public String GetValue(String name)
		{
			var control = this.Where(p => p.Name == name).FirstOrDefault();
			if (control != null)
			{
				if (control is CheckBox box)
					return box.Checked.ToString();
				else if (control is DateTimePicker picker)
					return picker.Value.ToString();
				else if (control is ComboBox comboBox)
					return comboBox.Text;
				else if (control is NumericUpDown numericUpDown)
					return numericUpDown.Value.ToString();
				else if (control is TextBox textBox)
					return textBox.Text;
			}
			return null;
		}

		private static Control CreateControl(String name, Parameter parameter)
		{
			Control control;
			switch (parameter.Type)
			{
				case ParameterTypes.Text:
					control = new TextBox()
					{
						Text = parameter.Value
					};
					break;
				case ParameterTypes.Integer:
					control = new NumericUpDown()
					{
						DecimalPlaces = 0,
						Minimum = Int32.MinValue,
						Maximum = Int32.MaxValue,
						Value = Int32.Parse(parameter.Value),
						TextAlign = HorizontalAlignment.Right
					};
					break;
				case ParameterTypes.Decimal:
					control = new NumericUpDown()
					{
						DecimalPlaces = 2,
						Minimum = Int32.MinValue,
						Maximum = Int32.MaxValue,
						Value = Int32.Parse(parameter.Value),
						TextAlign = HorizontalAlignment.Right
					};
					break;
				case ParameterTypes.List:
					control = new ComboBox()
					{
						DataSource = parameter.Options,
						SelectedValue = parameter.Value,
						ValueMember = "Value",
						DisplayMember = "Display",
						DropDownStyle = ComboBoxStyle.DropDownList
					};
					break;
				case ParameterTypes.Date:
					control = new DateTimePicker()
					{
						Value = DateTime.Parse(parameter.Value)
					};
					break;
				case ParameterTypes.Boolean:
					control = new CheckBox()
					{
						Checked = Boolean.Parse(parameter.Value),
						Text = parameter.Display
					};
					break;
				default:
					return null;
			}
			control.Name = name;
			return control;
		}
	}
}
