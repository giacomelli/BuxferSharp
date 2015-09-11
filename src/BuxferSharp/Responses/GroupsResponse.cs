using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace BuxferSharp.Responses
{
    /// <summary>
    /// Groups response from Buxfer API.
    /// </summary>
    public class GroupsResponse : SuccessResponseBase
    {
        /// <summary>
        /// Gets the groups.
        /// </summary>
        /// <value>
        /// The groups.
        /// </value>
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Used by RestSharp")]
        [SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists", Justification = "Used by RestSharp")]
        public List<Group> Groups { get; internal set; }
    }
}
