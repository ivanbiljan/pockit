using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Pockit.Core.Constants;
using Pockit.Core.DTOs;
using Pockit.Core.Helpers;

namespace Pockit.Functions.Functions 
{
    /// <summary>
    /// Represents an Azure function that exchanges temporary codes for GitHub access tokens.
    /// </summary>
    public sealed class ExchangeCodeForAccessToken 
    {
        [FunctionName(nameof(ExchangeCodeForAccessToken))]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)]
            HttpRequest req,
            ILogger log)
        {
            string code = req.Query["code"];
            string state = req.Query["state"];

            var httpClient = new HttpClient(new HttpClientHandler());
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            var response = await httpClient.PostAsync(
                OAuthWebFlowConstants.GetAccessTokenUri(AppConfiguration.GitHubClientId,
                    AppConfiguration.GitHubClientSecret, code), null);
            response.EnsureSuccessStatusCode();

            var contentJsonDocument = JsonDocument.Parse(await response.Content.ReadAsStringAsync());
            var redirectUri = StringHelpers.BuildUri(OAuthWebFlowConstants.CallbackUri,
                new Dictionary<string, string>
                {
                    ["access_token"] = contentJsonDocument.RootElement.GetProperty("access_token").GetString(),
                    ["state"] = state
                });

            return new RedirectResult(redirectUri, true);
        }
    }
}