using System;
using System.Collections.Generic;
using System.Text;

namespace MathLibrary
{
	public class Colour
	{
		public uint colour = 0;
		// 0x00000000
		// 00 00 00 00
		// 00000000 00000000 00000000 00000000
		// r  g  b  a

		public Colour()
		{

		}

		// Constructor with RGBA defaulted to 0
		public Colour(uint red, uint green, uint blue, uint alpha)
		{
			//Shift colours into rgba binary positions
			colour = ((red << 24) + (green << 16) + (blue << 8) + alpha);
		}

		public byte GetRed()
		{
			return (byte)((colour & 0xFF000000) >> 24);
		}

		public void SetRed(uint red)
		{
			// Clear the red component
			// Move red to the correct position and combine with the colour value
			colour &= 0x00FFFFFF;
			colour |= (red << 24);
		}
		
		public byte GetGreen()
		{
			return (byte)(((colour & 0x00FF0000) << 8) >> 24);
		}

		public void SetGreen(uint green)
		{
			// Clear the green component
			// Move green to the correct position and combine with the colour value
			colour &= 0x0000FFFF;
			colour |= (green << 16);
		}

		public byte GetBlue()
		{
			return (byte)((colour & 0x0000FF00) >> 8);
		}

		public void SetBlue(uint blue)
		{
			// Clear the blue component
			// Move blue to the correct position and combine with the colour value
			colour &= 0x000000FF;
			colour |= (blue << 8);
		}

		public byte GetAlpha()
		{
			return (byte)(colour & 0x000000FF);
		}

		public void SetAlpha(uint alpha)
		{
			// Clear the alpha component
			// Move alpha to the correct position and combine with the colour value
			colour &= 0x000000FF;
			colour |= alpha;
		}
	}
}
