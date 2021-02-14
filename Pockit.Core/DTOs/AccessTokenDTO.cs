using System;
using System.Collections.Generic;
using System.Text;

namespace Pockit.Core.DTOs 
{
    public sealed class AccessTokenDTO
    {
        public string AccessToken { get; }
        public string State { get; }

        public AccessTokenDTO(string accessToken, string state)
        {
            AccessToken = accessToken;
            State = state;
        }
    }
}
