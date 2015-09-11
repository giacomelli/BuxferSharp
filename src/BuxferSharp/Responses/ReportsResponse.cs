namespace BuxferSharp.Responses
{
    /// <summary>
    /// Reports response from Buxfer API.
    /// </summary>
    public class ReportsResponse : SuccessResponseBase
    {
        /// <summary>
        /// Gets or sets the reports.
        /// </summary>
        /// <value>
        /// The reports.
        /// </value>
        public ReportResponse Reports { get; set; }
    }
}
