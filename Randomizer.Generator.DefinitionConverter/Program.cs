using System;
using System.IO;
using System.Linq;
using TheRandomizer.Generators;
using Randomizer.Generator.Core;
using TheRandomizer.Utility;

namespace Randomizer.Generator.DefinitionConverter
{
    class Program
    {
		/// <summary>
		/// Converts an old xml formatted generator to a new hjson formatted definition
		/// </summary>
		/// <param name="source">The source file</param>
		/// <param name="target">The target file</param>
		/// <param name="overwrite">Overwrite target file without prompting.</param>
        static void Main(string source, string target = "", Boolean overwrite = false)
        {
			var assembly = System.Reflection.Assembly.GetExecutingAssembly();
			
			Console.Title = "Randomizer Definition Converter";
			Console.WriteLine(assembly.GetName().FullName);
			Console.WriteLine();
			var cont = true;
			if (String.IsNullOrWhiteSpace(source))
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine($"Required argument missing: --{nameof(source)}");				
				cont = false;
			}
			if (String.IsNullOrWhiteSpace(target))
			{
				target = Path.ChangeExtension(source, "hjson");
			}

			Console.ResetColor();
			Console.WriteLine($"Source: {Path.GetFileName(source)}");
			Console.WriteLine($"Target: {Path.GetFileName(target)}");

			if (!overwrite && File.Exists(target))
			{
				Console.Write("Target file exists, would you like to overwrite it? (Y/N) ");
				ConsoleKey response;
				var (left, top) = Console.GetCursorPosition();

				do
				{
					response = Console.ReadKey().Key;
					Console.SetCursorPosition(left, top);
				} while (response != ConsoleKey.Y && response != ConsoleKey.N);
				if (response == ConsoleKey.N)
					cont = false;
				Console.WriteLine();
			}

			if (cont)
			{
				Console.WriteLine($"Loading source grammar");
				var sourceGrammar = BaseGenerator.Deserialize(File.ReadAllText(source));
				Console.WriteLine($"Source grammar loaded");
				Console.WriteLine($"Converting to new definition");
				dynamic targetDefinition = Convert(sourceGrammar);
				if (targetDefinition != null)
				{
					Console.WriteLine($"Conversion complete");
					var hjson = BaseDefinition.Serialize(targetDefinition);
					Console.WriteLine($"Saving the target");
					File.WriteAllText(target, hjson);
					Console.WriteLine($"Process complete");
				}
				else
					Console.WriteLine("Unrecognized or unsupported source generator type.");
			}
			else
			{
				Console.WriteLine("Conversion aborted.");
			}
			Console.WriteLine();
        }

		private static dynamic Convert(BaseGenerator source) 
		{
			return source.GeneratorType switch
			{
				GeneratorType.Assignment => ConvertAssignment((TheRandomizer.Generators.Assignment.AssignmentGenerator)source),
				GeneratorType.List => ConvertList((TheRandomizer.Generators.List.ListGenerator)source),
				GeneratorType.Lua => ConvertLua((TheRandomizer.Generators.Lua.LuaGenerator)source),
				GeneratorType.Phonotactics => ConvertPhonotactics((TheRandomizer.Generators.Phonotactics.PhonotacticsGenerator)source),
				GeneratorType.Table => ConvertTable((TheRandomizer.Generators.Table.TableGenerator)source),
				_ => null,
			};
		}

		private static Assignment.AssignmentDefinition ConvertAssignment(TheRandomizer.Generators.Assignment.AssignmentGenerator source)
		{
			var target = new Assignment.AssignmentDefinition()
			{
				Imports = source.Imports.Select(i => i.Value).ToList()
			};
			CopyBaseProperties(source, target);
			foreach (var item in source.LineItems)
			{
				if (!target.LineItems.ContainsKey(item.Name)) target.LineItems.Add(item.Name, new Assignment.LineItemList());
				var targetItem = target.LineItems[item.Name];
				targetItem.Add(new Assignment.LineItem()
				{
					Content = item.Expression,
					Next = item.Next,
					Repeat = Int32.TryParse(item.Repeat, out _) ? Int32.Parse(item.Repeat) : 1,
					Variable = item.Variable,
					Weight = item.Weight,
				});				
			}
			return target;
		}

