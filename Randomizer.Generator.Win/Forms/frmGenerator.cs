using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Randomizer.Generator.Assignment;
using Randomizer.Generator.Core;
using Randomizer.Generator.Win.Helpers;

namespace Randomizer.Generator.Win.Forms
{
	public partial class frmGenerator : Form
	{
		#region Constructor
		public frmGenerator()
		{
			InitializeComponent();

			webBrowser.DocumentText = String.Empty;
		}

		#endregion

		#region Constants
		private const String REPEAT_CONTROL_NAME = "nudRepeat";
		#endregion

		#region Members
		private BaseDefinition _generator;
		private Classes.ParameterControlList _parameters;
		#endregion

		#region Properties
		public BaseDefinition Generator
		{
			get => _generator;
			set
			{
				_generator = value;
				BindGenerator();
			}
		}
		#endregion

		#region Private Methods
		private void BindGenerator()
		{
			pnlParameters.Controls.Clear();
			_parameters = new();
			if (_generator != null)
			{
				lblName.Text = _generator.Name;

				// Add repeat label and control
				var lblRepeat = new Label()
				{
					Text = "Repeat",
					Dock = DockStyle.Top,
					TextAlign = ContentAlignment.MiddleLeft
				};
				var nudRepeat = new NumericUpDown()
				{
					Minimum = 1,
					Maximum = 100,
					Value = Properties.Settings.Default.DefaultRepeat,
					Dock = DockStyle.Top,
					Name = REPEAT_CONTROL_NAME,
					TextAlign = HorizontalAlignment.Right
				};
				pnlParameters.Controls.Add(nudRepeat);
				pnlParameters.Controls.Add(lblRepeat);

				// Add parameter controls
				foreach (var parameter in _generator.Parameters.Where(p => p.Value.Visible).Reverse())
				{
					Control control;
					Label label = null;
					if (parameter.Value.Type != ParameterTypes.Boolean)
					{
						label = new Label()
						{
							Text = parameter.Value.Display,
							AutoSize = false,
							Dock = DockStyle.Top,
							TextAlign = ContentAlignment.MiddleLeft
						};
					}
					control = _parameters.Add(parameter.Key, parameter.Value);
					control.Dock = DockStyle.Top;
					pnlParameters.Controls.Add(control);
					if (label != null)
						pnlParameters.Controls.Add(label);
				}
			}
			else
			{
				MessageBox.Show("Unable to load the generator");
			}
		}

		private Boolean ValidateParameters()
		{
			var isValid = true;
			foreach (var parameter in _parameters)
			{
				_generator.Parameters[parameter.Name].Value = _parameters.GetValue(parameter.Name);
				var result = _generator.ValidateParameter(parameter.Name);
				if (!result.Valid)
				{
					errorProvider.SetError(parameter, result.Message);
					isValid = false;
				}
				else
				{
					errorProvider.SetError(parameter, String.Empty);
				}
			}
			return isValid;
		}
		#endregion

		private void btnGenerate_Click(Object sender, EventArgs e)
		{
			Cursor = Cursors.WaitCursor;
			try
			{
				if (ValidateParameters())
				{
					var result = String.Empty;
					var repeat = ((NumericUpDown)pnlParameters.Controls[REPEAT_CONTROL_NAME]).Value;
					for (var i = 1; i <= repeat; i++)
					{
						var current = Generate().Result;
						switch (Generator.OutputFormat)
						{
							case OutputFormats.Text:
								result += $"{current}\n\n";
								break;
							case OutputFormats.Html:
								result += $"{current}{(i < repeat ? "<hr />" : String.Empty)}";
								break;
							case OutputFormats.Markdown:
								result += $"{current}{(i < repeat ? "\n\n----\n\n" : String.Empty)}";
								break;
							case OutputFormats.Image:
								result += $"<img src=\"data: image/png;base64, {current}\" />{(i < repeat ? "<hr />" : String.Empty)}";
								break;
						}
					}
					switch (Generator.OutputFormat)
					{
						case OutputFormats.Text:
							webBrowser.DocumentText = $"<pre>{result}</pre>";
							break;
						case OutputFormats.Markdown:
							webBrowser.DocumentText = result.ToHTML();
							break;
						case OutputFormats.Html:
						case OutputFormats.Image:
							webBrowser.DocumentText = result;
							break;
					}
				}
			}
			catch (Exception ex)
			{
				webBrowser.DocumentText = ex.ToHTML();
			}
			finally
			{
				Cursor = Cursors.Default;
			}
		}

		private async Task<string> Generate()
		{
			return await Generator.GenerateAsync();
		}

		private void btnEdit_Click(Object sender, EventArgs e)
		{
			var definitionPath = Program.DataAccess.GetDefinitionPath(_generator.Name);
			Process.Start(Properties.Settings.Default.TextEditor, Properties.Settings.Default.TextEditorArgs.Replace("{filename}", definitionPath));
		}

		private void btnClear_Click(Object sender, EventArgs e)
		{
			webBrowser.DocumentText = String.Empty;
		}

		private void btnSelectAll_Click(Object sender, EventArgs e)
		{
			webBrowser.Document.ExecCommand("SelectAll", true, null);
		}

		private void btnCopy_Click(Object sender, EventArgs e)
		{
			webBrowser.Document.ExecCommand("Copy", true, null);

		}

		private void btnSave_Click(Object sender, EventArgs e)
		{
			webBrowser.ShowSaveAsDialog();
		}

		private void btnReload_Click(Object sender, EventArgs e)
		{
			var response = Program.DataAccess.GetDefinition(_generator.Name);
			if (response.Definition != null)
			{
				_generator = response.Definition;
				BindGenerator();
			}
			else
			{
				var dialog = new frmExceptions(response);
				dialog.ShowDialog();
				Close();
			}
		}

		private void btnOpenDialog_Click(Object sender, EventArgs e)
		{
			var path = ((DataAccess.FileSystemDataAccess)DataAccess.DataAccess.Instance).GetDefinitionPath(Generator.Name);
			var info = new ProcessStartInfo(Application.ExecutablePath, $"\"{path}\"");
			Process.Start(info);
		}

		private void btnInfo_Click(Object sender, EventArgs e)
		{
			var details = new Details(Generator.Name);
			details.ShowDialog(this);
		}
	}
}
