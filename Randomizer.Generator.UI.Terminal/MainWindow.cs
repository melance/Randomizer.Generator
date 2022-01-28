using Randomizer.Generator.UI.Terminal.Dialogs;
using Randomizer.Generator.UI.Terminal.Utility;
using Randomizer.Generator.UI.Terminal.Views;
using System;
using Terminal.Gui;

namespace Randomizer.Generator.UI.Terminal
{
	partial class MainWindow : Window
	{
		#region Constants
		private const String TITLE_TEXT = "";
		#endregion

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
			fvGeneratorList.GeneratorSelected += GeneratorList_GeneratorSelected;

			// Add controls
			Add(fvGeneratorList);
			Add(tabGenerators);

			// Construct the menu
			mnuMain = new(new MenuBarItem[]
			{
				new MenuBarItem("_File", new MenuItem[]
				{
					new MenuItem("_Change Directory", "", Program.ChangeDirectory, null, null),
					new MenuItem("_Refresh Generator List", "", Program.RefreshGeneratorList, null, null)
				}),
				new MenuBarItem("_Tools", new MenuItem[]
				{
					new MenuItem("Con_vert Old Grammar File", "", () => Application.Run(new ConvertGrammar() {Width = Dim.Percent(75), Height = Dim.Percent(75), X = Pos.Center(), Y = Pos.Center() })),
					new MenuItem("_Settings", "", () => Application.Run(new Settings() { Width = Dim.Percent(75), Height = Dim.Percent(75), X = Pos.Center(), Y = Pos.Center() }))
				}),
				new MenuBarItem("_Help", new MenuItem[]
				{
					new MenuItem("Open Online _Help", "", () => HelperMethods.OpenURL(Properties.Resources.HelpURL)) { Shortcut = Key.F1 },
					new MenuItem("Goto Project _GitHub", "", () => HelperMethods.OpenURL(Properties.Resources.GITURL)),
					new MenuItem("_About", "", () => Application.Run(new About() { Width = Dim.Percent(75), Height = Dim.Percent(75), X = Pos.Center(), Y = Pos.Center() }))
				})
			});
			Program.TopLevelObject.Add(mnuMain);
		}
		#endregion

		#region Controls
		private readonly MenuBar mnuMain;
		private readonly GeneratorListFrameView fvGeneratorList;
		private readonly GeneratorTabView tabGenerators;
		#endregion

		#region Event Handlers
		private void GeneratorList_GeneratorSelected(Object sender, EventArgs.GeneratorSelectedEventArgs e)
		{
			tabGenerators.AddGenerator(e.Name);
		}
		#endregion
	}
}
