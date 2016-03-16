using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SvgPatternGenerator.Patterns
{
	internal class CarbonFibre : Pattern
	{
		internal CarbonFibre(string primaryColour, string secondaryColour, string tertiaryColour)
			: base(SvgTemplates.CarbonFibre, primaryColour, secondaryColour, tertiaryColour)
		{
		}
	}
}
