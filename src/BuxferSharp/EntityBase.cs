namespace BuxferSharp
{
    /// <summary>
    /// An entity base class.
    /// </summary>
    public abstract class EntityBase : IEntity
    {
        #region Properties
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public virtual string Id { get; set; }
        #endregion
    }
}
