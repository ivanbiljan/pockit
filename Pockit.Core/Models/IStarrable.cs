using System;
using System.Collections.Generic;
using System.Text;

namespace Pockit.Core.Models
{
    /// <summary>
    /// Defines a contract that describes an object that can be starred by the user (e.g repositories).
    /// </summary>
    public interface IStarrable
    {
        /// <summary>
        /// Gets the number of stars this object has received.
        /// </summary>
        int StargazerCount { get; }
    }
}
