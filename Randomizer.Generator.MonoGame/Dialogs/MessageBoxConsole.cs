using SadRogue.Primitives;
using SadConsole.UI;
using SadConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console = SadConsole.Console;
using Randomizer.Generator.MonoGame.Utility;
using TextCopy;

namespace Randomizer.Generator.MonoGame.Dialogs
{
    partial class MessageBoxConsole : Window
    {
		#region Enumerators
		public enum MessageBoxButtons
		{
			Ok = 1,
			Yes = 2,
			No = 4,
			Cancel = 8,
			Copy = 16
		}

		[Flags]
		public enum DialogResults
		{
			Ok,
			Yes,
			No,
			Cancel
		}
		#endregion

		#region Events
		public EventHandler Close;
		#endregion

		#region Methods
		public static MessageBoxConsole MessageBox(String title, String message, Int32 width, Console parent, Styles.MessageBoxStyles style = Styles.MessageBoxStyles.Information, MessageBoxButtons buttons = MessageBoxButtons.Ok | MessageBoxButtons.Copy)
        {
            var messageWrapped = message.WordWrap(width - 2);
            var height = 6 + messageWrapped.Count();
            var x = (parent.Width - width) / 2;
            var y = (parent.Height - height) / 2;
            var box = new MessageBoxConsole(x, y, width, height, title, messageWrapped.ToArray(), style, buttons);
            parent.Children.Add(box);
			return box;
        }

		private void OnClose(DialogResults dialogResult)
		{
			DialogResult = dialogResult;
			Game.Instance.FocusedScreenObjects.Pop(this);
			Parent = null;
			Hide();
			Close?.Invoke(this, EventArgs.Empty);
		}
		#endregion

		#region Properties
		public new DialogResults DialogResult { get; set; }
		#endregion

		#region Members
		private readonly String _message;
		#endregion

		#region Event Handlers

		private void btnCancel_Click(Object sender, EventArgs e)
		{
			OnClose(DialogResults.Cancel);
		}

        private void btnCopy_Click(Object sender, EventArgs e)
        {
            var cb = new Clipboard();
            cb.SetText(_message);
        }

		private void btnNo_Click(Object sender, EventArgs e)
		{
			OnClose(DialogResults.No);
		}

		private void btnOk_Click(Object sender, EventArgs e)
        {
			OnClose(DialogResults.Ok);
        }

		private void btnYes_Click(Object sender, EventArgs e)
		{
			OnClose(DialogResults.Yes);
		}
		#endregion
	}
}
