using Randomizer.Generator.Core;
using System;

namespace Randomizer.Generator.UI.Terminal.Models
{
	class GeneratorListViewItem
	{
		public GeneratorListViewItem(BaseDefinition definition) => Name = definition.Name;

		readonly String _name = String.Empty;

		public String Name { get; }

		public override String ToString()
		{
			return Name;
		}
	}
}
