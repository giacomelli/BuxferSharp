using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace BuxferSharp
{
    /// <summary>
    /// Represents a report.
    /// </summary>
    public class Report
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Report"/> class.
        /// </summary>
        public Report()
        {
            Items = new List<ReportItem>();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the items.
        /// </summary>
        /// <value>
        /// The items.
        /// </value>
        [SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists", Justification = "Used by RestSharp")]
        public List<ReportItem> Items { get; internal set; }
        #endregion
    }
}
