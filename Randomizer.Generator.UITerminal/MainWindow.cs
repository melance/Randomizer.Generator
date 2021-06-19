using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;
using Randomizer.Generator.UITerminal.Views;

namespace Randomizer.Generator.UITerminal
{
	partial class MainWindow : Window
	{
		#region Constants
		private const String TITLE_TEXT = "";
		#endregion

		#region Properties
		
		#endregion

		#region Event Handlers
		private void fvGeneratorList_GeneratorSelected(Object sender, EventArgs.GeneratorSelectedEventArgs e)
		{
			tabGenerators.AddGenerator(e.FilePath);
		}
		#endregion
	}
}
