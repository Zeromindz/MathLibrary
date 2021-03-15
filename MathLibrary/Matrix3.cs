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
		public float[] m;

		//------------------------------------------------------------------------
		// Constructors
		//------------------------------------------------------------------------
		public Matrix3(bool bDefault = true)
		{
			m = new float[9];
			m[0] = 1;
			m[1] = 0;
			m[2] = 0;
			m[3] = 0;
			m[4] = 1;
			m[5] = 0;
			m[6] = 0;
			m[7] = 0;
			m[8] = 1;

		}

		public Matrix3(float _m0, float _m1, float _m2,
					   float _m3, float _m4, float _m5,
					   float _m6, float _m7, float _m8)
		{
			m = new float[9];
			m[0] = _m0;
			m[1] = _m1;
			m[2] = _m2;
			m[3] = _m3;
			m[4] = _m4;
			m[5] = _m5;
			m[6] = _m6;
			m[7] = _m7;
			m[8] = _m8;

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
			Vector3 result;

			result.x = (lhs.m[0] * rhs.x) + (lhs.m[3] * rhs.y) + (lhs.m[6] * rhs.z);
			result.y = (lhs.m[1] * rhs.x) + (lhs.m[4] * rhs.y) + (lhs.m[7] * rhs.z);
			result.z = (lhs.m[2] * rhs.x) + (lhs.m[5] * rhs.y) + (lhs.m[8] * rhs.z);

			return result;
		}
		
		public static Matrix3 operator *(Matrix3 lhs, Matrix3 rhs)
		{
			//------------------------------------------------------------------------
			// M = M x M(Matrix multiplication)
			//------------------------------------------------------------------------
			Matrix3 result = new Matrix3();

			// 0 - 3 - 6
			// 1 - 4 - 7
			// 2 - 5 - 8

			//m[0] = 0*0 + 3*1 + 6*2
			//m[1] = 1*0 + 4*1 + 7*2
			//m[2] = 2*0 + 5*1 + 8*2

			//m[3] = 0*3 + 3*4 + 6*5
			//m[4] = 1*3 + 4*4 + 7*5
			//m[5] = 2*3 + 5*4 + 8*5

			//m[6] = 0*6 + 3*7 + 6*8
			//m[7] = 1*6 + 4*7 + 7*8
			//m[8] = 2*6 + 5*7 + 8*8

			result.m[0] = (lhs.m[0] * rhs.m[0]) + (lhs.m[3] * rhs.m[1]) + (lhs.m[6] * rhs.m[2]);
			result.m[1] = (lhs.m[1] * rhs.m[0]) + (lhs.m[4] * rhs.m[1]) + (lhs.m[7] * rhs.m[2]);
			result.m[2] = (lhs.m[2] * rhs.m[0]) + (lhs.m[5] * rhs.m[1]) + (lhs.m[8] * rhs.m[2]);

			result.m[3] = (lhs.m[0] * rhs.m[3]) + (lhs.m[3] * rhs.m[4]) + (lhs.m[6] * rhs.m[5]);
			result.m[4] = (lhs.m[1] * rhs.m[3]) + (lhs.m[4] * rhs.m[4]) + (lhs.m[7] * rhs.m[5]);
			result.m[5] = (lhs.m[2] * rhs.m[3]) + (lhs.m[5] * rhs.m[4]) + (lhs.m[8] * rhs.m[5]);

			result.m[6] = (lhs.m[0] * rhs.m[6]) + (lhs.m[3] * rhs.m[7]) + (lhs.m[6] * rhs.m[8]);
			result.m[7] = (lhs.m[1] * rhs.m[6]) + (lhs.m[4] * rhs.m[7]) + (lhs.m[7] * rhs.m[8]);
			result.m[8] = (lhs.m[2] * rhs.m[6]) + (lhs.m[5] * rhs.m[7]) + (lhs.m[8] * rhs.m[8]);

			return result;
		}
		#endregion

		public void SetRotateX(float _radians)
		{
			// 1 - 0	   - 0
			// 0 - cos(a)  - sin(a)
			// 0 - -sin(a) - cos(a)

			m[4] = (float)Math.Cos(_radians);
			m[5] = -(float)Math.Sin(_radians);
			m[7] = (float)Math.Sin(_radians);
			m[8] = (float)Math.Cos(_radians);
		}

		public void SetRotateY(float _radians)
		{
			// cos(a) - 0 - -sin(a)
			// 0	  - 1 - 0
			// sin(a) - 0 - cos(a)

			m[0] = (float)Math.Cos(_radians);
			m[2] = (float)Math.Sin(_radians);
			m[6] = -(float)Math.Sin(_radians);
			m[8] = (float)Math.Cos(_radians);
		}

		public void SetRotateZ(float _radians)
		{
			// cos(a)  - sin(a) - 0
			// -sin(a) - cos(a) - 0
			// 0	   - 0		- 1

			m[0] = (float)Math.Cos(_radians);
			m[1] = -(float)Math.Sin(_radians);
			m[3] = -(float)Math.Sin(_radians);
			m[4] = (float)Math.Cos(_radians);
		}

		public void SetTranslation(float _x, float _y)
		{
			// Xx - Yx - Tx
			// Xy - Yy - Ty
			// Xw - Yw - Tw (V = 0 / P = 1)

			m[6] = _x;
			m[7] = _y;
		}

		public void SetTranslation(Vector2 _pos)
		{
			// Xx - Yx - Tx
			// Xy - Yy - Ty
			// Xw - Yw - Tw (V = 0 / P = 1)
			
			m[6] = _pos.x;
			m[7] = _pos.y;
		}

		public void SetScale(float _x, float _y)
		{
			m[0] = _x; m[3] = 0;  m[6] = 0;
			m[1] = 0;  m[4] = _y; m[7] = 0;
			m[2] = 0;  m[5] = 0;  m[8] = 1;
		}

		public void SetScale(Vector2 _v)
		{
			m[0] = _v.x; m[3] = 0;    m[6] = 0;
			m[1] = 0;    m[4] = _v.y; m[7] = 0;
			m[2] = 0;    m[5] = 0;    m[8] = 1;
		}

	}
}
