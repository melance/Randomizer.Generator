using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomizer.Generator.UITerminal.Models
{
	class GeneratorListViewItem
	{
		public GeneratorListViewItem(String path) => Path = path;


		public String Name {
			get => System.IO.Path.GetFileName(Path);
		}
		public String Path { get; private set; }

		public override String ToString()
		{
			return Name;
		}
	}
}
