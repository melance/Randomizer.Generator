using SadConsole;
using SadConsole.UI;
using SadConsole.UI.Controls;
using SadRogue.Primitives;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SadConsole.UI.Controls.ListBox;
using Randomizer.Generator.Core;
using Randomizer.Generator.MonoGame.Dialogs;
using Randomizer.Generator.MonoGame.ListItems;
using Randomizer.Generator.MonoGame.Utility;

namespace Randomizer.Generator.MonoGame
{
    internal partial class MainConsole : ControlsConsole
    {
        private String CurrentDirectory 
        {
            get 
            {
                return _currentDirectory;
            }
            set
            {
                _currentDirectory = value;
                lblCurrentDirectory.DisplayText = CurrentDirectoryDisplay;
            } 
        } 
        private String CurrentDirectoryDisplay { get => CurrentDirectory.ShortenPath(lblCurrentDirectory.Width); }

        private String _currentDirectory;
        private OpenDirectory _openDirectory;
        private BaseDefinition _loadedGenerator;
        private GeneratorConsole _generatorConsole;

        public void LoadGenerators()
        {
            var fileNames = Directory.GetFiles(CurrentDirectory, "*.rgen.*");
            lstGeneratorList.Items.Clear();
            if (fileNames.Any())
            {
                foreach (var fileName in fileNames)
                {
                    lstGeneratorList.Items.Add(new GeneratorListItem(fileName));
                }
                lstGeneratorList.UseMouse = true;
            }
            else
            {                
                lstGeneratorList.Items.Add("No Generators Found");
                lstGeneratorList.UseMouse = false;
            }
        }

        private void OpenGenerator(String path)
        {
            try
            {                
                if (_generatorConsole != null)
                    Children.Remove(_generatorConsole);

                var hjson = File.ReadAllText(path);
                var type = BaseDefinition.GetGeneratorType(hjson);
                switch (type)
                {
                    case GeneratorTypes.List: _loadedGenerator = BaseDefinition.Deserialize<List.ListDefinition>(hjson); break;
                    case GeneratorTypes.Assignment: _loadedGenerator = BaseDefinition.Deserialize<Assignment.AssignmentDefinition>(hjson); break;
                    case GeneratorTypes.Phonotactics: _loadedGenerator = BaseDefinition.Deserialize<Phonotactics.PhonotacticsDefinition>(hjson); break;
                }

                _generatorConsole = new GeneratorConsole(_loadedGenerator, MIDDLE_X + 1, 1, Width - MIDDLE_X - 2, Height - 3);
                _generatorConsole.Close += GeneratorConsole_Close;
                Children.Add(_generatorConsole);
            }
            catch (Exception ex)
            {
                MessageBoxConsole.MessageBox("Error", ex.Message, Width / 2, this, Styles.MessageBoxStyles.Error);
            }
        }
                
        private void lstGeneratorList_SelectedItemExecuted(Object sender, SelectedItemEventArgs e)
        {
            OpenGenerator(((GeneratorListItem)lstGeneratorList.SelectedItem).FilePath);
        }

        private void btnRefreshGeneratorList_Click(Object sender, EventArgs e)
        {
            LoadGenerators();
        }

        private void btnOpenDirectory_Click(Object sender, EventArgs e)
        {
            var width = Width / 2;
            var height = Height - 4;
            var x = (Width - width) / 2;
            _openDirectory = new OpenDirectory(CurrentDirectory, x, 1, width, height);
            _openDirectory.Close += OpenDirectory_Close;
            Children.Add(_openDirectory);
        }

        private void OpenDirectory_Close(Object sender, EventArgs e)
        {
            if (_openDirectory.Ok)
            {
                CurrentDirectory = _openDirectory.CurrentDirectory;
                lblCurrentDirectory.DisplayText = CurrentDirectory;
                LoadGenerators();
            }
            Children.Remove(_openDirectory);
            _openDirectory.Dispose();
        }

        private void GeneratorConsole_Close(Object sender, EventArgs e)
        {
            Children.Remove(_generatorConsole);
            _generatorConsole.Dispose();
        }
    }
}
