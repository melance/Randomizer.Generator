using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;
using Randomizer.Generator.UI.Terminal.Extensions;
using Randomizer.Generator.UI.Terminal.Models;
using Randomizer.Generator.Core;

namespace Randomizer.Generator.UI.Terminal.Views
{
	partial class GeneratorListFrameView : FrameView
	{
		#region Constructor
		public GeneratorListFrameView()
		{
			const String REFRESH_TEXT = "Refresh";
			const String TAGS_TEXT = "Tags";

			Title = "Generator List";

			// Construct controls
			lstGenerators = new()
			{
				LayoutStyle = LayoutStyle.Computed,
				X = 0,
				Y = 0,
				Width = Dim.Fill(),
				Height = Dim.Fill(1),
				AllowsMultipleSelection = false
			};
			btnRefresh = new(REFRESH_TEXT)
			{
				X = Pos.Right(this) - (REFRESH_TEXT.Length + 6),
				Y = Pos.Bottom(lstGenerators)
			};
			btnTags = new(TAGS_TEXT)
			{
				X = Pos.Left(btnRefresh) - (TAGS_TEXT.Length + 5),
				Y = Pos.Top(btnRefresh)
			};
			btnTags.Clicked += TagSelection_Clicked;

			// Register events
			lstGenerators.OpenSelectedItem += lstGenerators_OpenSelectedItem;
			btnRefresh.Clicked += RefreshGeneratorList;

			// Add controls
			Add(lstGenerators);
			Add(btnRefresh);
			Add(btnTags);

			var lstGeneratorsScrollBar = new ScrollBarView(lstGenerators, true)
			{
				IsVertical = true,
				AutoHideScrollBars = true
			};

			lstGenerators.DrawContent += (e) => {
				lstGeneratorsScrollBar.Size = lstGenerators.Source.Count;
				lstGeneratorsScrollBar.Position = lstGenerators.TopItem;
				lstGeneratorsScrollBar.OtherScrollBarView.Size = lstGenerators.Maxlength - 1;
				lstGeneratorsScrollBar.OtherScrollBarView.Position = lstGenerators.LeftItem;
				lstGeneratorsScrollBar.OtherScrollBarView.Visible = false;
				lstGeneratorsScrollBar.Refresh();
			};

			lstGeneratorsScrollBar.ChangedPosition += () => {
				lstGenerators.TopItem = lstGeneratorsScrollBar.Position;
				if (lstGenerators.TopItem != lstGeneratorsScrollBar.Position)
				{
					lstGeneratorsScrollBar.Position = lstGenerators.TopItem;
				}
				lstGenerators.SetNeedsDisplay();
			};

			Program.CurrentDirectoryChanged += CurrentDirectoryChanged;
			Program.RefreshGeneratorList += RefreshGeneratorList;

			// Load the generator list
			RefreshGeneratorList();
		}
		#endregion

		#region Controls
		private readonly ListView lstGenerators;
		private readonly Button btnRefresh;
		private readonly Button btnTags;
		#endregion

		#region Events
		public event EventHandler<EventArgs.GeneratorSelectedEventArgs> GeneratorSelected;
		#endregion

		#region Properties
		
		#endregion

		#region Public Methods
		public void RefreshGeneratorList()
		{
			var source = new List<GeneratorListViewItem>();
			var allTags = DataAccess.DataAccess.Instance.GetTagList();

			foreach (var tag in allTags)
			{
				if (!Program.TagList.Contains(tag)) Program.TagList.Add(new Tag(tag) { Selected = true });
			}

			var selectedTags = Program.TagList.Where(t => t.Selected).Select(t => t.Text).ToList();

			foreach (var definition in DataAccess.DataAccess.Instance.GetDefinitionList().Where(d => d.ShowInList && d.OutputFormat != OutputFormats.Image))
			{
				if (definition.Tags.Any(t => selectedTags.Contains(t)))
				{
					source.Add(new(definition));
				}
			}		

			lstGenerators.SetSource(source);
		}
		#endregion

		#region Protected Methods
		protected void OnGeneratorSelected(String name)
		{
			GeneratorSelected?.Invoke(this, new EventArgs.GeneratorSelectedEventArgs(name));
		}
		#endregion

		#region Event Handlers
		private void CurrentDirectoryChanged(String directoryPath)
		{
			RefreshGeneratorList();
		}

		private void lstGenerators_OpenSelectedItem(ListViewItemEventArgs e)			
		{
			OnGeneratorSelected(((GeneratorListViewItem)e.Value).Name);
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
