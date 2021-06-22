using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;
using Randomizer.Generator.Core;
using static Terminal.Gui.TabView;
using TextCopy;
using NStack;

namespace Randomizer.Generator.UITerminal.Views
{
	partial class GeneratorTab : Tab
	{
		#region Events
		public event EventHandler Close;
		#endregion

		#region Members
		private readonly String _filePath;
		private BaseDefinition _generator;
		private readonly Dictionary<String, View> _parameterControls = new();
		private String _saveFilePath;
		#endregion

		#region Private Methods
		private void LoadTheGenerator()
		{
			var hjson = File.ReadAllText(_filePath);			
			_generator = BaseDefinition.Deserialize(hjson);
			Text = _generator.Name;
		}

		private void GetParameterValues()
		{
			foreach (var parameter in _generator.Parameters)
			{
				parameter.Value.Value = parameter.Value.Type switch
				{
					ParameterTypes.Boolean => ((CheckBox)_parameterControls[parameter.Key]).Checked.ToString(),
					_ => _parameterControls[parameter.Key].Text.ToString(),
				};
			}
		}

		private void CreateParameterControls()
		{			
			var controlY = intRepeat.Bounds.Bottom + 2;

			foreach(var parameter in _generator.Parameters)
			{
				View control = null;
				Label label = new(parameter.Value.Display)
				{
					Y = controlY,
					X = 1
				};
				controlY++; 
				switch (parameter.Value.Type)
				{
					case ParameterTypes.Boolean:
						var chkBox = new CheckBox();
						if (Boolean.TryParse(parameter.Value.Value, out Boolean isChecked))
						{
							chkBox.Checked = isChecked;
						}
						control = chkBox;
						break;
					case ParameterTypes.Date:
						var dtmBox = new DateField();
						if (DateTime.TryParse(parameter.Value.Value, out DateTime dateValue))
						{
							dtmBox.Date = dateValue;
						}
						control = dtmBox;
						break;
					case ParameterTypes.Decimal:
						var txtDecimal = new FloatField()
						{
							Text = parameter.Value.Value
						};
						control = txtDecimal;
						break;
					case ParameterTypes.Integer:
						var txtInteger = new IntegerField()
						{
							Text = parameter.Value.Value
						};
						control = txtInteger;
						break;
					case ParameterTypes.List:
						var cboBox = new ListSelectField<ListOption>
						{
							Source = parameter.Value.Options
						};
						cboBox.Text = parameter.Value.Value;
						control = cboBox;
						break;
					case ParameterTypes.Text:
						var txtBox = new TextField(parameter.Value.Value);
						control = txtBox;
						break;
				}

				if (control != null)
				{
					control.Y = controlY;
					control.X = 1;
					control.Width = Dim.Fill(2);
					_parameterControls.Add(parameter.Key, control);
					frvParameters.Add(label);
					frvParameters.Add(control);
					controlY += 2;
				}
			}
		}

		private void Generate()
		{
			var results = new StringBuilder();
			GetParameterValues();

			for (Int32 i = 1; i <= intRepeat.Value; i++)
				results.AppendLine(_generator.Generate());

			txtResults.Text = results.ToString();
		}
		#endregion

		#region Protected Methods
		protected void OnClose()
		{
			Close?.Invoke(this, System.EventArgs.Empty);
		}
		#endregion

		#region Event Handlers
		private void btnClose_Clicked()
		{
			OnClose();	
		}

		private void btnViewDetails_Clicked()
		{
			var dialog = new Dialogs.GeneratorDetailsDialog(_generator)
			{
				Width = Dim.Percent(66),
				Height = Dim.Percent(66)
			};
			Application.Run(dialog);
		}

		private void btnGenerate_Clicked()
		{
			Generate();
		}

		private void btnCopyAll_Clicked()
		{
			var clip = new TextCopy.Clipboard();
			clip.SetText(txtResults.Text.ToString());
		}

		private void btnCopy_Clicked()
		{
			var clip = new TextCopy.Clipboard();
			clip.SetText(txtResults.SelectedText.ToString());
		}

		private void btnSave_Clicked()
		{
			var exit = false;	

			do
			{
				if (String.IsNullOrEmpty(_saveFilePath)) _saveFilePath = Path.Combine(Program.stsCurrentDirectory.Title.ToString(), $"{_generator.Name}.txt");
				var dialog = new SaveDialog("Save Results", String.Empty)
				{
					CanCreateDirectories = true,
					FilePath = _saveFilePath,
					Width = Dim.Percent(66),
					Height = Dim.Percent(75)					
				};
				Application.Run(dialog);

				if (!dialog.Canceled)
				{
					if (!File.Exists(dialog.FileName.ToString()))
					{
						File.WriteAllText(dialog.FileName.ToString(), txtResults.Text.ToString());
						exit = true;
					}
					else
					{
						var answer = MessageBox.Query("Overwrite", $"The file {dialog.FileName} already exists, do you want to overwrite it?", 1, new ustring[] { "Yes", "No", "Append" });
						switch (answer)
						{
							case 0:
								File.WriteAllText(dialog.FileName.ToString(), txtResults.Text.ToString());
								exit = true;
								break;
							case 2:
								File.AppendAllText(dialog.FileName.ToString(), txtResults.Text.ToString());
								exit = true;
								break;
						}
					}
				}
				else exit = true;
			} while (!exit);
		}

		private void txtResults_TextChanged()
		{
			btnCopy.Visible = !txtResults.Text.IsEmpty;
			btnCopyAll.Visible = !txtResults.Text.IsEmpty;
			btnSave.Visible = !txtResults.Text.IsEmpty;
		}
		#endregion
	}
}
