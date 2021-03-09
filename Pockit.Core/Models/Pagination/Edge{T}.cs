using System;
using System.Collections.Generic;
using System.Text;

namespace Pockit.Core.Models.Pagination
{
    /// <summary>
    /// Describes an edge of type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type this edge hosts.</typeparam>
    public abstract class Edge<T>
    {
        /// <summary>
        /// The type at the end of the edge.
        /// </summary>
        public T? Node { get; }

        /// <summary>
        /// A cursor for use in pagination.
        /// </summary>
        public string Cursor { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Edge{T}"/> class.
        /// </summary>
        /// <param name="node">The node at the end of the edge.</param>
        /// <param name="cursor">A cursor for use in pagination.</param>
        protected Edge(T? node, string cursor)
        {
            Node = node;
            Cursor = cursor;
        }
    }
}