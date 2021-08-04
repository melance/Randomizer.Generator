using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NCalc;
using Newtonsoft.Json;
using Randomizer.Generator.Core;
using Randomizer.Generator.Utility;

namespace Randomizer.Generator.Table
{
	public class TableDefinition : BaseDefinition
	{
		#region Properties
		[JsonProperty(Order = 102)]
		public InsensitiveDictionary<BaseTable> Tables { get; set; } = new();
		[JsonProperty(Order = 101)]
		public String Output { get; set; }
		private InsensitiveDictionary<Object> Values { get; } = new();
		public override Boolean SupportsParameters => true;
		#endregion

		#region Public Methods
		public override String Generate()
		{
			if (ValidateParameters())
			{
				Values.Clear();
				foreach (var table in Tables)
				{
					EvaluateTable(table.Key, table.Value);
				}
				return PopulateOutput(); 
			}
			return String.Empty;
		}

		public override String Analyze(AnalyzeOptions options)
		{
			var analysis = new AnalysisWriter(base.Analyze(options));

			analysis.AppendHeader("Table");
			analysis.AppendItemValue("Table Count", Tables.Count);
			analysis.AppendHeader("Output");
			analysis.AppendLine(Output);
			analysis.AppendHeader("Tables");

			foreach (var table in Tables)
			{
				analysis.AppendItemValue("Name", table.Key);
				analysis.AppendItemValue("Table Type", table.Value.GetType().Name);
				analysis.AppendItemValue("Skip Table", table.Value.SkipTable);
				analysis.AppendItemValue("Repeat", table.Value.Repeat);
				analysis.AppendItemValue("Repeat Join", table.Value.RepeatJoin);
				analysis.AppendItemValue("Enumerate Repeat", table.Value.EnumerateRepeat);
				switch (table.Value.GetType().Name)
				{
					case "LoopTable":
						var loopTable = (LoopTable)table.Value;
						analysis.AppendItemValue("Key Column", loopTable.KeyColumn);
						break;
					case "RandomTable":
						var randomTable = (RandomTable)table.Value;
						analysis.AppendItemValue("Roll Column", randomTable.RollColumn);
						analysis.AppendItemValue("Modifier", randomTable.Modifier);
						break;
					case "SelectTable":
						var selectTable = (SelectTable)table.Value;
						analysis.AppendItemValue("Select Column", selectTable.SelectColumn);
						analysis.AppendItemValue("Select Value", selectTable.SelectValue);
						break;
				}
				analysis.AppendLine();
				if (options.HasFlag(AnalyzeOptions.IterateItems))
				{
					analysis.AppendLine(table.Value.Table);
					analysis.AppendLine();
				}
			}

			return analysis.ToString();
		}
		#endregion

		#region Private Methods
		private void EvaluateTable(String key, BaseTable table, Boolean dontCheckSkip = false)
		{
			table.Evaluate += Calculate;
			var results = dontCheckSkip ? table.ProcessTableNoCheck() : table.ProcessTable();
			foreach (var result in results)
			{
				Values.Add($"{key}.{result.Key}", result.Value);
			}
			table.Evaluate -= Calculate;
		}

		private String PopulateOutput()
		{
			ExceptionDispatchInfo exi;
			try
			{
				if (String.IsNullOrEmpty(Output))
					return "Output is empty";
				return Evaluate(Output);
			}
			catch (Exception ex)
			{
				exi = ExceptionDispatchInfo.Capture(ex);
				exi.SourceException.AddData("Location: ", "Output");
			}
			exi.Throw();
			return String.Empty;
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

		private void TableFunction(String name, String repeat = "1")
		{
			var table = Tables[name];
			table.Repeat = repeat;
			EvaluateTable(name, table, true);
		}
		#endregion

		#region Protected Methods
		protected override void EvaluateParameter(String name, ParameterArgs e)
		{
			var isNullable = name.EndsWith("?");
			var cleanName = isNullable ? name[..^1] : name;
			if (Values.ContainsKey(cleanName))
				e.Result = Values[cleanName];
			else
			{
				// Convert to regex	
				var regex = cleanName.Replace(".", @"\.").Replace("*", ".");
				var result = Values.Where(v => Regex.IsMatch(v.Key, regex));

				if (result.Any())
				{
					e.Result = result.First().Value;
				}
				else if (isNullable)
				{
					e.Result = String.Empty;
				}
			}
		}

		protected override void EvaluateFunction(String name, FunctionArgs e)
		{
			switch (name.ToLower())
			{
				case "table":
					var tableName = e.Parameters[0].Evaluate().ToString();
					var repeat = e.Parameters.Length == 2 ? e.Parameters[1].Evaluate().ToString() : "1";
					TableFunction(tableName, repeat);
					e.Result = true;
					break;
			}
		}
		#endregion
	}
}
