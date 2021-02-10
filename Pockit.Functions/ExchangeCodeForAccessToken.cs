using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Pockit.Services.Authorization;

namespace Pockit.Functions
{
    public sealed class ExchangeCodeForAccessToken
    {
        private readonly IAuthorizationService _authorizationService;
        
        public ExchangeCodeForAccessToken(IAuthorizationService authorizationService)
        {
            _authorizationService =
                authorizationService ?? throw new ArgumentNullException(nameof(authorizationService));
        }
        
        [FunctionName(nameof(ExchangeCodeForAccessToken))]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)]
            HttpRequest req,
            ILogger log)
        {
            //log.LogInformation("C# HTTP trigger function processed a request.");

            //string name = req.Query["name"];

            //string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            //dynamic data = JsonConvert.DeserializeObject(requestBody);
            //name = name ?? data?.name;

            //string responseMessage = string.IsNullOrEmpty(name)
            //    ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
            //    : $"Hello, {name}. This HTTP triggered function executed successfully.";

            string code = req.Query["code"];
            string state = req.Query["state"];

            await _authorizationService.ExchangeCodeForAccessToken(code, state);

            return new OkObjectResult($"Redirected to {nameof(IAuthorizationService.ExchangeCodeForAccessToken)}");
        }
    }
}