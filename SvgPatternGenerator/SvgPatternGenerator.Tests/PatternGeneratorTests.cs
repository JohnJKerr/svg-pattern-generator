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
		private readonly string _redWhiteChecks = "PHN2ZyB4bWxucz0naHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmcnIHdpZHRoPSc2MCcgaGVpZ2h0PSc2MCc+DQoJPHJlY3Qgd2lkdGg9JzYwJyBoZWlnaHQ9JzYwJyBmaWxsPSdyZWQnIC8+DQoJPHJlY3Qgd2lkdGg9JzQyLjQyJyBoZWlnaHQ9JzQyLjQyJyB0cmFuc2Zvcm09J3RyYW5zbGF0ZSgzMCAwKSByb3RhdGUoNDUpJyBmaWxsPSd3aGl0ZScgLz4NCjwvc3ZnPg0K";
		private readonly string _redWhiteChevrons = "PHN2ZyB4bWxucz0naHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmcnIHhtbG5zOnhsaW5rPSdodHRwOi8vd3d3LnczLm9yZy8xOTk5L3hsaW5rJyB3aWR0aD0nNjAnIGhlaWdodD0nMzAnPg0KCTxkZWZzPg0KCQk8cmVjdCBpZD0ncicgd2lkdGg9JzMwJyBoZWlnaHQ9JzE1JyBmaWxsPSdyZWQnIHN0cm9rZS13aWR0aD0nMi41JyBzdHJva2U9J3doaXRlJyAvPg0KCQk8ZyBpZD0ncCc+DQoJCQk8dXNlIHhsaW5rOmhyZWY9JyNyJyAvPg0KCQkJPHVzZSB5PScxNScgeGxpbms6aHJlZj0nI3InIC8+DQoJCQk8dXNlIHk9JzMwJyB4bGluazpocmVmPScjcicgLz4NCgkJCTx1c2UgeT0nNDUnIHhsaW5rOmhyZWY9JyNyJyAvPg0KCQk8L2c+DQoJPC9kZWZzPg0KCTx1c2UgeGxpbms6aHJlZj0nI3AnIHRyYW5zZm9ybT0ndHJhbnNsYXRlKDAgLTI1KSBza2V3WSg0MCknIC8+DQoJPHVzZSB4bGluazpocmVmPScjcCcgdHJhbnNmb3JtPSd0cmFuc2xhdGUoMzAgMCkgc2tld1koLTQwKScgLz4NCjwvc3ZnPg==";
		private readonly string _redWhiteCrossHatch = "PHN2ZyB4bWxucz0naHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmcnIHdpZHRoPSc4JyBoZWlnaHQ9JzgnPg0KCTxyZWN0IHdpZHRoPSc4JyBoZWlnaHQ9JzgnIGZpbGw9J3JlZCcgLz4NCgk8cGF0aCBkPSdNMCAwTDggOFpNOCAwTDAgOFonIHN0cm9rZS13aWR0aD0nMScgc3Ryb2tlPSd3aGl0ZScgLz4NCjwvc3ZnPg==";
		private readonly string _redWhiteBlackDance = "PHN2ZyB4bWxucz0naHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmcnIHdpZHRoPSc4JyBoZWlnaHQ9JzgnPg0KCTxwYXRoIGQ9J00tMiAxMEwxMCAtMlpNMTAgNkw2IDEwWk0tMiAyTDIgLTInIHN0cm9rZT0ncmVkJyBzdHJva2Utd2lkdGg9JzQuNScgLz4NCjwvc3ZnPg0KDQo8c3ZnIHhtbG5zPSdodHRwOi8vd3d3LnczLm9yZy8yMDAwL3N2Zycgd2lkdGg9JzEwMCUnIGhlaWdodD0nMTAwJSc+DQoJPGxpbmVhckdyYWRpZW50IGlkPSdnJyB4Mj0nMScgeTI9JzEnPg0KCQk8c3RvcCBzdG9wLWNvbG9yPSd3aGl0ZScgLz4NCgkJPHN0b3Agb2Zmc2V0PScxMDAlJyBzdG9wLWNvbG9yPSdibGFjaycgLz4NCgk8L2xpbmVhckdyYWRpZW50Pg0KCTxyZWN0IHdpZHRoPScxMDAlJyBoZWlnaHQ9JzEwMCUnIGZpbGw9J3VybCgjZyknIC8+DQo8L3N2Zz4=";
		private readonly string _redWhiteDiagonalStripes = "PHN2ZyB4bWxucz0naHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmcnIHdpZHRoPSc3MCcgaGVpZ2h0PSc3MCc+DQoJPHJlY3Qgd2lkdGg9JzcwJyBoZWlnaHQ9JzcwJyBmaWxsPSdyZWQnIC8+DQoJPGcgdHJhbnNmb3JtPSdyb3RhdGUoNDUpJz4NCgkJPHJlY3Qgd2lkdGg9Jzk5JyBoZWlnaHQ9JzI1JyBmaWxsPSd3aGl0ZScgLz4NCgkJPHJlY3QgeT0nLTUwJyB3aWR0aD0nOTknIGhlaWdodD0nMjUnIGZpbGw9J3doaXRlJyAvPg0KCTwvZz4NCjwvc3ZnPg==";
		private readonly string _redWhiteDots = "PHN2ZyB4bWxucz0naHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmcnIHdpZHRoPSc1JyBoZWlnaHQ9JzUnPg0KCTxyZWN0IHdpZHRoPSc1JyBoZWlnaHQ9JzUnIGZpbGw9J3JlZCcgLz4NCgk8cmVjdCB3aWR0aD0nMScgaGVpZ2h0PScxJyBmaWxsPSd3aGl0ZScgLz4NCjwvc3ZnPg0K";
		private readonly string _redWhiteBlackGingham = "PHN2ZyB4bWxucz0naHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmcnIHdpZHRoPScyMCcgaGVpZ2h0PScyMCc+DQoJPHJlY3Qgd2lkdGg9JzIwJyBoZWlnaHQ9JzIwJyBmaWxsPSdyZWQnIC8+DQoJPHJlY3Qgd2lkdGg9JzEwJyBoZWlnaHQ9JzEwJyBmaWxsPSd3aGl0ZScgLz4NCgk8cmVjdCB4PScxMCcgeT0nMTAnIHdpZHRoPScxMCcgaGVpZ2h0PScxMCcgZmlsbD0nYmxhY2snIC8+DQo8L3N2Zz4=";
		private readonly string _redWhiteHalfRombes = "PHN2ZyB4bWxucz0naHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmcnIHdpZHRoPScxNScgaGVpZ2h0PScxNSc+DQoJPHJlY3Qgd2lkdGg9JzE1JyBoZWlnaHQ9JzE1JyBmaWxsPSdyZWQnIC8+DQoJPHBhdGggZD0nTTAgMTVMNy41IDBMMTUgMTVaJyBmaWxsPSd3aGl0ZScgLz4NCjwvc3ZnPg==";
		private readonly string _redWhiteBlackHoneycomb = "PHN2ZyB4bWxucz0naHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmcnIHdpZHRoPSc1NicgaGVpZ2h0PScxMDAnPg0KCTxyZWN0IHdpZHRoPSc1NicgaGVpZ2h0PScxMDAnIGZpbGw9J3JlZCcgLz4NCgk8cGF0aCBkPSdNMjggNjZMMCA1MEwwIDE2TDI4IDBMNTYgMTZMNTYgNTBMMjggNjZMMjggMTAwJyBmaWxsPSdub25lJyBzdHJva2U9J3doaXRlJyBzdHJva2Utd2lkdGg9JzInIC8+DQoJPHBhdGggZD0nTTI4IDBMMjggMzRMMCA1MEwwIDg0TDI4IDEwMEw1NiA4NEw1NiA1MEwyOCAzNCcgZmlsbD0nbm9uZScgc3Ryb2tlPSdibGFjaycgc3Ryb2tlLXdpZHRoPScyJyAvPg0KPC9zdmc+DQo=";
		private readonly string _redWhiteHorizontalStripes = "PHN2ZyB4bWxucz0naHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmcnIHdpZHRoPSczMCcgaGVpZ2h0PSczMCc+DQoJPHJlY3Qgd2lkdGg9JzMwJyBoZWlnaHQ9JzMwJyBmaWxsPSdyZWQnIC8+DQoJPHJlY3Qgd2lkdGg9JzMwJyBoZWlnaHQ9JzE4JyBmaWxsPSd3aGl0ZScgLz4NCjwvc3ZnPg0K";
		private readonly string _redWhiteMicrobial = "PHN2ZyB4bWxucz0naHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmcnIHdpZHRoPSc0MCcgaGVpZ2h0PSc0MCcgdmlld0JveD0nMCAwIDIwIDIwJz4NCgk8cmVjdCB3aWR0aD0nNDAnIGhlaWdodD0nNDAnIGZpbGw9J3JlZCcgLz4NCgk8Y2lyY2xlIHI9JzkuMicgc3Ryb2tlLXdpZHRoPScxJyBzdHJva2U9J3doaXRlJyBmaWxsPSdub25lJyAvPg0KCTxjaXJjbGUgY3k9JzE4LjQnIHI9JzkuMicgc3Ryb2tlLXdpZHRoPScxcHgnIHN0cm9rZT0nd2hpdGUnIGZpbGw9J25vbmUnIC8+DQoJPGNpcmNsZSBjeD0nMTguNCcgY3k9JzE4LjQnIHI9JzkuMicgc3Ryb2tlLXdpZHRoPScxJyBzdHJva2U9J3doaXRlJyBmaWxsPSdub25lJyAvPg0KPC9zdmc+";
		private readonly string _redNoise = "PHN2ZyB4bWxucz0naHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmcnIHhtbG5zOnhsaW5rPSdodHRwOi8vd3d3LnczLm9yZy8xOTk5L3hsaW5rJyB3aWR0aD0nMzAwJyBoZWlnaHQ9JzMwMCc+DQoJPGZpbHRlciBpZD0nbicgeD0nMCcgeT0nMCc+DQoJCTxmZVR1cmJ1bGVuY2UgdHlwZT0nZnJhY3RhbE5vaXNlJyBiYXNlRnJlcXVlbmN5PScwLjcnIG51bU9jdGF2ZXM9JzEwJyBzdGl0Y2hUaWxlcz0nc3RpdGNoJyAvPg0KCTwvZmlsdGVyPg0KCTxyZWN0IHdpZHRoPSczMDAnIGhlaWdodD0nMzAwJyBmaWxsPSdyZWQnIC8+DQoJPHJlY3Qgd2lkdGg9JzMwMCcgaGVpZ2h0PSczMDAnIGZpbHRlcj0idXJsKCNuKSIgb3BhY2l0eT0nMC40JyAvPg0KPC9zdmc+DQo=";
		private readonly string _redWhiteBlackShippo = "PHN2ZyB4bWxucz0naHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmcnIHdpZHRoPSc4MCcgaGVpZ2h0PSc4MCc+DQoJPHJlY3Qgd2lkdGg9JzgwJyBoZWlnaHQ9JzgwJyBmaWxsPSd3aGl0ZScgLz4NCgk8Y2lyY2xlIGN4PSc0MCcgY3k9JzQwJyByPSc0MCcgZmlsbD0ncmVkJyAvPg0KCTxwYXRoIGQ9J00wIDQwIEE0MCA0MCA0NSAwIDAgNDAgMCBBNDAgNDAgMzE1IDAgMCA4MCA0MCBBNDAgNDAgNDUgMCAwIDQwIDgwIEE0MCA0MCAyNzAgMCAwIDAgNDBaJyBmaWxsPSdibGFjaycgLz4NCjwvc3ZnPg==";
		private readonly string _redWhiteThinDiagonal = "PHN2ZyB4bWxucz0naHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmcnIHdpZHRoPSc1JyBoZWlnaHQ9JzUnPg0KCTxyZWN0IHdpZHRoPSc1JyBoZWlnaHQ9JzUnIGZpbGw9J3JlZCcgLz4NCgk8cGF0aCBkPSdNMCA1TDUgMFpNNiA0TDQgNlpNLTEgMUwxIC0xWicgc3Ryb2tlPSd3aGl0ZScgc3Ryb2tlLXdpZHRoPScxJyAvPg0KPC9zdmc+DQo=";
		private readonly string _redWhiteBlackTwoTone = "PHN2ZyB4bWxucz0naHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmcnIHdpZHRoPScyMCcgaGVpZ2h0PSc5Jz4NCgk8cmVjdCB3aWR0aD0nMjAnIGhlaWdodD0nOScgZmlsbD0ncmVkJyAvPg0KCTxyZWN0IHdpZHRoPScyMCcgaGVpZ2h0PScyJyBmaWxsPSd3aGl0ZScgLz4NCgk8cmVjdCB5PScyJyB3aWR0aD0nMjAnIGhlaWdodD0nMycgZmlsbD0nYmxhY2snIC8+DQo8L3N2Zz4=";
		private readonly string _redAndWhiteVerticalStripes = "PHN2ZyB4bWxucz0naHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmcnIHdpZHRoPSc1MCcgaGVpZ2h0PSc1MCc+DQoJPHJlY3Qgd2lkdGg9JzUwJyBoZWlnaHQ9JzUwJyBmaWxsPSdyZWQnIC8+DQoJPHJlY3QgeD0nMjUnIHdpZHRoPScyNScgaGVpZ2h0PSc1MCcgZmlsbD0nd2hpdGUnIC8+DQo8L3N2Zz4=";
		private readonly string _redWhiteWaves = "PHN2ZyB4bWxucz0naHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmcnIHdpZHRoPSc3NScgaGVpZ2h0PScxMDAnPg0KCTxyZWN0IHdpZHRoPSc3NScgaGVpZ2h0PScxMDAnIGZpbGw9J3JlZCcgLz4NCgk8Y2lyY2xlIGN4PSc3NScgY3k9JzUwJyByPScyOC4zJScgc3Ryb2tlLXdpZHRoPScxMicgc3Ryb2tlPSd3aGl0ZScgZmlsbD0nbm9uZScgLz4NCgk8Y2lyY2xlIGN4PScwJyByPScyOC4zJScgc3Ryb2tlLXdpZHRoPScxMicgc3Ryb2tlPSd3aGl0ZScgZmlsbD0nbm9uZScgLz4NCgk8Y2lyY2xlIGN5PScxMDAnIHI9JzI4LjMlJyBzdHJva2Utd2lkdGg9JzEyJyBzdHJva2U9J3doaXRlJyBmaWxsPSdub25lJyAvPg0KPC9zdmc+";

		[Test]
		public void Can_get_carbon()
		{
			//act
			var redWhiteBlackCarbon = PatternGenerator.Carbon("red", "white", "black");

			//assert
			Assert.That(redWhiteBlackCarbon, Is.EqualTo(_redWhiteBlackCarbon));
		}

		[Test]
		public void Carbon_differs_on_colour()
		{
			//act
			var redWhiteBlackCarbon = PatternGenerator.Carbon("red", "white", "black");
			var greenBlueYellowCarbon = PatternGenerator.Carbon("green", "blue", "yellow");

			//assert
			Assert.That(redWhiteBlackCarbon, Is.Not.EqualTo(greenBlueYellowCarbon));
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
		public void Carbon_fibre_differs_on_colour()
		{
			//act
			var redWhiteBlackCarbonFibre = PatternGenerator.CarbonFibre("red", "white", "black");
			var greenBlueYellowCarbonFibre = PatternGenerator.CarbonFibre("green", "blue", "yellow");

			//assert
			Assert.That(redWhiteBlackCarbonFibre, Is.Not.EqualTo(greenBlueYellowCarbonFibre));
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
			var redWhiteChecks = PatternGenerator.Chequered("red", "white");

			//assert
			Assert.That(redWhiteChecks, Is.EqualTo(_redWhiteChecks));
		}

		[Test]
		public void Chequered_differs_on_colour()
		{
			//act
			var redWhiteChecks = PatternGenerator.Chequered("red", "white");
			var greenBlueChecks = PatternGenerator.Chequered("green", "blue");

			//assert
			Assert.That(redWhiteChecks, Is.Not.EqualTo(greenBlueChecks));
		}

		[Test]
		public void Chequered_is_base_64()
		{
			//act
			var redWhiteChecks = PatternGenerator.Chequered("red", "white");
			bool isBase64 = _base64Regex.IsMatch(redWhiteChecks);

			//assert
			Assert.That(isBase64, Is.True);
		}

		[Test]
		public void Can_get_chevrons()
		{
			//act
			var redWhiteChevrons = PatternGenerator.Chevrons("red", "white");

			//assert
			Assert.That(redWhiteChevrons, Is.EqualTo(_redWhiteChevrons));
		}

		[Test]
		public void Chevrons_differs_on_colour()
		{
			//act
			var redWhiteChevrons = PatternGenerator.Chevrons("red", "white");
			var greenBlueChevrons = PatternGenerator.Chevrons("green", "blue");

			//assert
			Assert.That(redWhiteChevrons, Is.Not.EqualTo(greenBlueChevrons));
		}

		[Test]
		public void Chevrons_is_base_64()
		{
			//act
			var redWhiteChevrons = PatternGenerator.Chevrons("red", "white");
			bool isBase64 = _base64Regex.IsMatch(redWhiteChevrons);

			//assert
			Assert.That(isBase64, Is.True);
		}

		[Test]
		public void Can_get_cross_hatch()
		{
			//act
			var redWhiteCrossHatch = PatternGenerator.CrossHatch("red", "white");

			//assert
			Assert.That(redWhiteCrossHatch, Is.EqualTo(_redWhiteCrossHatch));
		}

		[Test]
		public void Cross_hatch_differs_on_colour()
		{
			//act
			var redWhiteCrossHatch = PatternGenerator.CrossHatch("red", "white");
			var greenBlueCrossHatch = PatternGenerator.CrossHatch("green", "blue");

			//assert
			Assert.That(redWhiteCrossHatch, Is.Not.EqualTo(greenBlueCrossHatch));
		}

		[Test]
		public void Cross_hatch_is_base_64()
		{
			//act
			var redWhiteCrossHatch = PatternGenerator.CrossHatch("red", "white");
			bool isBase64 = _base64Regex.IsMatch(redWhiteCrossHatch);

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
		public void Dance_differs_on_colour()
		{
			//act
			var redWhiteBlackDance = PatternGenerator.Dance("red", "white", "black");
			var greenBlueYellowDance = PatternGenerator.Dance("green", "blue", "yellow");

			//assert
			Assert.That(redWhiteBlackDance, Is.Not.EqualTo(greenBlueYellowDance));
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
		public void Diagonal_stripes_differs_on_colour()
		{
			//act
			var redWhiteDiagonalStripes = PatternGenerator.DiagonalStripes("red", "white");
			var blueGreenDiagonalStripes = PatternGenerator.DiagonalStripes("blue", "green");

			//assert
			Assert.That(redWhiteDiagonalStripes, Is.Not.EqualTo(blueGreenDiagonalStripes));
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
		public void Dots_differs_on_colour()
		{
			//act
			var redWhiteDots = PatternGenerator.Dots("red", "white");
			var blueGreenDots = PatternGenerator.Dots("blue", "green");

			//assert
			Assert.That(redWhiteDots, Is.Not.EqualTo(blueGreenDots));
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
		public void Gingham_differs_on_colour()
		{
			//act
			var redWhiteBlackGingham = PatternGenerator.Gingham("red", "white", "black");
			var blueGreenYellowGingham = PatternGenerator.Gingham("blue", "green", "yellow");

			//assert
			Assert.That(redWhiteBlackGingham, Is.Not.EqualTo(blueGreenYellowGingham));
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
		public void Half_rombes_differs_on_colour()
		{
			//act
			var redWhiteHalfRombes = PatternGenerator.HalfRombes("red", "white");
			var blueGreenHalfRombes = PatternGenerator.HalfRombes("blue", "green");

			//assert
			Assert.That(redWhiteHalfRombes, Is.Not.EqualTo(blueGreenHalfRombes));
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
		public void Honeycomb_differs_on_colour()
		{
			//act
			var redWhiteBlackHoneycomb = PatternGenerator.Honeycomb("red", "white", "black");
			var blueGreenYellowHoneycomb = PatternGenerator.Honeycomb("blue", "green", "yellow");

			//assert
			Assert.That(redWhiteBlackHoneycomb, Is.Not.EqualTo(blueGreenYellowHoneycomb));
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
		public void Horizontal_stripes_differs_on_colour()
		{
			//act
			var redWhiteHorizontalStripes = PatternGenerator.HorizontalStripes("red", "white");
			var blueGreenHorizontalStripes = PatternGenerator.HorizontalStripes("blue", "green");

			//assert
			Assert.That(redWhiteHorizontalStripes, Is.Not.EqualTo(blueGreenHorizontalStripes));
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
		public void Can_get_microbial_mat()
		{
			//act
			var redWhiteMicrobial = PatternGenerator.MicrobialMat("red", "white");

			//assert
			Assert.That(redWhiteMicrobial, Is.EqualTo(_redWhiteMicrobial));
		}

		[Test]
		public void Microbial_mat_differs_on_colour()
		{
			//act
			var redWhiteMicrobial = PatternGenerator.MicrobialMat("red", "white");
			var blueGreenMicrobial = PatternGenerator.MicrobialMat("blue", "green");

			//assert
			Assert.That(redWhiteMicrobial, Is.Not.EqualTo(blueGreenMicrobial));
		}

		[Test]
		public void Microbial_mat_is_base_64()
		{
			//act
			var redWhiteMicrobial = PatternGenerator.MicrobialMat("red", "white");
			bool isBase64 = _base64Regex.IsMatch(redWhiteMicrobial);

			//assert
			Assert.That(isBase64, Is.True);
		}

		[Test]
		public void Can_get_noise()
		{
			//act
			var redNoise = PatternGenerator.Noise("red");

			//assert
			Assert.That(redNoise, Is.EqualTo(_redNoise));
		}

		[Test]
		public void Noise_differs_on_colour()
		{
			//act
			var redNoise = PatternGenerator.Noise("red");
			var blueNoise = PatternGenerator.Noise("blue");

			//assert
			Assert.That(redNoise, Is.Not.EqualTo(blueNoise));
		}

		[Test]
		public void Noise_is_base_64()
		{
			//act
			var redNoise = PatternGenerator.Noise("red");
			bool isBase64 = _base64Regex.IsMatch(redNoise);

			//assert
			Assert.That(isBase64, Is.True);
		}

		[Test]
		public void Can_get_shippo()
		{
			//act
			var redWhiteBlackShippo = PatternGenerator.Shippo("red", "white", "black");

			//assert
			Assert.That(redWhiteBlackShippo, Is.EqualTo(_redWhiteBlackShippo));
		}

		[Test]
		public void Shippo_differs_on_colour()
		{
			//act
			var redWhiteBlackShippo = PatternGenerator.Shippo("red", "white", "black");
			var blueGreenYellowShippo = PatternGenerator.Shippo("blue", "green", "yellow");

			//assert
			Assert.That(redWhiteBlackShippo, Is.Not.EqualTo(blueGreenYellowShippo));
		}

		[Test]
		public void Shippo_is_base_64()
		{
			//act
			var redWhiteBlackShippo = PatternGenerator.Shippo("red", "white", "black");
			bool isBase64 = _base64Regex.IsMatch(redWhiteBlackShippo);

			//assert
			Assert.That(isBase64, Is.True);
		}

		[Test]
		public void Can_get_thin_diagonal_stripes()
		{
			//act
			var redWhiteThinDiagonal = PatternGenerator.ThinDiagonalStripes("red", "white");

			//assert
			Assert.That(redWhiteThinDiagonal, Is.EqualTo(_redWhiteThinDiagonal));
		}

		[Test]
		public void Thin_diagonal_stripes_differs_on_colour()
		{
			//act
			var redWhiteThinDiagonal = PatternGenerator.ThinDiagonalStripes("red", "white");
			var blueGreenThinDiagonal = PatternGenerator.ThinDiagonalStripes("blue", "green");

			//assert
			Assert.That(redWhiteThinDiagonal, Is.Not.EqualTo(blueGreenThinDiagonal));
		}

		[Test]
		public void Thin_diagonal_stripes_is_base_64()
		{
			//act
			var redWhiteThinDiagonal = PatternGenerator.ThinDiagonalStripes("red", "white");
			bool isBase64 = _base64Regex.IsMatch(redWhiteThinDiagonal);

			//assert
			Assert.That(isBase64, Is.True);
		}

		[Test]
		public void Can_get_two_tone_horizontal()
		{
			//act
			var redWhiteBlackTwoTone = PatternGenerator.TwoToneHorizontal("red", "white", "black");

			//assert
			Assert.That(redWhiteBlackTwoTone, Is.EqualTo(_redWhiteBlackTwoTone));
		}

		[Test]
		public void Two_tone_horizontal_differs_on_colour()
		{
			//act
			var redWhiteBlackTwoTone = PatternGenerator.TwoToneHorizontal("red", "white", "black");
			var blueGreenYellowTwoTone = PatternGenerator.TwoToneHorizontal("blue", "green", "yellow");

			//assert
			Assert.That(redWhiteBlackTwoTone, Is.Not.EqualTo(blueGreenYellowTwoTone));
		}

		[Test]
		public void Two_tone_horizontal_is_base_64()
		{
			//act
			var redWhiteBlackTwoTone = PatternGenerator.TwoToneHorizontal("red", "white", "black");
			bool isBase64 = _base64Regex.IsMatch(redWhiteBlackTwoTone);

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
		public void Vertical_stripes_differs_on_colour()
		{
			//act
			var redWhiteVerticalStripes = PatternGenerator.VerticalStripes("red", "white");
			var blueGreenVerticalStripes = PatternGenerator.VerticalStripes("blue", "green");

			//assert
			Assert.That(redWhiteVerticalStripes, Is.Not.EqualTo(blueGreenVerticalStripes));
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

		[Test]
		public void Can_get_waves()
		{
			//act
			var redWhiteWaves = PatternGenerator.Waves("red", "white");

			//assert
			Assert.That(redWhiteWaves, Is.EqualTo(_redWhiteWaves));
		}

		[Test]
		public void Waves_differs_on_colour()
		{
			//act
			var redWhiteWaves = PatternGenerator.Waves("red", "white");
			var blueGreenWaves = PatternGenerator.Waves("blue", "green");

			//assert
			Assert.That(redWhiteWaves, Is.Not.EqualTo(blueGreenWaves));
		}

		[Test]
		public void Waves_is_base_64()
		{
			//act
			var redWhiteWaves = PatternGenerator.Waves("red", "white");
			bool isBase64 = _base64Regex.IsMatch(redWhiteWaves);

			//assert
			Assert.That(isBase64, Is.True);
		}
	}
}
