#nullable enable

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Gitmax.Lib.Exceptions;
using Gitmax.Lib.Extensions;
using Newtonsoft.Json;

namespace Gitmax.Lib.Http
{
    public sealed class ApiConnection {
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

        public async Task<Response> GetResponseAsync(Request request, bool throwOnFailure = false) {
            var queryParameters = new Dictionary<string, string>();
            var existingParameters = HttpUtility.ParseQueryString(request.Uri.Query);
            for (var i = 0; i < existingParameters.Count; ++i) {
                queryParameters.Add(existingParameters.GetKey(i), existingParameters.Get(i));
            }

            foreach (var (param, value) in request.PathParameters) {
                queryParameters[param] = value; // Override any existing parameters
            }

            var uriBuilder = new UriBuilder(request.Uri) { Query = string.Join("&", queryParameters.Select(kvp => $"{kvp.Key}={kvp.Value}")) };
            var requestMessage = new HttpRequestMessage(request.HttpMethod, uriBuilder.Uri);
            foreach (var (header, value) in request.Headers) {
                requestMessage.Headers.Add(header, value);
            }

            requestMessage.Content = request.Body switch {
                Stream stream => new StreamContent(stream),
                _ => new StringContent(request.Body?.ToString() ?? "", Encoding.UTF8, "applicaton/json")
            };

            var responseMessage = await HttpClient.SendAsync(requestMessage, HttpCompletionOption.ResponseContentRead);
            var content = await responseMessage.Content.ReadAsStringAsync();
            if (!responseMessage.IsSuccessStatusCode && throwOnFailure) {
                // TODO: does GitHub always return a response?
                var apiResponse = JsonConvert.DeserializeObject<ErrorResponse>(content);
                throw new ApiErrorException(responseMessage.StatusCode, apiResponse);
            }

            var headers = responseMessage.Headers.ToDictionary(kvp => kvp.Key, kvp => string.Join(";", kvp.Value));
            var response = new Response(responseMessage.StatusCode, headers["Content-Type"], content, headers);
            return response;
        }
    }
}