using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SvgPatternGenerator.Patterns
{
	internal class CrossHatch : Pattern
	{
		internal CrossHatch(string backgroundColour, string lineColour)
			: base(SvgTemplates.CrossHatch, backgroundColour, lineColour)
		{
		}
	}
}
