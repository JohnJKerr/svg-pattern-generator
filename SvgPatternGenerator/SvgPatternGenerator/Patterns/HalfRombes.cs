using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SvgPatternGenerator.Patterns
{
	internal class HalfRombes : Pattern
	{
		internal HalfRombes(string primaryColour, string secondaryColour)
			: base(SvgTemplates.HalfRombes, primaryColour, secondaryColour)
		{
		}
	}
}
