using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;

namespace Randomizer.Generator.UITerminal.Views
{
	partial class GeneratorTab
	{
		public GeneratorTab(String filePath)
		{
			_filePath = filePath;
			LoadTheGenerator();

			// Create the view
			View = new()
			{
				X = 0,
				Y = 0,
				Width = Dim.Fill(),
				Height = Dim.Fill()
			}; 

			// Construct Controls			
			btnClose = new("X")
			{
				X = Pos.Right(View) - 5,
				Y = Pos.Top(View)
			};
			btnViewDetails = new("View Details")
			{
				X = 0,
				Y = Pos.Bottom(View) - 1
			};
			btnGenerate = new("Generate")
			{
				X = Pos.Percent(33) - ("Generate".Length + 4),
				Y = Pos.Bottom(View) - 1,				
				Shortcut = Key.F5,
				ShortcutAction = btnGenerate_Clicked
			};
			frvParameters = new("Parameters")
			{
				X = 0,
				Y = 1,
				Width = Dim.Percent(33),
				Height = Dim.Height(View) - 2
			};
			lblRepeat = new("Repeat")
			{
				X = 1,
				Y = 0,
				Width = Dim.Fill()
			};
			intRepeat = new(1, 100)
			{
				X = 1,
				Y = 1,
				Width = Dim.Fill() - 2,
				Value = 1
			};
			frvResults = new("Results")
			{
				X = Pos.Percent(33) + 1,
				Y = 1,
				Width = Dim.Fill(),
				Height = Dim.Fill() - 1
			};
			txtResults = new()
			{
				X = 0,
				Y = 0,
				Width = Dim.Fill(),
				Height = Dim.Fill(),
				WordWrap = true,
				ReadOnly = true
			};
			btnSave = new("_Save")
			{
				X = Pos.Right(View) - 8,
				Y = Pos.Bottom(View) - 1,
				Visible = false
			};
			btnCopyAll = new("Copy _All")
			{
				X = Pos.Right(View) - (12 + btnSave.Bounds.Width),
				Y = Pos.Bottom(View) - 1,
				Visible = false
			};
			btnCopy = new("_Copy")
			{
				X = Pos.Right(View) - (8 + btnCopyAll.Bounds.Width + btnSave.Bounds.Width),
				Y = Pos.Bottom(View) - 1,
				Visible = false
			};
			
			// Register events
			btnClose.Clicked += btnClose_Clicked;
			btnViewDetails.Clicked += btnViewDetails_Clicked;
			btnGenerate.Clicked += btnGenerate_Clicked;
			btnCopyAll.Clicked += btnCopyAll_Clicked;
			btnCopy.Clicked += btnCopy_Clicked;
			btnSave.Clicked += btnSave_Clicked;
			txtResults.TextChanged += txtResults_TextChanged;

			// Add controls
			frvParameters.Add(lblRepeat);
			frvParameters.Add(intRepeat);
			View.Add(btnClose);
			View.Add(btnViewDetails);
			View.Add(btnGenerate);
			View.Add(frvParameters);
			View.Add(frvResults);
			View.Add(btnCopyAll);
			View.Add(btnCopy);
			View.Add(btnSave);
			frvResults.Add(txtResults);

			var txtResultsScrollBar = new ScrollBarView(txtResults, true)
			{
				AutoHideScrollBars = true
			};

			txtResults.DrawContent += (e) => {
				txtResultsScrollBar.Size = txtResults.Lines;
				txtResultsScrollBar.Position = txtResults.TopRow;
				txtResultsScrollBar.OtherScrollBarView.Size = txtResults.Maxlength - 1;
				txtResultsScrollBar.OtherScrollBarView.Position = 0;
				txtResultsScrollBar.OtherScrollBarView.Visible = false;
				txtResultsScrollBar.Refresh();
			};

			txtResultsScrollBar.ChangedPosition += () => {
				txtResults.TopRow = txtResultsScrollBar.Position;
				if (txtResults.TopRow != txtResultsScrollBar.Position)
				{
					txtResultsScrollBar.Position = txtResults.TopRow;
				}
				txtResults.SetNeedsDisplay();
			};

			CreateParameterControls();
		}
				
		private readonly Button btnClose;
		private readonly Button btnViewDetails;
		private readonly Button btnGenerate;
		private readonly FrameView frvParameters;
		private readonly Label lblRepeat;
		private readonly IntegerField intRepeat;
		private readonly TextView txtResults;
		private readonly FrameView frvResults;
		private readonly Button btnCopyAll;
		private readonly Button btnCopy;
		private readonly Button btnSave;
	}
}
