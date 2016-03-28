using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SvgPatternGenerator.Patterns
{
	internal class ThinDiagonalStripes : Pattern
	{
		internal ThinDiagonalStripes(string primaryColour, string secondaryColour)
			: base(SvgTemplates.ThinDiagonalStripes, primaryColour, secondaryColour)
		{
		}
	}
}
