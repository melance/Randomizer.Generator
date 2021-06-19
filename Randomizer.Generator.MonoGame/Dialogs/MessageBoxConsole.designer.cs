using SadConsole;
using SadConsole.UI.Controls;
using SadRogue.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Randomizer.Generator.MonoGame.Utility;

namespace Randomizer.Generator.MonoGame.Dialogs
{
    partial class MessageBoxConsole
    {
		#region Constants
		private const String OK_TEXT = "Ok";
		private const String YES_TEXT = "Yes";
		private const String NO_TEXT = "No";
		private const String CANCEL_TEXT = "Cancel";
        private const String COPY_TEXT = "Copy Message";
		#endregion

		#region Constructors
		private MessageBoxConsole(Int32 x, Int32 y, Int32 width, Int32 height, String title, String[] message, Styles.MessageBoxStyles style, MessageBoxButtons buttons) : base(width, height)
        {
            CloseOnEscKey = true;
            CanDrag = true;

            _message = String.Join(" ", message);

            Center();

            ColoredGlyph borderColor;
            switch (style)
            {
                case Styles.MessageBoxStyles.Warning:
                    borderColor = new(Color.Yellow);
                    break;
                case Styles.MessageBoxStyles.Error:
                    borderColor = new(Color.Red);
                    break;
                default:
                    borderColor = Styles.BorderColor;
                    break;
            }

            this.DrawWindowBorder(title, borderColor);

            var messageY = 3;

            foreach (var line in message)
            {
                this.Print(2, messageY, line);
                messageY++;
            }
			
			AddButtons(buttons);

            Show(true);
        }
		#endregion

		#region Methods
		private void AddButtons(MessageBoxButtons buttons)
		{
			var x = Width;
			var y = Height - 2;
			if (buttons.HasFlag(MessageBoxButtons.Ok))
			{
				x -= (OK_TEXT.Length + 3);
				btnOk = new(OK_TEXT.Length + 2)
				{
					Position = new Point(x, y),
					Text = OK_TEXT
				};
				btnOk.Click += btnOk_Click;
				Controls.Add(btnOk);
			}
			if (buttons.HasFlag(MessageBoxButtons.Cancel))
			{
				x -= (CANCEL_TEXT.Length + 3);
				btnCancel = new(CANCEL_TEXT.Length + 2)
				{
					Position = new Point(x, y),
					Text = CANCEL_TEXT
				};
				btnCancel.Click += btnCancel_Click;
				Controls.Add(btnCancel);
			}
			if (buttons.HasFlag(MessageBoxButtons.Yes))
			{
				x -= (YES_TEXT.Length + 3);
				btnYes = new(YES_TEXT.Length + 2)
				{
					Position = new Point(x, y),
					Text = YES_TEXT
				};
				btnYes.Click += btnYes_Click;
				Controls.Add(btnYes);
			}
			if (buttons.HasFlag(MessageBoxButtons.No))
			{
				x -= (NO_TEXT.Length + 3);
				btnNo = new(NO_TEXT.Length + 2)
				{
					Position = new Point(x, y),
					Text = NO_TEXT
				};
				btnNo.Click += btnNo_Click;
				Controls.Add(btnNo);
			}
			if (buttons.HasFlag(MessageBoxButtons.Copy))
			{
				x -= (COPY_TEXT.Length + 3);
				btnCopy = new Button(COPY_TEXT.Length + 2)
				{
					Position = new Point(x, y),
					Text = COPY_TEXT
				};
				btnCopy.Click += btnCopy_Click;
				Controls.Add(btnCopy);
			}
		}
		#endregion

		#region Controls
		private Button btnOk { get; set; }
		private Button btnYes { get; set; }
		private Button btnNo { get; set; }
		private Button btnCancel { get; set; }
        private Button btnCopy { get; set; }
		#endregion
	}
}
