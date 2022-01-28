using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;
using Randomizer.Generator.Core;

namespace Randomizer.Generator.UI.Terminal.Views
{
	class GeneratorTabView : TabView
	{
		public GeneratorTabView() : base()
		{
			Style.ShowBorder = false;
		}

		public void AddGenerator(String name)
		{
			Style.ShowBorder = true;
			var tab = new GeneratorTab(name);
			tab.Close += Tab_Close;
			AddTab(tab, true);
		}

		private void Tab_Close(Object sender, System.EventArgs e)
		{
			RemoveTab((Tab)sender);
			if (Tabs.Count == 0) Style.ShowBorder = false;
		}
	}
}
