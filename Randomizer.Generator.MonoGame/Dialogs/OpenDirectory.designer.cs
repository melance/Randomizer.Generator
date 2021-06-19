using Randomizer.Generator.MonoGame.Utility;
using SadConsole;
using SadConsole.UI.Controls;
using SadRogue.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomizer.Generator.MonoGame.Dialogs
{
    partial class OpenDirectory
    {
        private const String CANCEL_TEXT = "Cancel";
        private const String OK_TEXT = "Ok";
        private const String HEADER_TEXT = "Select a directory";

        public OpenDirectory(String directory, Int32 x, Int32 y, Int32 width, Int32 height) : base(width, height)
        {
            Position = new Point(x, y);
            this.DrawWindowBorder(HEADER_TEXT);
                        
            lstDirectoryList = new(width - 4, height - 5)
            {
                Position = new Point(2, 3)
            };

            btnOk = new(OK_TEXT.Length + 2)
            {
                Text = OK_TEXT,
                Position = new Point(Width - OK_TEXT.Length - 3, Height - 2)
            };
            btnCancel = new(CANCEL_TEXT.Length + 2)
            {
                Text = CANCEL_TEXT,
                Position = new Point(btnOk.Position.X - CANCEL_TEXT.Length - 3, btnOk.Position.Y)
            };
            
            btnCancel.Click += btnCancel_Click;
            btnOk.Click += btnOk_Click;
            lstDirectoryList.SelectedItemExecuted += lstDirectoryList_SelectedItemExecuted;

            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Controls.Add(lstDirectoryList);

            CurrentDirectory = directory;
            LoadDirectories();
        }

        private ListBox lstDirectoryList { get; }
        private Button btnCancel { get; }
        private Button btnOk { get; }
    }
}
