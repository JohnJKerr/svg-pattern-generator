using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SvgPatternGenerator.Patterns
{
	internal class Dance : Pattern
	{
		internal Dance(string lineColour, string gradientStartColour, string gradientStopColour)
			: base(SvgTemplates.Dance, lineColour, gradientStartColour, gradientStopColour)
		{
		}
	}
}
