using Gitmax.Lib.Http;
using Gitmax.Lib.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gitmax.Lib.Modules {
    public sealed class UserModule : GitHubModule {
        public UserModule(ApiConnection apiConnection) : base(apiConnection) {
        }

        public async Task<Account> GetAuthenticatedAccountAsync() {
            return await _apiConnection.GetAsync<Account>(GitHubEndpoints.GetAuthenticatedUser);
        }
    }
}
