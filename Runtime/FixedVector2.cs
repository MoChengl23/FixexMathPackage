
using UnityEngine;

using System;
using Unity.Mathematics;

namespace FixedMath
{
    public struct FixedVector2
    {
        public FixedInt X;
        public FixedInt Y;

        // private FixedInt x;
        // private FixedInt y;

        public FixedVector2(FixedInt x, FixedInt y)
        {
            this.X = x;
            this.Y = y;
        }


        public FixedVector2(Vector2 v)
        {
            this.X = (FixedInt)v.x;
            this.Y = (FixedInt)v.y;

        }
        public static implicit operator FixedVector2(int2 i)
        {
            return new FixedVector2(i.x, i.y);
        }
        public FixedVector2(int2 v)
        {
            this.X = v.x;
            this.Y = v.y;

        }
        /// <summary>
        /// 将确定性数转化成表现层数，不可再参与运算
        /// </summary>
        /// <returns></returns>
        public Vector2 ConvertViewVector2()
        {
            return new Vector2(X.RawFloat, Y.RawFloat);
        }
        public int2 ConvertToint2()
        {
            return new int2(X.RawInt, Y.RawInt);
        }




        public FixedInt this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return X;
                    case 1:
                        return Y;

                    default:
                        return 0;
                }

            }
            set
            {
                switch (index)
                {
                    case 0:
                        X = value;
                        break;
                    case 1:
                        Y = value;
                        break;



                }

            }
        }

        public long[] ConvertLongArray()
        {
            return new long[] { X.ScaledValue, Y.ScaledValue };
        }

        #region 运算符
        public static FixedVector2 operator +(FixedVector2 a, FixedVector2 b)
        {
            return new FixedVector2((FixedInt)(a.X + b.X), (FixedInt)(a.Y + b.Y));
        }
        public static FixedVector2 operator -(FixedVector2 a, FixedVector2 b)
        {
            return new FixedVector2((FixedInt)(a.X - b.X), (FixedInt)(a.Y - b.Y));
        }

        public static FixedInt operator *(FixedVector2 vector1, FixedVector2 vector2)
        {
            return vector1.X * vector2.X + vector1.Y * vector2.Y;
        }
        public static FixedVector2 operator *(FixedVector2 vector, FixedInt scalar)
        {
            return new FixedVector2(vector.X * scalar, vector.Y * scalar);
        }
        public static FixedVector2 operator *(FixedInt b, FixedVector2 a)
        {
            return a * b;
        }
        //return dot
        // public static FixedInt operator *(FixedVector2 a, FixedVector2 b)
        // {
        //     FixedInt X = a.X * b.X;
        //     FixedInt Y = a.Y * b.Y;
        //     if ((a.X != 0 && b.X != 0 && X == 0) ||
        //           (a.Y != 0 && b.Y != 0 && Y == 0))
        //     {
        //         return new FixedInt((long)1);
        //     }
        //     return X + Y;
        // }

        public static FixedVector2 operator /(FixedVector2 a, FixedInt b)
        {
            return new FixedVector2((FixedInt)(a.X / b), (FixedInt)(a.Y / b));
        }

        public static FixedVector2 operator -(FixedVector2 a)
        {
            return new FixedVector2((FixedInt)(-a.X), (FixedInt)(-a.Y));
        }
        public static bool operator ==(FixedVector2 a, FixedVector2 b)
        {
            return a.X == b.X && a.Y == b.Y;
        }
        public static bool operator !=(FixedVector2 a, FixedVector2 b)
        {

            return a.X != b.X || a.Y != b.Y;
        }


        #endregion
        /// <summary>
        /// 用（-1，-1）作为invaild标志
        /// </summary>
        /// <value></value>
        public static FixedVector2 inVaild
        {
            get => new FixedVector2(-1, -1);
        }

        public FixedInt square
        {
            get => X * X + Y * Y;

        }

        public FixedInt magnitude
        {
            get => FixedCalculate.Sqrt(this.square);
        }

        public FixedVector2 normalize
        {
            get
            {
                if (magnitude > 0)
                {
                    FixedInt rate = (FixedInt)1 / magnitude;
                    return new FixedVector2(X * rate, Y * rate);
                }
                return new FixedVector2(0, 0);
            }
        }
        public static FixedVector2 Normalize(FixedVector2 a)
        {
            if (a.magnitude > 0)
            {
                FixedInt rate = (FixedInt)1 / a.magnitude;
                return new FixedVector2(a.X * rate, a.Y * rate);
            }
            return new FixedVector2(0, 0);
        }
        /// <summary>
        /// a.X * b.X + a.Y * b.Y
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static FixedInt Dot(FixedVector2 a, FixedVector2 b)
        {
            return a.X * b.X + a.Y * b.Y;
        }

        // / <summary>
        // / 向量叉乘，返回同时垂直两向量的向量
        // / </summary>
        // / <param name="a"></param>
        // / <param name="b"></param>
        // / <returns></returns>
        // public static FixedVector2 Cross(FixedVector2 a,FixedVector2 b){
        //     return new FixedVector2(a.Y *b.z - a.z*b.Y,a.z*b.X-a.X*b.z, a.X*b.Y - a.Y*b.X);
        // }


        /// <summary>
        /// a.X * b.Y - a.Y + b.X
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static FixedInt Det(FixedVector2 a, FixedVector2 b)
        {
            return a.X * b.Y - a.Y * b.X;
        }



        /// <summary>
        /// Computes the squared distance from a line segment with the  specified endpoints to a specified point.
        /// </summary>
        /// <param name="vector1">The first endpoint of the line segment.</param>
        /// <param name="vector2">The second endpoint of the line segment.</param>
        /// <param name="vector3">The point to which the squared distance is to be calculated.</param>
        /// <returns>The squared distance from the line segment to the point.</returns>
        public static FixedInt DistSqPointLineSegment(FixedVector2 vector1, FixedVector2 vector2, FixedVector2 vector3)
        {
            FixedInt r = ((vector3 - vector1) * (vector2 - vector1)) / (vector2 - vector1).square;

            if (r < 0)
            {
                return (vector3 - vector1).square;
            }

            if (r > 1)
            {
                return (vector3 - vector2).square;
            }

            return (vector3 - (vector1 + r * (vector2 - vector1))).square;

        }

        public static FixedInt LeftOf(FixedVector2 a, FixedVector2 b, FixedVector2 c)
        {
            return Det(a - c, b - a);
        }

        public static bool IntheSameSide(FixedVector2 baseone, FixedVector2 a, FixedVector2 b)
        {
            return Det(baseone, a).sign == Det(baseone, b).sign;


        }


        public override string ToString()
        {
            return string.Format("x:{0} y:{1}  ", X, Y);
        }

        public override int GetHashCode()
        {
            return X.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            FixedVector2 v = (FixedVector2)(obj);
            return v.X == X && v.Y == Y;
        }



















        public static FixedInt abs(FixedVector2 vector)
        {
            return sqrt(absSq(vector));
        }
        public static FixedInt absSq(FixedVector2 vector)
        {
            return vector * vector;
        }

        // public static FixedVector2 normalize(FixedVector2 vector)
        // {
        //     // if(abs(vector) == 0) return vector;
        //     return vector / abs(vector);
        // }
        public static FixedInt det(FixedVector2 vector1, FixedVector2 vector2)
        {
            return vector1.X * vector2.Y - vector1.Y * vector2.X;
        }
        public static FixedInt fabs(FixedInt scalar)
        {
            if (scalar >= 0)
                return scalar;
            return -scalar;

        }
        public static FixedInt sqr(FixedInt scalar)
        {
            return scalar * scalar;
        }
        public static FixedInt sqrt(FixedInt scalar)
        {
            return FixedCalculate.Sqrt(scalar);
        }




















    }
}