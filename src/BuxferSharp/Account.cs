using System;
using System.Diagnostics;

namespace BuxferSharp
{
    /// <summary>
    /// An account represents a real-life financial account you may own at a bank or credit card institution.
    /// </summary>
    [DebuggerDisplay("{Name}: {Balance}")]
    public class Account : EntityBase
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the bank.
        /// </summary>
        /// <value>
        /// The bank.
        /// </value>
        public string Bank { get; set; }

        /// <summary>
        /// Gets or sets the balance.
        /// </summary>
        /// <value>
        /// The balance.
        /// </value>
        public decimal Balance { get; set; }

        /// <summary>
        /// Gets or sets the currency.
        /// </summary>
        /// <value>
        /// The currency.
        /// </value>
        public string Currency { get; set; }

        /// <summary>
        /// Gets or sets the last synced.
        /// </summary>
        /// <value>
        /// The last synced.
        /// </value>
        public DateTime? LastSynced { get; set; }
    }
}
