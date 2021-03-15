using System;
using System.Collections.Generic;
using System.Text;

namespace MathLibrary
{

	//------------------------------------------------------------------------
	// Matrix3
	//------------------------------------------------------------------------
	class Matrix4
	{
		public float[] m;

		//------------------------------------------------------------------------
		// Constructors
		//------------------------------------------------------------------------
		public Matrix4(bool bDefault = true)
		{
			m = new float[16];
			m[0] = 1;
			m[1] = 0;
			m[2] = 0;
			m[3] = 0;
			m[4] = 0;
			m[5] = 1;
			m[6] = 0;
			m[7] = 0;
			m[8] = 0;
			m[9] = 0;
			m[10] = 1;
			m[11] = 0;
			m[12] = 0;
			m[13] = 0;
			m[14] = 0;
			m[15] = 1;
		}

		public Matrix4(float _m0, float _m1, float _m2, float _m3,
					   float _m4, float _m5, float _m6, float _m7, 
					   float _m8, float _m9, float _m10, float _m11,
					   float _m12, float _m13, float _m14, float _m15)
		{
			m = new float[16];
			m[0] = _m0;
			m[1] = _m1;
			m[2] = _m2;
			m[3] = _m3;
			m[4] = _m4;
			m[5] = _m5;
			m[6] = _m6;
			m[7] = _m7;
			m[8] = _m8;
			m[8] = _m9;
			m[10] = _m10;
			m[11] = _m11;
			m[12] = _m12;
			m[13] = _m13;
			m[14] = _m14;
			m[15] = _m15;
			
		}
		//------------------------------------------------------------------------
		// Operators
		//------------------------------------------------------------------------

		//------------------------------------------------------------------------
		// M = M x V(Vector transformation)
		//------------------------------------------------------------------------
		
		public static Vector4 operator *(Matrix4 lhs, Vector4 rhs)
		{
			Vector4 result;

			result.x = (lhs.m[0] * rhs.x) + (lhs.m[4] * rhs.y) + (lhs.m[8] * rhs.z) + (lhs.m[12] + rhs.w);
			result.y = (lhs.m[1] * rhs.x) + (lhs.m[5] * rhs.y) + (lhs.m[9] * rhs.z) + (lhs.m[13] + rhs.w);
			result.z = (lhs.m[2] * rhs.x) + (lhs.m[6] * rhs.y) + (lhs.m[10] * rhs.z) + (lhs.m[14] + rhs.w);
			result.w = (lhs.m[3] * rhs.x) + (lhs.m[7] * rhs.y) + (lhs.m[11] * rhs.z) + (lhs.m[15] + rhs.w);

			return result;
		}

		//------------------------------------------------------------------------
		// M = M x M(Matrix multiplication)
		//------------------------------------------------------------------------
		public static Matrix4 operator *(Matrix4 lhs, Matrix4 rhs)
		{
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

			result.m[0] = (lhs.m[0] * rhs.m[0]) + (lhs.m[4] * rhs.m[1]) + (lhs.m[8] * rhs.m[2]) + (lhs.m[12] * rhs.m[3]);
			result.m[1] = (lhs.m[1] * rhs.m[0]) + (lhs.m[5] * rhs.m[1]) + (lhs.m[9] * rhs.m[2]) + (lhs.m[13] * rhs.m[3]);
			result.m[2] = (lhs.m[2] * rhs.m[0]) + (lhs.m[6] * rhs.m[1]) + (lhs.m[10] * rhs.m[2]) + (lhs.m[14] * rhs.m[3]);
			result.m[3] = (lhs.m[3] * rhs.m[0]) + (lhs.m[7] * rhs.m[1]) + (lhs.m[11] * rhs.m[2]) + (lhs.m[15] * rhs.m[3]);

			result.m[4] = (lhs.m[0] * rhs.m[4]) + (lhs.m[4] * rhs.m[5]) + (lhs.m[8] * rhs.m[6]) + (lhs.m[12] * rhs.m[7]);
			result.m[5] = (lhs.m[1] * rhs.m[4]) + (lhs.m[5] * rhs.m[5]) + (lhs.m[9] * rhs.m[6]) + (lhs.m[13] * rhs.m[7]);
			result.m[6] = (lhs.m[2] * rhs.m[4]) + (lhs.m[6] * rhs.m[5]) + (lhs.m[10] * rhs.m[6]) + (lhs.m[14] * rhs.m[7]);
			result.m[7] = (lhs.m[3] * rhs.m[4]) + (lhs.m[7] * rhs.m[5]) + (lhs.m[11] * rhs.m[6]) + (lhs.m[15] * rhs.m[7]);

			result.m[8] = (lhs.m[0] * rhs.m[8]) + (lhs.m[4] * rhs.m[9]) + (lhs.m[8] * rhs.m[10]) + (lhs.m[12] * rhs.m[11]);
			result.m[9] = (lhs.m[1] * rhs.m[8]) + (lhs.m[5] * rhs.m[9]) + (lhs.m[9] * rhs.m[10]) + (lhs.m[13] * rhs.m[11]);
			result.m[10] = (lhs.m[2] * rhs.m[8]) + (lhs.m[6] * rhs.m[9]) + (lhs.m[10] * rhs.m[10]) + (lhs.m[14] * rhs.m[11]);
			result.m[11] = (lhs.m[3] * rhs.m[8]) + (lhs.m[7] * rhs.m[9]) + (lhs.m[11] * rhs.m[10]) + (lhs.m[15] * rhs.m[11]);

			result.m[12] = (lhs.m[0] * rhs.m[12]) + (lhs.m[4] * rhs.m[13]) + (lhs.m[8] * rhs.m[14]) + (lhs.m[12] * rhs.m[15]);
			result.m[13] = (lhs.m[1] * rhs.m[12]) + (lhs.m[5] * rhs.m[13]) + (lhs.m[9] * rhs.m[14]) + (lhs.m[13] * rhs.m[15]);
			result.m[14] = (lhs.m[2] * rhs.m[12]) + (lhs.m[6] * rhs.m[13]) + (lhs.m[10] * rhs.m[14]) + (lhs.m[14] * rhs.m[15]);
			result.m[15] = (lhs.m[3] * rhs.m[12]) + (lhs.m[7] * rhs.m[13]) + (lhs.m[11] * rhs.m[14]) + (lhs.m[15] * rhs.m[15]);


			return result;
		}

	}

}
