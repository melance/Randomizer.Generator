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
				dynamic targetDefinition = Converter.Convert(sourceGrammar);
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
    }
}
