using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SvgPatternGenerator.Patterns
{
	internal class Gingham : Pattern
	{
		internal Gingham(string primaryColour, string secondaryColour, string tertiaryColour)
			: base(SvgTemplates.Gingham, primaryColour, secondaryColour, tertiaryColour)
		{
		}
	}
}
