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
	public class Parameter : BaseClass
    {
		/// <summary>The value of the parameter</summary>
        public String Value {
			get => GetProperty(String.Empty);
			set => SetProperty(value);
		}
		/// <summary>The text to display for the parameter</summary>
        public String Display {
			get => GetProperty(String.Empty);
			set => SetProperty(value);
		}
		/// <summary>When used in a command line project, other names to use for the parameter</summary>
		public List<String> Aliases {
			get => GetProperty(new List<String>());
			set => SetProperty(value);
		}
		/// <summary>A description of the parameter to provide to users</summary>
		public String Description {
			get => GetProperty(String.Empty);
			set => SetProperty(value);
		}
		/// <summary>The type of parameter</summary>
		public ParameterTypes Type {
			get => GetProperty(ParameterTypes.Text);
			set => SetProperty(value);
		}
		[DefaultValue(true)]
		public Boolean Visible {
			get => GetProperty(true);
			set => SetProperty(value);
		}
		/// <summary>A series of expressions that determines if there is an error</summary>
		public List<ParameterValidation> Validation {
			get => GetProperty(new List<ParameterValidation>());
			set => SetProperty(value);
		}
		public Boolean IsValid {
			get => GetProperty(true);
			set => SetProperty(value);
		}
		public String ValidationMessage {
			get => GetProperty(String.Empty);
			internal set => SetProperty(value);
		}
		/// <summary>The list of options for a <see cref="ParameterTypes.List"/> parameter</summary>
		public ListOptionList Options {
			get => GetProperty(new ListOptionList());
			set => SetProperty(value);
		}

		/// <summary>The typed value of the <see cref="Value"/></summary>
		[JsonIgnore]
		public Object TypedValue => Type switch
		{
			ParameterTypes.Integer => Value.IsNullOrWhitespace() ? 0 : Int64.Parse(Value),
			ParameterTypes.Decimal => Value.IsNullOrWhitespace() ? 0d : Double.Parse(Value),
			ParameterTypes.Date => Value.IsNullOrWhitespace() ? DateTime.MinValue : DateTime.Parse(Value),
			ParameterTypes.Boolean => !Value.IsNullOrWhitespace() && Boolean.Parse(Value),
			_ => Value,
		};
	}
}
