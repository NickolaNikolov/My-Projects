using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Graphics_editor
{
    public interface IGraphics
    {
        void DrawShape(Color color, int x, int y, int Width, int Height);
    }
}
