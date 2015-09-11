using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace BuxferSharp.Responses
{
    /// <summary>
    /// Report response from Buxfer API.
    /// </summary>
    public class ReportResponse
    {
        /// <summary>
        /// Gets the raw data.
        /// </summary>
        /// <value>
        /// The raw data.
        /// </value>
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Used by RestSharp")]
        [SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists", Justification = "Used by RestSharp")]
        public List<ReportItemResponse> RawData { get; internal set; }
    }
}
