using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace LearnMatrix
{
    class Triangle
    {
        struct PointFStruct
        {
            public PointF p;
            private PointF pConst;
            public PointF PConst { get => pConst;}
            public PointFStruct(PointF a)
            {
                this.p = pConst = a;
            } 
        }

        PointFStruct a, b, c;

        public Triangle(PointF a, PointF b, PointF c)
        {
            this.a = new PointFStruct(a);
            this.b = new PointFStruct(b);
            this.c = new PointFStruct(c);
        }
        public void Draw(Graphics g)
        {
            Pen pen = new Pen(Color.Red, 2);
            g.DrawLine(pen, a.p, b.p);
            g.DrawLine(pen, b.p, c.p);
            g.DrawLine(pen, c.p, a.p);
        }
        public void Rotate(int degree)
        {
            float angle = (float)(degree / 180.0f * Math.PI);
            SetPointRotate(ref a, angle);
            SetPointRotate(ref b, angle);
            SetPointRotate(ref c, angle);
        }

        private void SetPointRotate(ref PointFStruct t, float angle)
        {
            float newX = (float)( t.p.X * Math.Cos(angle));
            float newY = (float)( t.p.Y );
            //float newX = (float)(t.X * Math.Cos(angle) - t.Y * Math.Sin(angle));
            //float newY = (float)(t.X * Math.Sin(angle) + t.Y * Math.Cos(angle));
            //float newX = (float)(Math.Cos(angle) * t.X + Math.Sin(angle) * t.Y);
            //float newY = (float)(-Math.Sin(angle) * t.X + Math.Cos(angle) * t.Y);
            t.p.X = newX;
            t.p.Y = newY;
        }
        
    }
}
