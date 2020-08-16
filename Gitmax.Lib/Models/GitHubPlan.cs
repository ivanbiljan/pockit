using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gitmax.Lib.Models {
    public sealed class GitHubPlan {
        [JsonProperty("name")]
        public string Name { get; private set; }

        [JsonProperty("space")]
        public int Space { get; private set; }

        [JsonProperty("collaborators")]
        public int CollaboratorCount { get; private set; }

        [JsonProperty("private_repos")]
        public int PrivateRepositoryCount { get; private set; }
    }
}
