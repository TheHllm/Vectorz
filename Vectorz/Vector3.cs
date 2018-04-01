using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vectorz
{
    public class Vector3
    {
        #region Vars
        public double x = 0;
        public double y = 0;
        public double z = 0;
        #endregion
        #region Constructors
        public Vector3(double xx, double yy, double zz)
        {
            x = xx;
            y = yy;
            z = zz;
        }
        public Vector3()
        {
            x = 0;
            y = 0;
            z = 0;
        }
        public Vector3(Vector3 v)
        {
            x = v.x;
            y = v.y;
            z = v.z;
        }
        #endregion
        #region Operators
        //addiotn
        public static Vector3 operator +(Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
        }
        public static Vector3[] operator +(Vector3[] v,Vector3 m)
        {
            Vector3[] ret = new Vector3[v.Length];
            for(int i = 0; i< v.Length; i++)
            {
                ret[i] = v[i] + m;
            }
            return ret;
        }
        //subtraction
        public static Vector3 operator -(Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
        }
        //mul
        public static Vector3 operator *(Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.x * v2.x, v1.y * v2.y, v1.z * v2.z);
        }
        //div
        public static Vector3 operator /(Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.x / v2.x, v1.y / v2.y, v1.z / v2.z);
        }
        //mul
        public static Vector3 operator *(Vector3 v1, double a)
        {
            return new Vector3(v1.x * a, v1.y * a, v1.z * a);
        }
        //div
        public static Vector3 operator /(Vector3 v1, double a)
        {
            return new Vector3(v1.x / a, v1.y / a, v1.z / a);
        }
        public static bool operator ==(Vector3 v1, Vector3 v2)
        {
            if (v1.x == v2.x && v1.y == v2.y && v1.z == v2.z)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator !=(Vector3 v1, Vector3 v2)
        {
            return !(v1 == v2);
        }
        #endregion
        #region Equals and hash
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return (int)(x + y + z);
        }
        #endregion
        #region Maths
        public void Scale(int s)
        {
            x *= s;
            y *= s;
            z *= s;
        }
        public void RotateX(double ang)
        {
            double bg = grad(ang % 360);
            double xx = x;
            double yy = y * Math.Cos(bg) - z * Math.Sin(bg);
            double zz = y * Math.Sin(bg) + z * Math.Cos(bg);
            x = xx;
            y = yy;
            z = zz;
        }
        public void RotateY(double ang)
        {
            double bg = grad(ang % 360);
            double xx = x * Math.Cos(bg) + z * Math.Sin(bg);
            double yy = y;
            double zz = -x * Math.Sin(bg) + z * Math.Cos(bg);
            x = xx;
            y = yy;
            z = zz;

        }
        public void RotateZ(double ang)
        {
            double bg = grad(ang % 360);
            double xx = x * Math.Cos(bg) - y * Math.Sin(bg);
            double yy = x * Math.Sin(bg) + y * Math.Cos(bg);
            double zz = z;
            x = xx;
            y = yy;
            z = zz;
        }
        public void Rotate(Vector3 ang)
        {
            this.RotateX(ang.x);
            this.RotateY(ang.y);
            this.RotateZ(ang.z);
        }
        private double grad(double a)
        {
            return (2 * Math.PI) / 360 * a;
        }

        public Vector2 Transform()
        {
            return new Vector2(-0.355 * x + y,-0.355 * x + z);
        }
        #endregion
    }
    #region Extensions
    public static class VectorExtensionMethods
    {
        public static void Rotate(this Vector3[] arr,Vector3 ang)
        {
            foreach(Vector3 v in arr)
            {
                v.Rotate(ang);
            }
        }
        public static void Scale(this Vector3[] arr, int scale)
        {
            foreach (Vector3 v in arr)
            {
                v.Scale(scale);
            }
        }
        public static Vector2[] Transform(this Vector3[] arr)
        {
            Vector2[] ar = new Vector2[arr.Length];
            for(int i = 0; i < arr.Length; i++)
            {
                ar[i] = arr[i].Transform();
            }
            return ar;
        }
    }
    #endregion
}
