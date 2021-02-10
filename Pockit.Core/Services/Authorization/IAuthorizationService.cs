using System.Threading.Tasks;

namespace Pockit.Core.Services.Authorization 
{
    public interface IAuthorizationService 
    {
        Task RequestUserIdentity(string state, string? usernameHint = null);

        Task<string> ExchangeCodeForAccessToken(string code, string state);
    }
}