using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCalc;
using Randomizer.Generator.Core;
using Randomizer.Generator.Utility;

namespace Randomizer.Generator.Table
{
	public class TableDefinition : BaseDefinition
	{
		public InsensitiveDictionary<BaseTable> Tables { get; set; } = new();
		public String Output { get; set; }
		public InsensitiveDictionary<Object> Values { get; } = new();

		public override String Generate()
		{
			Values.Clear();
			foreach (var table in Tables)
			{
				table.Value.Evaluate += Calculate;
				var results = table.Value.ProcessTable();
				foreach (var result in results)
				{
					Values.Add($"{table.Key}.{result.Key}", result.Value);
				}
				table.Value.Evaluate -= Calculate;
			}
			return PopulateOutput();
		}

		private String PopulateOutput()
		{
			if (String.IsNullOrEmpty(Output))
				return "Output is empty";
			return Evaluate(Output);
		}

		private String Evaluate(string expression)
		{
			var tokens = Assignment.Tokenizer.Tokenize(expression);
			var result = new StringBuilder();

			foreach (var token in tokens)
			{
				switch (token.TokenType)
				{
					case Assignment.TokenTypes.Text:
						result.Append(token.Value);
						break;
					case Assignment.TokenTypes.Item:
					case Assignment.TokenTypes.Variable:
						var variable = Calculate($"[{token.Value}]");
						result.Append(Evaluate(variable));
						break;
					case Assignment.TokenTypes.Equation:
						var expressionValue = Calculate(token.Value);
						result.Append(Evaluate(expressionValue));
						break;
				}
			}

			return result.ToString();
		}

		protected override void EvaluateFunction(String name, FunctionArgs e)  => throw new NotImplementedException();

		protected override void EvaluateParameter(String name, ParameterArgs e)
		{
			if (Values.ContainsKey(name))
				e.Result = Values[name];
		}
	}
}
