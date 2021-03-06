using System;
using System.Collections.Generic;
using System.Text;

namespace MathLibrary
{
	public class Vector4
	{
		public float x;
		public float y;
		public float z;
		public float w;


		public Vector4(float _x = 0.0f, float _y = 0.0f, float _z = 0.0f, float _w = 0.0f)
		{
			x = _x;
			y = _y;
			z = _z;
			w = _w;
		}

		//------------------------------------------------------------------------
		// Operators
		//------------------------------------------------------------------------
		#region Operators
		// V = V1 + V2
		public static Vector4 operator +(Vector4 lhs, Vector4 rhs)
		{
			return new Vector4(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z, lhs.w + rhs.w);
		}
		// V = V1 - V2
		public static Vector4 operator -(Vector4 lhs, Vector4 rhs)
		{
			return new Vector4(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z, lhs.w - rhs.w);
		}
		// V = V1 * f
		public static Vector4 operator *(Vector4 lhs, float rhs)
		{
			return new Vector4(lhs.x * rhs, lhs.y * rhs, lhs.z * rhs, lhs.w * rhs);
		}
		// V = f * V2
		public static Vector4 operator *(float lhs, Vector4 rhs)
		{
			return rhs * lhs;
		}
		// V = V1 / f
		public static Vector4 operator /(Vector4 lhs, float rhs)
		{
			return new Vector4(lhs.x / rhs, lhs.y / rhs, lhs.z / rhs, lhs.w / rhs);
		}
		
		#endregion

		public float Magnitude()
		{
			//------------------------------------------------------------------------
			// Divide elements by their magnitude
			// f = sqrt a^2 + b^2 + c^2 + d^2
			//------------------------------------------------------------------------
			return (float)Math.Sqrt((x * x) + (y * y) + (z * z) + (w * w));
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
				w /= magnitude;
			}
		}
		
		public float Dot(Vector4 rhs)
		{
			//------------------------------------------------------------------------
			// Dot Product - To calculate, we multiply corresponding elements from one Vector with another,
			// and add them all together
			//------------------------------------------------------------------------
			return (x * rhs.x) + (y * rhs.y) + (z * rhs.z) + (w * rhs.w);
		}

		public Vector4 Cross(Vector4 rhs)
		{
			//------------------------------------------------------------------------
			// Find the vector that is ‘perpendicular’ to two other vectors in 3D space. 
			// The magnitude of the resultant vector is a function of the ‘perpendicularness’ of the input vectors.
			//------------------------------------------------------------------------
			Vector4 result = new Vector4();

			result.x = ((y * rhs.z) - (z * rhs.y));
			result.y = ((z * rhs.x) - (x * rhs.z));
			result.z = ((x * rhs.y) - (y * rhs.x));
			result.w = 0f;

			return result;
		}

	}
}
