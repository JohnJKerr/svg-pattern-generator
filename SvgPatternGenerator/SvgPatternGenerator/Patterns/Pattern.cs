using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SvgPatternGenerator.Patterns
{
	internal abstract class Pattern
	{
		private readonly string _template;

		internal Pattern(string template, params object[] arguments)
		{
			_template = string.Format(template, arguments);
		}

		internal string Base64Image
		{
			get
			{
				var bytes = Encoding.UTF8.GetBytes(_template);
				return Convert.ToBase64String(bytes);
			}
		}
	}
}
