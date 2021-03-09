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
		public Vector3 x;
		public Vector3 y;
		public Vector3 z;

		//public Vector3[] myMatrix = { new Vector3 {x = 1, y = 0, z = 0 },
		//							  new Vector3 {x = 0, y = 1, z = 0 },
		//							  new Vector3 {x = 0, y = 0, z = 1 } };

		//------------------------------------------------------------------------
		// Constructors
		//------------------------------------------------------------------------
		public Matrix3(Vector3 _vectX, Vector3 _vectY, Vector3 _vectZ)
		{
			this.x = _vectX;
			this.y = _vectY;
			this.z = _vectZ;
		}

		//------------------------------------------------------------------------
		// Operators
		//------------------------------------------------------------------------
		// public static Matrix3 operator *(Matrix3 lhs, Vector3 rhs)
		// {
		// return new Matrix3(new Matrix3(_vectX * rhs, _vectY, _vectZ);

		// return new Matrix3(
		//		((lhs.m1 * rhs.m1) + (lhs.m4 * rhs.m2) + (lhs.m7 * rhs.m3) + 
		//		(lhs.m1 * rhs.m4) + (lhs.m4 * rhs.m5) + (lhs.m7 * rhs.m6) +
		//		(lhs.m1 * rhs.m7) + (lhs.m4 * rhs.m8) + (lhs.m7 * rhs.m9)),

		//		((lhs.m2 * rhs.m1) + (lhs.m5 * rhs.m2) + (lhs.m8 * rhs.m3) +
		//		(lhs.m2 * rhs.m4) + (lhs.m5 * rhs.m5) + (lhs.m8 * rhs.m6) +
		//		(lhs.m2 * rhs.m7) + (lhs.m5 * rhs.m8) + (lhs.m8 * rhs.m9)),

		//		((lhs.m3 * rhs.m1) + (lhs.m6 * rhs.m2) + (lhs.m9 * rhs.m3) +
		//		(lhs.m3 * rhs.m4) + (lhs.m6 * rhs.m5) + (lhs.m9 * rhs.m6) +
		//		(lhs.m3 * rhs.m7) + (lhs.m6 * rhs.m8) + (lhs.m9 * rhs.m9)));

		//}
	}
}
