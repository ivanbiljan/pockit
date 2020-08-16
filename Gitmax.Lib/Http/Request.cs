#nullable enable

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Gitmax.Lib.Http
{
    /// <summary>
    /// Describes an HTTP request.
    /// </summary>
    public sealed class Request
    {
        public Request(HttpMethod httpMethod, Uri uri) : this(httpMethod, uri, null)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Request"/> class with the specified HTTP method, request body, and headers.
        /// </summary>
        /// <param name="httpMethod">The HTTP method.</param>
        /// <param name="body"></param>
        /// <param name="headers"></param>
        public Request(HttpMethod httpMethod, Uri uri, object? body)
        {
            HttpMethod = httpMethod;
            Uri = uri;
            Body = body;
            //Headers = headers;
        }

        public HttpMethod HttpMethod { get; }
        public Uri Uri { get; }
        public object? Body { get; }
        public IDictionary<string, string> Headers { get; set; } = new Dictionary<string, string>();
        public IDictionary<string, string> PathParameters { get; set; } = new Dictionary<string, string>();
    }
}
