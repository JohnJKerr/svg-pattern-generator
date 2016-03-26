using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SvgPatternGenerator.Patterns
{
	internal class CarbonFibre : Pattern
	{
		internal CarbonFibre(string backgroundColour, string primaryDotColour, string secondaryDotColour)
			: base(SvgTemplates.CarbonFibre, backgroundColour, primaryDotColour, secondaryDotColour)
		{
		}
	}
}
