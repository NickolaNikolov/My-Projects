using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Graphics_editor
{
    public partial class Design_editor : Form
    {
        
        public Point MouseDownLocation;
        private bool button1WasClicked = false;
        private bool button2WasClicked = false;
        private bool button3WasClicked = false;
        private List<Shape> _shapes = new List<Shape>();
        private List<Shape> _selectedRectangles = new List<Shape>();
        private List<Shape> WhereContains(int x, int y)
        {
            List<Shape> resultlist = new List<Shape>();
            foreach (var shape in _shapes)
            {
                if (shape.Contains(new Point(x, y)))
                {
                    resultlist.Add(shape);
                }

            }
            return resultlist;
        }

        public Design_editor()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }
        protected override void OnPaint(PaintEventArgs e)
        {

            base.OnPaint(e);
            foreach (var shape in _shapes)
            {
                shape.Paint(e.Graphics);

            }

        }

        private void Design_editor_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1WasClicked = true;
            button2WasClicked = false;
            button3WasClicked = false;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1WasClicked = false;
            button2WasClicked = true;
            button3WasClicked = false;


        }

        private void button3_Click(object sender, EventArgs e)
        {
            button1WasClicked = false;
            button2WasClicked = false;
            button3WasClicked = true;

        }

        Shape rectangle = new Rectangle(60, 60, Cursor.Position, Color.Blue);
        private void Design_editor_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (button1WasClicked == true)
                {
                    rectangle = new Rectangle(60, 60, e.Location, Color.DarkRed);

                    _shapes.Add(rectangle);
                    using (var graphics = this.CreateGraphics())
                    {
                        rectangle.Paint(graphics);
                    }
                }
                if (button2WasClicked == true)
                {
                    Shape cross = new Cross(70, 70, e.Location, Color.ForestGreen);
                    _shapes.Add(cross);
                    using (var graphics = this.CreateGraphics())
                    {
                        cross.Paint(graphics);
                    }

                }
                if (button3WasClicked == true)
                {
                    Shape circle = new Circle(80, 80, e.Location, Color.SkyBlue);
                    _shapes.Add(circle);
                    using (var graphics = this.CreateGraphics())
                    {
                        circle.Paint(graphics);
                    }

                }
                Invalidate();
                
            }
            if (e.Button == MouseButtons.Right)
            {
                using (var graphics = this.CreateGraphics())
                {
                    ColorDialog col = new ColorDialog();
                    col.ShowDialog();
                    Pen mypen = new Pen(col.Color, 5);
                    if (button1WasClicked == true)
                    {
                      graphics.DrawRectangle(mypen, e.Location.X, e.Location.Y, 60, 60);
                    }
                    else if (button2WasClicked == true)
                    {
                        graphics.DrawLine(mypen, e.Location.X - 35, e.Location.Y - 35, e.Location.X + 35, e.Location.Y + 35);
                        graphics.DrawLine(mypen, e.Location.X - 35, e.Location.Y + 35, e.Location.X + 35, e.Location.Y - 35);
                    }
                    else if (button3WasClicked == true)
                    {
                        graphics.DrawEllipse(mypen, e.Location.X - 40, e.Location.Y - 40, 80, 80);
                    }
                }
            }
        }
        private void Design_editor_MouseMove(object sender, MouseEventArgs e)
        {
            Shape rectangle = new Rectangle(60, 60, e.Location, Color.Blue);
            if (e.Button == MouseButtons.Left)
            {

                rectangle.Width = e.X - 60;
                rectangle.Height = e.Y - 60;
                this.Invalidate();
            }

            if (e.Button == MouseButtons.Right)
            {
                rectangle.Position = new Point((e.X - MouseDownLocation.X), (e.Y - MouseDownLocation.Y));
                MouseDownLocation = e.Location;
                this.Invalidate();
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            _shapes.Clear();

        }
        private void Design_editor_MouseUp(object sender, MouseEventArgs e)
        {
            if(_selectedRectangles == null)
            {
                return;
            }
            using (var graphics = this.CreateGraphics())
            {               
                foreach (var selectedRectangle in _selectedRectangles)
                {
                    selectedRectangle.Color = Color.Blue    ;
                    selectedRectangle.Paint(graphics);

                }
            }
            _selectedRectangles = null; 
        }

        private void button5_Click(object sender, EventArgs e)
        {

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.ShowDialog();


            if (saveFileDialog1.FileName != "")
            {

                System.IO.FileStream fs =
                   (System.IO.FileStream)saveFileDialog1.OpenFile();

                switch (saveFileDialog1.FilterIndex)
                {
                    case 1:
                        this.button5.Image.Save(fs,
                           System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;

                    case 2:
                        this.button5.Image.Save(fs,
                           System.Drawing.Imaging.ImageFormat.Bmp);
                        break;

                    case 3:
                        this.button5.Image.Save(fs,
                           System.Drawing.Imaging.ImageFormat.Gif);
                        break;
                }

                fs.Close();
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.button6.Click += new System.EventHandler(this.button1_Click);
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.ShowDialog();
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.IO.StreamReader sr = new
                   System.IO.StreamReader(openFileDialog1.FileName);
                MessageBox.Show(sr.ReadToEnd());
                sr.Close();
            }
        }

    }
}
