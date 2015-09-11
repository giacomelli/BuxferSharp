using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace BuxferSharp.Responses
{
    /// <summary>
    /// Loans response from Buxfer API.
    /// </summary>
    public class LoansResponse : SuccessResponseBase
    {
        /// <summary>
        /// Gets the loans.
        /// </summary>
        /// <value>
        /// The loans.
        /// </value>
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Used by RestSharp")]
        [SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists", Justification = "Used by RestSharp")]
        public List<LoanResponse> Loans { get; internal set; }
    }
}
