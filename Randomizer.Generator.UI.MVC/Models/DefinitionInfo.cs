using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Randomizer.Generator.Core;

namespace Randomizer.Generator.UI.MVC.Models
{
	public class DefinitionInfo
	{
		public String Name { get; set; }
		public String Description { get; set; }
		public String Author { get; set; }
		public Version Version { get; set; }
		public GeneratorTypes Type { get; set; }
		public OutputFormats OutputFormat { get; set; }
		public String Url { get; set; }
		public List<String> Tags { get; set; }
		public String FileName { get; set; }
		public String ErrorMessage { get; set; }

		public static implicit operator DefinitionInfo(BaseDefinition definition)
		{
			var result = new DefinitionInfo()
			{
				Name = definition.Name,
				Description = definition.Description,
				Author = definition.Author,
				Version = definition.Version,
				OutputFormat = definition.OutputFormat,
				Url = definition.URL,
				Tags = definition.Tags
			};
			switch (definition)
			{
				case Assignment.AssignmentDefinition:
					result.Type = GeneratorTypes.Assignment;
					break;
				case List.ListDefinition:
					result.Type = GeneratorTypes.List;
					break;
				case Lua.LuaDefinition:
					result.Type = GeneratorTypes.Lua;
					break;
				case Phonotactics.PhonotacticsDefinition:
					result.Type = GeneratorTypes.Phonotactics;
					break;
				case Table.TableDefinition:
					result.Type = GeneratorTypes.Table;
					break;
			}
			return result;
		}
	}
}
