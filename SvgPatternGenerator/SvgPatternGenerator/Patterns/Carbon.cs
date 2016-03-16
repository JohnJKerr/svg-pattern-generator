using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SvgPatternGenerator.Patterns
{
	internal class Carbon : Pattern
	{
		internal Carbon(string primaryColour, string secondaryColour, string tertiaryColour)
			: base(SvgTemplates.Carbon, primaryColour, secondaryColour, tertiaryColour)
		{
		}
	}
}
