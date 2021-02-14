using System;
using System.Threading.Tasks;
using Pockit.Core.DTOs;

namespace Pockit.Core.Services.Authorization
{
    /// <summary>
    ///     Describes an authorization service. Implementations of this service are required to handle GitHub's OAuth App
    ///     authorization through web application flow.
    /// </summary>
    public interface IAuthorizationService
    {
        /// <summary>
        ///     Initiates the authorization flow for the given user. If successful, the control is passed on to the
        /// </summary>
        /// <param name="username">The account to use for authorizing the app.</param>
        /// <param name="state">An unguessable, random string used to validate the request.</param>
        /// <param name="callbackUri">The URI GitHub will redirect to once authorization is complete.</param>
        /// <returns>A task for this operation.</returns>
        Task RequestAuthorizationAsync(string username, string state, Uri callbackUri);

        /// <summary>
        ///     The callback method executed once authorization is complete and control is passed back to the caller.
        /// </summary>
        /// <param name="state">
        ///     The state returned by GitHub. You should always make sure this state matches the one provided in a
        ///     call to <see cref="RequestAuthorizationAsync" />.
        /// </param>
        /// <returns>A boolean value indicating the success.</returns>
        Task<bool> CallbackAsync(AccessTokenDTO state);
    }
}