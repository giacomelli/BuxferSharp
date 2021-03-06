﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using BuxferSharp.Responses;
using BuxferSharp.Security;
using BuxferSharp.Serialization;
using RestSharp;

namespace BuxferSharp
{
    /// <summary>
    /// Buxfer API client.
    /// </summary>
    public sealed class BuxferClient : IBuxferClient
    {
        #region Fields
        private TokenAuthenticator m_authenticator;
        private IRestClient m_restClient;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="BuxferClient"/> class.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="password">The password.</param>
        public BuxferClient(string userId, string password)
        {
            ApiBaseUrl = "https://www.buxfer.com/api/";
            m_authenticator = new TokenAuthenticator(userId, password, (resource, method) => CreateRequestBuilder(resource, method).Request, (r) => ExecuteRequest<LoginResponse>(r));

            m_restClient = new RestClient(ApiBaseUrl);
            m_restClient.AddHandler("application/x-javascript", new RestSharp.Deserializers.JsonDeserializer());
            m_restClient.PreAuthenticate = true;
            m_restClient.Authenticator = m_authenticator;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the API base URL.
        /// </summary>
        /// <value>
        /// The API base URL.
        /// </value>
        public string ApiBaseUrl { get; set; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="BuxferClient"/> is authenticated.
        /// </summary>
        /// <value>
        ///   <c>true</c> if authenticated; otherwise, <c>false</c>.
        /// </value>
        public bool Authenticated
        {
            get
            {
                return m_authenticator.Authenticated;
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Adds the transaction.
        /// </summary>
        /// <param name="transaction">The transaction.</param>
        /// <returns>True if transaction was added.</returns>
        public bool AddTransaction(Transaction transaction)
        {
            var serializer = new TransactionSerializer(transaction);
            var builder = CreateRequestBuilder("add_transaction", Method.POST);
            var request = builder.Request;
            request.AddParameter("format", "sms", ParameterType.GetOrPost);
            request.AddParameter("text", serializer.SerializeToSmsText());

            return ExecuteRequest<AddTransactionResponse>(request).TransactionAdded;
        }

        /// <summary>
        /// Uploads the statement.
        /// </summary>
        /// <param name="statement">The statement.</param>
        /// <returns>True if statement was uploaded.</returns>
        public bool UploadStatement(Statement statement)
        {
            var builder = CreateRequestBuilder("upload_statement", Method.POST);
            var request = builder.Request;
            request.AddParameter("accountId", statement.AccountId, ParameterType.GetOrPost);
            request.AddParameter("statement", statement.Text, ParameterType.GetOrPost);

            if (!String.IsNullOrEmpty(statement.DateFormat))
            {
                request.AddParameter("dateFormat", statement.DateFormat, ParameterType.GetOrPost);
            }

            try
            {
                return ExecuteRequest<UploadStatementResponse>(request).Uploaded;
            }
            catch(BuxferException ex)
            {
                if(ex.Message.Equals("Invalid request", StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }

                throw;
            }
        }

        /// <summary>
        /// Gets the transactions.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>The transactions.</returns>
        public FilterResult<Transaction> GetTransactions(TransactionFilter filter = null)
        {
            var response = ExecuteGet<TransactionsResponse>("transactions", filter);
            return new FilterResult<Transaction>(response.Transactions, response.NumTransactions);
        }

        /// <summary>
        /// Gets the reports.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>The reports.</returns>
        public FilterResult<Report> GetReports(ReportFilter filter = null)
        {
            var response = ExecuteGet<ReportsResponse>("reports", filter);
            return new FilterResult<Report>(
                new List<Report>() 
                { 
                    new Report() 
                    { 
                        Items = response.Reports.RawData.Select(i => new ReportItem() 
                        { 
                            Amount = i.Amount, 
                            Tag = new Tag() 
                            { 
                                Id = i.TagId, 
                                Name = i.Tag 
                            }  
                        }).ToList() 
                    }
                },
                1);
        }

        /// <summary>
        /// Gets the accounts.
        /// </summary>
        /// <returns>The accounts.</returns>
        public FilterResult<Account> GetAccounts()
        {
            var response = ExecuteGet<AccountsResponse>("accounts", null);
            return new FilterResult<Account>(response.Accounts);
        }

        /// <summary>
        /// Gets the loans.
        /// </summary>
        /// <returns>The loans.</returns>
        public FilterResult<Loan> GetLoans()
        {
            var response = ExecuteGet<LoansResponse>("loans", null);
            return new FilterResult<Loan>(response.Loans.Select(t => t.KeyLoan).ToList());
        }

        /// <summary>
        /// Gets the tags.
        /// </summary>
        /// <returns>The tags.</returns>
        public FilterResult<Tag> GetTags()
        {
            var response = ExecuteGet<TagsResponse>("tags", null);
            return new FilterResult<Tag>(response.Tags);
        }

        /// <summary>
        /// Gets the budgets.
        /// </summary>
        /// <returns>The budgets.</returns>
        public FilterResult<Budget> GetBudgets()
        {
            var response = ExecuteGet<BudgetsResponse>("budgets", null);
            return new FilterResult<Budget>(response.Budgets);
        }

        /// <summary>
        /// Gets the reminders.
        /// </summary>
        /// <returns>The reminders.</returns>
        public FilterResult<Reminder> GetReminders()
        {
            var response = ExecuteGet<RemindersResponse>("reminders", null);
            return new FilterResult<Reminder>(response.Reminders);
        }

        /// <summary>
        /// Gets the groups.
        /// </summary>
        /// <returns>The groups.</returns>
        public FilterResult<Group> GetGroups()
        {
            var response = ExecuteGet<GroupsResponse>("groups", null);
            return new FilterResult<Group>(response.Groups);
        }

        /// <summary>
        /// Gets the contacts.
        /// </summary>
        /// <returns>The contacts.</returns>
        public FilterResult<Contact> GetContacts()
        {
            var response = ExecuteGet<ContactsResponse>("contacts", null);
            return new FilterResult<Contact>(response.Contacts);
        }
        #endregion

        #region Private methods
        private static RequestBuilder CreateRequestBuilder(string resource, Method method)
        {
            var request = new RestRequest(resource, method);

            return new RequestBuilder(request);
        }

        private TResponse ExecuteGet<TResponse>(string resource, object filter) where TResponse : SuccessResponseBase
        {
            var requestBuilder = CreateRequestBuilder(resource, Method.GET);
            requestBuilder.Query(filter);

            return ExecuteRequest<TResponse>(requestBuilder.Request);
        }

        private TResponse ExecuteRequest<TResponse>(IRestRequest request) where TResponse : SuccessResponseBase
        {
            var output = m_restClient.Execute<Output<TResponse>>(request);

            if (output.StatusCode == HttpStatusCode.OK && output.Data != null)
            {
                return output.Data.Response;
            }
            else if (output.Data == null)
            {
                throw new BuxferException(output.ErrorMessage);
            }
            else
            {
                throw new BuxferException(output.Data.Error.Message);
            }
        }
        #endregion
    }
}
