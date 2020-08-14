using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Gitmax.Lib.Http
{
    public sealed class Response
    {
        public Response(HttpStatusCode statusCode, string contentType, string content, IDictionary<string, string> headers) {
            StatusCode = statusCode;
            ContentType = contentType;
            Content = content;
            Headers = headers;
        }

        public string ContentType { get; }
        public string Content { get; }
        public HttpStatusCode StatusCode { get; }
        public IDictionary<string, string> Headers { get; }
    }
}
