using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace Pockit.Core.Models.Pagination
{
    /// <summary>
    /// Defines a contract that describes a connection of type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type this connection hosts.</typeparam>
    public interface IConnection<T>
    {
        /// <summary>
        /// Gets a collection od edge.
        /// </summary>
        ImmutableArray<Edge<T>> Edges { get; }
        
        /// <summary>
        /// Gets a collection of nodes.
        /// </summary>
        ImmutableArray<T> Nodes { get; }
        
        /// <summary>
        /// Gets information used to aid in pagination.
        /// </summary>
        PageInfo PageInfo { get; }
        
        /// <summary>
        /// Gets the total amount of items in the connection.
        /// </summary>
        int TotalCount { get; }
    }
}