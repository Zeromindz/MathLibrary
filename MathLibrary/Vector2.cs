using System;

namespace MathLibrary
{
	// Vector3(3-dimensional vector using 3 floats)
	// Vector4(3-dimensional homogeneous vector using 4 floats)
	// Matrix3(2-dimensional 3x3 rotation matrix using 9 float)
	// Matrix4(3-dimensional 4x4 transform matrix using 16 float)
	// Colour(RGBA values stored as a 4 byte integer)
	// * V = V + V (point translated by a vector)
	// * V = V – V(point translated by a vector)
	// * V = V x f(vector scale)
	// * V = f x V(vector scale)
	// M = M x V(vector transformation)
	// M = M x M(matrix concatenation)
	// f = V.Dot(V )
	// V = V.Cross(V)
	// f = V.Magnitude()
	// Normalise()
	// setRotateX(f )
	// setRotateY(f ) and
	// setRotateZ(f )

	public struct Vector2
	{
		public float x;
		public float y;

		// Constructors
		// Optional params defaulted to 0.0
		public Vector2(float x = 0.0f, float y = 0.0f)
		{
			this.x = x;
			this.y = y;
		}

		// Operator overloading
		// Add contents of two vectors and return the result
		// V = V + V (Point translated by a Vector)
		public static Vector2 operator+(Vector2 lhs, Vector2 rhs)
		{
			Vector2 result;
			result.x = lhs.x + rhs.x;
			result.y = lhs.y + rhs.y;

			return result;
		}
		// Subtract contents of two vectors and return the result
		// V = V - V (Point translated by a Vector)
		public static Vector2 operator-(Vector2 lhs, Vector2 rhs)
		{
			Vector2 result;
			result.x = lhs.x - rhs.x;
			result.y = lhs.y - rhs.y;

			return result;
		}

		// Multiply contents a vector with a float and return the result
		// V = V x f(vector scale)
		public static Vector2 operator*(Vector2 lhs, float rhs)
		{
			Vector2 result;
			result.x = lhs.x * rhs;
			result.y = lhs.y * rhs;

			return result;
		}

		// Multiply a float with the contents a vector and return the result
		// V = f x V(vector scale)
		public static Vector2 operator*(float lhs, Vector2 rhs)
		{
			Vector2 result;
			result.x = rhs.x * lhs;
			result.y = rhs.y * lhs;

			return result;
		}

		//// M = M x V(vector transformation)
		//public static Vector2 operator*(Vector2 lhs, Vector2 rhs)
		//{
		//	Vector2 result;
		//	result.x = rhs.x * lhs;
		//	result.y = rhs.y * lhs;
		//
		//	return result;
		//}
	}












}
