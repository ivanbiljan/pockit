using Gitmax.Lib.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gitmax.Lib.Modules
{
    /// <summary>
    /// Represents a GitHub module.
    /// </summary>
    public abstract class GitHubModule
    {
        private protected readonly ApiConnection _apiConnection;
        protected GitHubModule(ApiConnection apiConnection) {
            _apiConnection = apiConnection ?? throw new ArgumentNullException(nameof(apiConnection));
        }
    }
}
