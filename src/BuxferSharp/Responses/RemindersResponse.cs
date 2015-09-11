using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace BuxferSharp.Responses
{
    /// <summary>
    /// Reminders response from Buxfer API.
    /// </summary>
    public class RemindersResponse : SuccessResponseBase
    {
        /// <summary>
        /// Gets the reminders.
        /// </summary>
        /// <value>
        /// The reminders.
        /// </value>
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Used by RestSharp")]
        [SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists", Justification = "Used by RestSharp")]
        public List<Reminder> Reminders { get; internal set; }
    }
}
