using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hjson;
using Newtonsoft.Json;

namespace Randomizer.Generator.UITerminal.Utility
{
	class UserSettings
	{
		private static UserSettings _instance;

		public static UserSettings Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new UserSettings();
					_instance.Load();
				}
				return _instance;
			}
		}

		private String _workingDirectory;

		public String WorkingDirectory { get; set; }
		//{ 
		//	get => _workingDirectory; 
		//	set => _workingDirectory = value; 
		//}
		public Boolean ShowFileNameInList { get; set; } = true;
		public String SettingPath { get; set; } = Path.Combine(Directory.GetCurrentDirectory(), "settings.hjson");

		public void Save()
		{
			var builder = new StringBuilder();
			using var sWriter = new StringWriter(builder);
			using var writer = new JsonTextWriter(sWriter);
			var serializer = JsonSerializer.Create(SerializerSettings);
			serializer.Serialize(writer, this);
			var hjson = HjsonValue.Parse(builder.ToString());
			File.WriteAllText(SettingPath, hjson.ToString(Stringify.Hjson));
		}

		public void Load()
		{
			if (File.Exists(SettingPath))
			{
				var json = HjsonValue.Parse(File.ReadAllText(SettingPath)).ToString();
				var serializer = JsonSerializer.Create(SerializerSettings);
				using var sReader = new StringReader(json);
				using var reader = new JsonTextReader(sReader);
				var value = serializer.Deserialize<UserSettings>(reader);
				WorkingDirectory = value.WorkingDirectory;
				ShowFileNameInList = value.ShowFileNameInList;
			}
		}

		/// <summary>
		/// The settings used to serialize and deserialize definitions
		/// </summary>
		protected static JsonSerializerSettings SerializerSettings => new()
		{
			Formatting = Formatting.Indented
		};
	}
}
