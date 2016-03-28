using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SvgPatternGenerator.Patterns
{
	internal class TwoToneHorizontal : Pattern
	{
		internal TwoToneHorizontal(string backgroundColour, string topHorizontalLineColour, string bottomHorizontalLineColour)
			: base(SvgTemplates.TwoToneHorizontal, backgroundColour, topHorizontalLineColour, bottomHorizontalLineColour)
		{
		}
	}
}
