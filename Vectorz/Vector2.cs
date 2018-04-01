using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vectorz
{
    public class Vector2
    {
        #region Vars
        public double x = 0;
        public double y = 0;
        #endregion
        #region Constructors
        public Vector2()
        {
        
        }
        public Vector2(double xx,double yy)
        {
            x = xx;
            y = yy;
        }
        public Vector2(double a)
        {
            x = a;
            y = a;
        }
        #endregion
        #region Operators
        //addiotn
        public static Vector2 operator +(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.x + v2.x, v1.y + v2.y);
        }
        //subtraction
        public static Vector2 operator -(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.x - v2.x, v1.y - v2.y);
        }
        //mul
        public static Vector2 operator *(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.x * v2.x, v1.y * v2.y);
        }
        //div
        public static Vector2 operator /(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.x / v2.x, v1.y / v2.y);
        }
        //mul
        public static Vector2 operator *(Vector2 v1, double a)
        {
            return new Vector2(v1.x * a, v1.y * a);
        }
        //div
        public static Vector2 operator /(Vector2 v1, double a)
        {
            return new Vector2(v1.x / a, v1.y / a);
        }
        public static bool operator ==(Vector2 v1, Vector2 v2)
        {
            if (v1.x == v2.x && v1.y == v2.y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator !=(Vector2 v1, Vector2 v2)
        {
            return !(v1 == v2);
        }
        #endregion
        #region maths
        public double Length()
        {
            return Math.Sqrt(Math.Pow(this.x,2)+Math.Pow(this.y,2));
        }
        public void Normalize()
        {
            double xx;
            double yy;
            double l = this.Length();
            xx = x / l;
            yy = y / l;
            x = xx;
            y = yy;
        }
        public double Distance(Vector2 v)
        {
            return (this - v).Length();
        }
        #endregion
        #region Equals and hash
        public override bool Equals(object obj)
        {
            throw new NotImplementedException();
        }
        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
