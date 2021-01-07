using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Learn3DMatrix
{
    public partial class Form1 : Form
    {
        Triangle3D t;
        Matrix4x4 m_Scale;
        Matrix4x4 m_RotateX;
        Matrix4x4 m_RotateY;
        Matrix4x4 m_RotateZ;
        Matrix4x4 m_View;
        Matrix4x4 m_Project;

        Cube cube;
        int a = 0;
        public Form1()
        {
            InitializeComponent();
            m_Scale = new Matrix4x4();
            m_Scale[1, 1] = 250;
            m_Scale[2, 2] = 250;
            m_Scale[3, 3] = 250;
            m_Scale[4, 4] = 1; 

            m_View = new Matrix4x4();
            m_View[1, 1] = 1;
            m_View[2, 2] = 1;
            m_View[3, 3] = 1;
            m_View[4, 3] = 250;
            m_View[4, 4] = 1;

            m_Project = new Matrix4x4();
            m_Project[1, 1] = 1;
            m_Project[2, 2] = 1;
            m_Project[3, 3] = 1;
            m_Project[3, 4] = 1.0d / 250;
            //m_Project[4, 4] = 1;

            RefreshLabel(m_View[4, 3].ToString());
            m_RotateX = new Matrix4x4();
            m_RotateY = new Matrix4x4();
            m_RotateZ = new Matrix4x4();
            cube = new Cube();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Vector4 a = new Vector4(0, 0.5, 0, 1);
            Vector4 b = new Vector4(0.5, -0.5, 0, 1);
            Vector4 c = new Vector4(-0.5, -0.5, 0, 1);
            t = new Triangle3D(a,b,c); 
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            int width = e.ClipRectangle.Width;
            int height = e.ClipRectangle.Height;
            e.Graphics.TranslateTransform((float)width / 2, (float)height / 2);
            e.Graphics.DrawLine(new Pen(Color.Red, 2), new PointF(-width / 2, 0), new PointF(width / 2, 0));
            e.Graphics.DrawLine(new Pen(Color.Blue, 2), new PointF(0, -height / 2), new PointF(0, height / 2));
            cube.Draw(e,this.mesh.Checked);
            //t.Draw(e);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            a += 1;
            double angle = a / 180.0 * Math.PI;
            //X_Axis
            m_RotateX[1, 1] = 1;
            m_RotateX[2, 2] = Math.Cos(angle);
            m_RotateX[2, 3] = Math.Sin(angle);
            m_RotateX[3, 2] = -Math.Sin(angle);
            m_RotateX[3, 3] = Math.Cos(angle);
            m_RotateX[4, 4] = 1;

            //Y_Axis
            m_RotateY[1, 1] = Math.Cos(angle);
            m_RotateY[1, 3] = Math.Sin(angle);
            m_RotateY[2, 2] = 1;
            m_RotateY[3, 1] = -Math.Sin(angle);
            m_RotateY[3, 3] = Math.Cos(angle);
            m_RotateY[4, 4] = 1;

            //Z_Axis 
            m_RotateZ[1, 1] = Math.Cos(angle);
            m_RotateZ[1, 2] = Math.Sin(angle);
            m_RotateZ[2, 1] = -Math.Sin(angle);
            m_RotateZ[2, 2] = Math.Cos(angle);
            m_RotateZ[3, 3] = 1;
            m_RotateZ[4, 4] = 1;

            Matrix4x4 mRotateMix = new Matrix4x4();
            mRotateMix[1, 1] = 1;
            mRotateMix[2, 2] = 1;
            mRotateMix[3, 3] = 1;
            mRotateMix[4, 4] = 1;

            if(this.xRotate.Checked)
            {
                //Matrix4x4 tx = m_RotateX.Transpose(); 
                mRotateMix = mRotateMix.Mul(m_RotateX);
            }

            if (this.yRotate.Checked)
            {
                //Matrix4x4 ty = m_RotateY.Transpose();
                mRotateMix = mRotateMix.Mul(m_RotateY);
            }
            if (this.zRotate.Checked)
            {
                //Matrix4x4 tz = m_RotateZ.Transpose();
                mRotateMix = mRotateMix.Mul(m_RotateZ);
            }

              
            Matrix4x4 m = m_Scale.Mul(mRotateMix);
            //t.Transform(m);
            //t.CalculateLighting(m, new Vector4(0, 1, -1, 0));
            cube.CalculateLighting(m, new Vector4(0, 1, -1, 0));

            Matrix4x4 mv = m.Mul(m_View);
            Matrix4x4 mvp = mv.Mul(m_Project);
            //t.Transform(mvp);
            cube.Transform(mvp);
            this.Invalidate();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            m_View[4, 3] = (sender as TrackBar).Value;
            RefreshLabel(m_View[4, 3].ToString());
        }

        private void RefreshLabel(string info)
        {
            label1.Text = info;
        }
    }
}
