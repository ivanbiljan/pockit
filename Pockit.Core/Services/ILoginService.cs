﻿namespace Pockit.Core.Services
{
    /// <summary>
    ///     Represents a contract that describes a login service.
    /// </summary>
    public interface ILoginService
    {
        /// <summary>
        ///     Returns a value indicating whether login information is present on the device. If so, the associated
        ///     <paramref name="accessToken" /> is returned.
        /// </summary>
        /// <param name="accessToken">The access token. Defaults to <see langword="null" /> if no login information is present.</param>
        /// <returns>A value indicating whether login information is present on the device.</returns>
        bool TryGetLogin(out string? accessToken);
    }
}