using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Learn3DMatrix
{
    class Triangle3D
    {
        public Vector4 A, B, C;
        public Vector4 Normal;
        //Data
        private Vector4 a, b, c;
        private Vector4 normal;
        private double dot;
        private bool cullBack;
        public Triangle3D() { }
        public Triangle3D(Vector4 a, Vector4 b, Vector4 c)
        {
            this.A = this.a = new Vector4(a);
            this.B = this.b = new Vector4(b);
            this.C = this.c = new Vector4(c);
            Vector4 u = this.b - this.a;
            Vector4 v = this.c - this.a;
            this.Normal = this.normal = Vector4.Cross(u, v);
            //this.N = this.n = (this.b - this.a) * (this.c - this.a)
        }
        //三角形利用矩阵的乘法进行变换
        public void Transform(Matrix4x4 m)
        { 
            this.a = m.Mul(this.A);
            this.b = m.Mul(this.B);
            this.c = m.Mul(this.C);
        } 
        public void CalculateLighting(Matrix4x4 _Object2World,Vector4 light)
        {
            Transform(_Object2World);

            Vector4 u = this.b - this.a;
            Vector4 v = this.c - this.a;
            normal = Vector4.Cross(u, v);
            dot = Vector4.Dot(normal.Normalized, light.Normalized);
            dot = dot * 0.5 + 0.5;
            //dot = Math.Max(0, dot); 
            Vector4 camera = new Vector4(0, 0, -1, 0);
            cullBack = Vector4.Dot(normal.Normalized, camera) < 0 ? true : false;  
            //视向量为(0,0,-1,0)，是否
        }
        //绘制三角形到2D窗口上
        public void Draw(PaintEventArgs e, bool isMesh)
        {
            Graphics g = e.Graphics;
            if(isMesh)
            {
                g.DrawLines(new Pen(Color.Black, 2), Get2DPointFArray());
            }
            else
            {
                if(!cullBack)
                {
                    GraphicsPath path = new GraphicsPath();
                    path.AddLines(this.Get2DPointFArray());
                    int cValue = (int)(200 * dot) + 55;
                    Color color = Color.FromArgb(255, 0, 0, cValue);
                    Brush brush = new SolidBrush(color);
                    g.FillPath(brush, path);
                }
            }
            //g.DrawLine(new Pen(Color.Green, 2), Get2DPointF(this.a), Get2DPointF(normal.Normalized / 250));
        }
        private PointF[] Get2DPointFArray()
        {
            PointF[] arr = new PointF[4];
            arr[0] = Get2DPointF(this.a);
            arr[1] = Get2DPointF(this.b);
            arr[2] = Get2DPointF(this.c);
            arr[3] = arr[0];
            return arr;
        }

        private PointF Get2DPointF(Vector4 v)
        {
            PointF p = new PointF();
            p.X = (float)(v.x / v.w);
            p.Y = -(float)(v.y / v.w);
            return p;
        }
    }
}
