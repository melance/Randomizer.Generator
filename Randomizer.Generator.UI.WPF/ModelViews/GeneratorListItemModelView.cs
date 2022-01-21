using Randomizer.Generator.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomizer.Generator.UI.WPF.ModelViews
{
	internal class GeneratorListItemModelView : BaseClass
	{
		public GeneratorListItemModelView() : base()
		{

		}

		public GeneratorListItemModelView(BaseDefinition definition) : this()
		{
			Name = definition.Name;
			Description = definition.Description;
			Tags = definition.Tags;
			OutputFormat = definition.OutputFormat;
		}

		public String Name 
		{ 
			get => GetProperty(String.Empty); 
			set => SetProperty(value); 
		} 
		public String Description
		{
			get => GetProperty(String.Empty);
			set => SetProperty(value);
		}
		public List<String> Tags
		{
			get => GetProperty(new List<String>());
			set => SetProperty(value);
		}
		public String TagDisplay => String.Join(", ", Tags);
		public OutputFormats OutputFormat
		{
			get => GetProperty(OutputFormats.Text);
			set => SetProperty(value);
		}
	}
}
