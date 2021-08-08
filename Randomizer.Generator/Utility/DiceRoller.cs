using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCalc;

namespace Randomizer.Generator.Utility
{
	/// <summary>
	/// Handles rolling dice
	/// </summary>
    class DiceRoller
    {
        #region Constants
        private const String KEEP_HIGHEST = "KH";
        private const String KEEP_LOWEST = "KL";
		private const String GREATER_THAN_OR_EQUAL_TO = "GE";
        private const String GREATER_THAN = "GT";
		private const String LESS_THAN_OR_EQUAL_TO = "LE";
        private const String LESS_THAN = "LT";
        private const String EXPLODING_DICE = "EX";
        private const String COMPOUND_EXPLODING_DICE = "CEX";
        private const String RULE_OF_ONE = "R1";
		#endregion

		#region Properties
		/// <summary>
		/// Keep the Highest n Rolls (KH)
		/// </summary>
		public Int32 KeepHighest { get; set; } = 0;
        /// <summary>
        /// Keep the Lowest n Rolls (KL)
        /// </summary>
        public Int32 KeepLowest { get; set; } = 0;
        /// <summary>
        /// Exploding Dice (EX)
        /// </summary>
        public Boolean Exploding { get; set; } = false;
        /// <summary>
        /// Compound Exploding Dice (CEX)
        /// </summary>
        public Boolean CompoundExploding { get; set; } = false;
        /// <summary>
        /// Keep Rolls Greater Than Target (GT)
        /// </summary>
        public Int32 GreaterThan { get; set; } = 0;
        /// <summary>
        /// Keep Rolls Less Than Target (LT)
        /// </summary>
        public Int32 LessThan { get; set; } = 0;
        /// <summary>
        /// Subtract Rolls of 1 from GreaterThan Results (R1)
        /// </summary>
        public Boolean RuleOfOne { get; set; } = false;

        /// <summary>
        /// The list of rolls from the last Roll
        /// </summary>
        public List<Int32> Rolls { get; set; }
        /// <summary>
        /// The result of the last roll
        /// </summary>
        public Int32 Result { get; set; }
        #endregion

        #region Public Methods
        /// <summary>
        /// Rolls a single die
        /// </summary>
        /// <param name="sides">The number of sides on the dice.  The value must be greater than 1</param>
        /// <exception cref="ArgumentOutOfRangeException">If value of <paramref name="sides"/> is less than 2 </exception>
        /// <returns>The result of the dice roll</returns>
        public Int32 Roll(Int32 sides)
        {            
            return Roll(1, sides, String.Empty);
        }

        /// <summary>
        /// Rolls multiple dice
        /// </summary>
        /// <param name="count">The number of dice to roll.  The value must be greater than 0</param>
        /// <param name="sides">The number of sides on the dice.  The value must be greater than 1</param>
        /// <exception cref="ArgumentOutOfRangeException">If value of <paramref name="count"/> is less than 1 or <paramref name="sides"/> is less than 2 </exception>
        /// <returns>The result of the dice roll</returns>
        public Int32 Roll(Int32 count, Int32 sides)
        {
            return Roll(count, sides, String.Empty);
        }

