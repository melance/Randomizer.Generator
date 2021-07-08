using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Randomizer.Generator.UI.MVC.Utility;

namespace Randomizer.Generator.UI.MVC.Models
{
	public class IndexModel
	{
		public IndexModel(MVCDataAccess dataAccess) : this(dataAccess, String.Empty) { }

		public IndexModel(MVCDataAccess dataAccess, String tag)
		{	
			Definitions = dataAccess.GetDefinitionInfoList(tag).OrderBy(d => d.Name).ToList();
			TagList = dataAccess.GetTagList().ToList();
		}

		public List<DefinitionInfo> Definitions { get; set; }
		public String Tag { get; set; }
		public List<String> TagList { get; set; } = new();
	}
}
