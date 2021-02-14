using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Pockit.Core.Services.Authorization;
using Pockit.Functions;

[assembly: FunctionsStartup(typeof(Startup))]

namespace Pockit.Functions
{
    public sealed class Startup : FunctionsStartup
    {
        /// <inheritdoc />
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddSingleton<IAuthorizationService, AuthorizationService>();
        }
    }
}