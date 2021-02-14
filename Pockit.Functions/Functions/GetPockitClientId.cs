using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

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