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
		/// <summary>The lua interpreter .NET wrapper</summary>
		private readonly NLua.Lua _lua = new();

		/// <summary>The Lua script to be run.</summary>
		/// <remarks>If <see cref="ScriptPath"/> is set, this property is ignored</remarks>
		public String Script { get; set; }
		/// <summary>The path to the Lua script to be run.</summary>
		public String ScriptPath { get; set; }
		/// <summary>Keeps the results that are printed as the generator is run.</summary>
		private StringBuilder Result { get; set; } = new();

		/// <summary>
		/// Generates random content
		/// </summary>
		/// <returns>The content generated</returns>
		public override String Generate()
		{
			base.Generate();
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
			if (!String.IsNullOrWhiteSpace(ScriptPath))
				Script = File.ReadAllText(ScriptPath);

			_lua.DoString(Script, Name);

			return Result.ToString();
		}


		/// <summary>
		/// Prints a blank line to the Results
		/// </summary>
		[LuaGlobal(Name = "printLine", Description = "Appends a blank line to the output")]
		public void PrintLine()
		{
			Result.AppendLine();
		}

		/// <summary>
		/// Prints a line of text to the Results
		/// </summary>
		/// <param name="value">The text to print</param>
		[LuaGlobal(Name = "printLine", Description = "Appends text to the output followed by a new line")]
		public void PrintLine(object value)
		{
			Result.AppendLine(value.ToString());
		}

		/// <summary>
		/// Prints a line of text to the Results if <paramref name="Condition"/> is true;
		/// </summary>
		/// <param name="condition">The condition to evaluate</param>
		/// <param name="value">The text to print</param>
		[LuaGlobal(Name = "printLineIf", Description = "Appends text to the output followed by a new line if the condition is true")]
		public void PrintLineIf(bool condition, object value)
		{
			if (condition) PrintLine(value);
		}

		/// <summary>
		/// Prints a formatted line of text to the Results
		/// </summary>
		/// <param name="format">A composite format string</param>
		/// <param name="values">An array of objects to format</param>
		[LuaGlobal(Name = "printLineFormat", Description = "Appends formatted text to the output followed by a new line")]
		public void PrintLineFormat(string format, params object[] values)
		{
			Result.AppendFormat(format, values);
			Result.AppendLine();
		}

		/// <summary>
		/// Prints text to the Results
		/// </summary>
		/// <param name="value">The text to print</param>
		[LuaGlobal(Name = "print", Description = "Appends text to the output")]
		public void Print(object value)
		{
			Result.Append(value.ToString());
		}

		/// <summary>
		/// Prints a text to the Results if <paramref name="Condition"/> is true.
		/// </summary>
		/// <param name="condition">The condition to evaluate</param>
		/// <param name="value">The text to print</param>
		[LuaGlobal(Name = "printIf", Description = "Appends text to the output if the condition is true")]
		public void PrintIf(bool condition, object value)
		{
			if (condition) Print(value);
		}

		/// <summary>
		/// Prints a formatted line of text to the Results
		/// </summary>
		/// <param name="format">A composite format string</param>
		/// <param name="values">An array of objects to format</param>
		[LuaGlobal(Name = "printFormat", Description = "Appends formatted text to the output")]
		public void PrintFormat(string format, params object[] values)
		{
			Result.AppendFormat(format, values);
		}

		/// <summary>
		/// Creates an empty LuaTable
		/// </summary>

		[LuaGlobal(Name = "createTable", Description = "Creates a table")]
		public LuaTable CreateTable()
		{
			return (LuaTable)_lua.DoString("return {}")[0];
		}

		/// <summary>
		/// Calls the NCalc engine to evaluate the provided expression
		/// </summary>
		/// <param name="expression">A string expression to evaluate</param>
		[LuaGlobal(Name = "calc", Description = "Runs the expression through the NCalc engine.")]
		public string NCalc(string expression)
		{
			return Calculate(expression);
		}

		/// <summary>
		/// Returns a non-negative random <see cref="Int32"/>.
		/// </summary>
		/// <returns>A non-negative random <see cref="Int32"/>.</returns>
		[LuaGlobal(Name = "rnd", Description = "Returns a non-negative random integer.")]
		public static Int32 GetRandomNumber()
		{
			return Utility.Random.RandomNumber();
		}

		/// <summary>
		/// Returns a non-negative random <see cref="Int32"/> that is less than the specified maximum.
		/// </summary>
		/// <param name="maxValue">The maxiumum <see cref="Int32"/> to be generated</param>
		/// <returns>A non-negative random <see cref="Int32"/> that is less than the specified maximum.</returns>
		[LuaGlobal(Name = "rnd", Description = "Returns a non-negative random integer that is less than the specified maximum.")]
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
		[LuaGlobal(Name = "rnd", Description = "Returns a random integer that is within a specified range.")]
		public static Int32 GetRandomNumber(int minValue, int maxValue)
		{
			return Utility.Random.RandomNumber(minValue, maxValue);
		}

		/// <summary>
		/// Selects one item from the provided table
		/// </summary>
		/// <param name="table">The table to select from, must have an integer index</param>
		[LuaGlobal(Name = "selectFromTable", Description = "Selects a single item from the provided table.")]
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
	}
}
