using System;
using Terminal.Gui;

namespace Randomizer.Generator.UITerminal
{
    class Program
    {
		public static Action<String> CurrentDirectoryChanged;
		public static Action RefreshGeneratorList;

		private static StatusItem stsCurrentDirectory { get; set; }

		public static Toplevel TopLevelObject { get; private set; }
		public static MainWindow MainWindow { get; private set; }
		public static String CurrentDirectory
		{
			get => System.IO.Directory.GetCurrentDirectory();
			set
			{
				System.IO.Directory.SetCurrentDirectory(value);
				stsCurrentDirectory.Title = CurrentDirectory;
				CurrentDirectoryChanged?.Invoke(value);
			}
		}

		static void Main()
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

		public static void ChangeDirectory()
		{
			var dlg = new OpenDialog(String.Empty, "Choose a directory to view all of the generator definitions contained within.")
			{
				DirectoryPath = Program.CurrentDirectory,
				CanChooseDirectories = true,
				CanChooseFiles = false
			};

			Application.Run(dlg);
			if (!dlg.Canceled)
				Program.CurrentDirectory = dlg.FilePath.ToString();
		}
	}
}
