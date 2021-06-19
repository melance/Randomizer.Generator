using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Randomizer.Generator.MonoGame.Utility;

namespace Randomizer.Generator.MonoGame.ListItems
{
	abstract class IOListItemBase
	{
		public IOListItemBase(String path) => (Path) = (path);

		public virtual String Path { get; set; }
		public virtual String Name
		{
			get => Path.Equals(Constants.UP_ONE_DIRECTORY) ? Constants.UP_ONE_DIRECTORY : $"{System.IO.Path.GetFileName(Path)}";
		}

		public override String ToString()
		{
			return Name;
		}
	}
}
