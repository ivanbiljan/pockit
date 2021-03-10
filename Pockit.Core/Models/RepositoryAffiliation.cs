using System;
using System.Collections.Generic;
using System.Text;

namespace Pockit.Core.Models
{
    /// <summary>
    /// Specifies a user's affiliation to a repository.
    /// </summary>
    public enum RepositoryAffiliation
    {
        /// <summary>
        /// Indicates that the user is a collaborator.
        /// </summary>
        Collaborator,

        /// <summary>
        /// Indicates that the user has access to a repository through being a member of an owner organization.
        /// </summary>
        OrganizationMember,

        /// <summary>
        /// Indicates that the repository is owned by the authenticated user.
        /// </summary>
        Owner
    }
}