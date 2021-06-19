using SadConsole;
using SadConsole.UI.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomizer.Generator.MonoGame.ScreenSurfaces
{
    class TextSurface : SurfaceViewer
    {
        public TextSurface(Int32 viewWidth, Int32 viewHeight, ICellSurface cellSurface) : base (viewWidth, viewHeight, cellSurface)
        {

        }

        public void UpOneLine()
        {
            Surface.ViewPosition -= (0, 1);
            IsDirty = true;
        }

        public void DownOneLine()
        {
            Surface.ViewPosition += (0, 1);
            IsDirty = true;
        }
    }
}
