using System;
using System.Collections.Generic;
using System.Text;

namespace Gitmax.Lib.Http {
    internal static class GitHubEndpoints {
        public static Uri GetAuthenticatedUser => RelativeUri("/user");

        private static Uri RelativeUri(string uriString) => new Uri(uriString, UriKind.Relative);
    }
}
