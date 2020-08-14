using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gitmax.Lib.Exceptions {
    public sealed class ErrorResponse {
        [JsonProperty("message")]
        public string Message { get; private set; }

        [JsonProperty("documentation_url")]
        public string DocumentationUrl { get; private set; }
    }

    public sealed class ApiErrorException : Exception {
        public ApiErrorException(ErrorResponse response) : base(response.Message) {
            Response = response;
        }

        public ErrorResponse Response { get; }
    }
}
