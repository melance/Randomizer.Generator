using Randomizer.Generator.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLua;
using Randomizer.Generator.Core;
using System.IO;
using NCalc;

namespace Randomizer.Generator.Lua
{
	/// <summary>
	/// Generates content via a Lua script
	/// </summary>
	public class LuaDefinition : BaseDefinition
	{
		#region Members
		/// <summary>The lua interpreter .NET wrapper</summary>
		private readonly NLua.Lua _lua = new();
		#endregion

		#region Properties
		/// <summary>The Lua script to be run.</summary>
		/// <remarks>If <see cref="ScriptPath"/> is set, this property is ignored</remarks>
		public String Script {
			get => GetProperty(String.Empty);
			set => SetProperty(value);
		}
		/// <summary>The path to the Lua script to be run.</summary>
		public String ScriptPath {
			get => GetProperty(String.Empty);
			set => SetProperty(value);
		}
		public override Boolean SupportsParameters => true;
		/// <summary>Keeps the results that are printed as the generator is run.</summary>
		private StringBuilder Result { get; set; } = new(); 
		#endregion

		#region Public Methods
		/// <summary>
		/// Generates random content
		/// </summary>
		/// <returns>The content generated</returns>
		public override String Generate()
		{
			if (ValidateParameters())
			{
				foreach (var parameter in Parameters)
				{
					_lua[parameter.Key] = parameter.Value.Value;
				}

				Result.Clear();

				// Register methods in this class marked with the Lua Global Attribute
				LuaRegistrationHelper.TaggedInstanceMethods(_lua, this);
				LuaRegistrationHelper.TaggedStaticMethods(_lua, typeof(LuaDefinition));

				// Prevent imports to sandbox the script
				_lua.DoString("import = function () end");

				// Load the script if ScriptPath is set
				var script = GetScript();

				_lua.DoString(script, Name);

				return Result.ToString(); 
			}
			return String.Empty;
		}

		public override String Analyze(AnalyzeOptions options)
		{
			var analysis = new AnalysisWriter(base.Analyze(options));

			analysis.AppendHeader("LUA");

			analysis.AppendItemValue("Script Path", ScriptPath);

			if (options.HasFlag(AnalyzeOptions.ShowScript))
			{
				analysis.AppendHeader("Script");
				analysis.AppendLine(GetScript());
			}

			return analysis.ToString();
		}

		/// <summary>
		/// Prints a blank line to the Results
		/// </summary>
		[LuaMember(Name = "printLine")]
		public void PrintLine()
		{
			Result.AppendLine();
		}

		/// <summary>
		/// Prints a line of text to the Results
		/// </summary>
		/// <param name="value">The text to print</param>
		[LuaMember(Name = "printLine")]
		public void PrintLine(object value)
		{
			Result.AppendLine(value.ToString());
		}

		/// <summary>
		/// Prints a line of text to the Results if <paramref name="Condition"/> is true;
		/// </summary>
		/// <param name="condition">The condition to evaluate</param>
		/// <param name="value">The text to print</param>
		[LuaMember(Name = "printLineIf")]
		public void PrintLineIf(bool condition, object value)
		{
			if (condition) PrintLine(value);
		}

		/// <summary>
		/// Prints a formatted line of text to the Results
		/// </summary>
		/// <param name="format">A composite format string</param>
		/// <param name="values">An array of objects to format</param>
		[LuaMember(Name = "printLineFormat")]
		public void PrintLineFormat(string format, params object[] values)
		{
			Result.AppendFormat(format, values);
			Result.AppendLine();
		}

		/// <summary>
		/// Prints text to the Results
		/// </summary>
		/// <param name="value">The text to print</param>
		[LuaMember(Name = "print")]
		public void Print(object value)
		{
			Result.Append(value.ToString());
		}

		/// <summary>
		/// Prints a text to the Results if <paramref name="Condition"/> is true.
		/// </summary>
		/// <param name="condition">The condition to evaluate</param>
		/// <param name="value">The text to print</param>
		[LuaMember(Name = "printIf")]
		public void PrintIf(bool condition, object value)
		{
			if (condition) Print(value);
		}

		/// <summary>
		/// Prints a formatted line of text to the Results
		/// </summary>
		/// <param name="format">A composite format string</param>
		/// <param name="values">An array of objects to format</param>
		[LuaMember(Name = "printFormat")]
		public void PrintFormat(string format, params object[] values)
		{
			Result.AppendFormat(format, values);
		}

		/// <summary>
		/// Creates an empty LuaTable
		/// </summary>

		[LuaMember(Name = "createTable")]
		public LuaTable CreateTable()
		{
			return (LuaTable)_lua.DoString("return {}")[0];
		}

		/// <summary>
		/// Calls the NCalc engine to evaluate the provided expression
		/// </summary>
		/// <param name="expression">A string expression to evaluate</param>
		[LuaMember(Name = "calc")]
		public string NCalc(string expression)
		{
			return Calculate(expression);
		}

		/// <summary>
		/// Returns a non-negative random <see cref="Int32"/>.
		/// </summary>
		/// <returns>A non-negative random <see cref="Int32"/>.</returns>
		[LuaMember(Name = "rnd")]
		public static Int32 GetRandomNumber()
		{
			return Utility.Random.RandomNumber();
		}

		/// <summary>
		/// Returns a non-negative random <see cref="Int32"/> that is less than the specified maximum.
		/// </summary>
		/// <param name="maxValue">The maxiumum <see cref="Int32"/> to be generated</param>
		/// <returns>A non-negative random <see cref="Int32"/> that is less than the specified maximum.</returns>
		[LuaMember(Name = "rnd")]
		public static Int32 GetRandomNumber(int maxValue)
		{
			return Utility.Random.RandomNumber(maxValue);
		}

		/// <summary>
		/// Returns a random <see cref="Int32"/> that is within a specified range.
		/// </summary>
		/// <param name="minValue">The minimum <see cref="Int32"/> to be generated</param>
		/// <param name="maxValue">The maximum <see cref="Int32"/> to be generated</param>
		/// <returns>A random <see cref="Int32"/> that is within a specified range.</returns>
		[LuaMember(Name = "rnd")]
		public static Int32 GetRandomNumber(int minValue, int maxValue)
		{
			return Utility.Random.RandomNumber(minValue, maxValue);
		}

		/// <summary>
		/// Selects one item from the provided table
		/// </summary>
		/// <param name="table">The table to select from, must have an integer index</param>
		[LuaMember(Name = "selectFromTable")]
		public static String SelectFromTable(LuaTable table)
		{
			var selected = GetRandomNumber(1, table.Keys.Count);
			foreach (KeyValuePair<object, object> value in table)
			{
				var index = value.Key as double?;
				if (index != null && selected <= index)
				{
					return value.Value.ToString();
				}
			}
			return string.Empty;
		}
		#endregion

		#region Private Methods
		private String GetScript()
		{
			var script = Script;
			if (!String.IsNullOrWhiteSpace(ScriptPath))
				script = DataAccess.DataAccess.Instance.GetText(ScriptPath);
			return script;
		}
		#endregion
	}
}
