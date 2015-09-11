using System;
#if !WINDOWS_PHONE
using System.Runtime.Serialization;
#endif

namespace BuxferSharp
{
    /// <summary>
    /// An exception from Buxfer.
    /// </summary>
#if !WINDOWS_PHONE
    [Serializable]
#endif
    public sealed class BuxferException : Exception
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="BuxferException"/> class.
        /// </summary>
        public BuxferException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BuxferException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public BuxferException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BuxferException"/> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        public BuxferException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

#if !WINDOWS_PHONE
        /// <summary>
        /// Initializes a new instance of the <see cref="BuxferException"/> class.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains contextual information about the source or destination.</param>
        private BuxferException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
#endif
        #endregion
    }
}