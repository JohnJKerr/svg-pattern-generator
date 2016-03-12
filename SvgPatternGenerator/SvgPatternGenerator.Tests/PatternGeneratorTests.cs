using NUnit.Framework;
using System;

namespace SvgPatternGenerator.Tests
{
	[TestFixture]
	public class PatternGeneratorTests
	{
		private readonly string _redAndWhiteStripes = "PHN2ZyB4bWxucz0naHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmcnIHdpZHRoPSc1MCcgaGVpZ2h0PSc1MCc+DQoJPHJlY3Qgd2lkdGg9JzUwJyBoZWlnaHQ9JzUwJyBmaWxsPSdyZWQnIC8+DQoJPHJlY3QgeD0nMjUnIHdpZHRoPScyNScgaGVpZ2h0PSc1MCcgZmlsbD0nd2hpdGUnIC8+DQo8L3N2Zz4=";

		[Test]
		public void Can_get_vertical_stripes()
		{
			//act
			var redAndWhiteStripes = PatternGenerator.VerticalStripes("red", "white");

			//assert
			Assert.That(redAndWhiteStripes, Is.EqualTo(_redAndWhiteStripes));
		}
	}
}
