using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace BuxferSharp
{
    #region Enums
    /// <summary>
    /// Loan types.
    /// </summary>
    public enum LoanType
    {
        /// <summary>
        /// The contact type.
        /// </summary>
        Contact,

        /// <summary>
        /// The group type.
        /// </summary>
        Group
    }
    #endregion

    /// <summary>
    /// Represents a loan.
    /// </summary>
    [DebuggerDisplay("{Entity} ({Type}): {Description} {Balance}")]
    public class Loan
    {
        /// <summary>
        /// Gets or sets the entity.
        /// </summary>
        /// <value>
        /// The entity.
        /// </value>
        public string Entity { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        [SuppressMessage("Microsoft.Naming", "CA1721:PropertyNamesShouldNotMatchGetMethods")]
        public LoanType Type { get; set; }

        /// <summary>
        /// Gets or sets the balance.
        /// </summary>
        /// <value>
        /// The balance.
        /// </value>
        public decimal Balance { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }
    }
}
