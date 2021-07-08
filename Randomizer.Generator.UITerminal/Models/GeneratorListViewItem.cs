using System;

namespace Randomizer.Generator.UI.Terminal.Models
{
	class GeneratorListViewItem
	{
		public GeneratorListViewItem(String path) => Path = path;
		public GeneratorListViewItem(String path, String name) => (Path, _name) = (path, name);

		readonly String _name = String.Empty;

		public String Name {
			get
			{
				if (String.IsNullOrEmpty(_name))
					return System.IO.Path.GetFileName(Path);
				else
					return _name;
			}
		}
		public String Path { get; private set; }

		public override String ToString()
		{
			return Name;
		}
	}
}
