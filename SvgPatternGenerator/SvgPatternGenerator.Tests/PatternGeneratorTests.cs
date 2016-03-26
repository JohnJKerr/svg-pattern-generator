using NUnit.Framework;
using System;
using System.Text.RegularExpressions;

namespace SvgPatternGenerator.Tests
{
	[TestFixture]
	public class PatternGeneratorTests
	{
		private readonly Regex _base64Regex = new Regex("^([A-Za-z0-9+/]{4})*([A-Za-z0-9+/]{4}|[A-Za-z0-9+/]{3}=|[A-Za-z0-9+/]{2}==)$");

		private readonly string _redWhiteBlackCarbon = "PHN2ZyB4bWxucz0naHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmcnIHhtbG5zOnhsaW5rPSdodHRwOi8vd3d3LnczLm9yZy8xOTk5L3hsaW5rJyB3aWR0aD0nNicgaGVpZ2h0PSc2Jz4NCgk8cmVjdCB3aWR0aD0nNicgaGVpZ2h0PSc2JyBmaWxsPSdyZWQnIC8+DQoJPGcgaWQ9J2MnPg0KCQk8cmVjdCB3aWR0aD0nMycgaGVpZ2h0PSczJyBmaWxsPSd3aGl0ZScgLz4NCgkJPHJlY3QgeT0nMScgd2lkdGg9JzMnIGhlaWdodD0nMicgZmlsbD0nYmxhY2snIC8+DQoJPC9nPg0KCTx1c2UgeGxpbms6aHJlZj0nI2MnIHg9JzMnIHk9JzMnIC8+DQo8L3N2Zz4NCg==";
		private readonly string _redWhiteBlackCarbonFibre = "PHN2ZyB4bWxucz0naHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmcnIHdpZHRoPScxNScgaGVpZ2h0PScxNSc+DQoJPHJlY3Qgd2lkdGg9JzUwJyBoZWlnaHQ9JzUwJyBmaWxsPSdyZWQnIC8+DQoJPGNpcmNsZSBjeD0nMycgY3k9JzQuMycgcj0nMS44JyBmaWxsPSd3aGl0ZScgLz4NCgk8Y2lyY2xlIGN4PSczJyBjeT0nMycgcj0nMS44JyBmaWxsPSdibGFjaycgLz4NCgk8Y2lyY2xlIGN4PScxMC41JyBjeT0nMTIuNScgcj0nMS44JyBmaWxsPSd3aGl0ZScgLz4NCgk8Y2lyY2xlIGN4PScxMC41JyBjeT0nMTEuMycgcj0nMS44JyBmaWxsPSdibGFjaycgLz4NCjwvc3ZnPg0K";
		private readonly string _redAndWhiteChecks = "PHN2ZyB4bWxucz0naHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmcnIHdpZHRoPSc2MCcgaGVpZ2h0PSc2MCc+DQoJPHJlY3Qgd2lkdGg9JzYwJyBoZWlnaHQ9JzYwJyBmaWxsPSdyZWQnIC8+DQoJPHJlY3Qgd2lkdGg9JzQyLjQyJyBoZWlnaHQ9JzQyLjQyJyB0cmFuc2Zvcm09J3RyYW5zbGF0ZSgzMCAwKSByb3RhdGUoNDUpJyBmaWxsPSd3aGl0ZScgLz4NCjwvc3ZnPg0K";
		private readonly string _redAndWhiteChevrons = "PHN2ZyB4bWxucz0naHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmcnIHhtbG5zOnhsaW5rPSdodHRwOi8vd3d3LnczLm9yZy8xOTk5L3hsaW5rJyB3aWR0aD0nNjAnIGhlaWdodD0nMzAnPg0KCTxkZWZzPg0KCQk8cmVjdCBpZD0ncicgd2lkdGg9JzMwJyBoZWlnaHQ9JzE1JyBmaWxsPSdyZWQnIHN0cm9rZS13aWR0aD0nMi41JyBzdHJva2U9J3doaXRlJyAvPg0KCQk8ZyBpZD0ncCc+DQoJCQk8dXNlIHhsaW5rOmhyZWY9JyNyJyAvPg0KCQkJPHVzZSB5PScxNScgeGxpbms6aHJlZj0nI3InIC8+DQoJCQk8dXNlIHk9JzMwJyB4bGluazpocmVmPScjcicgLz4NCgkJCTx1c2UgeT0nNDUnIHhsaW5rOmhyZWY9JyNyJyAvPg0KCQk8L2c+DQoJPC9kZWZzPg0KCTx1c2UgeGxpbms6aHJlZj0nI3AnIHRyYW5zZm9ybT0ndHJhbnNsYXRlKDAgLTI1KSBza2V3WSg0MCknIC8+DQoJPHVzZSB4bGluazpocmVmPScjcCcgdHJhbnNmb3JtPSd0cmFuc2xhdGUoMzAgMCkgc2tld1koLTQwKScgLz4NCjwvc3ZnPg==";
		private readonly string _redAndWhiteCrossHatch = "PHN2ZyB4bWxucz0naHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmcnIHdpZHRoPSc4JyBoZWlnaHQ9JzgnPg0KCTxyZWN0IHdpZHRoPSc4JyBoZWlnaHQ9JzgnIGZpbGw9J3JlZCcgLz4NCgk8cGF0aCBkPSdNMCAwTDggOFpNOCAwTDAgOFonIHN0cm9rZS13aWR0aD0nMScgc3Ryb2tlPSd3aGl0ZScgLz4NCjwvc3ZnPg==";
		private readonly string _redWhiteBlackDance = "PHN2ZyB4bWxucz0naHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmcnIHdpZHRoPSc4JyBoZWlnaHQ9JzgnPg0KCTxwYXRoIGQ9J00tMiAxMEwxMCAtMlpNMTAgNkw2IDEwWk0tMiAyTDIgLTInIHN0cm9rZT0ncmVkJyBzdHJva2Utd2lkdGg9JzQuNScgLz4NCjwvc3ZnPg0KDQo8c3ZnIHhtbG5zPSdodHRwOi8vd3d3LnczLm9yZy8yMDAwL3N2Zycgd2lkdGg9JzEwMCUnIGhlaWdodD0nMTAwJSc+DQoJPGxpbmVhckdyYWRpZW50IGlkPSdnJyB4Mj0nMScgeTI9JzEnPg0KCQk8c3RvcCBzdG9wLWNvbG9yPSd3aGl0ZScgLz4NCgkJPHN0b3Agb2Zmc2V0PScxMDAlJyBzdG9wLWNvbG9yPSdibGFjaycgLz4NCgk8L2xpbmVhckdyYWRpZW50Pg0KCTxyZWN0IHdpZHRoPScxMDAlJyBoZWlnaHQ9JzEwMCUnIGZpbGw9J3VybCgjZyknIC8+DQo8L3N2Zz4=";
		private readonly string _redWhiteDiagonalStripes = "PHN2ZyB4bWxucz0naHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmcnIHdpZHRoPSc3MCcgaGVpZ2h0PSc3MCc+DQoJPHJlY3Qgd2lkdGg9JzcwJyBoZWlnaHQ9JzcwJyBmaWxsPSdyZWQnIC8+DQoJPGcgdHJhbnNmb3JtPSdyb3RhdGUoNDUpJz4NCgkJPHJlY3Qgd2lkdGg9Jzk5JyBoZWlnaHQ9JzI1JyBmaWxsPSd3aGl0ZScgLz4NCgkJPHJlY3QgeT0nLTUwJyB3aWR0aD0nOTknIGhlaWdodD0nMjUnIGZpbGw9J3doaXRlJyAvPg0KCTwvZz4NCjwvc3ZnPg==";
		private readonly string _redWhiteDots = "PHN2ZyB4bWxucz0naHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmcnIHdpZHRoPSc1JyBoZWlnaHQ9JzUnPg0KCTxyZWN0IHdpZHRoPSc1JyBoZWlnaHQ9JzUnIGZpbGw9J3JlZCcgLz4NCgk8cmVjdCB3aWR0aD0nMScgaGVpZ2h0PScxJyBmaWxsPSd3aGl0ZScgLz4NCjwvc3ZnPg0K";
		private readonly string _redWhiteBlackGingham = "PHN2ZyB4bWxucz0naHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmcnIHdpZHRoPScyMCcgaGVpZ2h0PScyMCc+DQoJPHJlY3Qgd2lkdGg9JzIwJyBoZWlnaHQ9JzIwJyBmaWxsPSdyZWQnIC8+DQoJPHJlY3Qgd2lkdGg9JzEwJyBoZWlnaHQ9JzEwJyBmaWxsPSd3aGl0ZScgLz4NCgk8cmVjdCB4PScxMCcgeT0nMTAnIHdpZHRoPScxMCcgaGVpZ2h0PScxMCcgZmlsbD0nYmxhY2snIC8+DQo8L3N2Zz4=";
		private readonly string _redWhiteHalfRombes = "PHN2ZyB4bWxucz0naHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmcnIHdpZHRoPScxNScgaGVpZ2h0PScxNSc+DQoJPHJlY3Qgd2lkdGg9JzE1JyBoZWlnaHQ9JzE1JyBmaWxsPSdyZWQnIC8+DQoJPHBhdGggZD0nTTAgMTVMNy41IDBMMTUgMTVaJyBmaWxsPSd3aGl0ZScgLz4NCjwvc3ZnPg==";
		private readonly string _redWhiteBlackHoneycomb = "PHN2ZyB4bWxucz0naHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmcnIHdpZHRoPSc1NicgaGVpZ2h0PScxMDAnPg0KCTxyZWN0IHdpZHRoPSc1NicgaGVpZ2h0PScxMDAnIGZpbGw9J3JlZCcgLz4NCgk8cGF0aCBkPSdNMjggNjZMMCA1MEwwIDE2TDI4IDBMNTYgMTZMNTYgNTBMMjggNjZMMjggMTAwJyBmaWxsPSdub25lJyBzdHJva2U9J3doaXRlJyBzdHJva2Utd2lkdGg9JzInIC8+DQoJPHBhdGggZD0nTTI4IDBMMjggMzRMMCA1MEwwIDg0TDI4IDEwMEw1NiA4NEw1NiA1MEwyOCAzNCcgZmlsbD0nbm9uZScgc3Ryb2tlPSdibGFjaycgc3Ryb2tlLXdpZHRoPScyJyAvPg0KPC9zdmc+DQo=";
		private readonly string _redWhiteHorizontalStripes = "PHN2ZyB4bWxucz0naHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmcnIHdpZHRoPSczMCcgaGVpZ2h0PSczMCc+DQoJPHJlY3Qgd2lkdGg9JzMwJyBoZWlnaHQ9JzMwJyBmaWxsPSdyZWQnIC8+DQoJPHJlY3Qgd2lkdGg9JzMwJyBoZWlnaHQ9JzE4JyBmaWxsPSd3aGl0ZScgLz4NCjwvc3ZnPg0K";
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
		public void Carbon_is_base_64()
		{
			//act
			var redWhiteBlackCarbon = PatternGenerator.Carbon("red", "white", "black");
			bool isBase64 = _base64Regex.IsMatch(redWhiteBlackCarbon);

			//assert
			Assert.That(isBase64, Is.True);
		}

