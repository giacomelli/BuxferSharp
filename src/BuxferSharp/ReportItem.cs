using System.Diagnostics;

namespace BuxferSharp
{
    /// <summary>
    /// Represents a report item.
    /// </summary>
    [DebuggerDisplay("{Tag.Name}: {Amount}")]
    public class ReportItem
    {
        #region Properties
        /// <summary>
        /// Gets or sets the tag.
        /// </summary>
        /// <value>
        /// The tag.
        /// </value>
        public Tag Tag { get; set; }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        public decimal Amount { get; set; }
        #endregion
    }
}
