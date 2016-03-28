using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SvgPatternGenerator.Patterns
{
	internal class VerticalStripes : Pattern
	{
		internal VerticalStripes(string primaryColour, string secondaryColour) 
			: base(SvgTemplates.VerticalStripes, primaryColour, secondaryColour)
		{
		}
	}
}
