using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Reflection;
using RestSharp;

namespace BuxferSharp.Serialization
{
    /// <summary>
    /// A request builder.
    /// </summary>
    public class RequestBuilder
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="RequestBuilder"/> class.
        /// </summary>
        /// <param name="request">The request.</param>
        public RequestBuilder(IRestRequest request)
        {
            Request = request;
            Request.DateFormat = "yyyy-MM-dd";
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the request.
        /// </summary>
        /// <value>
        /// The request.
        /// </value>
        public IRestRequest Request { get; private set; }
        #endregion

        #region Methods
        /// <summary>
        /// Add the filter object to query string.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="prefix">The prefix.</param>
        /// <returns>The request builder.</returns>
        public RequestBuilder Query(object filter, string prefix = null)
        {
            if (filter != null)
            {
                prefix = prefix ?? String.Empty;

                var properties = filter.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

                foreach (var p in properties)
                {
                    var value = p.GetValue(filter);

                    if (value != null)
                    {
                        var entity = value as IEntity;

                        if (entity == null)
                        {
                            Request.AddQueryParameter(ToParameterName(prefix + p.Name), ToParameterValue(value));
                        }
                        else
                        {
                            Query(entity, entity.GetType().Name);
                        }
                    }
                }
            }

            return this;
        }
        #endregion

        #region Private methods
        [SuppressMessage("Microsoft.Globalization", "CA1308:NormalizeStringsToUppercase")]
        private static string ToParameterName(string name)
        {
            return name.Substring(0, 1).ToLowerInvariant() + name.Substring(1);
        }

        private static string ToParameterValue(object value)
        {
            string result;

            var type = value.GetType();

            if (type == typeof(DateTime))
            {
                var date = (DateTime)value;
                result = date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            }
            else
            {
                result = value.ToString();
            }

            return result;
        }
        #endregion
    }
}
