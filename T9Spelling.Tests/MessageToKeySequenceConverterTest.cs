using System;
using Xunit;

namespace T9Spelling.Tests
{
	public class MessageToKeySequenceConverterTest
	{
		[Fact]
		public void ConvertReturnsEmptyStringIfInputIsEmptySting()
		{
			Assert.Equal("", new MessageToKeySequenceConverter().Convert(""));
		}
		
		[Fact]
		public void ConvertThrowsExceptionIfInputIsNotText()
		{
			Assert.Throws<Exception>(() => new MessageToKeySequenceConverter().Convert("999"));
		}

		public void ConvertReturnsZeroIfInputIsWhitespace()
		{
			Assert.Equal("0", new MessageToKeySequenceConverter().Convert(" "));
		}

		public void ConvertReturnsWhitespaceForSameCharacters()
		{
			Assert.Equal("2 2", new MessageToKeySequenceConverter().Convert("aa"));
		}

		public void ConvertReturnsWhitespaceForCharactersOnSameKey()
		{
			Assert.Equal("2 22", new MessageToKeySequenceConverter().Convert("ab"));
		}

		public void ConvertReturnsValidResultsForOtherMessages()
		{
			var converter = new MessageToKeySequenceConverter();

			Assert.Equal("2", converter.Convert("a"));
			Assert.Equal("22", converter.Convert("b"));

			Assert.Equal("02", converter.Convert(" a"));
			Assert.Equal("0 02", converter.Convert("  a"));

			Assert.Equal("20 022 220 0222 222 222", converter.Convert("a  bb  ccc"));

			Assert.Equal("443 3776633877 7388999 9999666335 55569996555333888555 5534", converter.Convert("hddqnetqpduyzoejlmymlfvlkdg"));
			Assert.Equal("5598666 62226663993337799889999222555 55 55444077742224 4666 66997 733366444885544999", converter.Convert("kwtomcodxfqxuzclkki rgcggonxppfniukhy"));
		}
    }
}
