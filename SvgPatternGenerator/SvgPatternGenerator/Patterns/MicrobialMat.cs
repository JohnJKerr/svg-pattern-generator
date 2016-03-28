using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SvgPatternGenerator.Patterns
{
	internal class MicrobialMat : Pattern
	{
		internal MicrobialMat(string backgroundColour, string lineColour)
			: base(SvgTemplates.MicrobialMat, backgroundColour, lineColour)
		{
		}
	}
}
