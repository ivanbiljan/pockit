using System;
using System.Collections.Generic;
using System.Text;

namespace Pockit.Core.Models
{
    /// <summary>
    /// Represents a language found in a repository.
    /// </summary>
    public sealed class Language
    {
        /// <summary>
        /// Gets the color defined for the language.
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name { get; set; }
    }
}
