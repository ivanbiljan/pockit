using System.Threading.Tasks;
using Pockit.Core.Models;

namespace Pockit.Core.Services.Users
{
    public interface IUserService
    {
        Task<GitHubUser> GetAuthorizedUser();
    }
}