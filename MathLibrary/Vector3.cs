using System;
using System.Collections.Generic;
using System.Text;

namespace MathLibrary
{
	//------------------------------------------------------------------------
	// Vector3
	//------------------------------------------------------------------------
	public struct Vector3
	{
		public float x;
		public float y;
		public float z;
		//------------------------------------------------------------------------
		// Constructors
		// Optional params defaulted to 0.0
		//------------------------------------------------------------------------
		public Vector3(float x = 0.0f, float y = 0.0f, float z = 0.0f)
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}

		//------------------------------------------------------------------------
		// Operators
		//------------------------------------------------------------------------
		#region Operators
		// V = V1 + V2
		public static Vector3 operator +(Vector3 lhs, Vector3 rhs)
		{
			return new Vector3(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z);
		}
		// V = V1 - V2
		public static Vector3 operator -(Vector3 lhs, Vector3 rhs)
		{
			return new Vector3(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z);
		}
		// V = V1 * f
		public static Vector3 operator *(Vector3 lhs, float rhs)
		{
			return new Vector3(lhs.x * rhs, lhs.y * rhs, lhs.z * rhs);
		}
		// V = f * V2
		public static Vector3 operator *(float lhs, Vector3 rhs)
		{
			return new Vector3(lhs * rhs.x, lhs * rhs.y, lhs * rhs.z);
		}
		// V = V1 / f
		public static Vector3 operator /(Vector3 lhs, float rhs)
		{
			return new Vector3(lhs.x / rhs, lhs.y / rhs, lhs.z / rhs);
		}
		// V = f / V1
		public static Vector3 operator /(float lhs, Vector3 rhs)
		{
			return new Vector3(lhs / rhs.x, lhs / rhs.y, lhs / rhs.z);
		}
		#endregion
		
		public float Magnitude()
		{
			//------------------------------------------------------------------------
			// Divide elements by their magnitude
			// f = sqrt a^2 + b^2 + c^2
			//------------------------------------------------------------------------
			return (float)Math.Sqrt((x * x) + (y * y) + (z * z));
		}

		public void Normalise()
		{
			//------------------------------------------------------------------------
			// Divide elements by their magnitude
			//------------------------------------------------------------------------
			float magnitude = Magnitude();
			if (magnitude != 0)
			{
				x /= magnitude;
				y /= magnitude;
				z /= magnitude;
			}
		}

		public float Dot(Vector3 rhs)
		{
			//------------------------------------------------------------------------
			// Dot Product - To calculate, we multiply corresponding elements from one Vector with another,
			// and add them all together
			//------------------------------------------------------------------------
			return (x * rhs.x) + (y * rhs.y) + (z * rhs.z);
		}

		public Vector3 Cross(Vector3 rhs)
		{
			//------------------------------------------------------------------------
			// Find the vector that is ‘perpendicular’ to two other vectors in 3D space. 
			// The magnitude of the resultant vector is a function of the ‘perpendicularness’ of the input vectors.
			//------------------------------------------------------------------------
			Vector3 result;

			result.x = ((y * rhs.z) - (z * rhs.y));
			result.y = ((x * rhs.z) - (z * rhs.x));
			result.z = ((x * rhs.y) - (y * rhs.x));

			return result;
		}

	}
}
