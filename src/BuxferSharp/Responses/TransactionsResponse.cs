using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace BuxferSharp.Responses
{
    /// <summary>
    /// Transactions response from Buxfer API.
    /// </summary>
    public class TransactionsResponse : SuccessResponseBase
    {
        /// <summary>
        /// Gets or sets the number transactions.
        /// </summary>
        /// <value>
        /// The number transactions.
        /// </value>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Num")]
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "NumTransactions")]
        public int NumTransactions { get; set; }

        /// <summary>
        /// Gets the transactions.
        /// </summary>
        /// <value>
        /// The transactions.
        /// </value>
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Used by RestSharp")]
        [SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists", Justification = "Used by RestSharp")]
        public List<Transaction> Transactions { get; internal set; }
    }
}
