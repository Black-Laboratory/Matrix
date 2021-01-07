using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn3DMatrix
{
    class Vector4
    {
        public double x, y, z, w;
        public Vector4() { }
        public Vector4(double x, double y, double z, double w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }
        public Vector4(Vector4 v)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = v.z;
            this.w = v.w;
        } 
        public static Vector4 operator +(Vector4 a, Vector4 b)
        {
            return new Vector4(a.x + b.x, a.y + b.y, a.z + b.z, a.w + b.w);
        } 
        public static Vector4 operator -(Vector4 a, Vector4 b)
        {
            return new Vector4(a.x - b.x, a.y - b.y, a.z - b.z, a.w - b.w);
        } 
        public static Vector4 operator *(Vector4 a, float b)
        {
            return new Vector4(a.x * b, a.y * b, a.z * b, a.w * b);
        }
        public static Vector4 operator /(Vector4 a, float b)
        {
            return new Vector4(a.x / b, a.y / b, a.z / b, a.w / b);
        }
        public static double Dot(Vector4 a ,Vector4 b)
        {
            return a.x * b.x + a.y * b.y + a.z * b.z; //+ a.w * b.w;
        }
        public static Vector4 Cross(Vector4 a, Vector4 b)
        {
            return new Vector4(a.y * b.z - a.z * b.y, a.z * b.x - a.x * b.z, a.x * b.y - a.y * b.x, 1);
        }
        public Vector4 Normalized
        {
            get { return new Vector4(x / Magnitude, y / Magnitude, z / Magnitude, w / Magnitude); }
        }
        public double Magnitude
        {
            get{ return Math.Sqrt(x * x + y * y + z * z + w * w); }
        }
    }
}
