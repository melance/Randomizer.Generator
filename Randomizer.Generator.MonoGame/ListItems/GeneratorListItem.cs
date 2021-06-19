using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomizer.Generator.MonoGame.ListItems
{
    class GeneratorListItem 
    {
        public GeneratorListItem(String filePath) => (FilePath) = (filePath);


        public String FilePath { get; set; }
        public String FileName { get => Path.GetFileName(FilePath); }

        public override String ToString()
        {
            return FileName;
        }
    }
}
