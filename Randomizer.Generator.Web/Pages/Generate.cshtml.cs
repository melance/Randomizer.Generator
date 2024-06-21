using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Randomizer.Generator.Core;
using Randomizer.Generator.DataAccess;
using Randomizer.Generator.Web.DataAccess;
using Randomizer.Generator.Web.Helpers;
using Randomizer.Generator.Web.Models;
using System.ComponentModel.DataAnnotations;

namespace Randomizer.Generator.Web.Pages
{
    public class GenerateModel(IDataAccess dataAccess) : PageModel
    {		
		#region Properties
		public DefinitionDataAccess DataAccess { get; set; } = (DefinitionDataAccess)dataAccess;
		
		public BaseDefinition Definition { get; set; }

		[BindProperty]
		public GeneratorModel Generator { get; set; }
		public List<String> Results { get; set; } = [];
		public String ErrorMessage {  get; set; }
		#endregion

		#region Public Methods
		public IActionResult OnGet(String? definition)
        {
			try
			{
				if(String.IsNullOrWhiteSpace(definition)) return Redirect("/");
				Definition = DataAccess.GetDefinition(definition)?.Definition;
				if (Definition == null || !Definition.ShowInList)
				{
					ErrorMessage = $"Definition <i>{definition}</i> not found.";
					return Page();
				}
				Generator = new(Definition);
				ViewData["Title"] = Definition.Name;
				return Page();
			}
			catch
			{
				ErrorMessage = "There was an error loading the definition.  Please try again.";
				return Page();
			}
        }

		public IActionResult OnPostGenerate()
		{
			Definition = DataAccess.GetDefinition(Generator.Name).Definition;
			if (Definition == null) return Redirect("/");
			try
			{
				foreach(var parameter in Generator.Parameters)
				{
					var definition_parameter = Definition.Parameters[parameter.Name];
					var value = parameter.Value;
					if (definition_parameter.Type == ParameterTypes.Boolean)
						value = (parameter.Value == "on").ToString();
					definition_parameter.Value = value;
					parameter.Copy(definition_parameter);
				}
				for (var i = 0; i < Generator.Repeat; i++)
				{
					var result = Definition.Generate();
					if (Definition.OutputFormat == OutputFormats.Markdown)
					{
						result = result.ToHtml();
					}
					Results.Add(result);
				}
				ViewData["Title"] = Definition.Name;
				return Page();
			}
			catch
			{
				ErrorMessage = "There was an error generating your content.  Please try again later.";
				return Page();
			}
		}
		#endregion
	}
}
