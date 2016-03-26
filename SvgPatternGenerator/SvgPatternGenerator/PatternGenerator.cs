using SvgPatternGenerator.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SvgPatternGenerator
{
    public static class PatternGenerator
    {
		public static string Carbon(string primaryColour, string secondaryColour, string tertiaryColour)
		{
			return new Carbon(primaryColour, secondaryColour, tertiaryColour).Base64Image;
		}

		public static string CarbonFibre(string backgroundColour, string primaryDotColour, string secondaryDotColour)
		{
			return new CarbonFibre(backgroundColour, primaryDotColour, secondaryDotColour).Base64Image;
		}

		public static string Chequered(string primaryColour, string secondaryColour)
		{
			return new Chequered(primaryColour, secondaryColour).Base64Image;
		}

		public static string Chevrons(string backgroundColour, string lineColour)
		{
			return new Chevrons(backgroundColour, lineColour).Base64Image;
		}

		public static string CrossHatch(string backgroundColour, string lineColour)
		{
			return new CrossHatch(backgroundColour, lineColour).Base64Image;
		}

		public static string Dance(string lineColour, string gradientStartColour, string gradientStopColour)
		{
			return new Dance(lineColour, gradientStartColour, gradientStopColour).Base64Image;
		}

		public static string DiagonalStripes(string primaryColour, string secondaryColour)
		{
			return new DiagonalStripes(primaryColour, secondaryColour).Base64Image;
		}

		public static string Dots(string backgroundColour, string dotColour)
		{
			return new Dots(backgroundColour, dotColour).Base64Image;
		}

		public static string Gingham(string primaryColour, string secondaryColour, string tertiaryColour)
		{
			return new Gingham(primaryColour, secondaryColour, tertiaryColour).Base64Image;
		}

		public static string HalfRombes(string primaryColour, string secondaryColour)
		{
			return new HalfRombes(primaryColour, secondaryColour).Base64Image;
		}

		public static string Honeycomb(string backgroundColour, string primaryLineColour, string secondaryLineColour)
		{
			return new Honeycomb(backgroundColour, primaryLineColour, secondaryLineColour).Base64Image;
		}

		public static string HorizontalStripes(string primaryColour, string secondaryColour)
		{
			return new HorizontalStripes(primaryColour, secondaryColour).Base64Image;
		}

		public static string MicrobialMat(string backgroundColour, string lineColour)
		{
			return new MicrobialMat(backgroundColour, lineColour).Base64Image;
		}

		public static string Noise(string backgroundColour)
		{
			return new Noise(backgroundColour).Base64Image;
		}

		public static string Shippo(string circleBackgroundColour, string primaryPatternColour, string secondaryPatternColour)
		{
			return new Shippo(circleBackgroundColour, primaryPatternColour, secondaryPatternColour).Base64Image;
		}

		public static string ThinDiagonalStripes(string primaryColour, string secondaryColour)
		{
			return new ThinDiagonalStripes(primaryColour, secondaryColour).Base64Image;
		}

		public static string TwoToneHorizontal(string backgroundColour, string topHorizontalLineColour, string bottomHorizontalLineColour)
		{
			return new TwoToneHorizontal(backgroundColour, topHorizontalLineColour, bottomHorizontalLineColour).Base64Image;
		}

		public static string VerticalStripes(string primaryColour, string secondaryColour)
		{
			return new VerticalStripes(primaryColour, secondaryColour).Base64Image;
		}

		public static string Waves(string backgroundColour, string lineColour)
		{
			return new Waves(backgroundColour, lineColour).Base64Image;
		}
	}
}
