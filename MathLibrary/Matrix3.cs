using System;
using System.Collections.Generic;
using System.Text;

namespace MathLibrary
{

	//------------------------------------------------------------------------
	// Matrix3
	//------------------------------------------------------------------------
	public class Matrix3
	{
		
		public float m1, m2, m3, m4, m5, m6, m7, m8, m9;

		//------------------------------------------------------------------------
		// Constructors
		//------------------------------------------------------------------------
		public Matrix3(bool bDefault = true)
		{
			m1 = 1;
			m2 = 0;
			m3 = 0;
			m3 = 0;
			m4 = 1;
			m5 = 0;
			m6 = 0;
			m7 = 0;
			m8 = 1;

			
		}

		public Matrix3(float _m1, float _m2, float _m3,
					   float _m4, float _m5, float _m6,
					   float _m7, float _m8, float _m9)
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

		}

		//------------------------------------------------------------------------
		// Operators
		//------------------------------------------------------------------------

		#region Operators
		public static Vector3 operator *(Matrix3 lhs, Vector3 rhs)
		{
			//------------------------------------------------------------------------
			// M = M x V(Vector transformation)
			//------------------------------------------------------------------------
			Vector3 result = new Vector3(); 

			result.x = (lhs.m1 * rhs.x) + (lhs.m4 * rhs.y) + (lhs.m7 * rhs.z);
			result.y = (lhs.m2 * rhs.x) + (lhs.m5 * rhs.y) + (lhs.m8 * rhs.z);
			result.z = (lhs.m3 * rhs.x) + (lhs.m6 * rhs.y) + (lhs.m9 * rhs.z);

			return result;
		}
		
		public static Matrix3 operator *(Matrix3 lhs, Matrix3 rhs)
		{
			//------------------------------------------------------------------------
			// M = M x M(Matrix multiplication)
			//------------------------------------------------------------------------
			Matrix3 result = new Matrix3();

			//			    0 - 3 - 6
			//			    1 - 4 - 7
			//			    2 - 5 - 8

			// 0 - 3 - 6	0 - 3 - 6 
			// 1 - 4 - 7	1 - 4 - 7
			// 2 - 5 - 8	2 - 5 - 8

			//m[0] = 0*0 + 3*1 + 6*2
			//m[1] = 1*0 + 4*1 + 7*2
			//m[2] = 2*0 + 5*1 + 8*2

			//m[3] = 0*3 + 3*4 + 6*5
			//m[4] = 1*3 + 4*4 + 7*5
			//m[5] = 2*3 + 5*4 + 8*5

			//m[6] = 0*6 + 3*7 + 6*8
			//m[7] = 1*6 + 4*7 + 7*8
			//m[8] = 2*6 + 5*7 + 8*8

			result.m1 = (lhs.m1 * rhs.m1) + (lhs.m4 * rhs.m2) + (lhs.m7 * rhs.m3);
			result.m2 = (lhs.m2 * rhs.m1) + (lhs.m5 * rhs.m2) + (lhs.m8 * rhs.m3);
			result.m3 = (lhs.m3 * rhs.m1) + (lhs.m6 * rhs.m2) + (lhs.m9 * rhs.m3);

			result.m4 = (lhs.m1 * rhs.m4) + (lhs.m4 * rhs.m5) + (lhs.m7 * rhs.m6);
			result.m5 = (lhs.m2 * rhs.m4) + (lhs.m5 * rhs.m5) + (lhs.m8 * rhs.m6);
			result.m6 = (lhs.m3 * rhs.m4) + (lhs.m6 * rhs.m5) + (lhs.m9 * rhs.m6);

			result.m7 = (lhs.m1 * rhs.m7) + (lhs.m4 * rhs.m8) + (lhs.m7 * rhs.m9);
			result.m8 = (lhs.m2 * rhs.m7) + (lhs.m5 * rhs.m8) + (lhs.m8 * rhs.m9);
			result.m9 = (lhs.m3 * rhs.m7) + (lhs.m6 * rhs.m8) + (lhs.m9 * rhs.m9);

			return result;
		}
		#endregion

		public void SetRotateX(float _radians)
		{
			// 1 - 0	   - 0
			// 0 - cos(a)  - -sin(a)
			// 0 - sin(a)  - cos(a)

			m5 = (float)Math.Cos(_radians);
			m6 = (float)Math.Sin(_radians);
			m7 = -(float)Math.Sin(_radians);
			m8 = (float)Math.Cos(_radians);
		}

		public void SetRotateY(float _radians)
		{
			// cos(a) - 0 - sin(a)
			// 0	  - 1 - 0
			// -sin(a) - 0 - cos(a)

			m1 = (float)Math.Cos(_radians);
			m3 = -(float)Math.Sin(_radians);
			m7 = (float)Math.Sin(_radians);
			m9 = (float)Math.Cos(_radians);
		}

		public void SetRotateZ(float _radians)
		{
			// cos(a)  - -sin(a) - 0
			// sin(a) - cos(a) - 0
			// 0	   - 0		- 1

			m1 = (float)Math.Cos(_radians);
			m2 = (float)Math.Sin(_radians);
			m4 = -(float)Math.Sin(_radians);
			m5 = (float)Math.Cos(_radians);
		}

		public void SetTranslation(float _x, float _y)
		{
			// Xx - Yx - Tx
			// Xy - Yy - Ty
			// Xw - Yw - Tw (V = 0 / P = 1)

			m7 = _x;
			m8 = _y;
		}

		public void SetTranslation(Vector2 _pos)
		{
			// Xx - Yx - Tx
			// Xy - Yy - Ty
			// Xw - Yw - Tw (V = 0 / P = 1)
			
			m7 = _pos.x;
			m8 = _pos.y;
		}

		public void SetScale(float _x, float _y)
		{
			m1 = _x; m4 = 0;  m7 = 0;
			m2 = 0;  m5 = _y; m8 = 0;
			m3 = 0;  m6 = 0;  m9 = 1;
		}

		public void SetScale(Vector2 _v)
		{
			m1 = _v.x; m4 = 0;    m7 = 0;
			m2 = 0;    m5 = _v.y; m8 = 0;
			m3 = 0;    m6 = 0;    m9 = 1;
		}

	}
}
