using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SvgPatternGenerator.Patterns
{
	internal class Dots : Pattern
	{
		internal Dots(string backgroundColour, string dotColour)
			: base(SvgTemplates.Dots, backgroundColour, dotColour)
		{
		}
	}
}
