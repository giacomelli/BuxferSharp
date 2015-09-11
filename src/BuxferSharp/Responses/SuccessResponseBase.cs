namespace BuxferSharp.Responses
{
    /// <summary>
    /// Response status from Buxfer API.
    /// </summary>
    public enum ResponseStatus
    {
        /// <summary>
        /// Response is ok.
        /// </summary>
        Ok,

        /// <summary>
        /// Response with error.
        /// </summary>
        Error
    }

    /// <summary>
    /// Base class form success responses.
    /// </summary>
    public abstract class SuccessResponseBase
    {
        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public ResponseStatus Status { get; set; }
    }
}
