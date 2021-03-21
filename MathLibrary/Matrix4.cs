using System;
using System.Collections.Generic;
using System.Text;

namespace MathLibrary
{

	//------------------------------------------------------------------------
	// Matrix4
	//------------------------------------------------------------------------
	public struct Matrix4
	{
		public float m1, m2, m3, m4, m5, m6, m7, m8, m9, m10, m11, m12, m13, m14, m15, m16;

		//------------------------------------------------------------------------
		// Constructors
		//------------------------------------------------------------------------
		public Matrix4(bool bDefault = true)
		{
			
			m1 = 1;
			m2 = 0;
			m3 = 0;
			m4 = 0;
			m5 = 0;
			m6 = 1;
			m7 = 0;
			m8 = 0;
			m9 = 0;
			m10 = 0;
			m11 = 1;
			m12 = 0;
			m13 = 0;
			m14 = 0;
			m15 = 0;
			m16 = 1;
		}

		public Matrix4(float _m1, float _m2, float _m3, float _m4,
					   float _m5, float _m6, float _m7, float _m8, 
					   float _m9, float _m10, float _m11, float _m12,
					   float _m13, float _m14, float _m15, float _m16)
		{
			
			m1 = _m1;
			m2 = _m2;
			m3 = _m3;
			m4 = _m4;
			m5 = _m5;
			m6 = _m6;
			m7 = _m7;
			m8 = _m8;
			m9 = _m9;
			m10 = _m10;
			m11 = _m11;
			m12 = _m12;
			m13 = _m13;
			m14 = _m14;
			m15 = _m15;
			m16 = _m16;
			
		}

		//------------------------------------------------------------------------
		// Operators
		//------------------------------------------------------------------------
		#region Operators
		public static Vector4 operator *(Matrix4 lhs, Vector4 rhs)
		{
			//------------------------------------------------------------------------
			// M = M x V(Vector transformation)
			//------------------------------------------------------------------------
			Vector4 result = new Vector4();

			// 0 - 4 - 8 - 12	   x
			// 1 - 5 - 9 - 13	   y
			// 2 - 6 - 10 - 14	   z
			// 3 - 7 - 11 - 15	   w

			result.x = (lhs.m1 * rhs.x) + (lhs.m5 * rhs.y) + (lhs.m9 * rhs.z) + (lhs.m13 * rhs.w);
			result.y = (lhs.m2 * rhs.x) + (lhs.m6 * rhs.y) + (lhs.m10 * rhs.z) + (lhs.m14 * rhs.w);
			result.z = (lhs.m3 * rhs.x) + (lhs.m7 * rhs.y) + (lhs.m11 * rhs.z) + (lhs.m15 * rhs.w);
			result.w = (lhs.m4 * rhs.x) + (lhs.m8 * rhs.y) + (lhs.m12 * rhs.z) + (lhs.m16 * rhs.w);

			return result;
		}

		public static Matrix4 operator *(Matrix4 lhs, Matrix4 rhs)
		{
			//------------------------------------------------------------------------
			// M = M x M(Matrix multiplication)
			//------------------------------------------------------------------------
			Matrix4 result = new Matrix4();

			// 0 - 4 - 8 - 12
			// 1 - 5 - 9 - 13
			// 2 - 6 - 10 - 14
			// 3 - 7 - 11 - 15

			// m[0] = 0*0 + 4*1 + 8*2 + 12*3
			// m[1] = 1*0 + 5*1 + 9*2 + 13*3
			// m[2] = 2*0 + 6*1 + 10*2 + 14*3
			// m[3] = 3*0 + 7*1 + 11*2 + 15*3

			// m[4] = 0*4 + 4*5 + 8*6 + 12*7
			// m[5] = 1*4 + 5*5 + 9*6 + 13*7
			// m[6] = 2*4 + 6*5 + 10*6 + 14*7
			// m[7] = 3*4 + 7*5 + 11*6 + 15*7

			// m[8] = 0*8 + 4*9 + 8*10 + 12*11
			// m[9] = 1*8 + 5*9 + 9*10 + 13*11
			// m[10] = 2*8 + 6*9 + 10*10 + 14*11
			// m[11] = 3*8 + 7*9 + 11*10 + 15*11

			// m[12] = 0*12 + 4*13 + 8*14 + 12*15
			// m[13] = 1*12 + 5*13 + 9*14 + 13*15
			// m[14] = 2*12 + 6*13 + 10*14 + 14*15
			// m[15] = 3*12 + 7*13 + 11*14 + 15*15

			result.m1 = (lhs.m1 * rhs.m1) + (lhs.m5 * rhs.m2) + (lhs.m9 * rhs.m3) + (lhs.m13 * rhs.m4);
			result.m2 = (lhs.m2 * rhs.m1) + (lhs.m6 * rhs.m2) + (lhs.m10 * rhs.m3) + (lhs.m14 * rhs.m4);
			result.m3 = (lhs.m3 * rhs.m1) + (lhs.m7 * rhs.m2) + (lhs.m11 * rhs.m3) + (lhs.m15 * rhs.m4);
			result.m4 = (lhs.m4 * rhs.m1) + (lhs.m8 * rhs.m2) + (lhs.m12 * rhs.m3) + (lhs.m16 * rhs.m4);

			result.m5 = (lhs.m1 * rhs.m5) + (lhs.m5 * rhs.m6) + (lhs.m9 * rhs.m7) + (lhs.m13 * rhs.m8);
			result.m6 = (lhs.m2 * rhs.m5) + (lhs.m6 * rhs.m6) + (lhs.m10 * rhs.m7) + (lhs.m14 * rhs.m8);
			result.m7 = (lhs.m3 * rhs.m5) + (lhs.m7 * rhs.m6) + (lhs.m11 * rhs.m7) + (lhs.m15 * rhs.m8);
			result.m8 = (lhs.m4 * rhs.m5) + (lhs.m8 * rhs.m6) + (lhs.m12 * rhs.m7) + (lhs.m16 * rhs.m8);

			result.m9 = (lhs.m1* rhs.m9) + (lhs.m5 * rhs.m10) + (lhs.m9 * rhs.m11) + (lhs.m13 * rhs.m12);
			result.m10 = (lhs.m2 * rhs.m9) + (lhs.m6 * rhs.m10) + (lhs.m10 * rhs.m11) + (lhs.m14 * rhs.m12);
			result.m11 = (lhs.m3 * rhs.m9) + (lhs.m7 * rhs.m10) + (lhs.m11 * rhs.m11) + (lhs.m15 * rhs.m12);
			result.m12 = (lhs.m4 * rhs.m9) + (lhs.m8 * rhs.m10) + (lhs.m12 * rhs.m11) + (lhs.m16 * rhs.m12);

			result.m13 = (lhs.m1 * rhs.m13) + (lhs.m5 * rhs.m14) + (lhs.m9 * rhs.m15) + (lhs.m13 * rhs.m16);
			result.m14 = (lhs.m2 * rhs.m13) + (lhs.m6 * rhs.m14) + (lhs.m10 * rhs.m15) + (lhs.m14 * rhs.m16);
			result.m15 = (lhs.m3 * rhs.m13) + (lhs.m7 * rhs.m14) + (lhs.m11 * rhs.m15) + (lhs.m15 * rhs.m16);
			result.m16 = (lhs.m4 * rhs.m13) + (lhs.m8 * rhs.m14) + (lhs.m12 * rhs.m15) + (lhs.m16 * rhs.m16);


			return result;
		}
		#endregion

