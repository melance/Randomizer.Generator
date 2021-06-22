using Hjson;
using System.IO;
using JsonSubTypes;
using NCalc;
using Randomizer.Generator.Converters;
using Randomizer.Generator.Exceptions;
using Randomizer.Generator.Utility;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Text;
using Newtonsoft.Json.Converters;

[assembly: InternalsVisibleTo("Randomizer.Generator.Test")]

namespace Randomizer.Generator.Core
{	
	public abstract class BaseDefinition
    {
        private CalculationEngine _calculator;

		#region Public Static Methods
		public static BaseDefinition Deserialize(Byte[] value) 
		{
			return Deserialize(Encoding.Default.GetString(value));
		}

		/// <summary>
		/// Deserializes an HJSON string into a definition
		/// </summary>
		public static BaseDefinition Deserialize(String value) 
        {
            var json = HjsonValue.Parse(value).ToString();
			var serializer = JsonSerializer.Create(SerializerSettings);
			using var sReader = new StringReader(json);
			using var reader = new JsonTextReader(sReader);
            return serializer.Deserialize<BaseDefinition>(reader);
        }

        /// <summary>
        /// Serializes a definition into HJSON
        /// </summary>
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
													.SerializeDiscriminatorProperty() // ask to serialize the type property
													.Build(),
						JsonSubtypesConverterBuilder.Of(typeof(Table.BaseTable), "TableType")
													.RegisterSubtype<Table.LoopTable>(Table.TableTypes.Loop)
													.RegisterSubtype<Table.RandomTable>(Table.TableTypes.Random)
													.RegisterSubtype<Table.SelectTable>(Table.TableTypes.Select)
													.SerializeDiscriminatorProperty() // ask to serialize the type property
													.Build()
					}
		};

		/// <summary>Name of the generator definition</summary>
		public String Name { get; set; }
        /// <summary>Author of the generator definition</summary>
        public String Author { get; set; }
        /// <summary>Description of the generator definition</summary>
        public String Description { get; set; }
        /// <summary>Version of the generator definition</summary>
        public Version Version { get; set; }
        /// <summary>URL for more information about the generator definition</summary>
        public String URL { get; set; }
        /// <summary>A list of tags for the generator definition</summary>
        public List<String> Tags { get; set; }
        /// <summary>The format that the generator outputs</summary>
        public OutputFormats OutputFormat { get; set; }
        /// <summary>Parameters for the generator definition</summary>
        public virtual ParameterDictionary Parameters { get; set; } = new();
        #endregion

        #region Public Methods
        public abstract String Generate();
        #endregion

        #region Protected Methods
        protected String Calculate(String expression)
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

        /// <summary>
        /// Called when the base generator doesn't isn't aware of the function named
        /// </summary>
        protected virtual void OnEvaluateFunction(String name, FunctionArgs e) 
		{
			EvaluateFunction(name, e);
		}

        /// <summary>
        /// Called when the base generator isn't aware of the parameter named
        /// </summary>
        protected virtual void OnEvaluateParameter(String name, ParameterArgs e) 
		{
			if (Parameters != null && Parameters.ContainsKey(name))
				e.Result = Parameters[name];
			else
				EvaluateParameter(name, e);
		}

		protected abstract void EvaluateFunction(String name, FunctionArgs e);
		protected abstract void EvaluateParameter(String name, ParameterArgs e);


        #endregion

    }
}
