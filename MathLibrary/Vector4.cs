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
