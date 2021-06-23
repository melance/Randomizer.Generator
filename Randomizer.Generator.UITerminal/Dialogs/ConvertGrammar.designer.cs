using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;

namespace Randomizer.Generator.UITerminal.Dialogs
{
	partial class ConvertGrammar
	{
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
			lblTargetDefinition = new ("Target Definition:")
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

		private readonly Label lblSourceGrammar;
		private readonly TextField txtSourceGrammar;
		private readonly Button btnOpenSourceGrammar;
		private readonly Label lblTargetDefinition;
		private readonly TextField txtTargetDefinition;
		private readonly Button btnOpenTargetDefinition;
		private readonly Label lblMessages;
	}
}
