﻿using System;
using System.Collections.Generic;

namespace Pockit.Core.Models
{
    /// <summary>
    ///     Represents an account on GitHub.
    /// </summary>
    public sealed class GitHubUser
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
        public SocialConnection Followers { get; set; }

        /// <summary>
        ///     Gets the following connection.
        /// </summary>
        public SocialConnection Following { get; set; }

        /// <summary>
        ///     Gets the username used to login.
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Gets the number of contributions in the past year.
        /// </summary>
        public int TotalContributions { get; set; }
        
        /// <summary>
        /// Gets the user's location.
        /// </summary>
        public string Location { get; set; }
    }

    /// <summary>
    ///     Represents a social connection for a GitHub account.
    /// </summary>
    public sealed class SocialConnection
    {
        public List<GitHubUser> Nodes { get; set; }

        public int TotalCount { get; set; }
    }
}