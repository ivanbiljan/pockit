using System;
using System.Collections.Generic;
using System.Text;

namespace Pockit.Core.Models.Pagination
{
    /// <summary>
    /// Provides information about a page in a paginated result.
    /// </summary>
    public sealed class PageInfo
    {
        /// <summary>
        /// The cursor to continue when paginating forwards.
        /// </summary>
        public string StartCursor { get; }
        
        /// <summary>
        /// The cursor to continue when paginating backwards.
        /// </summary>
        public string EndCursor { get; }
        
        /// <summary>
        /// Gets a value indicating whether the user can go forwards.
        /// </summary>
        public bool HasNextPage { get; }
        
        /// <summary>
        /// Gets a value indicating whether the user can go backwards.
        /// </summary>
        public bool HasPreviousPage { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PageInfo"/> class.
        /// </summary>
        /// <param name="startCursor">The start cursor.</param>
        /// <param name="endCursor">The end cursor.</param>
        /// <param name="hasNextPage">A value indicating whether the user can go forwards.</param>
        /// <param name="hasPreviousPage">A value indicating whether the user can go backwards.</param>
        public PageInfo(string startCursor, string endCursor, bool hasNextPage, bool hasPreviousPage)
        {
            StartCursor = startCursor;
            EndCursor = endCursor;
            HasNextPage = hasNextPage;
            HasPreviousPage = hasPreviousPage;
        }
    }
}