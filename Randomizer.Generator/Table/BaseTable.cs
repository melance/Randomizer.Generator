using JsonSubTypes;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Randomizer.Generator.Table
{
	public abstract class BaseTable 
	{
		#region Constants
		private const String EXPRESSION_TOKEN = "=";
		private const String COMMENT_TOKEN = "#";
		private const String DELIMITER_TOKEN = "|";
		#endregion

		#region Delegates
		[JsonIgnore]
		public Func<String, Object> Evaluate;
		#endregion

		#region Properties
		public String Repeat { get; set; } = "1";
		public String SkipTable { get; set; }
		public String Value { get; set; }
		public String RepeatJoin { get; set ; }
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
