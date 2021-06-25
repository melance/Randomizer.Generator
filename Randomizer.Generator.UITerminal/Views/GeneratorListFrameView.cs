using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;
using Randomizer.Generator.UITerminal.Extensions;
using Randomizer.Generator.UITerminal.Models;
using Randomizer.Generator.Core;

namespace Randomizer.Generator.UITerminal.Views
{
	partial class GeneratorListFrameView : FrameView
	{
		#region Events
		public event EventHandler<EventArgs.GeneratorSelectedEventArgs> GeneratorSelected;
		#endregion

		#region Properties
		
		#endregion

		#region Public Methods
		public void RefreshGeneratorList()
		{
			var source = new List<GeneratorListViewItem>();
			var selectedTags = Program.TagList.Where(t => t.Selected).ToList();

			foreach (var filePath in Directory.GetFiles(Program.CurrentDirectory, "*.rgen.?json"))
			{
				var definition = BaseDefinition.Deserialize(File.ReadAllText(filePath));
				var tags = definition.Tags == null ? new List<String>() : definition.Tags.Where(t => !Program.TagList.Any(t2 => t2.Text.Equals(t, StringComparison.CurrentCultureIgnoreCase)));
				var include = true;

				foreach (var tag in tags)
				{
					Program.TagList.Add(tag);
				}

				if (definition.Tags?.Any() == true)
				{
					include = false;
					foreach (var tag in definition.Tags)
					{
						if (selectedTags.Any(st => st.Text.Equals(tag, StringComparison.CurrentCultureIgnoreCase)))
							include = true;
					}
				}

				if (include)
				{
					if (Utility.UserSettings.Instance.ShowFileNameInList)
						source.Add(new(filePath));
					else
						source.Add(new(filePath, definition.Name));
				}
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
		private void CurrentDirectoryChanged(String directoryPath)
		{
			RefreshGeneratorList();
		}

		private void lstGenerators_OpenSelectedItem(ListViewItemEventArgs e)			
		{
			OnGeneratorSelected(((GeneratorListViewItem)e.Value).Path);
		}

		private void TagSelection_Clicked()
		{
			var tagSelection = new Dialogs.TagSelection()
			{
				X = Pos.Center(),
				Y = Pos.Center(),
				Width = Dim.Percent(50),
				Height = Dim.Height(Program.MainWindow) - 6
			};
			Application.Run(tagSelection);
		}
		#endregion
	}
}
