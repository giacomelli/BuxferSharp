using System.Diagnostics;

namespace BuxferSharp
{
    /// <summary>
    /// Budgets let you control your expenses and plan your savings. 
    /// You can set weekly, monthly and yearly limits on specific expense categories, and receive alerts whenever you exceed those limits.
    /// </summary>
    [DebuggerDisplay("{Name}: {Limit} - {Spent} = {Balance}")]
    public class Budget : EntityBase
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the tag identifier.
        /// </summary>
        /// <value>
        /// The tag identifier.
        /// </value>
        public string TagId { get; set; }

        /// <summary>
        /// Gets or sets the limit.
        /// </summary>
        /// <value>
        /// The limit.
        /// </value>
        public decimal Limit { get; set; }

        /// <summary>
        /// Gets or sets the spent.
        /// </summary>
        /// <value>
        /// The spent.
        /// </value>
        public decimal Spent { get; set; }

        /// <summary>
        /// Gets or sets the balance.
        /// </summary>
        /// <value>
        /// The balance.
        /// </value>
        public decimal Balance { get; set; }

        /// <summary>
        /// Gets or sets the period.
        /// </summary>
        /// <value>
        /// The period.
        /// </value>
        //// TODO: transforma em enum?     
        public string Period { get; set; }
    }
}
