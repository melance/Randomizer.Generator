using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Randomizer.Generator.Core;
using Randomizer.Generator.DataAccess;

namespace Randomizer.Generator.UI.Terminal.Utility
{
	class TUIDataAccess : FileSystemDataAccess
	{
		public override String RootPath { get => Directory.GetCurrentDirectory(); }
	}
}
