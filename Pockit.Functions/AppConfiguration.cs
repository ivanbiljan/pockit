using System;
using System.Collections.Generic;
using System.Text;

namespace Pockit.Functions 
{
    public static class AppConfiguration
    {
        public static readonly string GitHubClientId = Environment.GetEnvironmentVariable("CLIENT_ID");

        public static readonly string GitHubClientSecret = Environment.GetEnvironmentVariable("CLIENT_SECRET");
    }
}
