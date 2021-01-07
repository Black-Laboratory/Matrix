using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Learn3DMatrix
{
    class Cube
    {
        Vector4 a = new Vector4(-0.5, 0.5, 0.5, 1);
        Vector4 b = new Vector4(0.5, 0.5, 0.5, 1);
        Vector4 c = new Vector4(0.5, 0.5, -0.5, 1);
        Vector4 d = new Vector4(-0.5, 0.5, -0.5, 1); 
        Vector4 e = new Vector4(-0.5, -0.5, 0.5, 1);
        Vector4 f = new Vector4(0.5, -0.5, 0.5, 1);
        Vector4 g = new Vector4(0.5, -0.5, -0.5, 1);
        Vector4 h = new Vector4(-0.5, -0.5, -0.5, 1);

        private Triangle3D[] triangels = new Triangle3D[12];
        public Cube()
        {
            //Top
            triangels[0] = new Triangle3D(a, b, c);
            triangels[1] = new Triangle3D(a, c, d);
            //Bottom
            triangels[2] = new Triangle3D(e, h, f);
            triangels[3] = new Triangle3D(f, h, g);
            //Front
            triangels[4] = new Triangle3D(d, c, g);
            triangels[5] = new Triangle3D(d, g, h);
            //Back
            triangels[6] = new Triangle3D(b, e, f);
            triangels[7] = new Triangle3D(b, a, e);
            //Lift
            triangels[8] = new Triangle3D(a, d, h);
            triangels[9] = new Triangle3D(a, h, e);
            //Right
            triangels[10] = new Triangle3D(c, f, g);
            triangels[11] = new Triangle3D(c, b, f);
        }
        public void Transform(Matrix4x4 m)
        {
            for (int i = 0; i < triangels.Length; i++)
                triangels[i].Transform(m);
        }
        public void CalculateLighting(Matrix4x4 _Object2World,Vector4 l)
        {
            for (int i = 0; i < triangels.Length; i++)
                triangels[i].CalculateLighting(_Object2World, l);
        } 
        public void Draw(PaintEventArgs e, bool isMesh)
        { 
            for (int i = 0; i < triangels.Length; i++)
                triangels[i].Draw(e, isMesh);
        }
    }
}
