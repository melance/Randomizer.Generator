using SadConsole.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SadConsole.UI.Controls;
using SadRogue.Primitives;
using Randomizer.Generator.MonoGame.Utility;
using SadConsole;
using TextCopy;
using Randomizer.Generator.Core;
using System.IO;
using SadConsole.UI.Themes;

namespace Randomizer.Generator.MonoGame.Dialogs
{
    internal partial class GeneratorConsole : DialogControlConsole
    {
        #region Members
        private List<String> _results;
        private readonly BaseDefinition _generator;
        private readonly List<ControlBase> _parameterControls = new();
		private FileDialogConsole _fileSaveDialog;
        #endregion

        private const Int32 MAX_REPEAT = 99;

        #region Properties
        private List<String> Results
        {
            get => _results;
            set
            {
                _results = value;
                btnSave.IsEnabled = _results != null;
                btnClear.IsEnabled = _results != null;
                btnCopy.IsEnabled = _results != null;
            }
        }
        #endregion

        #region Methods
        private void SetParameters()
        {
            foreach (var control in _parameterControls)
            {
                var value = String.Empty;
                if (control.GetType() == typeof(TextBox))
                {
                    value = ((TextBox)control).Text;
                }
                else if (control.GetType() == typeof(ListBox))
                {
                    var index = ((ListBox)control).SelectedIndex;
                    var selectedItem = ((ListBox)control).Items[index];

                    value = ((ListOption)(selectedItem)).Value;
                }
                else if (control.GetType() == typeof(CheckBox))
                {
                    value = ((CheckBox)control).IsSelected.ToString();
                }
                _generator.Parameters[control.Name].Value = value;
            }
        }
        #endregion

        #region Event Handlers
        private void btnClose_Click(Object sender, EventArgs e)
        {
            OnClose();
        }

        private void btnGenerate_Click(Object sender, EventArgs e)
        {
            try
            {
                var y = 0;
                _ = Int32.TryParse(txtRepeat.Text,out var repeat);

                if (repeat < 1)
                {
                    txtRepeat.Text = 1.ToString();
                    repeat = 1;
                }
                else if (repeat > MAX_REPEAT)
                {
                    txtRepeat.Text = MAX_REPEAT.ToString();
                    repeat = MAX_REPEAT;
                }

                SetParameters();
                Results = new List<String>();

                for (var i = 1; i <= repeat; i++)
                {
                    Results.AddRange(_generator.Generate().WordWrap(ResultClientArea.Width - 4).ToList());
                    Results.Add(String.Empty);
                }

                lstResults.Items.Clear();
                txtResults.Surface.Clear();

                txtResults.SetSurface(new CellSurface(ResultArea.Width - 4, ResultArea.Height - 4, ResultArea.Width - 4, Math.Max(ResultArea.Height - 4, Results.Count)));

                foreach (var line in Results)
                {
                    lstResults.Items.Add(line);
                    if (String.IsNullOrEmpty(line))
                        y++;
                    else
                        txtResults.ChildSurface.Print(1, y, line);
                    y++;
                }
            }
            catch (Exception ex)
            {
                MessageBoxConsole.MessageBox("Error", ex.Message, Width / 2, this, Styles.MessageBoxStyles.Error);
            }
        }

        private void btnClear_Click(Object sender, EventArgs e)
        {
            lstResults.Items.Clear();
            Results = null;
        }

        private void btnCopy_Click(Object sender, EventArgs e)
        {
            var cb = new Clipboard();
            var value = String.Join("\n", lstResults.Items);
            cb.SetText(value);
        }

        private void btnSave_Click(Object sender, EventArgs e)
        {
			if (_fileSaveDialog == null)
			{
				var screenWidth = Program.MainConsole.Width;
				_fileSaveDialog = new FileDialogConsole(Directory.GetCurrentDirectory(), screenWidth / 4, 6, screenWidth / 2, Height - 12);
				Program.MainConsole.Children.Add(_fileSaveDialog);
				_fileSaveDialog.Close += SaveFileDialog_Close;
			}
			var extension = _generator.OutputFormat == OutputFormats.Text ? "txt" : "html";
			_fileSaveDialog.FileName = $"{_generator.Name}.{extension}";
			_fileSaveDialog.IsVisible = true;
        }

		private void SaveFileDialog_Close(Object sender, EventArgs e)
		{
			if (_fileSaveDialog.DialogResult)
			{
				var value = String.Join("\n", lstResults.Items);
				File.WriteAllText(_fileSaveDialog.FilePath, value);
			}
			_fileSaveDialog.IsVisible = false;
		}
        #endregion
    }
}
