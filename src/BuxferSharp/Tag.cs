using System.Diagnostics;

namespace BuxferSharp
{
    /// <summary>
    /// A tag is a short description of a transaction, which lets you categorize your expenses in a flexible manner.
    /// </summary>
    [DebuggerDisplay("{Name}")]
    public class Tag : EntityBase
    {
        #region Properties
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the parent tag identifier.
        /// </summary>
        /// <value>
        /// The parent identifier.
        /// </value>
        public string ParentId { get; set; }
        #endregion
    }
}
