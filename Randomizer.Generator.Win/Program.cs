namespace Randomizer.Generator.Win
{
    internal static class Program
    {

		#region Constants
		
		#endregion

		#region Members
		private static DataAccess.FileSystemDataAccess _fileSystemDataAccess;
		#endregion

		#region Properties
		internal static String GeneratorDirectory
		{
			get => Environment.ExpandEnvironmentVariables(Properties.Settings.Default.GeneratorDirectory);
		}

		internal static DataAccess.FileSystemDataAccess DataAccess
		{
			get
			{
				if (_fileSystemDataAccess == null)
				{
					_fileSystemDataAccess = new DataAccess.FileSystemDataAccess(GeneratorDirectory);
					Randomizer.Generator.DataAccess.DataAccess.Instance = _fileSystemDataAccess;
				}
				return _fileSystemDataAccess;
			}
		}
		#endregion

		#region Methods
		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(String[] args)
		{
			// To customize application configuration such as set high DPI settings or default font,
			// see https://aka.ms/applicationconfiguration.
			ApplicationConfiguration.Initialize();
			var generatorPath = String.Empty;
			if (args.Length > 0)
			{
				generatorPath = args[0];
			}
			Application.Run(new frmMain(generatorPath));
		} 

		internal static void ResetDataAccess()
		{
			_fileSystemDataAccess = null;
		}
		#endregion
	}
}