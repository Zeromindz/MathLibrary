using System;
using System.Collections.Generic;
using System.Text;

namespace MathLibrary
{
	class Vector4
	{
		public float x;
		public float y;
		public float z;
		public float w;

		public Vector4(float x = 0.0f, float y = 0.0f, float z = 0.0f, float w = 0.0f)
		{
			this.x = x;
			this.y = y;
			this.z = z;
			this.w = w;
		}

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
			return new Vector4(lhs * rhs.x, lhs * rhs.y, lhs * rhs.z, lhs + rhs.w);
		}
		// V = V1 / f
		public static Vector4 operator /(Vector4 lhs, float rhs)
		{
			return new Vector4(lhs.x / rhs, lhs.y / rhs, lhs.z / rhs, lhs.w / rhs);
		}
		// V = f / V1
		public static Vector4 operator /(float lhs, Vector4 rhs)
		{
			return new Vector4(lhs / rhs.x, lhs / rhs.y, lhs / rhs.z, lhs / rhs.w);
		}

		// To calculate a Dot Product we simply multiply each element from one Vector with another,
		// and add them all together
		public float Dot(Vector4 rhs)
		{
			return (x * rhs.x + y * rhs.y + z * rhs.z + w * rhs.w);
		}

		// Find the vector that is ‘perpendicular’ to two other vectors in 3D space. 
		// The magnitude of the resultant vector is a function of the ‘perpendicularness’ of the input vectors.
		public Vector4 Cross(Vector4 lhs, Vector4 rhs)
		{
			double x, y, z, w;
			x = ((lhs.y * rhs.z) - (lhs.z * rhs.y));
			y = ((lhs.x * rhs.z) - (lhs.z * rhs.x));
			z = ((lhs.x * rhs.y) - (lhs.y * rhs.x));
			w = (lhs.w * rhs.w);


			Vector4 result = new Vector4((float)x, (float)y, (float)z, (float)w);
			return result;
		}

		public float Magnitude()
		{
			// f = sqrt a^2 + b^2 + c^2 + d^2
			return (float)Math.Sqrt((x * x) + (y * y) + (z * z) + (w * w));
		}

		public void Normalise()
		{
			// Divide elements by their magnitude
			float magnitude = Magnitude();
			if (magnitude != 0)
			{
				x /= magnitude;
				y /= magnitude;
				z /= magnitude;
				w /= magnitude;
			}
		}
	}
}
