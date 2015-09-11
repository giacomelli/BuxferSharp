using System;
using System.Diagnostics;
using System.Threading.Tasks;
using BuxferSharp.Responses;
using RestSharp;

namespace BuxferSharp.Security
{
    /// <summary>
    /// IAuthenticator's implementation that use Buxfer API token.
    /// </summary>
    public class TokenAuthenticator : IAuthenticator
    {
        #region Fields
        private string m_userId;
        private string m_password;
        private Func<string, Method, IRestRequest> m_createRequest;
        private Func<IRestRequest, LoginResponse> m_executeRequest;
        private string m_token;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="TokenAuthenticator"/> class.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="password">The password.</param>
        /// <param name="createRequest">The create request.</param>
        /// <param name="executeRequest">The execute request.</param>
        public TokenAuthenticator(string userId, string password, Func<string, Method, IRestRequest> createRequest, Func<IRestRequest, LoginResponse> executeRequest)
        {
            m_userId = userId;
            m_password = password;
            m_createRequest = createRequest;
            m_executeRequest = executeRequest;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets a value indicating whether this <see cref="TokenAuthenticator"/> is authenticated.
        /// </summary>
        /// <value>
        ///   <c>true</c> if authenticated; otherwise, <c>false</c>.
        /// </value>
        public bool Authenticated { get; private set; }
        #endregion

        #region Methods
        /// <summary>
        /// Authenticates the specified client.
        /// </summary>
        /// <param name="client">The client.</param>
        /// <param name="request">The request.</param>
        public void Authenticate(IRestClient client, IRestRequest request)
        {
            if (request.Resource.Equals("login", StringComparison.OrdinalIgnoreCase))
            {
                return;
            }

            Debug.WriteLine("Authenticated: {0}", Authenticated);

            if (!Authenticated)
            {
                var loginRequest = m_createRequest("login", Method.GET);

                loginRequest.AddParameter("userid", m_userId);
                loginRequest.AddParameter("password", m_password);

                try
                {
                    Task.Run(() =>
                    {
                        try
                        {
                            Debug.WriteLine("Requesting login...");
                            var response = m_executeRequest(loginRequest);
                            Debug.WriteLine("Login requested.");
                            m_token = response.Token;
                            Authenticated = true;
                        }
                        catch (Exception ex1)
                        {
                            Debug.WriteLine("Login error: {0}", ex1.Message);
                            throw ex1;
                        }
                    }).Wait(60000);
                }
                catch (AggregateException ex)
                {
                    Debug.WriteLine("Login error: {0}", ex.Message);
                    throw ex.InnerException;
                }
            }

            request.AddParameter("token", m_token);
        }
        #endregion
    }
}
