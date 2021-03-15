using System;

namespace MathLibrary
{
	// * Vector3(3-dimensional vector using 3 floats)
	// * Vector4(3-dimensional homogeneous vector using 4 floats)
	// Matrix3(2-dimensional 3x3 rotation matrix using 9 float)
	// Matrix4(3-dimensional 4x4 transform matrix using 16 float)
	// Colour(RGBA values stored as a 4 byte integer)
	// * V = V + V (point translated by a vector)
	// * V = V – V(point translated by a vector)
	// * V = V x f(vector scale)
	// * V = f x V(vector scale)
	// * M = M x V(vector transformation)
	// * M = M x M(matrix concatenation)
	// * f = V.Dot(V )
	// * V = V.Cross(V)
	// * f = V.Magnitude()
	// * Normalise()
	// * setRotateX(f )
	// * setRotateY(f ) and
	// * setRotateZ(f )

	public struct Vector2
	{
		public float x;
		public float y;

		//------------------------------------------------------------------------
		// Constructor
		// Optional params defaulted to 0.0
		//------------------------------------------------------------------------
		public Vector2(float _x = 0.0f, float _y = 0.0f)
		{
			x = _x;
			y = _y;
		}

		//------------------------------------------------------------------------
		// Operator overloading
		//------------------------------------------------------------------------
		#region Operators
		public static Vector2 operator+(Vector2 lhs, Vector2 rhs)
		{
			//------------------------------------------------------------------------
			// Add contents of two vectors and return the result
			// V = V + V (Point translated by a Vector)
			//------------------------------------------------------------------------
			return new Vector2(lhs.x + rhs.x, lhs.y + rhs.y);
		}

		public static Vector2 operator-(Vector2 lhs, Vector2 rhs)
		{
			//------------------------------------------------------------------------
			// Subtract contents of two vectors and return the result
			// V = V - V (Point translated by a Vector)
			//------------------------------------------------------------------------
			return new Vector2(lhs.x - rhs.x, lhs.y - rhs.y);
		}

		public static Vector2 operator*(Vector2 lhs, float rhs)
		{
			//------------------------------------------------------------------------
			// Multiply contents of a vector with a float and return the result
			// V = V x f(vector scale)
			//------------------------------------------------------------------------
			return new Vector2(lhs.x * rhs, lhs.y * rhs);
		}

		public static Vector2 operator*(float lhs, Vector2 rhs)
		{
			//------------------------------------------------------------------------
			// Multiply a float with the contents a vector and return the result
			// V = f x V(vector scale)
			//------------------------------------------------------------------------
			return new Vector2(lhs * rhs.x, lhs * rhs.y);
		}
		#endregion

		public float Magnitude()
		{
			//------------------------------------------------------------------------
			// Divide elements by their magnitude
			// f = sqrt a^2 + b^2
			//------------------------------------------------------------------------
			return (float)Math.Sqrt((x * x) + (y * y));
		}

		public void Normalise()
		{
			// Divide elements by their magnitude
			float magnitude = Magnitude();
			if (magnitude != 0)
			{
				x /= magnitude;
				y /= magnitude;
			}
		}

		public float Dot(Vector2 rhs)
		{
			//------------------------------------------------------------------------
			// Dot Product - To calculate, we multiply corresponding elements from one Vector with another,
			// and add them all together
			//------------------------------------------------------------------------
			return (x * rhs.x) + (y * rhs.y);
		}

		public Vector2 GetRightAngle()
		{
			//------------------------------------------------------------------------
			// Swap x and y and negate the y to find a vector at a right angle
			//------------------------------------------------------------------------
			Vector2 result;

			result.x = -y;
			result.y = x;

			return result;
		}

		public static float GetAngleBetween(Vector2 lhs, Vector2 rhs)
		{
			//------------------------------------------------------------------------
			// Normalize both vectors and get the dot product , which will be between -1 and 1
			// Use the result to get the angle (θ) between lhs and rhs vectors
			// Create a new vector which is perpendicular to lhs vector
			// Perform a dot product on rhs vector and new vector
			// Check if result is negative and if so, invert angle (θ)
			//------------------------------------------------------------------------
			lhs.Normalise();
			rhs.Normalise();
			float fDot = lhs.Dot(rhs);
			float angle = (float)Math.Acos(fDot);

			Vector2 rightAngle = lhs.GetRightAngle();
			float fRightDot = rhs.Dot(rightAngle);
			if (fRightDot < 0)
				angle = angle * -1.0f;

			return angle;
		}

	}

}
