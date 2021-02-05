using Gitmax.Lib.Http;
using Gitmax.Lib.Modules;
using System;
using System.Resources;

namespace Gitmax.Lib
{
    public sealed class GitHubClient {
        private readonly Lazy<UserModule> _userModule;

        public GitHubClient(string authenticationToken) {
            var apiConnection = new ApiConnection(authenticationToken);

            _userModule = new Lazy<UserModule>(() => new UserModule(apiConnection));
        }

        public UserModule Users => _userModule.Value;
    }
}
