using Hjson;
using JsonSubTypes;
using NCalc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Randomizer.Generator.Converters;
using Randomizer.Generator.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("Randomizer.Generator.Test")]

namespace Randomizer.Generator.Core
{
	/// <summary>
	/// The base class for all definitions
	/// </summary>
	public abstract class BaseDefinition : BaseClass
	{
		#region Members
		private CalculationEngine _calculator;
		#endregion

		#region Public Static Methods

		/// <summary>
		/// Deserializes an HJSON byte array into a definition
		/// </summary>
		/// <param name="value">A byte array in the default encoding</param>
		/// <returns>A definition instance</returns>
		public static BaseDefinition Deserialize(Byte[] value)
		{
			return Deserialize(Encoding.Default.GetString(value));
		}

		/// <summary>
		/// Deserializes an HJSON string into a definition
		/// </summary>
		/// <param name="value">An HJSON formatted string</param>
		/// <returns>A definition instance</returns>
		public static BaseDefinition Deserialize(String value)
		{
			var json = HjsonValue.Parse(value).ToString();
			var serializer = JsonSerializer.Create(SerializerSettings);
			using var sReader = new StringReader(json);
			using var reader = new JsonTextReader(sReader);
			return serializer.Deserialize<BaseDefinition>(reader);
		}
		
		/// <summary>
		/// Deserializes an HJSON string into a definition
		/// </summary>
		/// <param name="value">An HJSON formatted string</param>
		/// <returns>A definition instance</returns>
		public static T Deserialize<T>(String value) where T : BaseDefinition
		{
			return (T)Deserialize(value);
		}

		/// <summary>
		/// Deserializes an HJSON byte array into a definition
		/// </summary>
		/// <param name="value">A byte array in the default encoding</param>
		/// <returns>A definition instance</returns>
		public static T Deserialize<T>(Byte[] value) where T : BaseDefinition
		{
			return (T)Deserialize(value);
		}

		/// <summary>
		/// Tries to deserialize an HJSON string into a definition
		/// </summary>
		/// <param name="value">An HJSON formatted string</param>
		/// <param name="definition">The definition instance</param>
		/// <returns>True if successful; otherwise false</returns>
		public static Boolean TryDeserialize(String value,out BaseDefinition definition)
		{
			definition = null;
			try
			{
				definition = Deserialize(value);
				return true;
			}
			catch
			{
				return false;
			}
		}

		/// <summary>
		/// Serializes a definition into HJSON
		/// </summary>
		/// <param name="value">The definition to serialize</param>
		/// <param name="hjsonFormat">If true, the return value will be in hjson format otherwise it will be in json format</param>
		/// <returns>A string representation of the definition</returns>
		public static String Serialize(BaseDefinition value, Boolean hjsonFormat = true)
		{
			var builder = new StringBuilder();
			using var sWriter = new StringWriter(builder);
			using var writer = new JsonTextWriter(sWriter);
			var serializer = JsonSerializer.Create(SerializerSettings);
			serializer.Serialize(writer, value);
			var hjson = HjsonValue.Parse(builder.ToString());
			return hjson.ToString(hjsonFormat ? Stringify.Hjson : Stringify.Formatted);
		}
		#endregion

		#region Properties
		/// <summary>
		/// The settings used to serialize and deserialize definitions
		/// </summary>
		protected static JsonSerializerSettings SerializerSettings => new()
		{
			Formatting = Formatting.Indented,
			Converters =
					{
						new StringEnumConverter(),
						new JsonVersionConverter(),
						new JsonListOptionConverter(),
						JsonSubtypesConverterBuilder.Of(typeof(BaseDefinition), "GeneratorType")
													.RegisterSubtype<Assignment.AssignmentDefinition>(GeneratorTypes.Assignment)
													.RegisterSubtype<List.ListDefinition>(GeneratorTypes.List)
													.RegisterSubtype<Lua.LuaDefinition>(GeneratorTypes.Lua)
													.RegisterSubtype<Phonotactics.PhonotacticsDefinition>(GeneratorTypes.Phonotactics)
													.RegisterSubtype<Table.TableDefinition>(GeneratorTypes.Table)
													.RegisterSubtype<DotNet.DotNetDefinition>(GeneratorTypes.DotNet)
													.RegisterSubtype<Sampler.SamplerDefinition>(GeneratorTypes.Sampler)
													.SerializeDiscriminatorProperty() // ask to serialize the type property
													.Build(),
						JsonSubtypesConverterBuilder.Of(typeof(Table.BaseTable), "TableType")
													.RegisterSubtype<Table.LoopTable>(Table.TableTypes.Loop)
													.RegisterSubtype<Table.RandomTable>(Table.TableTypes.Random)
													.RegisterSubtype<Table.SelectTable>(Table.TableTypes.Select)
													.SerializeDiscriminatorProperty() // ask to serialize the type property
													.Build()
					},
			NullValueHandling = NullValueHandling.Ignore, 
			DefaultValueHandling = DefaultValueHandling.Ignore
		};

