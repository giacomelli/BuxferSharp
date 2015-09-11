using System;
using System.Linq;
using NUnit.Framework;
using TestSharp;

namespace BuxferSharp.FunctionalTests
{
    [TestFixture]
    [Category("Accounts")]
    public class AccountsTest
    {      
        [Test]
        public void GetAccounts_NoArgs_AllAccounts()
        {
            var target = TestHelper.CreateClient();
            var actual = target.GetAccounts();

            Assert.AreNotEqual(0, actual.TotalCount);
            Assert.AreNotEqual(0, actual.Entities.Count());
            Assert.AreEqual(actual.TotalCount, actual.Entities.Count);

            foreach (var account in actual.Entities)
            {
                Assert.IsNotNull(account.Id);
                Assert.IsNotNull(account.Name);
                Assert.IsNotNull(account.Currency);
            }
        }
    }
}

