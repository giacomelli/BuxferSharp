using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace BuxferSharp.Responses
{
    /// <summary>
    /// Budgets response from Buxfer API.
    /// </summary>
    public class BudgetsResponse : SuccessResponseBase
    {
        /// <summary>
        /// Gets the budgets.
        /// </summary>
        /// <value>
        /// The budgets.
        /// </value>
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Used by RestSharp")]
        [SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists", Justification = "Used by RestSharp")]
        public List<Budget> Budgets { get; internal set; }
    }
}
