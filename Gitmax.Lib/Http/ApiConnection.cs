using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Gitmax.Lib.Http
{
    public sealed class ApiConnection
    {
        private static readonly HttpClient HttpClient;

        static ApiConnection() {
            HttpClient = new HttpClient {
                BaseAddress = new Uri("https://api.github.com"),
                DefaultRequestHeaders = {
                    Accept = {new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json")},
                    CacheControl = {
                        MaxStale = true,
                        MaxStaleLimit = new TimeSpan(0, 1, 0, 0, 0)
                    }
                }
            };
        }

        public async Task<Response> GetResponseAsync(Request request) {
            var queryParameters = new Dictionary<string, string>();

            return null;
        }
    }
}
