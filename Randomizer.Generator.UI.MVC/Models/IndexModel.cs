using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Randomizer.Generator.UI.MVC.Utility;
using X.PagedList;

namespace Randomizer.Generator.UI.MVC.Models
{
	public class IndexModel
	{
		#region Constants
		private const Int32 PAGE_SIZE = 10;
		#endregion

		#region Constructors
		public IndexModel() { }
		public IndexModel(MVCDataAccess dataAccess) : this(dataAccess, 1) { }
		public IndexModel(MVCDataAccess dataAccess, Int32 page)
		{
			Definitions = dataAccess.GetDefinitionInfoList().OrderBy(d => d.Name).ToPagedList(page, PAGE_SIZE);
			foreach (var tag in dataAccess.GetTagList())
			{
				TagList.Add(tag, false);
			}
		}
		#endregion

		#region Public Methods
		public void GetDefinitions(MVCDataAccess dataAccess)
		{
			var definitions = new List<DefinitionInfo>();
			var selectedTags = TagList.Where(t => t.Value).Select(t => t.Key);

			if (!selectedTags.Any())
				selectedTags = TagList.Select(t => t.Key);

			foreach (var definition in dataAccess.GetDefinitionInfoList())
			{
				if (definition.Tags.Any(t => selectedTags.Contains(t, StringComparer.CurrentCultureIgnoreCase)))
				{
					definitions.Add(definition);
				}
			}
			if (!String.IsNullOrWhiteSpace(Search))
			{
				definitions = definitions.Where(d => d.Name.Contains(Search, StringComparison.CurrentCultureIgnoreCase)).ToList();
			}
			Definitions = definitions.OrderBy(d => d.Name).ToPagedList(Page, PAGE_SIZE);
		} 
		#endregion

		#region Properties
		public IPagedList<DefinitionInfo> Definitions { get; set; }
		public String Search { get; set; }
		public Dictionary<String, Boolean> TagList { get; set; } = new();
		public Int32 Page { get; set; } = 1;
		public Boolean IsFiltered
		{
			get
			{
				var allTags = TagList.All(tl => tl.Value) || TagList.All(tl => !tl.Value);
				return !allTags || !String.IsNullOrWhiteSpace(Search);
			}
		}
		#endregion
	}
}
