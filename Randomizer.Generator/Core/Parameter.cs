using System;
using System.Linq;
using System.Collections.Generic;
using Randomizer.Generator.Utility;
using Newtonsoft.Json;
using System.ComponentModel;

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
		public List<String> Aliases { get; set; } = new();
		/// <summary>A description of the parameter to provide to users</summary>
		public String Description { get; set; }
		/// <summary>The type of parameter</summary>
		public ParameterTypes Type { get; set; }
		[DefaultValue(true)]
		public Boolean Visible { get; set; } = true;
		/// <summary>A series of expressions that determines if there is an error</summary>
		public List<ParameterValidation> Validation { get; set; } = new();
		public Boolean IsValid { get; set; } = true;
		public String ValidationMessage { get; set; }
		/// <summary>The list of options for a <see cref="ParameterTypes.List"/> parameter</summary>
		public ListOptionList Options { get; set; } = new();

		/// <summary>The typed value of the <see cref="Value"/></summary>
		[JsonIgnore]
		public Object TypedValue
		{
			get
			{
				return Type switch
				{
					ParameterTypes.Integer => Value.IsNullOrWhitespace() ? 0 : Int64.Parse(Value),
					ParameterTypes.Decimal => Value.IsNullOrWhitespace() ? 0d : Double.Parse(Value),
					ParameterTypes.Date => Value.IsNullOrWhitespace() ? DateTime.MinValue : DateTime.Parse(Value),
					ParameterTypes.Boolean => !Value.IsNullOrWhitespace() && Boolean.Parse(Value),
					_ => Value,
				};
			}
		}
	}
}
