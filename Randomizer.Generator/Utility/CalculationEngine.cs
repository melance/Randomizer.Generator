using NCalc;
using System;
using System.Globalization;

namespace Randomizer.Generator.Utility
{
    class CalculationEngine : Expression
    {
        #region Constants
        private const String DICE_SHORT = "D";
        private const String DICE_LONG = "DICE";
        private const String RANDOM_SHORT = "RAND";
        private const String RANDOM_LONG = "RANDOM";
        private const String PICK_ITEM = "PICK";
        private const String TO_UPPER_CASE = "UCASE";
        private const String TO_LOWER_CASE = "LCASE";
        private const String TO_TITLE_CASE = "TCASE";
        private const String TO_ORDINAL = "ORDINAL";
        private const String TO_TEXT = "TOTEXT";
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
            switch (name.ToUpper())
            {
                case DICE_SHORT:
                case DICE_LONG:
                    Dice(name, args);                    
                    break;
                case RANDOM_SHORT:
                case RANDOM_LONG:
                    Random(name, args);
                    break;
                case PICK_ITEM:
                    Pick(name, args);
                    break;
                case TO_UPPER_CASE:
                    UCase(name, args);
                    break;
                case TO_LOWER_CASE:
                    LCase(name, args);
                    break;
                case TO_TITLE_CASE:
                    TCase(name, args);
                    break;
                case TO_ORDINAL:
                    ToOrdinal(name, args);
                    break;
                case TO_TEXT:
                    ToText(name, args);
                    break;
            }
        }        

        public void EvaluateParameterHandler(String name, ParameterArgs args)
        {

        }
        #endregion

        #region Static Methods
        /// <summary>
        /// Simulates rolling dice
        /// </summary>
        private static void Dice(String name, FunctionArgs args)
        {
            Int32 count;
            Int32 sides;
            string options;
            var roller = new DiceRoller();

            switch (args.Parameters.Length)
            {
                case 1:
                    sides = ValidateParameterType<Int32>(name, nameof(sides), args.Parameters[0].Evaluate());
                    args.Result = roller.Roll(sides);
                    break;
                case 2:
                    count = ValidateParameterType<Int32>(name, nameof(sides), args.Parameters[0].Evaluate());
                    sides = ValidateParameterType<Int32>(name, nameof(sides), args.Parameters[1].Evaluate());
                    args.Result = roller.Roll(count, sides);
                    break;
                case 3:
                    count = ValidateParameterType<Int32>(name, nameof(sides), args.Parameters[0].Evaluate());
                    sides = ValidateParameterType<Int32>(name, nameof(sides), args.Parameters[1].Evaluate());
                    options = ValidateParameterType<String>(name, nameof(options), args.Parameters[2].Evaluate());
                    args.Result = roller.Roll(count, sides, options);
                    break;
                default: throw new EvaluationException($"Function {name} requires 1 to 3 parameters");

            }
        }

        /// <summary>
        /// Selects an item from the list
        /// </summary>
        private static void Pick(String name, FunctionArgs args)
        {
            if (args.Parameters.Length > 0)
            {
                var parameters = args.EvaluateParameters();
                var index = Utility.Random.RandomNumber(0, parameters.Length - 1);
                args.Result = parameters[index];
            }
            else
            {
                throw new EvaluationException($"{name} requires at least one parameter");
            }
        }

        /// <summary>
        /// Generates a random number
        /// </summary>
        private static void Random(String name, FunctionArgs args)
        {
            Int32 min;
            Int32 max;

            switch (args.Parameters.Length)
            {
                case 1:
                    max = ValidateParameterType<Int32>(name, nameof(max), args.Parameters[0].Evaluate());
                    args.Result = Utility.Random.RandomNumber(0, max);
                    break;
                case 2:
                    min = ValidateParameterType<Int32>(name, nameof(min), args.Parameters[0].Evaluate());
                    max = ValidateParameterType<Int32>(name, nameof(max), args.Parameters[1].Evaluate());
                    args.Result = Utility.Random.RandomNumber(min, max);
                    break;
                default: throw new EvaluationException($"Function {name} requires 1 or 2 parameters");

            }
        }

        /// <summary>
        /// Converts a number to an ordinal
        /// </summary>
        private static void ToOrdinal(String name, FunctionArgs args)
        {
            Int32 value;

            if (args.Parameters.Length == 1)
            {
                value = ValidateParameterType<Int32>(name, nameof(value), args.Parameters[0].Evaluate());
                args.Result = value.ToOrdinal();
            }
            else
            {
                throw new EvaluationException($"Function {name} requires 1 parameter");
            }
        }


        /// <summary>
        /// Converts a number to a text string
        /// </summary>
        private static void ToText(String name, FunctionArgs args)
        {
            Int32 value;

            if (args.Parameters.Length == 1)
            {
                value = ValidateParameterType<Int32>(name, nameof(value), args.Parameters[0].Evaluate());
                args.Result = value.ToText();
            }
            else
            {
                throw new EvaluationException($"Function {name} requires 1 parameter");
            }
        }

        /// <summary>
        /// Converts a string to lower case
        /// </summary>
        private static void LCase(String name, FunctionArgs args)
        {
            String value;
            if (args.Parameters.Length == 1)
            {
                value = ValidateParameterType<String>(name, nameof(value), args.Parameters[0].Evaluate());
                args.Result =  value.LCase();
            }
            else
            {
                throw new EvaluationException($"Function {name} requires 1 parameter");
            }
        }

        /// <summary>
        /// Converts a string to Title Case
        /// </summary>
        private static void TCase(String name, FunctionArgs args)
        {
            if (args.Parameters.Length == 1)
            {
                var value = ValidateParameterType<String>(name, "value", args.Parameters[0].Evaluate());
                args.Result = value.TCase();
            }
            else
            {
                throw new EvaluationException($"Function {name} requires 1 parameter");
            }
        }

        /// <summary>
        /// Converts a string to UPPER CASE
        /// </summary>
        private static void UCase(String name, FunctionArgs args)
        {
            if (args.Parameters.Length == 1)
            {
                var value = ValidateParameterType<String>(name, "value", args.Parameters[0].Evaluate());
                args.Result = value.UCase();
            }
            else
            {
                throw new EvaluationException($"Function {name} requires 1 parameter");
            }
        }

        /// <summary>
        /// Returns the value cast to the type if the cast is possible otherwise throws and exception
        /// </summary>
        private static T ValidateParameterType<T>(String functionName, String parameterName, dynamic value)
        {
            var type = typeof(T);
            if (value.GetType() != type)
                throw new EvaluationException($"Function {functionName} expected parameter {parameterName} to be {type.ToString().AOrAn()}.  Found type {value.GetType()}");
            return (T)value;
        }        
        #endregion

    }
}