		/// <summary>Name of the generator definition</summary>
		[JsonProperty(Order = 0)]
		public String Name {
			get => GetProperty(String.Empty);
			set => SetProperty(value); 
		}
		[JsonProperty(Order = 1)]
		/// <summary>Author of the generator definition</summary>
		public String Author { 
			get => GetProperty(String.Empty); 
			set => SetProperty(value); 
		}
		/// <summary>Description of the generator definition</summary>
		[JsonProperty(Order = 2)]
		public String Description {
			get => GetProperty(String.Empty);
			set => SetProperty(value);
		}
		/// <summary>Remarks for the definition</summary>
		[JsonProperty(Order = 2)]
		public String Remarks {
			get => GetProperty(String.Empty);
			set => SetProperty(value);
		}
		/// <summary>Version of the generator definition</summary>
		[JsonProperty(Order = 3)]
		public Version Version {
			get => GetProperty(new Version(1, 0));
			set => SetProperty(value);
		}
		/// <summary>URL for more information about the generator definition</summary>
		[JsonProperty(Order = 4)]
		public String URL {
			get => GetProperty(String.Empty);
			set => SetProperty(value);
		}
		/// <summary>A list of tags for the generator definition</summary>
		[JsonProperty(Order = 5)]
		public List<String> Tags {
			get => GetProperty(new List<String>());
			set => SetProperty(value);
		}
		/// <summary>The format that the generator outputs</summary>
		[JsonProperty(Order = 6)]
		public OutputFormats OutputFormat {
			get => GetProperty(OutputFormats.Text);
			set => SetProperty(value);
		}
		/// <summary>If true, show in the list of generators</summary>
		[JsonProperty(Order = 7)]
		[DefaultValue(true)]
		public Boolean ShowInList {
			get => GetProperty(true);
			set => SetProperty(value);
		}
		/// <summary>Parameters for the generator definition</summary>
		[JsonProperty(Order = 8)]
		public virtual ParameterDictionary Parameters {
			get => GetProperty(new ParameterDictionary());
			set => SetProperty(value);
		}
		/// <summary>If true, this definition type supports parameters</summary>
		[JsonIgnore]
		public abstract Boolean SupportsParameters { get; }
		#endregion

		#region Public Methods
		/// <summary>
		/// In child classes, overridden to process the definition and return a result
		/// </summary>
		/// <returns>The result of the definition process</returns>
		public abstract String Generate();

		/// <summary>
		/// Calls the generate method asyncronously
		/// </summary>
		/// <returns>The result of the definition process</returns>
		public virtual Task<String> GenerateAsync()
		{
			return Task.FromResult(Generate());
		}

		public virtual String Analyze(AnalyzeOptions options)
		{
			var analysis = new AnalysisWriter();
			analysis.AppendLine(Name);
			analysis.AppendLine(Description);
			analysis.AppendHeader("General");
			analysis.AppendItemValue("Generator Type", GetType().Name);
			analysis.AppendItemValue("Author", Author);
			analysis.AppendItemValue("Version", Version);
			analysis.AppendItemValue("Tags", Tags != null && Tags.Count > 0 ? String.Join(", ", Tags) : "");
			analysis.AppendItemValue("Output Format", OutputFormat);
			analysis.AppendItemValue("URL", URL);
			
			if (SupportsParameters)
			{
				analysis.AppendHeader("Parameters");			
				foreach (var parameter in Parameters)
				{
					analysis.AppendLine($"Name:           {parameter.Key}");
					analysis.AppendLine($"Display:        {parameter.Value.Display}");
					analysis.AppendLine($"Aliases:        {String.Join(", ", parameter.Value.Aliases)}");
					analysis.AppendLine($"Description:    {parameter.Value.Description}");
					analysis.AppendLine($"Type:           {parameter.Value.Type}");
					analysis.AppendLine($"Default:        {parameter.Value.Value}");

					if (parameter.Value.Type == ParameterTypes.List)
					{
						analysis.AppendLine("Options:");
						analysis.Level++;
						var labelWidth = parameter.Value.Options.Max(o => o.Display.Length) + 1;
						foreach (var option in parameter.Value.Options)
						{
							analysis.AppendLine($"{option.Display.PadRight(labelWidth)} : {option.Value}");
						}
						analysis.Level--;
					}
					analysis.AppendLine();
				}
			}

			return analysis.ToString();
		}


