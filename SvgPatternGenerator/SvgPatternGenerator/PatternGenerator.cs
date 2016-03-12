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
		public static string VerticalStripes(string primaryColour, string secondaryColour)
		{
			return new VerticalStripes(primaryColour, secondaryColour).Base64Image;
		}
    }
}
