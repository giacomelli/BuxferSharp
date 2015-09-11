using System.Collections.Generic;

namespace BuxferSharp
{
    /// <summary>
    /// Represents a filter result.
    /// </summary>
    /// <typeparam name="TEntity">The entity type.</typeparam>
    public sealed class FilterResult<TEntity>
    {
        #region Constructors        
        /// <summary>
        /// Initializes a new instance of the <see cref="FilterResult{TEntity}"/> class.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <param name="totalCount">The total count.</param>
        public FilterResult(IList<TEntity> entities, long totalCount)
        {
            Entities = entities;
            TotalCount = totalCount;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FilterResult{TEntity}"/> class.
        /// </summary>
        /// <param name="entities">The entities.</param>
        public FilterResult(IList<TEntity> entities)
            : this(entities, entities.Count)
        {
        }
        #endregion

        #region Properties        
        /// <summary>
        /// Gets or sets the total count.
        /// </summary>
        /// <value>
        /// The total count.
        /// </value>
        public long TotalCount { get; set; }

        /// <summary>
        /// Gets the entities.
        /// </summary>
        /// <value>
        /// The entities.
        /// </value>
        public IList<TEntity> Entities { get; private set; }
        #endregion
    }
}
