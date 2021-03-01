using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Pockit.Core.Models;
using Refit;

namespace Pockit.Core
{
    public interface IGitHubApi
    {
        [Get("/user")]
        Task<GitHubUser> GetAuthenticatedUser();
    }
}