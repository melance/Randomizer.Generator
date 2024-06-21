using NCalc;
using System;
using System.Linq;
using System.Globalization;
using Randomizer.Generator.Attributes;
using System.Reflection;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using Pluralize.NET;
using Randomizer.Generator.Core;


namespace Randomizer.Generator.Utility
{
    public class CalculationEngine : Expression
    {
        #region Constants
        
		#endregion

		#region Constructor
		public CalculationEngine(String expression) : base(expression, EvaluateOptions.NoCache)
        {
			EvaluateFunction += EvaluateFunctionHandler;
            EvaluateParameter += EvaluateParameterHandler;
        }
		#endregion

		#region Public Methods
		public T Evaluate<T>()
		{
			return Evaluate<T>(new Expression[0]);
		}

		/// <summary>
		/// Evaluates the expression
		/// </summary>
		public T Evaluate<T>(Expression[] parameters)
        {
			try
			{
				var result = Evaluate();
				return result.GetType().Equals(typeof(T)) ? (T)result : (T)Convert.ChangeType(result, typeof(T));
			}
			catch (Exception ex)
			{
				ex.Data.Add("Expression", OriginalExpression);
			}
			return default;
        }

		public void EvaluateFunctionHandler(String name, FunctionArgs args) => _ = ExecuteFunction(name, args);

		public void EvaluateParameterHandler(String name, ParameterArgs args) { }
		#endregion

		#region Static Methods
		/// <summary>
		/// Executes the named function
		/// </summary>
		private static Boolean ExecuteFunction(String name, FunctionArgs args)
		{
			ExceptionDispatchInfo exi = null;
			try
			{
				switch (name.ToLowerInvariant())
				{
					case "pick":
						args.Result = Pick(args.EvaluateParameters().Cast<String>().ToArray());
						return true;
					case "pickw":
						args.Result = PickW(args.EvaluateParameters().Cast<String>().ToArray());
						return true;
					case "switch":
						if (args.Parameters.Length < 4) throw new EvaluationException($"{nameof(Switch)} requires at least 4 parameters.");
						var value = args.Parameters[0].Evaluate();
						var defaultValue = args.Parameters[1].Evaluate();
						var cases = new List<SwitchCase>();
						for (var i = 2; i < args.Parameters.Length - 1; i += 2)
						{
							cases.Add(new SwitchCase(args.Parameters[i].Evaluate(), args.Parameters[i + 1].Evaluate()));
						}
						args.Result = Switch(value, defaultValue, cases);
						return true;
					case "generate":
						var evaluated = args.EvaluateParameters();
						var generatorName = evaluated[0].ToString();
						var parameters = evaluated[1..].Cast<String>();
						args.Result = Generate(generatorName, parameters.ToArray());
						return true;
					default:
						return NCalcFunction(name, args);
				}
			}
			catch (Exception ex)
			{
				exi = ExceptionDispatchInfo.Capture(ex);
				ex.AddData(nameof(name), name);
				ex.AddData(nameof(args), args);
			}
			exi?.Throw();
			return false;
		}

		/// <summary>
		/// Process one of the registerd ncalc functions
		/// </summary>
		private static Boolean NCalcFunction(String name, FunctionArgs args)
		{
			var paramValues = new List<dynamic>();
			var paramTypes = new List<Type>();
			for (var i = 0; i < args.Parameters.Length; i++)
			{
				var value = args.Parameters[i].Evaluate();
				paramValues.Add(value);
				paramTypes.Add(value.GetType());

			}
			var method = typeof(CalculationEngine).GetMethod(name, BindingFlags.Public | BindingFlags.Static | BindingFlags.IgnoreCase, paramTypes.ToArray()) ?? typeof(CalculationEngine).GetMethod(name, BindingFlags.Public | BindingFlags.Static | BindingFlags.IgnoreCase);
			if (method != null && method.GetCustomAttribute<NCalcFunctionAttribute>() != null)
			{
				args.Result = method.Invoke(null, paramValues.ToArray());
				return true;
			}

			return false;
		}

		/// <summary>
		/// Converts the value to the provided type
		/// </summary>
		[NCalcFunction]
		public static Object Cast(Object value, String nameOfType)
		{
			var type = Type.GetType(nameOfType);
			if (type == null)
				throw new ArgumentException($"{nameof(Cast)} function parameter {nameof(nameOfType)} invalid.  Expects a valid .net type.");
			return Convert.ChangeType(value, type, CultureInfo.InvariantCulture);
		}

