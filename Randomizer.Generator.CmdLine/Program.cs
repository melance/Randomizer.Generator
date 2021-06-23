using System;
using System.Collections.Generic;
using System.IO;
using Randomizer.Generator.Core;
using System.CommandLine.Rendering;
using System.CommandLine.Invocation;
using Randomizer.Generator.Utility;
using System.CommandLine.IO;
using Spectre.Console;
using Randomizer.Generator.CmdLine.Classes;
using Spectre.Console.Rendering;
using System.Linq;
using System.Text;

namespace Randomizer.Generator.CmdLine
{
    class Program
    {
        private static readonly Rule STANDARD_RULE = new() { Style = Style.Parse("blue") };
        private static readonly Color GREEN = new(100, 255, 0);

        private static Boolean TextOnly { get; set; }

        /// <summary>
        /// Generates content using the definition file provided by the path option.
        /// </summary>
        /// <param name="path">The relative or absolute path to the definition file. [Required]</param>
        /// <param name="repeat">The number of times to run the generator.</param>
        /// <param name="args">A list of parameters to supply to the generator in the format: name:value</param>
        /// <param name="info">Displays information about the definition</param>
        /// <param name="textonly">When set to true, output simple text</param>
        static void Main(String path, Int32 repeat = 1, Boolean info = false, Boolean textonly = false, String[] args = null)
        {
            TextOnly = Console.IsOutputRedirected || textonly;
            if (!TextOnly)
            {
                AnsiConsole.Clear();
                AnsiConsole.Foreground = Color.White;
            }
            var fullPath = ResolvePath(path);

            if (String.IsNullOrWhiteSpace(path))
                WriteError($"Missing required option: --path");
            else if (!File.Exists(fullPath))
                WriteError($"File not found: {fullPath}");
            else
            {
                BaseDefinition generator = BaseDefinition.Deserialize(File.ReadAllText(fullPath));

                if (!TextOnly)
                {
                    AnsiConsole.Markup($"[bold {GREEN.ToMarkup()}]{generator.Name}[/]");
                    if (generator.Version != null) AnsiConsole.Markup($"[bold {GREEN.ToMarkup()}] v{generator.Version}[/]");
                    if (!String.IsNullOrWhiteSpace(generator.Author)) AnsiConsole.Markup($"[bold {GREEN.ToMarkup()}] by {generator.Author}[/]");
                    AnsiConsole.WriteLine();
                    AnsiConsole.Render(STANDARD_RULE);
                }
                else
                {
                    Console.Write(generator.Name);
                    if (generator.Version != null) Console.Write($"v{generator.Version}");
                    if (!String.IsNullOrWhiteSpace(generator.Author)) Console.Write($"by {generator.Author}");
                    Console.WriteLine();                    
                }
                if (info)
                {
                    if (!TextOnly)
                        ShowInfoAnsi(generator);
                    else
                        ShowInfo(generator);
                }
                else
                {
                    Generate(generator, repeat, args);
                }
            }
        }

