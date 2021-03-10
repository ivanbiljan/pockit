using System.Threading.Tasks;
using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using GraphQL.Types;
using Pockit.Core.Models;

namespace Pockit.Core.Services.Users
{
    internal sealed class UserService : IUserService
    {
        private static string GetProfileInfoQuery(string username = null) => @$"
query {{ 
  {(username is null ? "viewer" : $"user(login: \"{username}\"")} {{
    avatarUrl
    bio
    company
    createdAt
    location
    followers {{
      totalCount
    }}
    following {{
      totalCount
    }}
    name
    login
    contributionsCollection {{
      contributionCalendar {{
        totalContributions
      }}
    }}
  }}
}}";

        private readonly IGraphQLClient _graphClient;

        public UserService(IGraphQLClient graphClient)
        {
            _graphClient = graphClient;
        }

        /// <inheritdoc />
        public async Task<User> GetProfileInformation(string? username = null)
        {
            var request = new GraphQLHttpRequest(GetProfileInfoQuery(username));
            var response = await _graphClient.SendQueryAsync(request, () => new {viewer = new User()});
            return response.Data.viewer;
        }
    }
}