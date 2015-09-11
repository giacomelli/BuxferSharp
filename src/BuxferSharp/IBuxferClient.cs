using System.Diagnostics.CodeAnalysis;

namespace BuxferSharp
{
    /// <summary>
    /// Defines a interface for a Buxfer API client.
    /// </summary>
    public interface IBuxferClient
    {
        /// <summary>
        /// Adds the transaction.
        /// </summary>
        /// <param name="transaction">The transaction.</param>
        /// <returns>True if transaction was added.</returns>
        bool AddTransaction(Transaction transaction);

        /// <summary>
        /// Gets the accounts.
        /// </summary>
        /// <returns>The accounts.</returns>
        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        FilterResult<Account> GetAccounts();

        /// <summary>
        /// Gets the budgets.
        /// </summary>
        /// <returns>The budgets.</returns>
        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        FilterResult<Budget> GetBudgets();

        /// <summary>
        /// Gets the contacts.
        /// </summary>
        /// <returns>The contacts.</returns>
        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        FilterResult<Contact> GetContacts();

        /// <summary>
        /// Gets the groups.
        /// </summary>
        /// <returns>The groups.</returns>
        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        FilterResult<Group> GetGroups();

        /// <summary>
        /// Gets the loans.
        /// </summary>
        /// <returns>The loans.</returns>
        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        FilterResult<Loan> GetLoans();

        /// <summary>
        /// Gets the reminders.
        /// </summary>
        /// <returns>The reminders.</returns>
        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        FilterResult<Reminder> GetReminders();

        /// <summary>
        /// Gets the reports.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>The reports.</returns>
        FilterResult<Report> GetReports(ReportFilter filter = null);

        /// <summary>
        /// Gets the tags.
        /// </summary>
        /// <returns>The tags.</returns>
        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        FilterResult<Tag> GetTags();

        /// <summary>
        /// Gets the transactions.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>The transactions.</returns>
        FilterResult<Transaction> GetTransactions(TransactionFilter filter = null);

        /// <summary>
        /// Uploads the statement.
        /// </summary>
        /// <param name="statement">The statement.</param>
        /// <returns>True if statement was uploaded.</returns>
        bool UploadStatement(Statement statement);
    }
}
