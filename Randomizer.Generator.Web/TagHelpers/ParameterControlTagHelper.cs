using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Randomizer.Generator.Core;
using Randomizer.Generator.Web.Models;
using System.Text;
using System.Text.Encodings.Web;

namespace Randomizer.Generator.Web.TagHelpers
{
	[HtmlTargetElement("Parameter")]
	public class ParameterControlTagHelper : TagHelper
	{
		[HtmlAttributeName("parameter")]
		public ParameterModel Parameter { get; set; }

		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			switch (Parameter.Type)
			{
				case ParameterTypes.List:
					GenerateSelect(output);
					break;
				case ParameterTypes.Boolean:
					GenerateCheckbox(output);
					break;
				default:
					GenerateInput(output);
					break;
			}			

			base.Process(context, output);
		}

		private void GenerateSelect(TagHelperOutput output)
		{
			output.TagName = "select";
			output.AddClass("form-select", HtmlEncoder.Default);
			var options = new StringBuilder();
			foreach(var option in Parameter.Options)
			{
				options.Append(@$"<option value=""{option.Value}""{(option.Value == Parameter.Value ? " selected" : "")}>{option.Display}</option>");
			}
			output.Content.Clear();
			output.Content.AppendHtml(options.ToString());
		}

		private void GenerateCheckbox(TagHelperOutput output)
		{
			var id = output.Attributes["id"].Value.ToString();
			var name = output.Attributes["name"].Value.ToString();
			var input = new TagBuilder("input");
			output.TagName = "div";
			output.AddClass("input-group-text", HtmlEncoder.Default);
			output.Attributes.Remove(output.Attributes["id"]);
			output.Attributes.Remove(output.Attributes["name"]);

			input.Attributes.Add("id", id);
			input.Attributes.Add("name", name);	
			input.AddCssClass("form-check-input");
			input.AddCssClass("mt-0");
			input.Attributes.Add("type", "checkbox");

			if (Boolean.TryParse(Parameter.Value, out Boolean value) && value)
			{
				input.Attributes.Add("checked", null);
			}
			using var writer = new StringWriter();

			input.WriteTo(writer, HtmlEncoder.Default);

			output.Content.AppendHtml(writer.ToString());
		}

		private void GenerateInput(TagHelperOutput output)
		{
			output.TagName = "input";
			output.AddClass("form-control", HtmlEncoder.Default);
			switch (Parameter.Type)
			{
				case ParameterTypes.Integer:
					output.Attributes.Add("type", "number");
					output.Attributes.Add("step", "1");
					break;
				case ParameterTypes.Decimal:
					output.Attributes.Add("type", "number");
					break;
				case ParameterTypes.Date:
					output.Attributes.Add("type", "date");
					break;
				default:
					output.Attributes.Add("type", "text");
					break;
			}
			output.Attributes.SetAttribute("value", Parameter.Value);
			if (!String.IsNullOrWhiteSpace(Parameter.Value)) output.Attributes.Add("val", Parameter.Value);
		}
	}
}
