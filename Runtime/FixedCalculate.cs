using System.Numerics;
using System;
namespace FixedMath
{
    public class FixedCalculate
    {

        public static FixedInt superSmallValue = (FixedInt)(long)1 << 5;
        public static FixedInt superBigValue = 9999;

        /// <summary>
        /// 求平方
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static FixedInt Square(FixedInt a) => a * a;

        /// <summary>
        /// 牛顿迭代法求平方根
        /// </summary>
        /// <param name="a">传入值</param>
        /// <param name="interatorCount">迭代次数</param>
        /// <returns></returns>
        public static FixedInt Sqrt(FixedInt a, int interatorCount = 8)
        {
            if (a == 0) return 0;

            if (a < 0) throw new Exception();

            FixedInt result = a;

            FixedInt pre = result;
            for (int i = 0; i < interatorCount; i++)
            {
                result = (result + a / result) >> 1;
                if (pre == result) break;

                pre = result;
            }

            return result;
        }

        public static FixedArgs Acos(FixedInt a)
        {
            FixedInt rate = (a * AcosTable.HalfIndexCount) + AcosTable.HalfIndexCount;
            rate = Clamp(rate, 0, AcosTable.IndexCount);
            //rad = 弧度
            // int rad = AcosTable.table[rate.RawInt];
            return new FixedArgs(AcosTable.table[rate.RawInt], AcosTable.Multipler);



        }
        /// <summary>
        /// clamp
        /// </summary>
        /// <param name="input"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static FixedInt Clamp(FixedInt input, FixedInt min, FixedInt max)
        {
            if (input < min) return min;
            if (input > max) return max;
            return input;
        }
        /// <summary>
        /// min
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static FixedInt Min(FixedInt a, FixedInt b)
        {
            if (a <= b) return a;
            return b;
        }
        /// <summary>
        /// max
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static FixedInt Max(FixedInt a, FixedInt b)
        {
            if (a >= b) return a;
            return b;
        }

        /// <summary>
        /// 模长
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static FixedInt Abs(FixedInt a)
        {
            if (a >= 0) return a;
            return -a;
        }











        #region Vector2


        /// <summary>
        /// 模长
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public static FixedInt Abs(FixedVector2 vector)
        {
            return Sqrt(Square(vector));
        }
        /// <summary>
        /// 平方
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public static FixedInt Square(FixedVector2 vector)
        {
            return vector * vector;
        }
        /// <summary>
        /// distance
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static FixedInt Distance(FixedVector2 a, FixedVector2 b)
        {
            return Abs(a - b);
        }
        /// <summary>
        /// a.X * b.X + a.Y * b.Y
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static FixedInt Dot(FixedVector2 a, FixedVector2 b)
        {
            return FixedVector2.Dot(a, b);
        }

        /// <summary>
        /// 标准化
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public static FixedVector2 Normalize(FixedVector2 vector)
        {
            // return vector / Abs(vector);
            return vector.normalize;
        }
        /// <summary>
        /// 返回行列式的值,a.X * b.Y - a.Y + b.X
        /// </summary>
        /// <param name="vector1"></param>
        /// <param name="vector2"></param>
        /// <returns></returns>
        public static FixedInt Det(FixedVector2 vector1, FixedVector2 vector2)
        {
            return FixedVector2.Det(vector1, vector2);
            //  vector1.X * vector2.Y - vector1.Y * vector2.X;
        }
        public static FixedInt DistSqPointLineSegment(FixedVector2 vector1, FixedVector2 vector2, FixedVector2 vector3)
        {
            return FixedVector2.DistSqPointLineSegment(vector1, vector2, vector3);
        }
        /// <summary>
        /// 绝对值
        /// </summary>
        /// <param name="scalar"></param>
        /// <returns></returns>
        public static FixedInt Fabs(FixedInt scalar)
        {
            if (scalar >= 0)
                return scalar;
            return -scalar;

        }
        
        public static FixedInt LeftOf(FixedVector2 a, FixedVector2 b, FixedVector2 c)
        {
            return FixedVector2.LeftOf(a, b, c);
        }

        #endregion
    }
}