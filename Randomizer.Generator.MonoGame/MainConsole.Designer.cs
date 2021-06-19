using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SadConsole;
using SadConsole.UI;
using SadConsole.UI.Controls;
using SadRogue.Primitives;

namespace Randomizer.Generator.MonoGame
{
    partial class MainConsole
    {
        private const String REFRESH_TEXT = "Refresh";
        private const String CHANGE_DIRECTORY_TEXT = "cd";
        private const Int32 MIDDLE_X = 25;
        private const String GENERATOR_LIST_TEXT = "Generator List";

        public MainConsole(Int32 width, Int32 height) : base(width, height)
        {
            // Draw Borders
            // Outer Border
            OuterBorder = new Rectangle(0, 0, width, height);
            this.DrawBox(OuterBorder, Styles.BorderColor, null, ICellSurface.ConnectedLineThick);
            // Generator List Border
            GeneratorListArea = new Rectangle(2, 2, MIDDLE_X - 1, height - 7);
            this.DrawBox(GeneratorListArea, Styles.BorderColor, null, ICellSurface.ConnectedLineThin);
			// Generator List Button Border
			GeneratorListButtonArea = new Rectangle(2, GeneratorListArea.Y + GeneratorListArea.Height, MIDDLE_X - 1, 3);
			this.DrawBox(GeneratorListButtonArea, Styles.BorderColor, null, ICellSurface.ConnectedLineThin);

            CurrentDirectoryArea = new Rectangle(2, height - 2, width - 2, 1);

            // Set control positions and sizes
            btnRefreshGeneratorList = new(REFRESH_TEXT.Length + 2)
            {
                Name = nameof(btnRefreshGeneratorList),
                Text = REFRESH_TEXT,
                Position = new Point(GeneratorListArea.Width - 1 - REFRESH_TEXT.Length, GeneratorListArea.Height + 3)
            };
            lblGeneratorList = new(GENERATOR_LIST_TEXT)
            {
                Name = nameof(lblGeneratorList),
                TextColor = Styles.TitleColor,
                Position = new Point(GeneratorListArea.X + 1, GeneratorListArea.Y - 1)
            };
            lstGeneratorList = new(GeneratorListArea.X + GeneratorListArea.Width - 4, GeneratorListArea.Y + GeneratorListArea.Height - 4)
            {
                Name = nameof(lstGeneratorList),
                IsScrollBarVisible = true,
                Position = new Point(GeneratorListArea.X + 1, GeneratorListArea.Y + 1)
            };
            lblCurrentDirectory = new(CurrentDirectoryArea.Width - (6 + CHANGE_DIRECTORY_TEXT.Length))
            {
                Name = nameof(lblCurrentDirectory),
                Position = new Point(GeneratorListArea.X, height - 2)
            };
            btnOpenDirectory = new(CHANGE_DIRECTORY_TEXT.Length + 2)
            {
                Name = nameof(btnOpenDirectory),
                Text = CHANGE_DIRECTORY_TEXT,
                Position = new Point(CurrentDirectoryArea.Width - (CHANGE_DIRECTORY_TEXT.Length + 3) , CurrentDirectoryArea.Y + CurrentDirectoryArea.Height - 1)
            };

            // Add controls to the screen
            Controls.Add(lblGeneratorList);
            Controls.Add(lstGeneratorList);
            Controls.Add(btnRefreshGeneratorList);
            Controls.Add(lblCurrentDirectory);
            Controls.Add(btnOpenDirectory);

            // Set the initial directory
            CurrentDirectory = Directory.GetCurrentDirectory();

            // Load the generator list
            LoadGenerators();

            // Register events
            lstGeneratorList.SelectedItemExecuted += lstGeneratorList_SelectedItemExecuted;
            btnRefreshGeneratorList.Click += btnRefreshGeneratorList_Click;
            btnOpenDirectory.Click += btnOpenDirectory_Click;
        }

        private Rectangle OuterBorder { get; }
        private Rectangle GeneratorListArea { get; }
		private Rectangle GeneratorListButtonArea { get; }
        private Rectangle CurrentDirectoryArea { get; }
        private Button btnRefreshGeneratorList { get; } 
        private Label lblGeneratorList { get; }
        private ListBox lstGeneratorList { get; } 
        private Label lblCurrentDirectory { get; }
        private Button btnOpenDirectory { get; } 
    }
}