		[Test]
		public void Can_get_carbon_fibre()
		{
			//act
			var redWhiteBlackCarbonFibre = PatternGenerator.CarbonFibre("red", "white", "black");

			//assert
			Assert.That(redWhiteBlackCarbonFibre, Is.EqualTo(_redWhiteBlackCarbonFibre));
		}

		[Test]
		public void Carbon_fibre_is_base_64()
		{
			//act
			var redWhiteBlackCarbonFibre = PatternGenerator.CarbonFibre("red", "white", "black");
			bool isBase64 = _base64Regex.IsMatch(redWhiteBlackCarbonFibre);

			//assert
			Assert.That(isBase64, Is.True);
		}

		[Test]
		public void Can_get_chequered()
		{
			//act
			var redAndWhiteChecks = PatternGenerator.Chequered("red", "white");

			//assert
			Assert.That(redAndWhiteChecks, Is.EqualTo(_redAndWhiteChecks));
		}

		[Test]
		public void Chequered_is_base_64()
		{
			//act
			var redAndWhiteChecks = PatternGenerator.Chequered("red", "white");
			bool isBase64 = _base64Regex.IsMatch(redAndWhiteChecks);

			//assert
			Assert.That(isBase64, Is.True);
		}

		[Test]
		public void Can_get_chevrons()
		{
			//act
			var redAndWhiteChevrons = PatternGenerator.Chevrons("red", "white");

			//assert
			Assert.That(redAndWhiteChevrons, Is.EqualTo(_redAndWhiteChevrons));
		}

