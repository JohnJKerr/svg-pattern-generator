using NUnit.Framework;
using System;

namespace SvgPatternGenerator.Tests
{
	[TestFixture]
	public class PatternGeneratorTests
	{
		private readonly string _redWhiteBlackCarbon = "PHN2ZyB4bWxucz0naHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmcnIHhtbG5zOnhsaW5rPSdodHRwOi8vd3d3LnczLm9yZy8xOTk5L3hsaW5rJyB3aWR0aD0nNicgaGVpZ2h0PSc2Jz4NCgk8cmVjdCB3aWR0aD0nNicgaGVpZ2h0PSc2JyBmaWxsPSdyZWQnIC8+DQoJPGcgaWQ9J2MnPg0KCQk8cmVjdCB3aWR0aD0nMycgaGVpZ2h0PSczJyBmaWxsPSd3aGl0ZScgLz4NCgkJPHJlY3QgeT0nMScgd2lkdGg9JzMnIGhlaWdodD0nMicgZmlsbD0nYmxhY2snIC8+DQoJPC9nPg0KCTx1c2UgeGxpbms6aHJlZj0nI2MnIHg9JzMnIHk9JzMnIC8+DQo8L3N2Zz4NCg==";
		private readonly string _redAndWhiteVerticalStripes = "PHN2ZyB4bWxucz0naHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmcnIHdpZHRoPSc1MCcgaGVpZ2h0PSc1MCc+DQoJPHJlY3Qgd2lkdGg9JzUwJyBoZWlnaHQ9JzUwJyBmaWxsPSdyZWQnIC8+DQoJPHJlY3QgeD0nMjUnIHdpZHRoPScyNScgaGVpZ2h0PSc1MCcgZmlsbD0nd2hpdGUnIC8+DQo8L3N2Zz4=";

		[Test]
		public void Can_get_carbon()
		{
			//act
			var redWhiteBlackCarbon = PatternGenerator.Carbon("red", "white", "black");

			//assert
			Assert.That(redWhiteBlackCarbon, Is.EqualTo(_redWhiteBlackCarbon));
		}

		[Test]
		public void Can_get_vertical_stripes()
		{
			//act
			var redAndWhiteStripes = PatternGenerator.VerticalStripes("red", "white");

			//assert
			Assert.That(redAndWhiteStripes, Is.EqualTo(_redAndWhiteVerticalStripes));
		}
	}
}
