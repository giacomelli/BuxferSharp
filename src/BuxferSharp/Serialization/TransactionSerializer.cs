using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text;

namespace BuxferSharp.Serialization
{
    /// <summary>
    /// Transaction serializer.
    /// </summary>
    public class TransactionSerializer
    {
        #region Fields
        private Transaction m_transaction;
        private StringBuilder m_builder;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionSerializer"/> class.
        /// </summary>
        /// <param name="transaction">The transaction.</param>
        public TransactionSerializer(Transaction transaction)
        {
            m_transaction = transaction;
        }
        #endregion

        /// <summary>
        /// Serializes to SMS text using the following format:
        /// &lt;description&gt; [+]&lt;amount&gt; [tags:&lt;tags&gt;] [acct:&lt;account&gt;] [date:&lt;date&gt;] [status:&lt;status&gt;]
        /// https://www.buxfer.com/help/mobile
        /// </summary>
        /// <returns>The SMS text.</returns>
        public string SerializeToSmsText()
        {
            m_builder = new StringBuilder();
            ValidateTransaction();

            AddDescription();
            AddAmount();
            AddTags();
            AddAccount();
            AddDate();
            AddStatus();

            return m_builder.ToString();
        }

        private void AddDescription()
        {
            m_builder.Append(m_transaction.Description);
        }

        private void AddAmount()
        {
            m_builder.AppendFormat(
                " {0}{1}",
                m_transaction.Type == TransactionType.Income ? "+" : String.Empty,
                m_transaction.Amount.ToString(CultureInfo.InvariantCulture));
        }

        private void AddTags()
        {
            if (!String.IsNullOrEmpty(m_transaction.TagNames))
            {
                m_builder.AppendFormat(
                    " tags:{0}",
                    m_transaction.TagNames);
            }
        }

        private void AddAccount()
        {
            if (!String.IsNullOrEmpty(m_transaction.AccountName))
            {
                m_builder.AppendFormat(
                    " acct:{0}",
                    m_transaction.AccountName);
            }
        }

        private void AddDate()
        {
            if (m_transaction.Date != DateTime.MinValue)
            {
                m_builder.AppendFormat(
                    " date:{0}",
                    m_transaction.Date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
            }
        }

        [SuppressMessage("Microsoft.Globalization", "CA1308:NormalizeStringsToUppercase")]
        private void AddStatus()
        {
            if (m_transaction.Status != TransactionStatus.Cleared)
            {
                m_builder.AppendFormat(
                    " status:{0}",
                    m_transaction.Status.ToString().ToLowerInvariant());
            }
        }

        private void ValidateTransaction()
        {
            if (String.IsNullOrEmpty(m_transaction.Description))
            {
                throw new ArgumentException("Description must be defined");
            }

            if (m_transaction.Amount == 0)
            {
                throw new ArgumentException("Amount must be defined");
            }

            if (m_transaction.Type != TransactionType.Expense && m_transaction.Type != TransactionType.Income)
            {
                throw new ArgumentException("Only expense or income transactions can be serialized to SMS text");
            }
        }
    }
}
