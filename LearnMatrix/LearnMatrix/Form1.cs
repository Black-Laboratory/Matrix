using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LearnMatrix
{
    public partial class Form1 : Form
    {
        Triangle t;
        int degrees = 1;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.TranslateTransform((float)e.ClipRectangle.Width / 2, (float)e.ClipRectangle.Height / 2);
            t.Draw(e.Graphics);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PointF a = new PointF(0, -200);
            PointF b = new PointF(200, 200);
            PointF c = new PointF(-200, 200);
            t = new Triangle(a, b, c);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //degrees++; 
            t.Rotate(degrees);
            this.Invalidate();
        }
    }
}
