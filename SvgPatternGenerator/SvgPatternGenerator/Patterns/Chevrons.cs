using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SvgPatternGenerator.Patterns
{
	internal class Chevrons : Pattern
	{
		internal Chevrons(string backgroundColour, string lineColour)
			: base(SvgTemplates.Chevrons, backgroundColour, lineColour)
		{
		}
	}
}
