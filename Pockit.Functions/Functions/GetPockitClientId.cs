using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Pockit.Core.Constants;
using Pockit.Core.DTOs;
using System.Text.Json;

namespace Pockit.Functions.Functions 
{
    public sealed class GetPockitClientId
    {
        [FunctionName(nameof(GetPockitClientId))]
        public async Task<string> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)]
            HttpRequest req,
            ILogger log)
        {
            return AppConfiguration.GitHubClientId;
        }
    }
}
