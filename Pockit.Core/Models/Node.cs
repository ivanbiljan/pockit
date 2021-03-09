using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Pockit.Core.Models
{
    /// <summary>
    /// Describes an object with an ID.
    /// </summary>
    public abstract class Node
    {
        /// <summary>
        /// Gets the ID.
        /// </summary>
        public string Id { get; }
    }
}
