using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Randomizer.Generator.Core;
using Randomizer.Generator.UI.MVC.Utility;

namespace Randomizer.Generator.UI.MVC.Models
{
	public class SidebarModel
	{
		public SidebarModel(MVCDataAccess dataAccess)
		{
			foreach (var item in dataAccess.GetDefinitionInfoList())
			{
				try
				{
					foreach(var tag in item.Tags)
					{
						if (!TagList.ContainsKey(tag))
						{
							TagList.Add(tag, new());
						}
						TagList[tag].Add(new(item.Name, item.FileName));
					}
				}
				catch
				{
					//TODO: Add Logging
				}
			}
		}


		public Dictionary<String, List<(String Name, String Path)>> TagList { get; private set; } = new();
	}
}
