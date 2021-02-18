using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Pockit.Core.DTOs 
{
    public sealed class GitHubUser 
    {
        [JsonPropertyName("login")]
        public string Login { get; set; }
        
        [JsonPropertyName("avatar_url")]
        public string AvatarUrl { get; set; }
        
        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        [JsonPropertyName("company")]
        public string Company { get; set; }
        
        [JsonPropertyName("location")]
        public string Location { get; set; }
        
        [JsonPropertyName("email")]
        public string Email { get; set; }
        
        [JsonPropertyName("bio")]
        public string Bio { get; set; }
        
        [JsonPropertyName("followers")]
        public int Followers { get; set; }
        
        [JsonPropertyName("following")]
        public int Following { get; set; }
    }
}
