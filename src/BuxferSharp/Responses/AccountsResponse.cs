using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace BuxferSharp.Responses
{
    /// <summary>
    /// Accounts response from Buxfer API.
    /// </summary>
    public class AccountsResponse : SuccessResponseBase
    {
        /// <summary>
        /// Gets the accounts.
        /// </summary>
        /// <value>
        /// The accounts.
        /// </value>
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Used by RestSharp")]
        [SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists", Justification = "Used by RestSharp")]
        public List<Account> Accounts { get; internal set; }
    }
}
