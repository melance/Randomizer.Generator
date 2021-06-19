using Randomizer.Generator.UITerminal.Dialogs;
using Randomizer.Generator.UITerminal.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;

namespace Randomizer.Generator.UITerminal
{
	partial class MainWindow
	{
		#region Constructor
		public MainWindow() : base(TITLE_TEXT)
		{
			// Set dimensions
			Height = Dim.Fill();
			Width = Dim.Fill();

			// Construct controls
			fvGeneratorList = new() { LayoutStyle = LayoutStyle.Computed, X = 0, Y = 0, Width = Dim.Percent(25), Height = Dim.Fill() };
			tabGenerators = new() { LayoutStyle = LayoutStyle.Computed, X = Pos.Percent(25) + 1, Y = 0, Width = Dim.Fill(), Height = Dim.Fill() };

			// Register Events
			fvGeneratorList.GeneratorSelected += fvGeneratorList_GeneratorSelected;

			// Add controls
			Add(fvGeneratorList);
			Add(tabGenerators);

			// Construct the menu
			mnuMain = new(new MenuBarItem[]
			{
				new MenuBarItem("_File", new MenuItem[]
				{
					new MenuItem("_Change Directory", "", fvGeneratorList.ChangeDirectory, null, null),
					new MenuItem("_Refresh Generator List", "", fvGeneratorList.RefreshGeneratorList, null, null)
				}),
				new MenuBarItem("_Help", new MenuItem[]
				{
					new MenuItem("_About", "", () => Application.Run(new About() { Width = Dim.Percent(75), Height = Dim.Percent(75), X = Pos.Center(), Y = Pos.Center() }))
				})
			});
			Program.TopLevelObject.Add(mnuMain);
		}
		#endregion

		#region Controls
		private MenuBar mnuMain;
		private GeneratorListFrameView fvGeneratorList;
		private GeneratorTabView tabGenerators;
		#endregion
	}
}