        /// <summary>
        /// Show info about the definition
        /// </summary>
        static void ShowInfo(BaseDefinition generator)
        {
            Console.WriteLine("Generator Information");
            Console.WriteLine(new String('-', 80));

            Console.WriteLine(generator.Description);
            Console.WriteLine();
          
            Console.WriteLine($"Generator Type:   {generator.GetType().Name}");
            Console.WriteLine($"Tags:             {String.Join(", ", generator.Tags)}");
            Console.WriteLine($"Output Format:    {generator.OutputFormat}");
            if (!String.IsNullOrWhiteSpace(generator.URL)) Console.WriteLine($"URL:              {generator.URL}");

            if (generator.GetType() == typeof(Assignment.AssignmentDefinition))
            {
                var ad = (Assignment.AssignmentDefinition)generator;
                Console.WriteLine($"Category Count:   {ad.LineItems.Count:#,##0}");
                Console.WriteLine($"Line Item Count:  {ad.LineItems.Sum(kvp => kvp.Value.Count):#,##0}");
				if (ad.Imports.Any())
				{
					Console.WriteLine("Imports:");
					foreach (var import in ad.Imports)
					{
						Console.WriteLine($"\t{import}");
					}
				}
            }
            if (generator.GetType() == typeof(Phonotactics.PhonotacticsDefinition))
            {
                var pd = (Phonotactics.PhonotacticsDefinition)generator;
                Console.WriteLine($"Definition Count: {pd.Definitions.Count:#,##0}");
                Console.WriteLine($"Pattern Count:    {pd.Patterns.Count:#,##0}");
            }
            if (generator.GetType() == typeof(List.ListDefinition))
            {
                Console.WriteLine($"Item Count:       {((List.ListDefinition)generator).Items.Count:#:##0}");
            }

            // Parameter table
            if (generator.Parameters?.Count > 0)
            {
                Console.WriteLine();
                Console.WriteLine("Parameters");
                var nameWidth = Math.Max(generator.Parameters.Keys.Max(k => k.Length), "Name".Length) + 1;
                var displayWidth = Math.Max(generator.Parameters.Values.Max(p => p.Display.Length), "Display".Length) + 1;
                var typeWidth = Math.Max(generator.Parameters.Values.Max(p => p.Type.ToString().Length), "Type".Length) + 1;
                var valueWidth = Math.Max(generator.Parameters.Values.Max(p => p.Value.ToString().Length), "Default".Length) + 1;

                Console.Write("Name".PadRight(nameWidth));
                Console.Write("Display".PadRight(displayWidth));
                Console.Write("Type".PadRight(typeWidth));
                Console.Write("Default".PadRight(valueWidth));
                Console.WriteLine("Values");
                                
                foreach (var parameter in generator.Parameters)
                {
                    Console.Write(parameter.Key.PadRight(nameWidth));
                    Console.Write(parameter.Value.Display.PadRight(displayWidth));
                    Console.Write(parameter.Value.Type.ToString().PadRight(typeWidth));
                    Console.Write(parameter.Value.Value.PadRight(valueWidth));
                    Console.Write(String.Join(", ", parameter.Value.Options));
                }
            }
        }

