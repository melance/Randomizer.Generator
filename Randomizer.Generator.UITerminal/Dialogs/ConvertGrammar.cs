using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;

namespace Randomizer.Generator.UITerminal.Dialogs
{
	partial class ConvertGrammar : Dialog
	{
		enum DialogResult
		{
			Yes,
			No,
			Cancel
		}

		private void btnOpenSourceGrammar_Clicked()
		{
			var open = new OpenDialog("Open Source Grammar", "")
			{
				CanChooseDirectories = false,
				DirectoryPath = Program.CurrentDirectory
			};
			Application.Run(open);
			if (!open.Canceled)
			{
				txtSourceGrammar.Text = open.FilePath;
				txtSourceGrammar.CursorPosition = txtSourceGrammar.Text.Length;
			}
		}

		private void btnOpenTargetDefinition_Clicked()
		{
			var save = new SaveDialog("Save Target Definition", "")
			{
				AllowedFileTypes = new string[] { "rgen.hjson", "rgen.json" },
				DirectoryPath = Program.CurrentDirectory
			};
			Application.Run(save);
			if (!save.Canceled)
			{
				txtTargetDefinition.Text = save.FilePath;
				txtTargetDefinition.CursorPosition = txtTargetDefinition.Text.Length;
			}	
		}

		private void btnProcess_Clicked()
		{
			var sourceFile = txtSourceGrammar.Text.ToString();
			var targetFile = txtTargetDefinition.Text.ToString();
			var result = DialogResult.Yes;

			lblMessages.Clear();
			lblMessages.Visible = false;
						
			if (String.IsNullOrWhiteSpace(sourceFile))
				AppendError($"Please select a source grammar.");
			else
			{
				if (!Path.IsPathRooted(sourceFile)) sourceFile = Path.Combine(Program.CurrentDirectory, sourceFile);
				if (!File.Exists(sourceFile))
					AppendError($"File not found: {sourceFile}");
				else
				{
					if (String.IsNullOrWhiteSpace(targetFile)) targetFile = Path.ChangeExtension(sourceFile, "rgen.hjson");
					if (!Path.IsPathRooted(targetFile)) targetFile = Path.Combine(Program.CurrentDirectory, targetFile);

					if (File.Exists(targetFile))
					{						
						var yes = new Button("_Yes");
						var no = new Button("_No");
						var cancel = new Button("_Cancel");
						var confirm = new Dialog("File Exists", new Button[] { yes, no, cancel });
						yes.Clicked += () =>
						{
							result = DialogResult.Yes;
							Application.RequestStop();
						};
						cancel.Clicked += () =>
						{
							result = DialogResult.Cancel;
							Application.RequestStop();
						};
						no.Clicked += () =>
						{
							result = DialogResult.No;
							Application.RequestStop();
						};						
					}

					switch (result)
					{
						case DialogResult.Cancel:
							Application.RequestStop();
							break;
						case DialogResult.Yes:
							Convert(sourceFile, targetFile);
							break;
					}

				}
			}
		}

		private void Convert(String sourceFile, String targetFile)
		{
			try
			{
				var source = TheRandomizer.Generators.BaseGenerator.Deserialize(File.ReadAllText(sourceFile));
				var target = DefinitionConverter.Converter.Convert(source);
				File.WriteAllText(targetFile, Core.BaseDefinition.Serialize(target));

				Program.RefreshGeneratorList?.Invoke();

				if (MessageBox.Query("Complete", "Conversion complete, convert another grammar?", "Yes", "No") == 1)
				{
					Application.RequestStop();
				}
			}
			catch (Exception ex)
			{
				AppendError(ex.Message);
			}
		}

		private void AppendError(String message)
		{
			lblMessages.Text += $"{message}\n";
			lblMessages.Visible = true;
		}
	}
}
