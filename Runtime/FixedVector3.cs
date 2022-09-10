
using UnityEngine;

using System;
using Unity.Mathematics;

namespace FixedMath
{
    public struct FixedVector3
    {
        public FixedInt x;
        public FixedInt y;
        public FixedInt z;
        public FixedVector3(FixedInt x, FixedInt y, FixedInt z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public FixedVector3(int3 v)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = v.z;
        }


        public FixedVector3(Vector3 v)
        {
            this.x = (FixedInt)v.x;
            this.y = (FixedInt)v.y;
            this.z = (FixedInt)v.z;
        }
        public FixedVector3(float3 v)
        {
            this.x = (FixedInt)v.x;
            this.y = (FixedInt)v.y;
            this.z = (FixedInt)v.z;
        }
        /// <summary>
        /// 将确定性数转化成表现层数，不可再参与运算
        /// </summary>
        /// <returns></returns>
        public Vector3 ConvertViewVector3()
        {
            return new Vector3(x.RawFloat, y.RawFloat, z.RawFloat);
        }
        public int3 ConvertToInt3()
        {
            return new int3(x.RawInt, y.RawInt, z.RawInt);
        }



        public FixedInt this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return x;
                    case 1:
                        return y;
                    case 2:
                        return z;
                    default:
                        return 0;
                }

            }
            set
            {
                switch (index)
                {
                    case 0:
                        x = value;
                        break;
                    case 1:
                        y = value;
                        break;
                    case 2:
                        z = value;
                        break;

                }

            }
        }

        public long[] ConvertLongArray()
        {
            return new long[] { x.ScaledValue, y.ScaledValue, z.ScaledValue };
        }

        #region 运算符
        public static FixedVector3 operator +(FixedVector3 a, FixedVector3 b)
        {
            return new FixedVector3((FixedInt)(a.x + b.x), (FixedInt)(a.y + b.y), (FixedInt)(a.z + b.z));
        }
        public static FixedVector3 operator -(FixedVector3 a, FixedVector3 b)
        {
            return new FixedVector3((FixedInt)(a.x - b.x), (FixedInt)(a.y - b.y), (FixedInt)(a.z - b.z));
        }
        public static FixedVector3 operator *(FixedVector3 a, FixedInt b)
        {
            return new FixedVector3((FixedInt)(a.x * b), (FixedInt)(a.y * b), (FixedInt)(a.z * b));
        }
        public static FixedVector3 operator /(FixedVector3 a, FixedInt b)
        {
            return new FixedVector3((FixedInt)(a.x / b), (FixedInt)(a.y / b), (FixedInt)(a.z / b));
        }

        public static FixedVector3 operator -(FixedVector3 a)
        {
            return new FixedVector3((FixedInt)(-a.x), (FixedInt)(-a.y), (FixedInt)(-a.z));
        }
        public static bool operator ==(FixedVector3 a, FixedVector3 b)
        {
            return a.x == b.x && a.y == b.y && a.z == b.z;
        }
        public static bool operator !=(FixedVector3 a, FixedVector3 b)
        {
            return a.x != b.x || a.y != b.y || a.z != b.z;
        }


        #endregion

        public FixedInt sqrMagnitude
        {
            get => x * x + y * y + z * z;
        }
        public static FixedInt SqrMagnitude(FixedVector3 v)
        {
            return v.x * v.x + v.y * v.y + v.z * v.z;
        }

        public FixedInt magnitude
        {
            get => FixedCalculate.Sqrt(this.sqrMagnitude);
        }

        public FixedVector3 normalize
        {
            get
            {
                if (magnitude > 0)
                {
                    FixedInt rate = (FixedInt)1 / magnitude;
                    return new FixedVector3(x * rate, y * rate, z * rate);
                }
                return new FixedVector3(0, 0, 0);
            }
        }
        public static FixedVector3 Normalize(FixedVector3 a)
        {
            if (a.magnitude > 0)
            {
                FixedInt rate = (FixedInt)1 / a.magnitude;
                return new FixedVector3(a.x * rate, a.y * rate, a.z * rate);
            }
            return new FixedVector3(0, 0, 0);
        }

        public static FixedInt Dot(FixedVector3 a, FixedVector3 b)
        {
            return a.x * b.x + a.y * b.y + a.z * b.z;
        }
        /// <summary>
        /// 向量叉乘，返回同时垂直两向量的向量
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static FixedVector3 Cross(FixedVector3 a, FixedVector3 b)
        {
            return new FixedVector3(a.y * b.z - a.z * b.y, a.z * b.x - a.x * b.z, a.x * b.y - a.y * b.x);
        }

        public static FixedArgs Angle(FixedVector3 from, FixedVector3 to)
        {
            FixedInt dot = Dot(from, to);
            FixedInt mod = from.magnitude * to.magnitude;
            if (mod == (FixedInt)0) return new FixedArgs(0, 10000);

            FixedInt value = dot / mod;

            return FixedCalculate.Acos(value);
        }




        public override string ToString()
        {
            return string.Format("x:{0} y:{1} z:{2}", x, y, z);
        }

        public override int GetHashCode()
        {
            return x.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            FixedVector3 v = (FixedVector3)(obj);
            return v.x == x && v.y == y && v.z == z;
        }


    }
}