        /// <summary>
        /// Shows info about the definition
        /// </summary>
        static void ShowInfoAnsi(BaseDefinition generator)
        {
            AnsiConsole.Render(new Panel($"Generator Information") { Border = BoxBorder.Rounded });

            AnsiConsole.MarkupLine($"[bold]{generator.Description}[/]");
            AnsiConsole.WriteLine();

            // Property table
            var propertyTable = new Spectre.Console.Table() { ShowHeaders = false, Border = TableBorder.None };

            propertyTable.AddColumn("Property");
            propertyTable.AddColumn("Value");

            propertyTable.AddRow("Generator Type:", generator.GetType().Name);
            propertyTable.AddRow("Tags:", String.Join(", ", generator.Tags));
            propertyTable.AddRow("Output Format:", generator.OutputFormat.ToString());
            if (!String.IsNullOrWhiteSpace(generator.URL)) propertyTable.AddRow("URL:", generator.URL);

            if (generator.GetType() == typeof(Assignment.AssignmentDefinition))
            {
                var ad = (Assignment.AssignmentDefinition)generator;
                propertyTable.AddRow("Category Count:", ad.LineItems.Count.ToString("#,##0"));
                propertyTable.AddRow("Line Item Count:", ad.LineItems.Sum(kvp => kvp.Value.Count).ToString("#,##0"));
				if (ad.Imports.Any())
				{
					var importList = new StringBuilder();

					foreach (var import in ad.Imports)
					{
						importList.AppendLine(import);
					}
					propertyTable.AddRow("Imports:", importList.ToString());					
				}
            }
            if (generator.GetType() == typeof(Phonotactics.PhonotacticsDefinition))
            {
                var pd = (Phonotactics.PhonotacticsDefinition)generator;
                propertyTable.AddRow("Definition Count:", pd.Definitions.Count.ToString());
                propertyTable.AddRow("Pattern Count:", pd.Patterns.Count.ToString());
            }
            if (generator.GetType() == typeof(List.ListDefinition))
            {
                propertyTable.AddRow("Item Count:", ((List.ListDefinition)generator).Items.Count.ToString());
            }

            AnsiConsole.Render(propertyTable);

            // Parameter table
            if (generator.Parameters?.Count > 0)
            {
                AnsiConsole.WriteLine();
                AnsiConsole.MarkupLine("[Bold]Parameters[/]");
                var parameterTable = new Spectre.Console.Table() { ShowHeaders = true, Border = new CustomTableBorder() };

                parameterTable.AddColumn("Name");
                parameterTable.AddColumn("Display");
                parameterTable.AddColumn("Type");
                parameterTable.AddColumn("Default Value");
                parameterTable.AddColumn("List Values");

                foreach (var parameter in generator.Parameters)
                {
                    var rowData = new List<IRenderable>()
                    {
                        { new Text(parameter.Key + (parameter.Value.Aliases.Count > 0 ? $" ({String.Join(", ", parameter.Value.Aliases)})" : String.Empty)) },
                        { new Text(parameter.Value.Display )},
                        { new Text(parameter.Value.Type.ToString()) },
                        { new Text(parameter.Value.Value) }
                    };
                    var optionTable = new Spectre.Console.Table() { ShowHeaders = false, Border = TableBorder.None };
                    if (parameter.Value.Options?.Count > 0)
                    {
                        optionTable.AddColumn("Value");
                        optionTable.AddColumn("Display");
                        foreach (var option in parameter.Value.Options)
                        {
                            optionTable.AddRow(option.Value, option.Display);
                        }
                        rowData.Add(optionTable);
                    }
                         
                    parameterTable.AddRow(rowData);
                }

                AnsiConsole.Render(parameterTable);
            }
        }

        /// <summary>
        /// Generates content
        /// </summary>
        static void Generate(BaseDefinition generator, Int32 repeat, String[] args)
        {
            if (repeat <= 0)
            {
                WriteError("Repeat must be greater than 0");                
            }
            else
            {
                try
                {
                    foreach (var parameter in ParseParameters(args))
                    {
						generator.Parameters[parameter.Key].Value = parameter.Value;
                    }

                    for (var i = 0; i < repeat; i++)
                    {
                        var content = generator.Generate();
                        if (!TextOnly)
                            AnsiConsole.MarkupLine(content);
                        else
                            Console.WriteLine(content);
                    }
                }
                catch (Exceptions.ItemNotFoundException ex)
                {
                    WriteError($"Generator error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    WriteError(ex.Message);
                }
            }
        }

        /// <summary>
        /// Writes an error to the output
        /// </summary>
        static void WriteError(String message)
        {
            if (!TextOnly)
                AnsiConsole.MarkupLine($"[bold red]{message}[/]");
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(message);
                Console.ResetColor();
            }    
        }

        /// <summary>
        /// Loop through the args and return a dictionary of the values
        /// </summary>
        static Dictionary<String, String> ParseParameters(String[] args)
        {
            var result = new Dictionary<String, String>();

            if (args != null)
            {
                for (var i = 0; i <= args.Length - 1; i++)
                {
                    var parts = args[i].Split(':');
                    var name = parts[0];
                    var value = parts.Length == 2 ? parts[1] : true.ToString();
                    name = System.Text.RegularExpressions.Regex.Replace(name, @"^-{1,2}", String.Empty);
                    result.Add(name, value);
                }
            }

            return result;
        }

        /// <summary>
        /// Resolves the path to an absolute path
        /// </summary>
        static string ResolvePath(String path)
        {
            if (Path.IsPathRooted(path))
            {
                return path;
            }

            return Path.Combine(Directory.GetCurrentDirectory(), path);
        }
    }
}
