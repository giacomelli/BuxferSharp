namespace BuxferSharp
{
    /// <summary>
    /// A base class for filters.
    /// </summary>
    public abstract class FilterBase
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="FilterBase"/> class.
        /// </summary>
        protected FilterBase()
        {
            Page = 1;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the page.
        /// </summary>
        /// <value>
        /// The page.
        /// </value>
        public int Page { get; set; }
        #endregion
    }
}
