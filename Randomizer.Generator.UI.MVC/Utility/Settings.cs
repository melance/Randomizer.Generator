using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Randomizer.Generator.UI.MVC.Utility
{
	public class Settings
	{
		public const string SectionName = "Settings";

		public Boolean FullExceptions { get; set; }
		public String DefinitionsPath { get; set; }
	}
}
