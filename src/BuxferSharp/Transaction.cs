using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using RestSharp.Deserializers;

namespace BuxferSharp
{
    #region Enums
    /// <summary>
    /// Transaction types.
    /// </summary>
    public enum TransactionType
    {
        /// <summary>
        /// An expense.
        /// </summary>
        Expense,

        /// <summary>
        /// An income.
        /// </summary>
        Income,

        /// <summary>
        /// A transfer.
        /// </summary>
        Transfer,

        /// <summary>
        /// A refund.
        /// </summary>
        Refund,

        /// <summary>
        /// A paid for friend.
        /// </summary>
        PaidForFriend,

        /// <summary>
        /// A shared bill.
        /// </summary>
        SharedBill,

        /// <summary>
        /// A loan.
        /// </summary>
        Loan,

        /// <summary>
        /// A settlement.
        /// </summary>
        Settlement
    }

    /// <summary>
    /// Transaction status.
    /// </summary>
    public enum TransactionStatus
    {
        /// <summary>
        /// Cleared status.
        /// </summary>
        Cleared,

        /// <summary>
        /// Reconciled status.
        /// </summary>
        Reconciled,

        /// <summary>
        /// pending status.
        /// </summary>
        Pending
    }
    #endregion

    /// <summary>
    /// Represents a transaction.
    /// </summary>
    [DebuggerDisplay("{Description}. {Type}: {Amount} in {Date} ({Tags})")]
    public class Transaction : EntityBase
    {
        #region Properties
        /// <summary>
        /// Gets or sets the account identifier.
        /// </summary>
        /// <value>
        /// The account identifier.
        /// </value>
        public string AccountId { get; set; }

        /// <summary>
        /// Gets or sets the name of the account.
        /// </summary>
        /// <value>
        /// The name of the account.
        /// </value>
        public string AccountName { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        /// <value>
        /// The date.
        /// </value>
        [DeserializeAs(Name = "NormalizedDate")]
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        [SuppressMessage("Microsoft.Naming", "CA1721:PropertyNamesShouldNotMatchGetMethods")]
        public TransactionType Type { get; set; }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the tag names.
        /// </summary>
        /// <value>
        /// The tag names.
        /// </value>
        //// TODO: transformar numa lista?
        public string TagNames { get; set; }

        /// <summary>
        /// Gets or sets the extra information.
        /// </summary>
        /// <value>
        /// The extra information.
        /// </value>
        public string ExtraInfo { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public TransactionStatus Status { get; set; }
        #endregion
    }
}
