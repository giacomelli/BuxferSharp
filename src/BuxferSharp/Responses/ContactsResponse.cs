using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace BuxferSharp.Responses
{
    /// <summary>
    /// Contacts response from Buxfer API.
    /// </summary>
    public class ContactsResponse : SuccessResponseBase
    {
        /// <summary>
        /// Gets the contacts.
        /// </summary>
        /// <value>
        /// The contacts.
        /// </value>
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Used by RestSharp")]
        [SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists", Justification = "Used by RestSharp")]
        public List<Contact> Contacts { get; internal set; }
    }
}
