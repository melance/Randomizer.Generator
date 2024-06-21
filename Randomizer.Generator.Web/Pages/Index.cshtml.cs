using LB.Utility.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Randomizer.Generator.Core;
using Randomizer.Generator.DataAccess;
using Randomizer.Generator.Web.DataAccess;
using Randomizer.Generator.Web.Models;
using System.ComponentModel.DataAnnotations;

namespace Randomizer.Generator.Web.Pages
{
	public class IndexModel : PageModel
	{
		public enum SearchByEnum
		{
			Name,
			Description,
			Author
		}

		private readonly DefinitionDataAccess _dataAccess;

		public IndexModel(IDataAccess dataAccess) => _dataAccess = (DefinitionDataAccess)dataAccess;

		[BindProperty]
		public List<Tag> Tags { get; set; } = [];
		[BindProperty]
		[Display(Name = "Name")]
		public String Criteria { get; set; } = String.Empty;
		[BindProperty]
		public SearchByEnum SearchBy { get; set; } = SearchByEnum.Name;

		public List<BaseDefinition> Definitions { get; set; } = [];

		public void OnGet()
		{
			Definitions = GetDefinitions();
			Tags = Definitions.SelectMany(d => d.Tags).Distinct().Select(t => (Tag)t).ToList();
		}

		public List<BaseDefinition> GetDefinitions()
		{
			var taglist = Tags.Where(t => t.Selected).Select(t => t.Name);
			var definitions = _dataAccess.GetDefinitionList(d => d.ShowInList && 
																 (String.IsNullOrWhiteSpace(Criteria) || d.Name.Contains(Criteria)) &&
																 (!taglist.Any() || d.Tags.Any(t => taglist.Contains(t, StringComparer.InvariantCultureIgnoreCase))));			
			if (definitions?.Count > 0)
			{
				return definitions.Where(gdl => gdl.Definition != null).Select(gdl => gdl.Definition!).ToList();
			}
			else
			{
				return [];
			}
		}

		public void OnPostSearch()
		{
			Definitions = GetDefinitions();
		}
	}
}