		/// <summary>
		/// Converts the value to a string
		/// </summary>
		[NCalcFunction]
		public static String CStr(Object value) => value.ToString();

		/// <summary>
		/// Converts the value to an integer
		/// </summary>
		[NCalcFunction]
		public static Int32 CInt(Object value) => Convert.ToInt32(value);

		/// <summary>
		/// Converts the value to a double
		/// </summary>
		[NCalcFunction]
		public static Double CDbl(Object value) => Convert.ToDouble(value);

		/// <summary>
		/// Converts the value to a boolean
		/// </summary>
		[NCalcFunction]
		public static Boolean CBool(Object value) => Convert.ToBoolean(value);

		/// <summary>
		/// Converts the value to a datetime
		/// </summary>
		[NCalcFunction]
		public static DateTime CDate(Object value) => Convert.ToDateTime(value);

		/// <summary>
		/// Formats the provided integer using the given format
		/// </summary>
		[NCalcFunction]
		public static String Format(Int32 value, String format) => value.ToString(format);

		/// <summary>
		/// Formats the provided double using the given format
		/// </summary>
		[NCalcFunction]
		public static String Format(Double value, String format) => value.ToString(format);

		/// <summary>
		/// Formats the provided date time using the given format
		/// </summary>
		[NCalcFunction]
		public static String Format(DateTime value, String format) => value.ToString(format);

		/// <summary>
		/// Runs the generator for the definition file provided
		/// </summary>
		/// <param name="definitionPath">The path to the definition file</param>
		/// <returns>The result of the generation</returns>
		[NCalcFunction]
		public static String Generate(String definitionPath) => Generate(definitionPath, null);

		/// <summary>
		/// Runs the generator for the definition file provided
		/// </summary>
		/// <param name="name">The path to the definition file</param>
		/// <returns>The result of the generation</returns>
		[NCalcFunction]
		public static String Generate(String name, params String[] parameters)
		{
			ExceptionDispatchInfo edi;
			try
			{
				var definition = DataAccess.DataAccess.Instance.GetDefinition(name).Definition;
				if (parameters != null)
				{
					foreach (var parameter in parameters)
					{
						var parts = parameter.Split('=');
						definition.Parameters[parts[0]].Value = parts[1];
					}
				}
				if (definition == null) throw new Exceptions.DefinitionNotFoundException(name);
				return definition.Generate();
			}
			catch (Exceptions.DefinitionNotFoundException)
			{
				throw;
			}
			catch (Exception ex)
			{
				edi = ExceptionDispatchInfo.Capture(ex);
				ex.AddData(nameof(name), name);
			}
			edi?.Throw();
			return String.Empty;
		}

		/// <summary>
		/// Returns result if value is true otherwise returns empty string
		/// </summary>
		[NCalcFunction]
		public static String IIF(Boolean value, String result) => value ? result : String.Empty;

		/// <summary>
		/// Simulates rolling a single die
		/// </summary>
		[NCalcFunction]
		public static Int32 Roll(Int32 sides) => Roll(1, sides);

		/// <summary>
		/// Simulates rolling dice
		/// </summary>
		[NCalcFunction]
		public static Int32 Roll(Int32 count, Int32 sides) => Roll(count, sides, String.Empty);

		/// <summary>
		/// Simulates rolling dice
		/// </summary>
		[NCalcFunction]
		public static Int32 Roll(Int32 count, Int32 sides, String options)
		{
			if (sides < 2) throw new ArgumentOutOfRangeException(nameof(sides), sides, "Must be greater than 1");
			if (count < 1) throw new ArgumentOutOfRangeException(nameof(count), count, "Must be greater than 0");
			var roller = new DiceRoller();
			return roller.Roll(count, sides, options);
		}

        /// <summary>
        /// Selects an item from the list
        /// </summary>
		[NCalcFunction]
        public static dynamic Pick(params String[] parameters)
        {
            if (parameters.Length > 0)
			{
                var index = Utility.Random.RandomNumber(0, parameters.Length - 1);
				return parameters[index];
            }
            else
            {
                throw new ArgumentException("Requires at least one value.");
            }
        }

