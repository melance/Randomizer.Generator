using System;
using System.Collections.Generic;

namespace Randomizer.Generator.Core
{
	/// <summary>
	/// A parameter for a definition
	/// </summary>
	public class Parameter
    {
		/// <summary>The value of the parameter</summary>
        public String Value { get; set; }
		/// <summary>The text to display for the parameter</summary>
        public String Display { get; set; }
		/// <summary>When used in a command line project, other names to use for the parameter</summary>
		public List<String> Aliases { get; set; } = new List<String>();
		/// <summary>The type of parameter</summary>
		public ParameterTypes Type { get; set; }
		/// <summary>The list of options for a <see cref="ParameterTypes.List"/> parameter</summary>
		public ListOptionList Options { get; set; } = new ListOptionList();
    }
}