		[Test]
		public void Chevrons_is_base_64()
		{
			//act
			var redAndWhiteChevrons = PatternGenerator.Chevrons("red", "white");
			bool isBase64 = _base64Regex.IsMatch(redAndWhiteChevrons);

			//assert
			Assert.That(isBase64, Is.True);
		}

		[Test]
		public void Can_get_cross_hatch()
		{
			//act
			var redAndWhiteCrossHatch = PatternGenerator.CrossHatch("red", "white");

			//assert
			Assert.That(redAndWhiteCrossHatch, Is.EqualTo(_redAndWhiteCrossHatch));
		}

		[Test]
		public void Cross_hatch_is_base_64()
		{
			//act
			var redAndWhiteCrossHatch = PatternGenerator.CrossHatch("red", "white");
			bool isBase64 = _base64Regex.IsMatch(redAndWhiteCrossHatch);

			//assert
			Assert.That(isBase64, Is.True);
		}

		[Test]
		public void Can_get_dance()
		{
			//act
			var redWhiteBlackDance = PatternGenerator.Dance("red", "white", "black");

			//assert
			Assert.That(redWhiteBlackDance, Is.EqualTo(_redWhiteBlackDance));
		}

		[Test]
		public void Dance_is_base_64()
		{
			//act
			var redWhiteBlackDance = PatternGenerator.Dance("red", "white", "black");
			bool isBase64 = _base64Regex.IsMatch(redWhiteBlackDance);

			//assert
			Assert.That(isBase64, Is.True);
		}

