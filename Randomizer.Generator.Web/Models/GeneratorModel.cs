using Randomizer.Generator.Core;

namespace Randomizer.Generator.Web.Models
{
	public class GeneratorModel
	{
		public GeneratorModel() { }
		public GeneratorModel(BaseDefinition definition) 
		{
			Name = definition.Name;
			Description = definition.Description;
			Author = definition.Author;
			Repeat = 1;
			foreach(var parameter in definition.Parameters)
			{
				Parameters.Add(new ParameterModel(parameter.Key, parameter.Value));
			}
		}

		public String Name { get; set; }
		public String Description { get; set; }
		public String Author { get; set; }
		public Int32 Repeat { get; set; }
		public List<ParameterModel> Parameters { get; set; } = new();
	}
}
