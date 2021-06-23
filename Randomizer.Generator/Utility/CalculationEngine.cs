using NCalc;
using System;
using System.Linq;
using System.Globalization;
using Randomizer.Generator.Attributes;
using System.Reflection;
using System.Collections.Generic;

namespace Randomizer.Generator.Utility
{
    class CalculationEngine : Expression
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
        /// <summary>
        /// Evaluates the expression
        /// </summary>
        public T Evaluate<T>()
        {
            var result = Evaluate();
            if (result.GetType().Equals(typeof(T)))
            {
                return (T)result;
            }
            else
            {
                return (T)Convert.ChangeType(result, typeof(T));
            }
        }

        public void EvaluateFunctionHandler(String name, FunctionArgs args)
        {
			ExecuteFunction(name, args);			
        }        

        public void EvaluateParameterHandler(String name, ParameterArgs args)
        {

        }
		#endregion

		#region Static Methods
		/// <summary>
		/// Executes the named function
		/// </summary>
		private static Boolean ExecuteFunction(String name, FunctionArgs args)
		{
			var paramValues = new List<dynamic>();
			var paramTypes = new List<Type>();
			for (var i = 0; i < args.Parameters.Length; i++)
			{
				var value = args.Parameters[i].Evaluate();
				paramValues.Add(value);
				paramTypes.Add(value.GetType());

				var method = typeof(CalculationEngine).GetMethod(name, paramTypes.ToArray());

				if (method != null && method.GetCustomAttribute<NCalcFunctionAttribute>() != null)
				{
					args.Result = method.Invoke(null, paramValues.ToArray());
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// Simulates rolling a single die
		/// </summary>
		[NCalcFunction]
		public static Int32 Roll(Int32 sides)
		{
			return Roll(1, sides);
		}

		/// <summary>
		/// Simulates rolling dice
		/// </summary>
		[NCalcFunction]
		public static Int32 Roll(Int32 count, Int32 sides)
		{
			return Roll(count, sides, String.Empty);
		}

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
        public static dynamic Pick(params dynamic[] parameters)
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
        /// Generates a random number between 0 and <paramref name="max">max</paramref> inclusive
        /// </summary>
		[NCalcFunction]
        public static Int32 Random(Int32 max)
        {
			return Random(0, max);
        }

		/// <summary>
		/// Generates a random number between <paramref name="min"/> and <paramref name="max"/> inclusive
		/// </summary>
		[NCalcFunction]
		public static Int32 Random(Int32 min, Int32 max)
		{
			return Utility.Random.RandomNumber(min, max);
		}


		/// <summary>
		/// Converts a number to an ordinal
		/// </summary>
		[NCalcFunction]
		public static String ToOrdinal(Int32 value)
        {
            return value.ToOrdinal();            
        }

        /// <summary>
        /// Converts a number to a text string
        /// </summary>
		[NCalcFunction]
        public static String ToText(Int32 value)
        {
            return value.ToText();            
        }

        /// <summary>
        /// Converts a string to lower case
        /// </summary>
		[NCalcFunction]
        public static String LCase(String value)
        {
			return value.LCase();
        }

        /// <summary>
        /// Converts a string to Title Case
        /// </summary>
		[NCalcFunction]
        public static String TCase(String value)
        {            
            return value.TCase();
         }

        /// <summary>
        /// Converts a string to UPPER CASE
        /// </summary>
		[NCalcFunction]
        public static String UCase(String value)
        {
            return value.UCase();
        }        
        #endregion

    }
}
