using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCalc;
using Randomizer.Generator.Core;
using Randomizer.Generator.Exceptions;
using Randomizer.Generator.Utility;
using System.IO;

namespace Randomizer.Generator.Assignment
{
    /// <summary>
    /// Using a series of line items containing line item references, equations, and variables generates random content
    /// </summary>
    public class AssignmentDefinition : BaseDefinition
    {		
		#region Constants
		private const string START_ITEM = "Start"; 
        private const Int32 MAX_RECURSION_DEPTH = 1000;
        private const Int32 MAX_LOOP_COUNT = 10000000;
        #endregion

        #region Members
        private Int32 _loopCount;
        private Int32 _recursionDepth;
		private Boolean _importComplete = false;
		#endregion

		#region Properties
		/// <summary>List of line items used in the generator</summary>
		public LineItemDictionary LineItems { get; set; } = new();
		/// <summary>List of imported assignment generators</summary>
		public List<String> Imports { get; set; } = new();
		private InsensitiveDictionary<String> Variables { get; set; } = new();
		#endregion

		#region Public Methods
		/// <summary>
		/// Generates random content
		/// </summary>
		public override string Generate()
        {
            var value = string.Empty;
            var next = START_ITEM;
            LineItem item;
			LoadImports();

            _loopCount = 0;
            _recursionDepth = 0;

            do
            {
                item = LineItems[next].SelectRandomItem();
                value += EvaluateLineItem(item);
                next = item.Next;
            } while (!String.IsNullOrWhiteSpace(next));

            return value;
        }
		#endregion

		#region Protected Methods
		protected virtual AssignmentDefinition LoadImport(String importPath)
		{
			return (AssignmentDefinition)Deserialize(File.ReadAllText(importPath));
		}

		protected virtual void LoadImports()
		{
			if (!_importComplete)
			{
				foreach (var import in Imports)
				{
					var definition = LoadImport(import);
					if (definition != null)
					{
						foreach (var item in definition.LineItems)
						{
							if (LineItems.ContainsKey(item.Key))
								LineItems[item.Key].AddRange(item.Value);
							else
								LineItems.Add(item.Key, item.Value);
						}
					}
				}
				_importComplete = true;
			}
		}
		#endregion

		#region Private Methods

        private string EvaluateLineItem(LineItem item)
        {
            var result = new StringBuilder();

            _recursionDepth++;
            _loopCount++;
            if (_recursionDepth > MAX_RECURSION_DEPTH) throw new MaxRecursionDepthExceededException(MAX_RECURSION_DEPTH);
            if (_loopCount > MAX_LOOP_COUNT) throw new MaxLoopCountException(MAX_LOOP_COUNT);

            if (!String.IsNullOrWhiteSpace(item.Content))
            {
                var evaluated = EvaluateContent(item.Content);

                if (!String.IsNullOrWhiteSpace(item.Variable))
                {
                    if (!Variables.ContainsKey(item.Variable.ToUpper()))
                        Variables.Add(item.Variable.ToUpper(), String.Empty);
                    Variables[item.Variable.ToUpper()] = evaluated;
                }
                else
                {
                    result.Append(evaluated);
                }
            }
            _recursionDepth--;
            return result.ToString();
        }

        private string EvaluateContent(String content)
        {
            var result = new StringBuilder();
            var tokens = Tokenizer.Tokenize(content);

            foreach (var token in tokens)
            {
                switch (token.TokenType)
                {
                    case TokenTypes.Text:
                        result.Append(token.Value);
                        break;
                    case TokenTypes.Variable:
                        if (Variables.ContainsKey(token.Value))
                            result.Append(Variables[token.Value]);
                        else if (Parameters.ParameterExists(token.Value))
                            result.Append(Parameters[token.Value].Value);
                        break;
                    case TokenTypes.Equation:
                        result.Append(Calculate(token.Value));
                        break;
                    case TokenTypes.Item:
                        var name = token.Value;

                        // If there is a parameter with this name, get the value
                        if (Parameters.ContainsKey(token.Value))
                            name = Parameters[token.Value].Value;

                        // Reevaluate to allow nested items
                        name = EvaluateContent(name);

                        if (LineItems.ContainsKey(name))
                            result.Append(EvaluateLineItem(LineItems[name].SelectRandomItem()));
                        else
                            throw new ItemNotFoundException(token.Value);
                        break;
                }
            }

            return result.ToString();
        }

        protected override void EvaluateFunction(String name, FunctionArgs args)
        {

        }

        protected override void EvaluateParameter(String name, ParameterArgs args)
        {
            if (Variables.ContainsKey(name))
            {
                args.Result = Variables[name];
            }
            else if (Parameters.ContainsKey(name))
            {
                args.Result = Parameters[name].Value;
            }
        }
        #endregion
    }
}
