using System;
using Terminal.Gui;

namespace Randomizer.Generator.UITerminal
{
    class Program
    {
		public static Toplevel TopLevelObject { get; private set; }
		public static MainWindow MainWindow { get; private set; }
		public static StatusItem stsCurrentDirectory { get; private set; }

        static void Main(string[] args)
        {
			Application.Init();
			TopLevelObject = Application.Top;
			MainWindow = new()
			{
				Title = AssemblyInfo.ProductName
			};
			stsCurrentDirectory = new(Key.Null, System.IO.Directory.GetCurrentDirectory(), null);
			TopLevelObject.Add(new StatusBar(new[] { stsCurrentDirectory }));
			TopLevelObject.Add(MainWindow);	
			Application.Run();
		}		
    }
}
