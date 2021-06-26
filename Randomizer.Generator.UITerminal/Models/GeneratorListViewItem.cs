using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Randomizer.Generator.UITerminal.Utility;
using Randomizer.Generator.Core;

namespace Randomizer.Generator.UITerminal.Models
{
	class GeneratorListViewItem
	{
		public GeneratorListViewItem(String path) => Path = path;
		public GeneratorListViewItem(String path, String name) => (Path, _name) = (path, name);

		String _name = String.Empty;

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
