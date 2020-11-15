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
    public class Cross : Shape
    {
        public Cross(int Width, int Height, Point Position,Color Color) : base(Width, Height, Position,Color) { }
        public override void Paint(Graphics graphics)
        {
            Pen pentwo = new Pen(Color.ForestGreen, 7);
            graphics.DrawLine(pentwo, Position.X - Width/2, Position.Y - Height/2, Position.X + Width/2, Position.Y + Height/2);
            graphics.DrawLine(pentwo, Position.X + Width/2, Position.Y - Height/2, Position.X - Width/2, Position.Y + Height/2);
        }


    }
}
