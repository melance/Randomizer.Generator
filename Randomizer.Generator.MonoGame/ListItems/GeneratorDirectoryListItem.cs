using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Randomizer.Generator.MonoGame.Utility;

namespace Randomizer.Generator.MonoGame.ListItems
{
    class GeneratorDirectoryListItem : DirectoryListItem
    {
		public GeneratorDirectoryListItem(String path) : base(path) { }

        public override String Name
        {
            get => Path.Equals(Constants.UP_ONE_DIRECTORY) ? Constants.UP_ONE_DIRECTORY : $"{base.Name} ({Directory.GetFiles(Path, "*.rgen.*").Length})";
        }

        public override String ToString()
        {
            return Name;
        }
    }
}
