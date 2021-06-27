using Randomizer.Generator.UITerminal.Utility;
using System;
using System.IO;
using Terminal.Gui;
using NStack;
using Randomizer.Generator.UITerminal.Models;
using System.Collections.Generic;

namespace Randomizer.Generator.UITerminal
{
    class Program
    {
		private const String DEFAULT_DIRECTORY = @"%AppData%\Randomizer.Generator";
		private const String SETTINGS_DIRECTORY = @"%AppData%\Randomizer.Generator\settings.hjson";

		internal static String DefaultDirectory { get => Environment.ExpandEnvironmentVariables(DEFAULT_DIRECTORY); }
		internal static String SettingsDirectory { get => Environment.ExpandEnvironmentVariables(SETTINGS_DIRECTORY); }

		public static Action<String> CurrentDirectoryChanged;
		public static Action RefreshGeneratorList;

		private static StatusItem stsCurrentDirectory { get; set; }

		public static Toplevel TopLevelObject { get; private set; }
		public static MainWindow MainWindow { get; private set; }

		public static List<Tag> TagList { get; set; } = new();

		public static String CurrentDirectory
		{
			get => Directory.GetCurrentDirectory();
			set
			{
				value ??= Directory.GetCurrentDirectory();
				Directory.SetCurrentDirectory(value);
				stsCurrentDirectory.Title = CurrentDirectory;
				TagList = new();
				CurrentDirectoryChanged?.Invoke(value);
			}
		}

		static void Main(String settingsPath)
        {
			Application.Init();
			Directory.CreateDirectory(DefaultDirectory);
			Directory.SetCurrentDirectory(DefaultDirectory);
			
			TopLevelObject = Application.Top;
			MainWindow = new()
			{
				Title = AssemblyInfo.ProductName
			};

			if (!String.IsNullOrEmpty(settingsPath))
			{
				UserSettings.Instance.SettingPath = settingsPath;
			}
			UserSettings.Instance.Load();

			stsCurrentDirectory = new(Key.Null, ustring.Empty, null);
			CurrentDirectory = UserSettings.Instance.WorkingDirectory;
			
			TopLevelObject.Add(new StatusBar(new[] { stsCurrentDirectory }));
			TopLevelObject.Add(MainWindow);	
			Application.Run();
		}

		public static void ChangeDirectory()
		{
			var dlg = new OpenDialog(String.Empty, "Choose a directory to view all of the generator definitions contained within.")
			{
				DirectoryPath = CurrentDirectory,
				CanChooseDirectories = true,
				CanChooseFiles = false
			};

			Application.Run(dlg);
			if (!dlg.Canceled)
				CurrentDirectory = dlg.FilePath.ToString();
		}
	}
}
