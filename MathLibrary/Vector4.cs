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
