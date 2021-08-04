using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Randomizer.Generator.Core;

namespace Randomizer.Generator.UI.MVC.Models
{
	public class GeneratorModel
	{
		public String Name { get; set; }
		public String Author { get; set; }
		public String Description { get; set; }
		public String Remarks { get; set; }
		public Version Version { get; set; }
		public String URL { get; set; }
		public List<String> Tags { get; set; }
		public OutputFormats OutputFormat { get; set; }
		public virtual ParameterDictionary Parameters { get; set; } = new();
		public Int32 Repeat { get; set; } = 1;
		public String Result { get; set; }
		public String ErrorMessage { get; set; }

		public static explicit operator GeneratorModel(BaseDefinition definition)
		{
			return new()
			{
				Name = definition.Name,
				Author = definition.Author,
				Description = definition.Description,
				Remarks = definition.Remarks,
				Version = definition.Version,
				URL = definition.URL,
				Tags = definition.Tags,
				OutputFormat = definition.OutputFormat,
				Parameters = definition.Parameters				
			};
		}
	}
}
