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

		public String WorkingDirectory { get; set; }
		public Boolean ShowFileNameInList { get; set; } = true;
		public Boolean RememberLastDirectory { get; set; } = false;

		[JsonIgnore]
		public String SettingPath { get; set; } = Program.SettingsDirectory;

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
				try
				{
					var json = HjsonValue.Parse(File.ReadAllText(SettingPath)).ToString();
					var serializer = JsonSerializer.Create(SerializerSettings);
					using var sReader = new StringReader(json);
					using var reader = new JsonTextReader(sReader);
					var value = serializer.Deserialize<UserSettings>(reader);
					WorkingDirectory = value.WorkingDirectory;
					ShowFileNameInList = value.ShowFileNameInList;
				}
				catch
				{
					WorkingDirectory = Program.DefaultDirectory;
				}
			}
			else
			{
				WorkingDirectory = Program.DefaultDirectory;
				Save();
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
