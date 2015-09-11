namespace BuxferSharp.Responses
{
    /// <summary>
    /// Add transaction response from Buxfer API.
    /// </summary>
    public class AddTransactionResponse : SuccessResponseBase
    {
        /// <summary>
        /// Gets or sets a value indicating whether transaction was added.
        /// </summary>
        /// <value>
        ///   <c>true</c> if transaction was added; otherwise, <c>false</c>.
        /// </value>
        public bool TransactionAdded { get; set; }
    }
}
