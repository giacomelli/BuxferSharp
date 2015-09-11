
using System;

namespace BuxferSharp.FunctionalTests
{
    public static class TestHelper
    {
        #region Fields
        private static readonly string m_userId;
        private static readonly string m_password;
        public static readonly int AccountId;
        public static readonly string AccountName;
        public static readonly string TagId;
        public static readonly string TagName;
        #endregion

        #region Constructors
        static TestHelper()
        {
            m_userId = Environment.GetEnvironmentVariable("BuxferSharp_UserId");
            m_password = Environment.GetEnvironmentVariable("BuxferSharp_Password");
            AccountId = Convert.ToInt32(Environment.GetEnvironmentVariable("BuxferSharp_AccountId"));
            AccountName = Environment.GetEnvironmentVariable("BuxferSharp_AccountName");
            TagId = Environment.GetEnvironmentVariable("BuxferSharp_TagId");
            TagName = Environment.GetEnvironmentVariable("BuxferSharp_TagName");

            if (string.IsNullOrEmpty(m_userId)
            || string.IsNullOrEmpty(m_password)
            || AccountId == 0
            || string.IsNullOrEmpty(AccountName)
            || string.IsNullOrEmpty(TagId)
            || string.IsNullOrEmpty(TagName))
            {
                throw new InvalidOperationException("You'll need to define some environment variables before run BuxferSharp.FunctionalTests: BuxferSharp_UserId, BuxferSharp_Password, BuxferSharp_AccountId, BuxferSharp_AccountName, BuxferSharp_TagId and BuxferSharp_TagName.");
            }
        }
        #endregion

        #region Methods
        public static BuxferClient CreateClient()
        {
            return new BuxferClient(m_userId, m_password);
        }
        #endregion
    }
}
