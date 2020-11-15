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
    public class Shape
    {
        public virtual void Paint(Graphics graphics)
        {
            Pen penthree = new Pen(Color.Black, 10);
        }

        public Point Position { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Color Color { get; set; }
        public bool Contains(Point point)
        {
            return
                Position.X < point.X && (Position.X + Width) > point.X &&
                Position.Y < point.Y && (Position.Y + Height) > point.Y;
        }
        public Shape(int Width, int Height, Point Position, Color Color)
        {
            this.Width = Width;
            this.Height = Height;
            this.Position = Position;
            this.Color = Color;
        }

    }
}
