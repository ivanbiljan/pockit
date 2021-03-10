using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pockit.Core.Models.Pagination;

namespace Pockit.Core.Models
{
    /// <summary>
    ///     Represents an account on GitHub.
    /// </summary>
    public sealed class User
    {
        /// <summary>
        ///     Gets the URI of the user's public avatar.
        /// </summary>
        public Uri AvatarUrl { get; set; }

        /// <summary>
        ///     Gets the bio.
        /// </summary>
        public string? Bio { get; set; }

        /// <summary>
        ///     Gets the company.
        /// </summary>
        public string? Company { get; set; }

        /// <summary>
        ///     Gets the registration date.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        ///     Gets the email.
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        ///     Gets the followers connection.
        /// </summary>
        public IConnection<User> Followers { get; set; }

        /// <summary>
        ///     Gets the following connection.
        /// </summary>
        public SocialConnection Following { get; set; }

        /// <summary>
        ///     Gets the username used to login.
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Gets the user's contributions. This object aggregates issue, commit and pull request contributions.
        /// </summary>
        [JsonPropertyName("contributionsCollection")]
        public ContributionsCollection Contributions { get; set; }
        
        /// <summary>
        /// Gets the user's location.
        /// </summary>
        public string Location { get; set; }
        
        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name { get; set; }
    }

    /// <summary>
    ///     Represents a social connection for a GitHub account.
    /// </summary>
    public sealed class SocialConnection
    {
        public List<User> Nodes { get; set; }

        public int TotalCount { get; set; }
    }

    public sealed class ContributionsCollection
    {
        public ContributionCalendar ContributionCalendar { get; set; }
    }

    public sealed class ContributionCalendar
    {
        public int TotalContributions { get; set; }
    }
}