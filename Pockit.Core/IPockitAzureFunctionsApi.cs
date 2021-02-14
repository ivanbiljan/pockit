using System.Threading.Tasks;
using Refit;

namespace Pockit.Core
{
    public interface IPockitAzureFunctionsApi
    {
        [Get("/GetPockitClientId")]
        Task<string> GetPockitClientIdAsync();
    }
}