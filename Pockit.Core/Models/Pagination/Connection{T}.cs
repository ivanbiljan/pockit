using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace Pockit.Core.Models.Pagination
{
    /// <summary>
    /// Represents a connection of type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type this connection hosts.</typeparam>
    public sealed class Connection<T>
    {
        /// <summary>
        /// Gets a collection od edge.
        /// </summary>
        public ImmutableArray<Edge<T>> Edges { get; set; }
        
        /// <summary>
        /// Gets a collection of nodes.
        /// </summary>
        public ImmutableArray<T> Nodes { get; set; }
        
        /// <summary>
        /// Gets information used to aid in pagination.
        /// </summary>
        public PageInfo PageInfo { get; set; }
        
        /// <summary>
        /// Gets the total amount of items in the connection.
        /// </summary>
        public int TotalCount { get; set; }
    }
}