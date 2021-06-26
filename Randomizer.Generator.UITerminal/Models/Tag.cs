using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomizer.Generator.UITerminal.Models
{
	class Tag
	{
		public Tag(String text) => (Text, Selected) = (text, true);

		public String Text { get; set; }
		public Boolean Selected { get; set; }

		public override String ToString()
		{
			return Text;
		}

		public static implicit operator Tag(String value)
		{
			return new Tag(value);
		}

		public static implicit operator String(Tag value)
		{
			return value.Text;
		}
	}
}
