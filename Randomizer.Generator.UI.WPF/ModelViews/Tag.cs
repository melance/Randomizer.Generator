using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomizer.Generator.UI.WPF.ModelViews
{
	class Tag : BaseClass
	{
		public Tag() : base() { }
		public Tag(String name, Boolean selected = false) : base() => (Name, Selected) = (name, selected);

		public String Name
		{
			get => GetProperty(String.Empty);
			set => SetProperty(value);
		}

		public Boolean Selected
		{
			get => GetProperty(false);
			set => SetProperty(value);
		}
	}
}
