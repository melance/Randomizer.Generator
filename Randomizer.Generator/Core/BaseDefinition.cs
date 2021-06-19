using NCalc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using Randomizer.Generator.Utility;
using Randomizer.Generator.Converters;
using System.Linq;
using Hjson;
using Randomizer.Generator.Exceptions;
using System.ComponentModel;

[assembly: InternalsVisibleTo("Randomizer.Generator.Test")]

namespace Randomizer.Generator.Core
{    
    public abstract class BaseDefinition
    {
        private CalculationEngine _calculator;

        #region Public Static Methods
        public static T Deserialize<T>(Byte[] value) where T : BaseDefinition
        {
            return Deserialize<T>(System.Text.Encoding.Default.GetString(value));
        }

        /// <summary>
        /// Deserializes an HJSON string into a definition
        /// </summary>
        public static T Deserialize<T>(String value) where T : BaseDefinition
        {
            var json = HjsonValue.Parse(value).ToString();

            return JsonSerializer.Deserialize<T>(json, SerializerOptions);
        }

        /// <summary>
        /// Serializes a definition into HJSON
        /// </summary>
        public static String Serialize<T>(T value, Boolean hjsonFormat = true) where T : BaseDefinition
        {
            var hjson = HjsonValue.Parse(JsonSerializer.Serialize(value, SerializerOptions));
            return hjson.ToString(hjsonFormat ? Stringify.Hjson : Stringify.Formatted);
        }

        /// <summary>
        /// Returns the type of the given hjson definition
        /// </summary>
        public static GeneratorTypes GetGeneratorType(String value)
        {
            var json = HjsonValue.Parse(value).Qo();
            if (json[nameof(GeneratorType)] != null)
            {
                var typeName = json[nameof(GeneratorType)].Qs();
                if (Enum.TryParse<GeneratorTypes>(typeName, out var result))
                {
                    return result;
                }
                else
                {
                    throw new UnrecognizedGeneratorException(typeName);
                }
            }
            else throw new DefinitionException("GeneratorType not found.");
        }
        #endregion

        #region Properties
        protected static JsonSerializerOptions SerializerOptions
        {
            get => new()
			{
                WriteIndented = true,
                Converters =
                    {
                        new JsonStringEnumConverter(),
                        new JsonVersionConverter(),
                        new JsonListOptionConverter()
                    }
            };
        }

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
        /// <summary>The type of generator in the definition</summary>
        public GeneratorTypes GeneratorType { get; set; }
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
            _calculator.EvaluateFunction += EvaluateFunction;
            _calculator.EvaluateParameter += EvaluateParameter;
            value = _calculator.Evaluate();
            _calculator.EvaluateFunction -= EvaluateFunction;
            _calculator.EvaluateParameter -= EvaluateParameter;
            return value.ToString();
        }

        /// <summary>
        /// Called when the base generator doesn't isn't aware of the function named
        /// </summary>
        protected virtual void EvaluateFunction(String name, FunctionArgs e) { }

        /// <summary>
        /// Called when the base generator isn't aware of the parameter named
        /// </summary>
        protected virtual void EvaluateParameter(String name, ParameterArgs e) { }
        #endregion

    }
}
