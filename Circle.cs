using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphics_editor
{
    public class Circle : Shape
    {
        public Circle(int Width, int Height, Point Position,Color Color) : base(Width, Height, Position,Color) { }

        public override void Paint(Graphics graphics)
        {
            Pen penthree = new Pen(Color.SkyBlue, 10);
            graphics.DrawEllipse(penthree, Position.X - Width/2, Position.Y - Height/2, Width, Height);
            
        }
    }
}
