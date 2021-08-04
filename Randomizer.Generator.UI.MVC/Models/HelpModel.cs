using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Randomizer.Generator.UI.MVC.Models
{
	public class HelpModel
	{
		public HelpModel() { }
		public HelpModel(String category, String topic) => (Category, Topic) = (category, topic);

		public String Category { get; set; }
		public String Topic { get; set; }
	}
}
