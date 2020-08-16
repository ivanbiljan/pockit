using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gitmax.Lib.Models {
    public sealed class Account {
        [JsonProperty("name")]
        public string Name { get; private set; }

        [JsonProperty("node_id")]
        public string NodeId { get; private set; }

        [JsonProperty("login")]
        public string Username { get; private set; }

        [JsonProperty("company")]
        public string Company { get; private set; }

        [JsonProperty("location")]
        public string Location { get; private set; }

        [JsonProperty("email")]
        public string Email { get; private set; }

        [JsonProperty("bio")]
        public string Bio { get; private set; }

        [JsonProperty("followers")]
        public int FollowerCount { get; private set; }

        [JsonProperty("following")]
        public int FollowingCount { get; private set; }

        [JsonProperty("type")]
        public AccountType Type { get; private set; }
    }
}
