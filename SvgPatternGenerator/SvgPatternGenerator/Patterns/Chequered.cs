using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SvgPatternGenerator.Patterns
{
	internal class Chequered : Pattern
	{
		internal Chequered(string primaryColour, string secondaryColour)
			: base(SvgTemplates.Chequered, primaryColour, secondaryColour)
		{
		}
	}
}
