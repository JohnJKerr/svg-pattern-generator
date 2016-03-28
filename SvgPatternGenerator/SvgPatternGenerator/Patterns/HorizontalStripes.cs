using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SvgPatternGenerator.Patterns
{
	internal class HorizontalStripes : Pattern
	{
		internal HorizontalStripes(string primaryColour, string secondaryColour)
			: base(SvgTemplates.HorizontalStripes, primaryColour, secondaryColour)
		{
		}
	}
}
