using JsonSubTypes;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Randomizer.Generator.Table
{
	/// <summary>
	/// Base class for all table types
	/// </summary>
	public abstract class BaseTable 
	{
		#region Constants
		/// <summary>Denotes the token is an NCalc expression</summary>
		private const String EXPRESSION_TOKEN = "=";
		/// <summary>Denotes the row in the table is a comment and should be ignored</summary>
		private const String COMMENT_TOKEN = "//";
		/// <summary>Delimiter used to separate table columns</summary>
		private const String DELIMITER_TOKEN = "|";
		#endregion

		#region Delegates
		/// <summary>
		/// Implemented in child classes to Evaluate the table
		/// </summary>
		[JsonIgnore]
		public Func<String, Object> Evaluate;
		#endregion

		#region Properties
		/// <summary>An expression that determines the number of times to repeat the table evaluation.  Default is 1</summary>
		public String Repeat { get; set; } = "1";
		/// <summary>An expression that denotes if the table should be skipped</summary>
		public String SkipTable { get; set; }
		/// <summary>The formatted table string</summary>
		public String Value { get; set; }
		/// <summary>The string to use between values when repeat is greater than 1</summary>
		public String RepeatJoin { get; set ; }
		/// <summary>The parsed table</summary>
		protected Table Table { get; set; }
		#endregion

		#region Public Methods
		/// <summary>
		/// Processes the table and returns the results
		/// </summary>
		public Dictionary<String, String> ProcessTable()
		{
			if (String.IsNullOrWhiteSpace(SkipTable) || !OnEvaluate<Boolean>(SkipTable))
			{				
				ParseTable();
				return ProcessTableInternal();
			}

			return new Dictionary<String, String>();
		}
		#endregion

		#region Protected Methods
		/// <summary>
		/// When overriden in a child class, handles processing of the table
		/// </summary>
		protected abstract Dictionary<String, String> ProcessTableInternal();

		/// <summary>
		/// Evaluates the provided expression 
		/// </summary>
		/// <param name="expression">The expression to evaluate</param>
		protected T OnEvaluate<T>(object expression)
		{
			var isString = expression.GetType() == typeof(string);
			var value = expression;
			var parseMethod = typeof(T).GetMethod("Parse", new Type[] { typeof(string) });
			if (isString && ((string)expression).StartsWith(EXPRESSION_TOKEN))
			{
				value = Evaluate?.Invoke(expression.ToString()[1..]);
			}

			if (isString && parseMethod != null)
			{
				return (T)parseMethod.Invoke(null, new object[] { value });
			}
			else
			{
				return (T)Convert.ChangeType(value, typeof(T));
			}
		}

		/// <summary>
		/// Processes a row and set puts the result into the <paramref name="result"/> 
		/// </summary>
		/// <param name="result">The results of the process</param>
		/// <param name="row">The index of the row to process</param>
		protected virtual void ProcessRow(Dictionary<String, String> result, Int32 row)
		{
			if (row >= 0 && row < Table.RowCount)
			{
				foreach (Column column in Table.Columns)
				{
					var value = OnEvaluate<object>(column[row]);
					if (result.ContainsKey(column.Name))
					{
						result[column.Name] = $"{result[column.Name]}{RepeatJoin}{value}";
					}
					else
					{
						result[column.Name] = (String)value;
					}
				}
			}
		}

		/// <summary>
		/// Gets or evaluates the value of the repeat property
		/// </summary>
		protected Int32 GetRepeat()
		{
			if (string.IsNullOrWhiteSpace(Repeat)) return 1;
			return OnEvaluate<Int32>(Repeat);
		}
		#endregion

		#region Private Methods
		/// <summary>
		/// Parses the delimited table
		/// </summary>
		private void ParseTable()
		{
			Table = new();

			if (!string.IsNullOrWhiteSpace(Value))
			{
				using var reader = new System.IO.StringReader(Value);
				using var parser = new TextFieldParser(reader);

				parser.Delimiters = new string[] { DELIMITER_TOKEN };
				parser.TextFieldType = FieldType.Delimited;
				parser.CommentTokens = new string[] { COMMENT_TOKEN };
				parser.HasFieldsEnclosedInQuotes = true;
				parser.TrimWhiteSpace = true;

				var headers = parser.ReadFields();
				foreach (var header in headers)
				{
					Table.AddColumn(header);
				}

				while (!parser.EndOfData)
				{
					var fields = parser.ReadFields();
					Table.AddRow(fields);
				}
			}
		} 
		#endregion
	}
}
