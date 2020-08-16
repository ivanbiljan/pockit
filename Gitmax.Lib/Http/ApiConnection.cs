#nullable enable

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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
        private readonly string _authToken;

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

        public ApiConnection(string authenticationToken) {
            _authToken = authenticationToken;
        }

        public async Task<T> GetAsync<T>(Uri uri) {
            //var request = CreateRequest(HttpMethod.Get, uri);
            var response = await GetResponseAsync(HttpMethod.Get, uri, null, null, null);
            return DeserializeObject<T>(response);
        }

        private static T DeserializeObject<T>(Response response) {
            if (!response.ContentType.Equals("application/json", StringComparison.InvariantCultureIgnoreCase)) {
                return (T)typeof(T).GetDefaultValue();
            }

            return JsonConvert.DeserializeObject<T>(response.Content);
        }

        //private static Request CreateRequest(HttpMethod httpMethod, Uri uri, object? body = null, IDictionary<string, string>? pathParameters = null, IDictionary<string, string>? headers = null) {
        //    return new Request(httpMethod, uri, body) {
        //        PathParameters = pathParameters ?? new Dictionary<string, string>(),
        //        Headers = headers ?? new Dictionary<string, string>()
        //    };
        //}

        private async Task<Response> GetResponseAsync(HttpMethod httpMethod, Uri uri, object? body, IDictionary<string, string>? pathParameters, IDictionary<string, string>? headers, bool throwOnFailure = false) {
            var queryParameters = new Dictionary<string, string>();
            var existingParameters = HttpUtility.ParseQueryString(uri.Query);
            for (var i = 0; i < existingParameters.Count; ++i) {
                queryParameters.Add(existingParameters.GetKey(i), existingParameters.Get(i));
            }

            if (pathParameters != null) {
                foreach ((string param, string value) in pathParameters) {
                    queryParameters[param] = value; // Override any existing parameters
                }
            }

            var uriBuilder = new UriBuilder(uri) { Query = string.Join("&", queryParameters.Select(kvp => $"{kvp.Key}={kvp.Value}")) };
            var requestMessage = new HttpRequestMessage(httpMethod, uri);

            if (headers != null) {
                foreach ((string header, string value) in headers) {
                    requestMessage.Headers.Add(header, value);
                }
            }

            if (body != null) {
                requestMessage.Content = body switch
                {
                    Stream stream => new StreamContent(stream),
                    //object obj => new StringContent(JsonConvert.SerializeObject(request.Body), Encoding.UTF8, "application/json"),
                    //_ => new StringContent(body.ToString(), Encoding.UTF8, "applicaton/json")
                    _ => new StringContent(body as string ?? JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json")
                };
            }

            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Token", _authToken);
            var responseMessage = await HttpClient.SendAsync(requestMessage, HttpCompletionOption.ResponseContentRead);
            var content = await responseMessage.Content.ReadAsStringAsync();
            if (!responseMessage.IsSuccessStatusCode && throwOnFailure) {
                // TODO: does GitHub always return a response?
                var apiResponse = JsonConvert.DeserializeObject<ErrorResponse>(content);
                throw new ApiErrorException(responseMessage.StatusCode, apiResponse);
            }

            var responseHeaders = responseMessage.Headers.ToDictionary(kvp => kvp.Key, kvp => string.Join(";", kvp.Value));
            var response = new Response(responseMessage.StatusCode, responseHeaders["Content-Type"], content, responseHeaders);
            return response;
        }
    }
}