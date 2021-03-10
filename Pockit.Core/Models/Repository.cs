using System;
using System.Collections.Generic;
using System.Text;

namespace Pockit.Core.Models
{
    /// <summary>
    /// Represents a GitHub repository.
    /// </summary>
    public sealed class Repository : Node
    {
        /// <summary>
        /// Gets the <see cref="DateTime"/> object that represents when the repository was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets the number of forks this repository has received.
        /// </summary>
        public int ForkCount { get; set; }

        /// <summary>
        /// Gets a value indicating whether the repository has the Issues feature enabled.
        /// </summary>
        public bool HasIssuesEnabled { get; set; }

        /// <summary>
        /// Gets a value indicating whether the repository is archived.
        /// </summary>
        public bool IsArchived { get; set; }

        /// <summary>
        /// Gets a value indicating whether the repository is empty.
        /// </summary>
        public bool IsEmpty { get; set; }

        /// <summary>
        /// Gets a value indicating whether this repository is a fork of another repository.
        /// </summary>
        public bool IsFork { get; set; }

        /// <summary>
        /// Gets a value indicating whether the repository is private.
        /// </summary>
        public bool IsPrivate { get; set; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets the owner.
        /// </summary>
        public User Owner { get; set; }

        /// <summary>
        /// Gets the parent repository. This property is <see langword="null"/> unless the current repository is a fork.
        /// </summary>
        public Repository? Parent { get; set; }
    }
}