using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomizer.Generator.MonoGame.ListItems
{
	class DirectoryListItem : IOListItemBase
	{
		public DirectoryListItem(String path) : base(path) { }

		public override String Name => $"{System.IO.Path.DirectorySeparatorChar}{base.Name}";
	}
}
