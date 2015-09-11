namespace BuxferSharp.Responses
{
    /// <summary>
    /// Upload statement response from Buxfer API.
    /// </summary>
    public class UploadStatementResponse : SuccessResponseBase
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="UploadStatementResponse"/> is uploaded.
        /// </summary>
        /// <value>
        ///   <c>true</c> if uploaded; otherwise, <c>false</c>.
        /// </value>
        public bool Uploaded { get; set; }

        /// <summary>
        /// Gets or sets the balance.
        /// </summary>
        /// <value>
        /// The balance.
        /// </value>
        public decimal Balance { get; set; }
    }
}
