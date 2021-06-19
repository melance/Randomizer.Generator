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
			Title = "Generator List";

			// Construct controls
			lstGenerators = new()
			{
				LayoutStyle = LayoutStyle.Computed,
				X = 0,
				Y = 0,
				Width = Dim.Fill(),
				Height = Dim.Fill(),
				AllowsMultipleSelection = false
			};			

			// Register events
			lstGenerators.OpenSelectedItem += lstGenerators_OpenSelectedItem;

			// Add controls
			Add(lstGenerators);

			var lstGeneratorsScrollBar = new ScrollBarView(lstGenerators, true)
			{
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

			// Load the generator list
			RefreshGeneratorList();
		}
		#endregion


		#region Controls
		private readonly ListView lstGenerators;
		#endregion
	}
}