		public void SetRotateX(float _radians)
		{
			// 1 - 0	   - 0		- 0
			// 0 - cos(a)  - -sin(a) - 0
			// 0 - sin(a) - cos(a) - 0
			// 0 - 0	   - 0		- 1

			m6 = (float)Math.Cos(_radians);
			m7 = (float)Math.Sin(_radians);
			m10 = -(float)Math.Sin(_radians);
			m11 = (float)Math.Cos(_radians);
		}

		public void SetRotateY(float _radians)
		{
			// cos(a) - 0 - sin(a) - 0
			// 0	  - 1 - 0		- 0
			// -sin(a) - 0 - cos(a)  - 0
			// 0	  - 0 - 0		- 1

			m1 = (float)Math.Cos(_radians);
			m3 = -(float)Math.Sin(_radians);
			m9 = (float)Math.Sin(_radians);
			m11 = (float)Math.Cos(_radians);
		}

		public void SetRotateZ(float _radians)
		{
			// cos(a)  - -sin(a) - 0 - 0
			// sin(a) - cos(a) - 0 - 0
			// 0	   - 0		- 1 - 0
			// 0	   - 0		- 0 - 1

			m1 = (float)Math.Cos(_radians);
			m2 = (float)Math.Sin(_radians);
			m5 = -(float)Math.Sin(_radians);
			m6 = (float)Math.Cos(_radians);
		}

		public void SetTranslation(float _x, float _y, float _z)
		{
			// Xx - Yx - Zx - Tx
			// Xy - Yy - Zy - Ty
			// Xz - Yz - Zz - Tz
			// Xw - Yw - Zw - Tw (V = 0 / P = 1)

			m1 = 1; m5 = 0; m9 = 0;  m13 = _x;
			m2 = 0; m6 = 1; m10 = 0; m14 = _y;
			m3 = 0; m7 = 0; m11 = 1; m15 = _z;
			m4 = 0; m8 = 0; m12 = 0; m16 = 1;
		}

		public void SetTranslation(Vector3 _pos)
		{
			// Xx - Yx - Zx - Tx
			// Xy - Yy - Zy - Ty
			// Xz - Yz - Zz - Tz
			// Xw - Yw - Zw - Tw (V = 0 / P = 1)

			m1 = 1; m5 = 0; m9  = 0; m13 = _pos.x;
			m2 = 0; m6 = 1; m10 = 0; m14 = _pos.y;
			m3 = 0; m7 = 0; m11 = 1; m15 = _pos.z;
			m4 = 0; m8 = 0; m12 = 0; m16 = 1;

		}

		public void SetScale(float _x, float _y, float _z)
		{
			m1 = _x; m5 = 0;  m9  = 0;  m13 = 0;
			m2 = 0;  m6 = _y; m10 = 0;  m14 = 0;
			m3 = 0;  m7 = 0;  m11 = _z; m15 = 0;
			m4 = 0;  m8 = 0;  m12 = 0;  m16 = 1;
		}

		public void SetScale(Vector3 _v)
		{
			m1 = _v.x; m5 = 0;    m9  = 0;    m13 = 0; 
			m2 = 0;    m6 = _v.y; m10 = 0;    m14 = 0;
			m3 = 0;    m7 = 0;    m11 = _v.z; m15 = 0;
			m4 = 0;    m8 = 0;    m12 = 0;    m16 = 1;
		}
	}

}
