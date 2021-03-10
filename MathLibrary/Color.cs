using System;
using System.Collections.Generic;
using System.Text;

namespace MathLibrary
{
	struct Color
	{
		public byte r;
		public byte g;
		public byte b;
		public byte a;

		public Color(byte _r, byte _g, byte _b, byte _a)
		{
			this.r = _r;
			this.g = _g;
			this.b = _b;
			this.a = _a;
		}
	}
}
