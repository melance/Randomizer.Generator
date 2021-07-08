using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomizer.Generator.UI.Terminal.EventArgs
{
	class GeneratorSelectedEventArgs : System.EventArgs
	{
		#region Properties
		public String FilePath { get; private set; }
		#endregion

		#region Constructor
		public GeneratorSelectedEventArgs(String filePath) => FilePath = filePath; 
		#endregion
	}
}
