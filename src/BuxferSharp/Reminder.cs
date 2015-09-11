using System;
using System.Diagnostics;

namespace BuxferSharp
{
    /// <summary>
    /// Represents a transaction reminder.
    /// </summary>
    [DebuggerDisplay("{Description}: {Amount} {Period}")]
    public class Reminder : EntityBase
    {
        #region Properties
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        /// <value>
        /// The start date.
        /// </value>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or sets the notification time.
        /// </summary>
        /// <value>
        /// The notification time.
        /// </value>
        public TimeSpan? NotificationTime { get; set; }

        /// <summary>
        /// Gets or sets the period.
        /// </summary>
        /// <value>
        /// The period.
        /// </value>
        public string Period { get; set; }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the account identifier.
        /// </summary>
        /// <value>
        /// The account identifier.
        /// </value>
        public string AccountId { get; set; }
        #endregion
    }
}
