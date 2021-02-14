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
    }
}