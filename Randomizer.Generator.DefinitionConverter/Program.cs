using System;
using System.IO;
using System.Linq;
using TheRandomizer.Generators;
using Randomizer.Generator.Core;
using Randomizer.Generator.Utility;
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

			Console.ResetColor();
			Console.WriteLine($"Source: {Path.GetFileName(source)}");
			Console.WriteLine($"Target: {Path.GetFileName(target)}");

			if (cont)
			{
				if (File.GetAttributes(source).HasFlag(FileAttributes.Directory))
				{
					foreach (var file in Directory.GetFiles(source, "*.rgen"))
					{
						var targetFile = Path.ChangeExtension(Path.GetFileName(file), "rgen.hjson");
						if (Directory.Exists(target))
							targetFile = Path.Combine(target, targetFile);
						else
							targetFile = Path.Combine(source, targetFile);
						Convert(file, targetFile, overwrite);
					}
				}
				else
				{
					if (String.IsNullOrWhiteSpace(target))
						target = Path.ChangeExtension(source, "rgen.hjson");
					else if (File.GetAttributes(target).HasFlag(FileAttributes.Directory))
						target = Path.Combine(target, Path.ChangeExtension(Path.GetFileName(source), "rgen.hjson"));

					Convert(source, target, overwrite);
				}
				Console.WriteLine($"Process complete");
			}
			else
			{
				Console.WriteLine("Conversion aborted.");
			}
			Console.WriteLine();
		}

		private static void Convert(String sourcePath, String targetPath, Boolean overwrite)
		{
			var cont = true;
			if (!overwrite && File.Exists(targetPath))
			{
				Console.Write($"{targetPath} exists, would you like to overwrite it? (Y/N) ");
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
				Console.WriteLine($"Loading source grammar {sourcePath}");
				var sourceGrammar = BaseGenerator.Deserialize(File.ReadAllText(sourcePath));
				Console.WriteLine($"Source grammar loaded");
				Console.WriteLine($"Converting to new definition");
				dynamic targetDefinition = Utility.Converter.Convert(sourceGrammar);
				if (targetDefinition != null)
				{
					Console.WriteLine($"Conversion complete");
					var hjson = BaseDefinition.Serialize(targetDefinition);
					Console.WriteLine($"Saving the target {targetPath}");
					File.WriteAllText(targetPath, hjson);
				}
				else
					Console.WriteLine("Unrecognized or unsupported source generator type.");
			}
		}
    }
}
