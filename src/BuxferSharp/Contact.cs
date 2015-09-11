using System.Diagnostics;

namespace BuxferSharp
{
    /// <summary>
    /// Represents a contact.
    /// </summary>
    [DebuggerDisplay("{Name} {Email}: {Balance}")]
    public class Contact : EntityBase
    {
        #region Properties
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the balance.
        /// </summary>
        /// <value>
        /// The balance.
        /// </value>
        public decimal Balance { get; set; }
        #endregion
    }
}
