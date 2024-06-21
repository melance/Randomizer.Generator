using Randomizer.Generator.Core;
using System.Xml.Linq;

namespace Randomizer.Generator.Web.Models
{
	public class ParameterModel
	{
		public ParameterModel() { }
		public ParameterModel(String name, Parameter parameter)
		{
			Name = name;
			Description = parameter.Description;
			Value = parameter.Value;
			Type = parameter.Type;
			Display = parameter.Display;
			Visible = parameter.Visible;
			Validation = parameter.Validation;
			IsValid = parameter.IsValid;
			ValidationMessage = parameter.ValidationMessage;
			Options = parameter.Options;
		}

		public String Name {  get; set; }
		public String Description {  get; set; }
		public String Value { get; set; }
		public ParameterTypes Type { get; set; }
		public String Display {  get; set; }
		public Boolean Visible { get; set; } = true;
		public List<ParameterValidation> Validation { get; set; } = new();
		public Boolean IsValid { get; set; } = true;
		public String ValidationMessage { get; set; }
		public ListOptionList Options { get; set; } = new();

		public String GetDisplay() => String.IsNullOrWhiteSpace(Display) ? Name : Display;
		public void Copy(Parameter parameter)
		{
			Description = parameter.Description;
			Value = parameter.Value;
			Type = parameter.Type;
			Display = parameter.Display;
			Visible = parameter.Visible;
			Validation = parameter.Validation;
			IsValid = parameter.IsValid;
			ValidationMessage = parameter.ValidationMessage;
			Options = parameter.Options;
		}
	}
}
