using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SvgPatternGenerator.Patterns
{
	internal class DiagonalStripes : Pattern
	{
		internal DiagonalStripes(string primaryColour, string secondaryColour)
			: base(SvgTemplates.DiagonalStripes, primaryColour, secondaryColour)
		{
		}
	}
}
