using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomizer.Generator.UITerminal.EventArgs
{
	class GeneratorSelectedEventArgs : System.EventArgs
	{
		public String FilePath { get; private set; }

		public GeneratorSelectedEventArgs(String filePath) => FilePath = filePath;
	}
}
