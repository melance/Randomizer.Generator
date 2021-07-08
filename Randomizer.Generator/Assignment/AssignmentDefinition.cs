using NCalc;
using Newtonsoft.Json;
using Randomizer.Generator.Core;
using Randomizer.Generator.Exceptions;
using Randomizer.Generator.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Randomizer.Generator.Assignment
{
	/// <summary>
	/// Using a series of line items containing line item references, equations, and variables generates random content
	/// </summary>
	public class AssignmentDefinition : BaseDefinition
    {
		#region Constants
		/// <summary>The starting lineitem for generation</summary>
		private const string START_ITEM = "Start"; 
		/// <summary>The maximum level of recursion to allow before aborting the generation process</summary>
        private const Int32 MAX_RECURSION_DEPTH = 1000;
		/// <summary>The maximum number of loops to allow before aborting the generation process</summary>
		private const Int32 MAX_LOOP_COUNT = 10000000;
        #endregion

        #region Members
		/// <summary>Tracks the number of loops that have occured during generation</summary>
        private Int32 _loopCount;
		/// <summary>Tracks the recursion depth during generation</summary>
        private Int32 _recursionDepth;
		/// <summary>Is set to true when importing of <see cref="Imports"/> is complete</summary>
		private Boolean _importComplete = false;
		#endregion

		#region Properties
		/// <summary>List of line items used in the generator</summary>
		[JsonProperty(Order = 102)]
		public LineItemDictionary LineItems { get; set; } = new();
		/// <summary>List of imported assignment generators</summary>
		[JsonProperty(Order = 101)]
		public List<String> Imports { get; set; } = new();
		/// <summary>The case to convert the text to</summary>
		[JsonProperty(Order = 100)]
		public TextCases TextCase { get; set; } = TextCases.None;
		/// <summary>Variables added during generation</summary>
		private InsensitiveDictionary<String> Variables { get; set; } = new();		
		#endregion

		#region Public Methods
		/// <summary>
		/// Generates random content
		/// </summary>
		/// <returns>The generated content</returns>
		public override string Generate() 
        {
			base.Generate();
			var next = START_ITEM;
            LineItem item;
			LoadImports();

            _loopCount = 0;
            _recursionDepth = 0;

            item = LineItems[next].SelectRandomItem();
			var value = EvaluateLineItem(item);

			return value.ToCase(TextCase);
        }
		#endregion

		#region Protected Methods
		/// <summary>
		/// Loads a definition from the list of <see cref="Imports"/>
		/// </summary>
		/// <param name="name">The name to the definition to import</param>
		/// <returns>The <see cref="AssignmentDefinition"/> requested</returns>
		protected virtual AssignmentDefinition LoadImport(String name)
		{
			if (DataAccess.DataAccess.Instance.LibraryExists(name))
				return (AssignmentDefinition)DataAccess.DataAccess.Instance.GetLibrary(name);
			else if (DataAccess.DataAccess.Instance.DefinitionExists(name))
				return (AssignmentDefinition)DataAccess.DataAccess.Instance.GetDefinition(name);
			else
				throw new DefinitionNotFoundException(name);
		}

		/// <summary>
		/// Loads all definitions in the <see cref="Imports"/> list
		/// </summary>
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
		/// <summary>
		/// Evaluates a <see cref="LineItem"/>
		/// </summary>
		/// <param name="item">The <see cref="LineItem"/> to evaluate</param>
		/// <returns>The result of the evaluation</returns>
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
			if (!String.IsNullOrWhiteSpace(item.Next))
				result.Append(EvaluateLineItem(LineItems[item.Next].SelectRandomItem()));
            _recursionDepth--;
            return result.ToString();
        }

		/// <summary>
		/// Processes <see cref="LineItem.Content"/>
		/// </summary>
		/// <param name="content">The content to process</param>
		/// <returns>The result of the evaluation</returns>
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

						// If there are more than on item names in the token, select one
						var parts = name.Split("|");
						if (parts.Length > 1)
							name = parts[Utility.Random.RandomNumber(0, parts.Length - 1)];

                        // If there is a parameter with this name, get the value
                        if (Parameters.ContainsKey(token.Value))
                            name = Parameters[token.Value].Value.ToString();

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

		/// <summary>
		/// Handles providing values for parameters requested by the <see cref="CalculationEngine"/>
		/// </summary>
		/// <param name="name">The name of the parameter</param>
		/// <param name="args">The result of the parameter request</param>
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
