namespace BuxferSharp.Responses
{
    /// <summary>
    /// An output from Buxfer API.
    /// </summary>
    /// <typeparam name="TResponse">The type of the response.</typeparam>
    public class Output<TResponse> where TResponse : SuccessResponseBase
    {
        /// <summary>
        /// Gets or sets the response.
        /// </summary>
        /// <value>
        /// The response.
        /// </value>
        public TResponse Response { get; set; }

        /// <summary>
        /// Gets or sets the error.
        /// </summary>
        /// <value>
        /// The error.
        /// </value>
        public ErrorResponse Error { get; set; }
    }
}