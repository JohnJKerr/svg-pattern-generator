using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SvgPatternGenerator.Patterns
{
	internal class Shippo : Pattern
	{
		internal Shippo(string circleBackgroundColour, string primaryPatternColour, string secondaryPatternColour)
			: base(SvgTemplates.Shippo, circleBackgroundColour, primaryPatternColour, secondaryPatternColour)
		{
		}
	}
}
