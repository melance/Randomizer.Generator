using System;
using System.IO;
using Terminal.Gui;

namespace Randomizer.Generator.UI.Terminal.Dialogs
{
	class ConvertGrammar : Dialog
	{
		#region Enumerators
		enum DialogResult
		{
			Yes,
			No,
			Cancel
		}
		#endregion

		#region Constructor
		public ConvertGrammar()
		{
			Title = "Convert Grammar to Definition";

			lblSourceGrammar = new("Source Grammar:")
			{
				X = 1,
				Y = 1,
				Width = Dim.Sized(19)
			};
			txtSourceGrammar = new()
			{
				X = Pos.Right(lblSourceGrammar) + 1,
				Y = Pos.Top(lblSourceGrammar),
				Width = Dim.Fill(6)
			};
			btnOpenSourceGrammar = new("…")
			{
				X = Pos.Right(txtSourceGrammar) + 1,
				Y = Pos.Top(txtSourceGrammar)
			};
			lblTargetDefinition = new("Target Definition:")
			{
				X = 1,
				Y = Pos.Bottom(lblSourceGrammar) + 2,
				Width = Dim.Sized(19)
			};
			txtTargetDefinition = new()
			{
				X = Pos.Right(lblTargetDefinition) + 1,
				Y = Pos.Top(lblTargetDefinition),
				Width = Dim.Fill(6)
			};
			btnOpenTargetDefinition = new("…")
			{
				X = Pos.Right(txtTargetDefinition) + 1,
				Y = Pos.Top(txtTargetDefinition)
			};
			lblMessages = new("")
			{
				X = 1,
				Y = Pos.Bottom(lblTargetDefinition) + 2,
				Width = Dim.Fill(1),
				Height = Dim.Fill(1),
				Visible = false,
				ColorScheme = Colors.Error
			};

			btnOpenSourceGrammar.Clicked += btnOpenSourceGrammar_Clicked;
			btnOpenTargetDefinition.Clicked += btnOpenTargetDefinition_Clicked;

			Add(lblSourceGrammar);
			Add(txtSourceGrammar);
			Add(btnOpenSourceGrammar);
			Add(lblTargetDefinition);
			Add(txtTargetDefinition);
			Add(btnOpenTargetDefinition);
			Add(lblMessages);

			var btnClose = new Button("Cancel");
			var btnProcess = new Button("Ok");
			btnClose.Clicked += () => Application.RequestStop();
			btnProcess.Clicked += btnProcess_Clicked;

			AddButton(btnClose);
			AddButton(btnProcess);
		}
		#endregion

		#region Controls
		private readonly Label lblSourceGrammar;
		private readonly TextField txtSourceGrammar;
		private readonly Button btnOpenSourceGrammar;
		private readonly Label lblTargetDefinition;
		private readonly TextField txtTargetDefinition;
		private readonly Button btnOpenTargetDefinition;
		private readonly Label lblMessages;
		#endregion

		#region Event Handlers
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
		#endregion

		#region Private Methods
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
		#endregion
	}
}