        /// <summary>
        /// Rolls multiple dice with additional options
        /// </summary>
        /// <param name="count">The number of dice to roll.  The value must be greater than 0</param>
        /// <param name="sides">The number of sides on the dice.  The value must be greater than 1</param>
        /// <param name="options">The options to use in the dice roll as listed in the remarks.</param>
        /// <exception cref="ArgumentOutOfRangeException">If value of <paramref name="count"/> is less than 1 or <paramref name="sides"/> is less than 2 </exception>
        /// <remarks>The following options are available:
        /// KH = Keep Highest Die Rolled
        /// KH(n) = Keep Higest n Dice Rolled
        /// KL = Keep Lowest Die Rolled
        /// KL(n) = Keep Lowest n Dice Rolled
        /// EX = Exploding Dice
        /// CEX = Compounding Exploding Dice
        /// GT(n) = Count Rolls Greater Than the Target Number n
        /// LT(n) = Count Rolls Less Than the Target Number n
        /// R1 = Rule of One, Subtract Results of 1 From GT(n)
        /// </remarks>
        /// <returns>The result of the dice roll</returns>
        public Int32 Roll(Int32 count, Int32 sides, String options)
        {
            if (sides <= 1) throw new ArgumentOutOfRangeException(nameof(sides), sides, "Sides must be greater than 1");
            if (count <= 0) throw new ArgumentOutOfRangeException(nameof(count), count, "Count must be greater than 0");
            Rolls = new List<Int32>();

            if (String.IsNullOrWhiteSpace(options))
            {
                for (var i = 1; i <= count; i++)
                {
                    Rolls.Add(Random.RandomNumber(1, sides));
                }
            }
            else
            {
                foreach (var option in options.Split(",").Select(op => op.Trim()))
                {
                    var calc = new Expression(option);
                    calc.EvaluateFunction += EvaluateFunctionHandler;
                    calc.EvaluateParameter += EvaluateParameterHandler;
                    calc.Evaluate();
                }

                for (var i = 1; i <= count; i++)
                {
                    var value = Random.RandomNumber(1, sides);
                    if ((Exploding || CompoundExploding) && value == sides)
                    {
                        var lastRoll = 0;
                        do
                        {
                            lastRoll = Random.RandomNumber(1, sides);
                            value += lastRoll;
                        } while (CompoundExploding && lastRoll == sides);
                    }
                    Rolls.Add(value);
                }
            }

            if (KeepHighest > 0)
            {
                while (Rolls.Count > KeepHighest)
                {
                    Rolls.Remove(Rolls.Min());
                }
            }
            else if (KeepLowest > 0)
            {
                while (Rolls.Count < KeepLowest)
                {
                    Rolls.Remove(Rolls.Max());
                }
            }
            if (GreaterThan > 0)
            {
                Result = Rolls.Count(r => r > GreaterThan) - (RuleOfOne ? Rolls.Count(r => r == 1) : 0);
            }
            else if (LessThan > 0)
            {
                Result = Rolls.Count(r => r < LessThan);
            }
            else
            {
                Result = Rolls.Sum();
            }
            return Result;
        }
        #endregion

        #region Private Methods
        void EvaluateFunctionHandler(String name, FunctionArgs args)
        {
            switch (name.ToUpper())
            {
                case KEEP_HIGHEST:
                    KeepHighest = (Int32)args.Parameters[0].Evaluate();
                    args.Result = 0;
                    break;
                case KEEP_LOWEST:
                    KeepLowest = (Int32)args.Parameters[0].Evaluate();
                    args.Result = 0;
                    break;
				case GREATER_THAN_OR_EQUAL_TO:
					GreaterThan = (Int32)args.Parameters[0].Evaluate();
					GreaterThan--;
					args.Result = 0;
					break;
				case GREATER_THAN:
                    GreaterThan = (Int32)args.Parameters[0].Evaluate();
                    args.Result = 0;
                    break;
				case LESS_THAN_OR_EQUAL_TO:
					LessThan = (Int32)args.Parameters[0].Evaluate();
					LessThan++;
					args.Result = 0;
					break;
                case LESS_THAN:
                    LessThan = (Int32)args.Parameters[0].Evaluate();
                    args.Result = 0;
                    break;
            }
        }

        void EvaluateParameterHandler(String name, ParameterArgs args)
        {
            switch (name.ToUpper())
            {
                case EXPLODING_DICE: 
                    Exploding = true;
                    CompoundExploding = false;
                    args.Result = 0;
                    break;
                case COMPOUND_EXPLODING_DICE:
                    Exploding = false;
                    CompoundExploding = true;
                    args.Result = 0;
                    break;
                case KEEP_HIGHEST:
                    KeepHighest = 1;
                    KeepLowest = 0;
                    args.Result = 0;
                    break;
                case KEEP_LOWEST:
                    KeepHighest = 0;
                    KeepLowest = 1;
                    args.Result = 0;
                    break;
                case RULE_OF_ONE:
                    RuleOfOne = true;
                    args.Result = 0;
                    break;
            }
        }
        #endregion
    }
}