		/// <summary>
		/// Selects an item from the list using weights
		/// </summary>
		[NCalcFunction]
		public static dynamic PickW(params String[] parameters)
		{
			if (parameters.Length > 0)
			{
				var parsed = new List<(String Value, UInt32 Weight)>();
				foreach (var parameter in parameters)
				{
					var parts = parameter.Split(':').Select(p => p.Trim()).ToArray();
					if (parts.Length == 1)
						parsed.Add(new(parts[0], 1));
					else
						parsed.Add(new(parts[0], UInt32.Parse(parts[1])));
				}
				var total = (Int32)parsed.Sum(i => i.Weight);
				var index = Utility.Random.RandomNumber(1, total);
				var current = (UInt32)0;

				foreach (var (Value, Weight) in parsed)
				{
					current += Weight;
					if (index <= current) return Value;
				}

				throw new Exceptions.DefinitionException($"Error in {nameof(PickW)}");
			}
			else
			{
				throw new ArgumentException("Requires at least one value.");
			}
		}

		/// <summary>
		/// Generates a random number between 0 and <paramref name="max">max</paramref> inclusive
		/// </summary>
		[NCalcFunction]
		public static Int32 Random(Int32 max) => Random(0, max);

		/// <summary>
		/// Generates a random number between <paramref name="min"/> and <paramref name="max"/> inclusive
		/// </summary>
		[NCalcFunction]
		public static Int32 Random(Int32 min, Int32 max) => Utility.Random.RandomNumber(min, max);

		/// <summary>
		/// Determines if the article should be A or An
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		[NCalcFunction]
		public static String AddIndefiniteArticle(String value)
		{
			return value.AddIndefiniteArticle();
		}

		/// <summary>
		/// Adds a random article
		/// </summary>
		[NCalcFunction]
		public static String RandomArticle(String value)
		{
			var i = Random(100);

			if (i < 50) return $"the {value}";
			else return value.AddIndefiniteArticle();
		}

		/// <summary>
		/// Pluralizes the provided English word
		/// </summary>
		[NCalcFunction]
		public static String Pluralize(String value)
		{
			var pluralizer = new Pluralizer();
			return pluralizer.Pluralize(value);
		}

		/// <summary>
		/// Pluralizes the provided English word
		/// </summary>
		[NCalcFunction]
		public static String Singularize(String value)
		{
			var pluralizer = new Pluralizer();
			return pluralizer.Singularize(value);
		}

		/// <summary>
		/// Converts a number to an ordinal
		/// </summary>
		[NCalcFunction]
		public static String ToOrdinal(Int32 value) => value.ToOrdinal();

		/// <summary>
		/// Converts a number to Roman numerals
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		[NCalcFunction]
		public static String ToRoman(Double value) => ((Int32)value).ToRomanNumerals();

		/// <summary>
		/// Converts a number to a text string
		/// </summary>
		[NCalcFunction]
        public static String ToText(Int32 value) => value.ToText();

		/// <summary>
		/// Converts a number to a text string
		/// </summary>
		[NCalcFunction]
		public static String ToText(Int32 value, TextCases textCase) => value.ToText(textCase);

        /// <summary>
        /// Converts a string to lower case
        /// </summary>
		[NCalcFunction]
        public static String LCase(String value) => value.LCase();

        /// <summary>
        /// Converts a string to Title Case
        /// </summary>
		[NCalcFunction]
        public static String TCase(String value) => value.TCase();

        /// <summary>
        /// Converts a string to UPPER CASE
        /// </summary>
		[NCalcFunction]
        public static String UCase(String value) => value.UCase();

		/// <summary>
		/// Converts a string to Sentence case
		/// </summary>
		[NCalcFunction]
		public static String SCase(String value) => value.SCase();

		public class SwitchCase
		{
			public SwitchCase(Object c, Object v) => (Case, Value) = (c, v);

			public Object Case { get; set; }
			public Object Value { get; set; }
		}

		[NCalcFunction]
		public static String Trim(String value) => value.Trim();

		[NCalcFunction]
		public static Object Switch(Object value, Object defaultValue, List<SwitchCase> cases)
		{
			foreach (var switchCase in cases)
			{
				if (value.Equals(switchCase.Case)) return switchCase.Value;
			}

			return defaultValue;
		}
        #endregion

    }
}
