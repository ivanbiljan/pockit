using System;
using System.Collections.Generic;
using System.Text;

namespace Pockit.Core.DTOs 
{
    public sealed class OAuthSecretsDTO 
    {
        public string ClientId { get; }
        public string ClientSecret { get; }

        public OAuthSecretsDTO(string clientId, string clientSecret)
        {
            ClientId = clientId;
            ClientSecret = clientSecret;
        }
    }
}