		/// <summary>
		/// Serializes the definition and returns the string result
		/// </summary>
		/// <returns>The serialized definition</returns>
		public override String ToString()
		{
			return Serialize(this);
		}

		/// <summary>
		/// Including explicit cast to <see cref="String"/> for convenience
		/// </summary>
		/// <param name="definition">The definition to serialize</param>
		public static explicit operator String(BaseDefinition definition)
		{
			return definition.ToString();
		}

		/// <summary>
		/// Including explicit cast from <see cref="String"/> for convenience
		/// </summary>
		/// <param name="definition">The hjson to deserialize</param>
		public static explicit operator BaseDefinition(String hjson)
		{
			return Deserialize(hjson);
		}

		/// <summary>
		/// Validates the named parameter
		/// </summary>
		public (Boolean Valid, String Message) ValidateParameter(String parameterName)
		{
			(Boolean Valid, String Message) result = (true, String.Empty);
			var parameter = Parameters[parameterName];
			if (parameter.Validation.Any())
			{
				foreach (var validation in parameter.Validation)
				{
					var calc = new Expression(validation.Expression, EvaluateOptions.MatchStringsWithIgnoreCase);
					calc.Parameters.Add("Value", parameter.TypedValue);
					if ((Boolean)calc.Evaluate())
					{
						var thisMessage = validation.Message.IsNullOrWhitespace() ? validation.Expression : validation.Message;
						var message = thisMessage.MultiReplace(false, ("[Name]", parameter.Display),
																	  ("[Value]", parameter.Value));
						parameter.IsValid = false;
						result.Valid = false;
						result.Message = message;
						parameter.ValidationMessage = message;
					}
				}
			}
			return result;
		}
		#endregion

		#region Protected Methods
		/// <summary>
		/// Validates all parameters
		/// </summary>
		protected Boolean ValidateParameters()
		{
			var result = true;
			foreach (var parameter in Parameters)
			{
				if (!ValidateParameter(parameter.Key).Valid)
					result = false;
			}
			return result;
		}

		/// <summary>
		/// Processes an expression through the <see cref="CalculationEngine"/>
		/// </summary>
		/// <param name="expression">The expression to process</param>
		/// <returns>The result of the evaluation</returns>
		protected String Calculate(String expression)
		{
			ExceptionDispatchInfo exi = null;
			try
			{
				Object value;
				_calculator = new CalculationEngine(expression);
				_calculator.EvaluateFunction += OnEvaluateFunction;
				_calculator.EvaluateParameter += OnEvaluateParameter;
				value = _calculator.Evaluate();
				_calculator.EvaluateFunction -= OnEvaluateFunction;
				_calculator.EvaluateParameter -= OnEvaluateParameter;
				return value.ToString();
			}
			catch (EvaluationException nex)
			{
				exi = ExceptionDispatchInfo.Capture(nex);
				exi.SourceException.AddData(nameof(expression), expression);
			}

			exi?.Throw();
			return String.Empty;
		}

		/// <summary>
		/// Called when the base generator doesn't isn't aware of the function named
		/// </summary>
		/// <param name="name">The name of the function found by the <see cref="CalculationEngine"/></param>
		/// <param name="e">The parameters and result for the call</param>
		protected virtual void OnEvaluateFunction(String name, FunctionArgs e) => EvaluateFunction(name, e);

		/// <summary>
		/// Called when the base generator isn't aware of the parameter named
		/// </summary>
		/// <param name="name">The name of the parameter found by the <see cref="CalculationEngine"/></param>
		/// <param name="e">The result for the call</param>
		protected virtual void OnEvaluateParameter(String name, ParameterArgs e)
		{
			if (Parameters != null && Parameters.ContainsKey(name))
			{
				var parameter = Parameters[name];
				if (parameter.Type == ParameterTypes.Calculation)
				{
					e.Result = new CalculationEngine(parameter.Value).Evaluate();
				}
				else
				{
					e.Result = Parameters[name].Value;
				}
			}
			else
				EvaluateParameter(name, e);
		}

		/// <summary>
		/// When overridden in child classes, handles unknown Function processing for the <see cref="Calculate(string)"/> method
		/// </summary>
		/// <param name="name">The name of the function found by the <see cref="CalculationEngine"/></param>
		/// <param name="e">The parameters and result for the call</param>
		protected virtual void EvaluateFunction(String name, FunctionArgs e) { }

		/// <summary>
		/// When overridden in child classes, handles unknown Parameter processing for the <see cref="Calculate(string)"/> method
		/// </summary>
		/// <param name="name">The name of the parameter found by the <see cref="CalculationEngine"/></param>
		/// <param name="e">The result for the call</param>
		protected virtual void EvaluateParameter(String name, ParameterArgs e) { }
		#endregion

	}
}
