using System;
using System.Collections.Generic;
using System.Text;

namespace Pockit.Core.Models.Pagination
{
    /// <summary>
    /// Describes an edge of type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type this edge hosts.</typeparam>
    public sealed class Edge<T>
    {
        /// <summary>
        /// The type at the end of the edge.
        /// </summary>
        public T? Node { get; set; }

        /// <summary>
        /// A cursor for use in pagination.
        /// </summary>
        public string Cursor { get; set; }
    }
}