using System;
using System.Collections.Generic;
using Pockit.Core.Helpers;
using Xunit;

namespace Pockit.Core.Tests.Helpers
{
    public sealed class StringHelpersTests
    {
        [Fact]
        public void BuildUri_NoPresetParameters_ReturnsValidUri()
        {
            var baseUri = "pockit://callback";
            var parameters = new Dictionary<string, string>
            {
                ["access_token"] = "test",
                ["state"] = "ABCDE!()"
            };

            var builtUri = StringHelpers.BuildUri(baseUri, parameters);

            Assert.Equal("pockit://callback?access_token=test&state=ABCDE!()", builtUri);
        }

        [Fact]
        public void BuildUri_NullQueryParameters_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => StringHelpers.BuildUri("google.com", null!));
        }

        [Fact]
        public void BuildUri_NullUri_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => StringHelpers.BuildUri(null, new Dictionary<string, string>()));
        }

        [Fact]
        public void BuildUri_WithPresetParameters_CollidingParametersDoNotGetOverwritten()
        {
            var baseUri = "pockit://callback?access_token=test";
            var parameters = new Dictionary<string, string>
            {
                ["access_token"] = "newtoken",
                ["state"] = "ABCDE!()"
            };

            var builtUri = StringHelpers.BuildUri(baseUri, parameters);

            Assert.Equal("pockit://callback?access_token=test&state=ABCDE!()", builtUri);
        }

        [Fact]
        public void BuildUri_WithPresetParameters_NewParametersAreAppended()
        {
            var baseUri = "pockit://callback?access_token=test";
            var parameters = new Dictionary<string, string>
            {
                ["state"] = "ABCDE!()"
            };

            var builtUri = StringHelpers.BuildUri(baseUri, parameters);

            Assert.Equal("pockit://callback?access_token=test&state=ABCDE!()", builtUri);
        }

        [Theory]
        [InlineData(1, "1")]
        [InlineData(17, "17")]
        [InlineData(123, "123")]
        [InlineData(1000, "1K")]
        [InlineData(9570, "9,6K")]
        [InlineData(8023, "8K")]
        [InlineData(12345, "12,3K")]
        [InlineData(123456, "123K")]
        [InlineData(1234567, "1,2M")]
        [InlineData(1000000, "1M")]
        [InlineData(1000000000, "1B")]
        [InlineData(1234567890000, "1,2e12")]
        public void ToAbbreviatedString_IsCorrect(ulong number, string expectedAbbreviation)
        {
            var abbreviatedString = StringHelpers.ToAbbreviatedString(number);

            Assert.Equal(expectedAbbreviation, abbreviatedString);
        }
    }
}