using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn3DMatrix
{
    class Matrix4x4
    { 
        private const int row = 4;
        private const int col = 4;
        private double[,] pts;
        public Matrix4x4()
        {
            pts = new double[row, col];
        }
        public double this[int i, int j]
        { 
            get
            {
                if (i >= 1 && i <= row && j >= 1 && j <= col)
                    return pts[i-1, j-1];
                throw new Exception($"索引异常i:{i},应小于{row}；j:{j},应小于{col}");
            }
            set
            {
                if (i >= 1 && i <= row && j >= 1 && j <= col)
                    pts[i-1, j-1] = value;
                else
                    throw new Exception($"索引异常i:{i},应小于{row}；j:{j},应小于{col}");
            }
        }

        public Matrix4x4 Mul(Matrix4x4 m)
        {
            Matrix4x4 newM = new Matrix4x4();
            for (int w = 1; w <= row; w++)
                for (int h = 1; h <= col; h++)
                    for (int n = 1; n <= 4; n++)
                        newM[w, h] += this[w, n] * m[n, h];
            return newM;
        }

        public Vector4 Mul(Vector4 v)
        {
            Vector4 newV = new Vector4();
            newV.x = v.x * this[1, 1] + v.y * this[2, 1] + v.z * this[3, 1] + v.w * this[4, 1];
            newV.y = v.x * this[1, 2] + v.y * this[2, 2] + v.z * this[3, 2] + v.w * this[4, 2];
            newV.z = v.x * this[1, 3] + v.y * this[2, 3] + v.z * this[3, 3] + v.w * this[4, 3];
            newV.w = v.x * this[1, 4] + v.y * this[2, 4] + v.z * this[3, 4] + v.w * this[4, 4];
            return newV;
        }


        public Matrix4x4 Transpose()
        {
            Matrix4x4 t = new Matrix4x4();
            for (int w = 1; w <= row; w++)
                for (int h = 1; h <= col; h++)
                    t[w, h] = this[h, w];
            return t;
        }

    }
}
