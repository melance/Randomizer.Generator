using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;

namespace Randomizer.Generator.UITerminal.Views
{
	partial class GeneratorListFrameView
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
	}
}
