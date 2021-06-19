using SadConsole.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomizer.Generator.MonoGame.Dialogs
{
    abstract class DialogControlConsole : ControlsConsole
    {
        public EventHandler Close;

        public DialogControlConsole(Int32 width, Int32 height) : base(width, height) { }

        protected void OnClose()
        {
            var handler = Close;
            Close?.Invoke(this, EventArgs.Empty);
        }
    }
}
