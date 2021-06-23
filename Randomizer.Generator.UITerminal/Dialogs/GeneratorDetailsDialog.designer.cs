using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Randomizer.Generator.Core;
using Randomizer.Generator.UITerminal.Views;
using Terminal.Gui;

namespace Randomizer.Generator.UITerminal.Dialogs
{
	partial class GeneratorDetailsDialog
	{
		public GeneratorDetailsDialog(BaseDefinition generator) : base(generator.Name)
		{
			// Construct controls
			btnClose = new("Close");

			var labelWidth = 16;
			var labelY = 0;

			var lblDescription = new Label(generator.Description) { X = 0, Y = labelY, Width = Dim.Fill() };			
			Add(lblDescription);

			labelY += lblDescription.Bounds.Height;

			if (!String.IsNullOrWhiteSpace(generator.Author))
			{				
				var lblAuthor = new Label($"By {generator.Author}") { X = 0, Y = labelY, Width = Dim.Fill(), Height = 1 };
				Add(lblAuthor);
				labelY += lblAuthor.Bounds.Height;
			}

			if (generator.Version != null)
			{
				var lblVersion = new Label($"{"Version:".PadRight(labelWidth)}{generator.Version}") { X = 0, Y = labelY, Width = Dim.Fill(), Height = 1 };
				Add();
				labelY += lblVersion.Bounds.Height;
			}

			var lblGeneratorType = new Label($"{"Type:".PadRight(labelWidth)}{generator.GetType().Name}") { X = 0, Y = labelY, Width = Dim.Fill(), Height = 1 };
			Add(lblGeneratorType);
			labelY += lblGeneratorType.Bounds.Height;

			var lblOutputFormat = new Label($"{"Output Format:".PadRight(labelWidth)}{generator.OutputFormat}") { X = 0, Y = labelY, Width = Dim.Fill(), Height = 1 };
			Add(lblOutputFormat);
			labelY += lblOutputFormat.Bounds.Height;
			
			if (generator.URL != null)
			{
				var lblURL = new LinkLabel($"{"URL:".PadRight(labelWidth)}{generator.URL}", generator.URL) { X = 0, Y = labelY, Width = Dim.Fill(), Height = 1 };
				
				Add(lblURL);
				labelY += lblURL.Bounds.Height;
			}

			if (generator.Tags?.Count > 0)
			{
				var lblTags = new Label($"{"Tags:".PadRight(labelWidth)}{String.Join(", ", generator.Tags.ToArray())}") { X = 0, Y = labelY, Width = Dim.Fill() };
				Add(lblTags);
				labelY += lblTags.Bounds.Height;
			}

			var @switch = new Dictionary<Type, Action> {
							{ typeof(List.ListDefinition), () => Add(new Label($"{"List Items:".PadRight(labelWidth)}{((List.ListDefinition)generator).Items.Count}")) },
							{ typeof(Assignment.AssignmentDefinition), () => {
																var lblKeys = new Label($"{"Keys:".PadRight(labelWidth)}{((Assignment.AssignmentDefinition)generator).LineItems.Count:#,##0}") { X = 0, Y = labelY, Width = Dim.Fill() };
																Add(lblKeys);
																labelY += lblKeys.Bounds.Height;
																Add(new Label($"{"Items:".PadRight(labelWidth)}{((Assignment.AssignmentDefinition)generator).LineItems.Sum(li => li.Value.Count):#,##0}") { X = 0, Y = labelY, Width = Dim.Fill() });} },
							{ typeof(Phonotactics.PhonotacticsDefinition), () => {
																var lblDefinitions = new Label($"{"Definitions:".PadRight(labelWidth)}{((Phonotactics.PhonotacticsDefinition)generator).Definitions.Count:#,##0}") { X = 0, Y = labelY, Width = Dim.Fill() };
																Add(lblDefinitions);
																labelY += lblDefinitions.Bounds.Height;
																Add(new Label($"{"Patterns:".PadRight(labelWidth)}{((Phonotactics.PhonotacticsDefinition)generator).Patterns.Count:#,##0}") { X = 0, Y = labelY, Width = Dim.Fill() });
							} },
							{ typeof(Lua.LuaDefinition), () => { } },
							{ typeof(Table.TableDefinition), () => { } }
						};

			@switch[generator.GetType()]();
						
			// Register Event Handlers
			btnClose.Clicked += () => Application.RequestStop();

			// Add controls
			AddButton(btnClose);
		}

		private Button btnClose;		
	}
}