		[Test]
		public void Can_get_diagonal_stripes()
		{
			//act
			var redWhiteDiagonalStripes = PatternGenerator.DiagonalStripes("red", "white");

			//assert
			Assert.That(redWhiteDiagonalStripes, Is.EqualTo(_redWhiteDiagonalStripes));
		}

		[Test]
		public void Diagonal_stripes_is_base_64()
		{
			//act
			var redWhiteDiagonalStripes = PatternGenerator.DiagonalStripes("red", "white");
			bool isBase64 = _base64Regex.IsMatch(redWhiteDiagonalStripes);

			//assert
			Assert.That(isBase64, Is.True);
		}

		[Test]
		public void Can_get_dots()
		{
			//act
			var redWhiteDots = PatternGenerator.Dots("red", "white");

			//assert
			Assert.That(redWhiteDots, Is.EqualTo(_redWhiteDots));
		}

		[Test]
		public void Dots_is_base_64()
		{
			//act
			var redWhiteDots = PatternGenerator.Dots("red", "white");
			bool isBase64 = _base64Regex.IsMatch(redWhiteDots);

			//assert
			Assert.That(isBase64, Is.True);
		}

		[Test]
		public void Can_get_gingham()
		{
			//act
			var redWhiteBlackGingham = PatternGenerator.Gingham("red", "white", "black");

			//assert
			Assert.That(redWhiteBlackGingham, Is.EqualTo(_redWhiteBlackGingham));
		}

		[Test]
		public void Gingham_is_base_64()
		{
			//act
			var redWhiteBlackGingham = PatternGenerator.Gingham("red", "white", "black");
			bool isBase64 = _base64Regex.IsMatch(redWhiteBlackGingham);

			//assert
			Assert.That(isBase64, Is.True);
		}

		[Test]
		public void Can_get_half_rombes()
		{
			//act
			var redWhiteHalfRombes = PatternGenerator.HalfRombes("red", "white");

			//assert
			Assert.That(redWhiteHalfRombes, Is.EqualTo(_redWhiteHalfRombes));
		}

		[Test]
		public void Half_rombes_is_base_64()
		{
			//act
			var redWhiteHalfRombes = PatternGenerator.HalfRombes("red", "white");
			bool isBase64 = _base64Regex.IsMatch(redWhiteHalfRombes);

			//assert
			Assert.That(isBase64, Is.True);
		}

		[Test]
		public void Can_get_honeycomb()
		{
			//act
			var redWhiteBlackHoneycomb = PatternGenerator.Honeycomb("red", "white", "black");

			//assert
			Assert.That(redWhiteBlackHoneycomb, Is.EqualTo(_redWhiteBlackHoneycomb));
		}

		[Test]
		public void Honeycomb_is_base_64()
		{
			//act
			var redWhiteBlackHoneycomb = PatternGenerator.Honeycomb("red", "white", "black");
			bool isBase64 = _base64Regex.IsMatch(redWhiteBlackHoneycomb);

			//assert
			Assert.That(isBase64, Is.True);
		}

		[Test]
		public void Can_get_horizontal_stripes()
		{
			//act
			var redWhiteHorizontalStripes = PatternGenerator.HorizontalStripes("red", "white");

			//assert
			Assert.That(redWhiteHorizontalStripes, Is.EqualTo(_redWhiteHorizontalStripes));
		}

		[Test]
		public void Horizontal_stripes_is_base_64()
		{
			//act
			var redWhiteHorizontalStripes = PatternGenerator.HorizontalStripes("red", "white");
			bool isBase64 = _base64Regex.IsMatch(redWhiteHorizontalStripes);

			//assert
			Assert.That(isBase64, Is.True);
		}

		[Test]
		public void Can_get_vertical_stripes()
		{
			//act
			var redWhiteVerticalStripes = PatternGenerator.VerticalStripes("red", "white");

			//assert
			Assert.That(redWhiteVerticalStripes, Is.EqualTo(_redAndWhiteVerticalStripes));
		}

		[Test]
		public void Vertical_stripes_is_base_64()
		{
			//act
			var redWhiteVerticalStripes = PatternGenerator.VerticalStripes("red", "white");
			bool isBase64 = _base64Regex.IsMatch(redWhiteVerticalStripes);

			//assert
			Assert.That(isBase64, Is.True);
		}
	}
}
