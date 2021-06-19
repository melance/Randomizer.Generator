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
using Randomizer.Generator.MonoGame.ListItems;
using Randomizer.Generator.MonoGame.Utility;

namespace Randomizer.Generator.MonoGame.Dialogs
{
    internal partial class OpenDirectory : DialogControlConsole
    {
        public Boolean Ok { get; private set; }
        public String CurrentDirectory { get; set; }
        
        private void LoadDirectories()
        {            
            lstDirectoryList.Items.Clear();
            if (Path.GetPathRoot(CurrentDirectory) != CurrentDirectory)
                lstDirectoryList.Items.Add(new GeneratorDirectoryListItem(Constants.UP_ONE_DIRECTORY));
            foreach (var directory in Directory.GetDirectories(CurrentDirectory))
            {
                lstDirectoryList.Items.Add(new GeneratorDirectoryListItem(directory));
            }
        }

        private void btnOk_Click(Object sender, EventArgs e)
        {
            var newDirectory = lstDirectoryList.SelectedItem != null ? ((GeneratorDirectoryListItem)lstDirectoryList.SelectedItem)?.Path : Constants.UP_ONE_DIRECTORY;
            if (!newDirectory.Equals(Constants.UP_ONE_DIRECTORY))
                CurrentDirectory = newDirectory;
            Ok = true;
            OnClose();
        }

        private void btnCancel_Click(Object sender, EventArgs e)
        {
            Ok = false;
            OnClose();
        }

        private void lstDirectoryList_SelectedItemExecuted(Object sender, SelectedItemEventArgs e)
        {
            var newDirectory = ((GeneratorDirectoryListItem)lstDirectoryList.SelectedItem).Path;
            if (newDirectory.Equals(Constants.UP_ONE_DIRECTORY))
                CurrentDirectory = Directory.GetParent(CurrentDirectory).FullName;
            else
                CurrentDirectory = newDirectory;

            LoadDirectories();
        }
    }
}