		private static List.ListDefinition ConvertList(TheRandomizer.Generators.List.ListGenerator source)
		{
			var target = new List.ListDefinition();
			CopyBaseProperties(source, target);
			target.Items = source.Items.Split('\n').ToList();
			target.KeepWhitespace = source.KeepWhitespace;
			return target;
		}

		private static Lua.LuaDefinition ConvertLua(TheRandomizer.Generators.Lua.LuaGenerator source)
		{
			var target = new Lua.LuaDefinition();
			CopyBaseProperties(source, target);
			target.Script = source.Script;
			target.ScriptPath = source.ScriptPath;
			return target;
		}

		private static Phonotactics.PhonotacticsDefinition ConvertPhonotactics(TheRandomizer.Generators.Phonotactics.PhonotacticsGenerator source)
		{
			var target = new Phonotactics.PhonotacticsDefinition();
			CopyBaseProperties(source, target);
			foreach (var definition in source.Definitions)
			{
				target.Definitions.Add(definition.Key.First(), new Phonotactics.DefinitionList(definition.ValueList));
			}

			target.Patterns.Add(String.Empty, new Phonotactics.PatternList());
			foreach (var pattern in source.Patterns)
			{
				target.Patterns.First().Value.Add(new Phonotactics.PhonotacticPattern(pattern.Value, pattern.Weight));
			}
			return target;
		}

		private static Table.TableDefinition ConvertTable(TheRandomizer.Generators.Table.TableGenerator source)
		{
			var target = new Table.TableDefinition();
			CopyBaseProperties(source, target);
			foreach (var table in source.Tables)
			{
				Table.BaseTable newTable = null;

				switch (table.TableType)
				{
					case "LoopTable":
						newTable = new Table.LoopTable()
						{
							KeyColumn = table.Column
						};
						break;
					case "RandomTable":
						newTable = new Table.RandomTable
						{
							RollColumn = table.Column,
							Modifier = ((TheRandomizer.Generators.Table.RandomTable)table).Modifier
						};
						break;
					case "SelectTable":
						newTable = new Table.SelectTable()
						{
							SelectColumn = table.Column,
							SelectValue = ((TheRandomizer.Generators.Table.SelectTable)table).SelectValue
						};
						break;
				}

				target.Tables.Add(table.Name, newTable);
			}
			return target;
		}

		private static void CopyBaseProperties(BaseGenerator source, BaseDefinition target)
		{
			target.Name = source.Name;
			target.Author = source.Author;
			target.Description = source.Description;
			target.OutputFormat = Enum.Parse<OutputFormats>(source.OutputFormat.ToString());
			target.URL = source.Url;
			target.Version = new Version(source.Version, 0);
			target.Parameters = CopyParameters(source.Parameters);
			target.Tags = source.Tags.Select(t => t.Value).ToList();
		}

		private static ParameterDictionary CopyParameters(TheRandomizer.Generators.Parameter.ConfigurationList source)
		{
			var target = new ParameterDictionary();

			foreach (var sourceParam in source)
			{
				target.Add(sourceParam.Name, new Parameter()
				{
					Display = sourceParam.DisplayName,
					Type = Enum.Parse<ParameterTypes>(sourceParam.Type.ToString()),
					Value = sourceParam.Value,
					Options = CopyListOptions(sourceParam.Options)
				});
			}

			return target;
		}

		private static ListOptionList CopyListOptions(TheRandomizer.Generators.Parameter.OptionList source)
		{
			var target = new ListOptionList();

			foreach (var sourceOption in source)
			{
				target.Add(sourceOption.Value, sourceOption.DisplayName);
			};

			return target;
		}
    }
}
