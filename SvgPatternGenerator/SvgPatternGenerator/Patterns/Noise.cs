using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SvgPatternGenerator.Patterns
{
	internal class Noise : Pattern
	{
		internal Noise(string backgroundColour)
			: base(SvgTemplates.Noise, backgroundColour)
		{
		}
	}
}
