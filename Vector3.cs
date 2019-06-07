using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace REngine
{
    public class Vector3
    {
        public float[] Values;

        public float X
        {
            get { return Values[0]; }
            set { Values[0] = value; }
        }
        public float Y
        {
            get { return Values[1]; }
            set { Values[1] = value; }
        }
        public float Z
        {
            get { return Values[2]; }
            set { Values[2] = value; }
        }


        public Vector3()
        {
            Values = new float[3];
        }
        public Vector3(float all)
        {
            Values = new float[3];
            Values[0] = all;
            Values[1] = all;
            Values[2] = all;
        }
        public Vector3(float x, float y, float z)
        {
            Values = new float[3];
            Values[0] = x;
            Values[1] = y;
            Values[2] = z;
        }
        public Vector3(Vector3 vector3)
        {
            Values = new float[3];
            Values[0] = vector3.X;
            Values[1] = vector3.Y;
            Values[2] = vector3.Z;
        }


        public void Set(float all)
        {
            X = all;
            Y = all;
            Z = all;
        }
        public float Get_Max()
        {
            return Values.Max();
        }
        public float Get_Length()
        {
            return (float)Math.Sqrt(Vector3.Sum(this * this));
        }
        public float Get_Length_2()
        {
            return (float)Math.Sqrt(X * X + Y * Y);
        }
        public Color Get_Color()
        {
            for (int i = 0; i < Values.Length; i++)
                if (Values[i] > 255) Values[i] = 255;
                else if (Values[i] < 0)
                    Values[i] = 0;

            return Color.FromArgb(255, (int)X, (int)Y, (int)Z);
        }


        public void Rotate(Vector3 rotation)
        {
            Rotate_X(rotation.X);
            Rotate_Y(rotation.Y);
            Rotate_Z(rotation.Z);
        }
        public void Rotate_X(float angle)
        {
            angle = (float)(angle * Math.PI / 180);
            float tempY = Y;
            Y = (float)(Y * Math.Cos(angle) - Z * Math.Sin(angle));
            Z = (float)(Z * Math.Cos(angle) + tempY * Math.Sin(angle));
        }
        public void Rotate_Y(float angle)
        {
            angle = (float)(angle * Math.PI / 180);
            float tempZ = Z;
            Z = (float)(Z * Math.Cos(angle) - X * Math.Sin(angle));
            X = (float)(X * Math.Cos(angle) + tempZ * Math.Sin(angle));
        }
        public void Rotate_Z(float angle)
        {
            angle = (float)(angle * Math.PI / 180);
            float tempX = X;
            X = (float)(X * Math.Cos(angle) - Y * Math.Sin(angle));
            Y = (float)(Y * Math.Cos(angle) + tempX * Math.Sin(angle));
        }


        public static Vector3 Abs(Vector3 v)
        {
            return new Vector3(Math.Abs(v.X), Math.Abs(v.Y), Math.Abs(v.Z));
        }
        public static Vector3 Normalized(Vector3 v)
        {
            if (v.X == 0 && v.Y == 0 && v.Z == 0)
                return v;

            return v / v.Get_Length();
        }

        public static float Sum(Vector3 v)
        {
            return v.X + v.Y + v.Z;
        }
        public static float Dot(Vector3 a, Vector3 b)
        {
            return a.X * b.X + a.Y * b.Y + a.Z * b.Z;
        }

        public static Vector3 Empty = new Vector3();

        public static Vector3 operator *(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(lhs.X * rhs.X, lhs.Y * rhs.Y, lhs.Z * rhs.Z);
        }
        public static Vector3 operator *(Vector3 lhs, float rhs)
        {
            return new Vector3(lhs.X * rhs, lhs.Y * rhs, lhs.Z * rhs);
        }
        public static Vector3 operator *(float lhs, Vector3 rhs)
        {
            return new Vector3(rhs.X * lhs, rhs.Y * lhs, rhs.Z * lhs);
        }
        public static Vector3 operator *(Color lhs, Vector3 rhs)
        {
            return new Vector3(lhs.R * rhs.X, lhs.G * rhs.Y, lhs.B * rhs.Z);
        }

        //public static Vector3 operator *(Vector3 lhs, Color rhs)
        //{
        //    return new Vector3(lhs.X * rhs.R, lhs.Y * rhs.G, lhs.Z * rhs.B);
        //}
        //public static Vector3 operator *(Color lhs, Vector3 rhs)
        //{
        //    return new Vector3(rhs.X * lhs.R, rhs.Y * lhs.G, rhs.Z * lhs.B);
        //}

        public static Vector3 operator /(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(lhs.X / rhs.X, lhs.Y / rhs.Y, lhs.Z / rhs.Z);
        }
        public static Vector3 operator /(Vector3 lhs, float rhs)
        {
            return new Vector3(lhs.X / rhs, lhs.Y / rhs, lhs.Z / rhs);
        }
        public static Vector3 operator /(float lhs, Vector3 rhs)
        {
            return new Vector3(rhs.X / lhs, rhs.Y / lhs, rhs.Z / lhs);
        }

        public static Vector3 operator -(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(lhs.X - rhs.X, lhs.Y - rhs.Y, lhs.Z - rhs.Z);
        }
        //public static Vector3 operator +(Vector3 lhs, PointF rhs)
        //{
        //    return new Vector3(lhs.X + rhs.X, lhs.Y + rhs.Y, lhs.Z);
        //}

        public static Vector3 operator +(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(lhs.X + rhs.X, lhs.Y + rhs.Y, lhs.Z + rhs.Z);
        }
        public static Color operator +(Color lhs, Vector3 rhs)
        {
            int[] colorArr = new int[3] {(int)(lhs.R + rhs.X), (int)(lhs.G + rhs.Y), (int)(lhs.B + rhs.Z)};

            for (int i = 0; i < colorArr.Length; i++)
                if (colorArr[i] > 255) colorArr[i] = 255;
                else if (colorArr[i] < 0) colorArr[i] = 0;

            return Color.FromArgb(lhs.A, colorArr[0], colorArr[1], colorArr[2]);
        }
        public static float[] operator +(float[] lhs, Vector3 rhs)
        {
            return new float[] { lhs[0] + rhs.X, lhs[1] + rhs.Y, lhs[2] + rhs.Z };
        }
        public static Vector3 operator +(float lhs, Vector3 rhs)
        {
            return new Vector3(lhs + rhs.X, lhs + rhs.Y, lhs + rhs.Z);
        }
        public static Vector3 operator +(Vector3 lhs, float rhs)
        {
            return new Vector3(rhs + lhs.X, rhs + lhs.Y, rhs + lhs.Z);
        }

        //public static Vector3 operator +(Vector3 lhs, Color rhs)
        //{
        //    return new Vector3(lhs.X + rhs.R, lhs.Y + rhs.G, lhs.Z + rhs.B);
        //}
        //public static Vector3 operator +(Color lhs, Vector3 rhs)
        //{
        //    return new Vector3(rhs.X + lhs.R, rhs.Y + lhs.G, rhs.Z + lhs.B);
        //}
    }
}
