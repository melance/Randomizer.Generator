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
		public String Name { get; private set; }
		#endregion

		#region Constructor
		public GeneratorSelectedEventArgs(String name) => Name = name; 
		#endregion
	}
}
