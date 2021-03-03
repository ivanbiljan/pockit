using System.Threading.Tasks;
using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using GraphQL.Types;
using Pockit.Core.Models;

namespace Pockit.Core.Services.Users
{
    internal sealed class UserService : IUserService
    {
        private readonly IGraphQLClient _graphClient;

        public UserService(IGraphQLClient graphClient)
        {
            _graphClient = graphClient;
        }

        /// <inheritdoc />
        public async Task<GitHubUser> GetAuthorizedUser()
        {
            const string query = @"
query { 
  viewer { 
    avatarUrl
    bio
    company
    createdAt
    location
    followers {
      totalCount
    }
    following {
      totalCount
    }
    login
    contributionsCollection {
      contributionCalendar {
        totalContributions
      }
    }
  }
}";

            var request = new GraphQLHttpRequest(query);
            var response = await _graphClient.SendQueryAsync(request, () => new {viewer = new GitHubUser()});
            return response.Data.viewer;
        }
    }
}