using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SvgPatternGenerator.Patterns
{
	internal class Waves : Pattern
	{
		internal Waves(string backgroundColour, string lineColour)
			: base(SvgTemplates.Waves, backgroundColour, lineColour)
		{
		}
	}
}
