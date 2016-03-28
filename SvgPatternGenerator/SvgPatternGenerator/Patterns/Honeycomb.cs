using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SvgPatternGenerator.Patterns
{
	internal class Honeycomb : Pattern
	{
		internal Honeycomb(string backgroundColour, string primaryLineColour, string secondaryLineColour)
			: base(SvgTemplates.Honeycomb, backgroundColour, primaryLineColour, secondaryLineColour)
		{
		}
	}
}
