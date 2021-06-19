using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;
using Randomizer.Generator.UITerminal.Extensions;
using Randomizer.Generator.UITerminal.Models;

namespace Randomizer.Generator.UITerminal.Views
{
	partial class GeneratorListFrameView : FrameView
	{
		#region Events
		public event EventHandler<EventArgs.GeneratorSelectedEventArgs> GeneratorSelected;
		#endregion

		#region Properties
		public String CurrentDirectory
		{
			get => Directory.GetCurrentDirectory();
			set
			{
				Directory.SetCurrentDirectory(value);
				Program.stsCurrentDirectory.Title = CurrentDirectory;
				RefreshGeneratorList();
			}
		}
		#endregion

		#region Public Methods
		public void ChangeDirectory()
		{
			var dlg = new OpenDialog(String.Empty, "Choose a directory to view all of the generator definitions contained within.")
			{
				DirectoryPath = CurrentDirectory,
				CanChooseDirectories = true,
				CanChooseFiles = false
			};
			
			Application.Run(dlg);
			if (!dlg.Canceled)
				CurrentDirectory = dlg.FilePath.ToString();
		}

		public void RefreshGeneratorList()
		{
			var source = new List<GeneratorListViewItem>();

			foreach (var filePath in Directory.GetFiles(CurrentDirectory, "*.rgen.*"))
			{
				source.Add(new(filePath));
			}

			lstGenerators.SetSource(source);
		}
		#endregion

		#region Protected Methods
		protected void OnGeneratorSelected(String filePath)
		{
			GeneratorSelected?.Invoke(this, new EventArgs.GeneratorSelectedEventArgs(filePath));
		}
		#endregion

		#region Event Handlers
		private void lstGenerators_OpenSelectedItem(ListViewItemEventArgs e)			
		{
			OnGeneratorSelected(((GeneratorListViewItem)e.Value).Path);
		}
		#endregion
	}
}
