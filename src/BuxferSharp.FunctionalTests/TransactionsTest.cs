using System;
using System.Linq;
using NUnit.Framework;

namespace BuxferSharp.FunctionalTests
{
    [TestFixture]
    [Category("Transactions")]
    public class TransactionsTest
    {
        [Test]
        public void GetTransactions_NoArgs_Firts25Transactions()
        {
            var target = TestHelper.CreateClient();
            var actual = target.GetTransactions();

            Assert.IsTrue(target.Authenticated);
            Assert.AreNotEqual(0, actual.TotalCount);
            Assert.AreNotEqual(0, actual.Entities.Count());
            var first = actual.Entities[0];

            Assert.IsNotNull(first.AccountId);
            Assert.AreNotEqual(1, first.Date.Year);
        }

        [Test]
        public void GetTransactions_FilterByString_FilteredTransactions()
        {
            var target = TestHelper.CreateClient();
            var filter = new TransactionFilter();
            filter.AccountName = TestHelper.AccountName;
            var actual = target.GetTransactions(filter);

            Assert.AreNotEqual(0, actual.TotalCount);

            foreach (var t in actual.Entities)
            {
                if (t.Type != TransactionType.Transfer)
                {
                    Assert.AreEqual(TestHelper.AccountName, t.AccountName);
                }
            }
        }

        [Test]
        public void GetTransactions_FilterByDate_FilteredTransactions()
        {
            var target = TestHelper.CreateClient();
            var filter = new TransactionFilter();
            filter.StartDate = DateTime.UtcNow.AddDays(-20);
            filter.EndDate = DateTime.UtcNow.AddDays(-10);
            var actual = target.GetTransactions(filter);

            Assert.AreNotEqual(0, actual.TotalCount);

            foreach (var t in actual.Entities)
            {
                Assert.IsTrue(t.Date >= filter.StartDate.Value);
                Assert.IsTrue(t.Date <= filter.EndDate.Value);
            }
        }

        [Test]
        public void GetTransactions_FilterByTag_FilteredTransactions()
        {
            var target = TestHelper.CreateClient();
            var filter = new TransactionFilter();
            filter.TagId = TestHelper.TagId;
            var actual = target.GetTransactions(filter);

            Assert.AreNotEqual(0, actual.TotalCount);

            foreach (var t in actual.Entities)
            {
                Assert.IsTrue(t.TagNames.Contains(TestHelper.TagName));
            }

            filter.TagId = null;
            filter.TagName = TestHelper.TagName;
            actual = target.GetTransactions(filter);

            Assert.AreNotEqual(0, actual.TotalCount);

            foreach (var t in actual.Entities)
            {
                Assert.IsTrue(t.TagNames.Contains(TestHelper.TagName));
            }
        }

        [Test]
        public void GetTransactions_Page2_DiffResultPage1()
        {
            var target = TestHelper.CreateClient();
            var filter = new TransactionFilter();
            var actual = target.GetTransactions(filter);
            var page1FirstTransaction = actual.Entities.First();

            filter.Page = 2;
            actual = target.GetTransactions(filter);
            var page2FirstTransaction = actual.Entities.First();

            Assert.AreNotEqual(page1FirstTransaction.Id, page2FirstTransaction.Id);
        }

        [Test]
        public void AddTransaction_Transaction_Added()
        {
            var target = TestHelper.CreateClient();
            var transaction = new Transaction()
            {
                Description = "Test transaction from BuxferSharp.FunctionalTest",
                Amount = 1,
                AccountName = TestHelper.AccountName,
                Date = DateTime.Now.AddYears(1)
            };

            var actual = target.AddTransaction(transaction);
            Assert.IsTrue(actual);

            var filter = new TransactionFilter()
            {
                AccountName = TestHelper.AccountName
            };
            var lastTransactions = target.GetTransactions(filter);
            var last = lastTransactions.Entities.First();

            Assert.AreEqual(transaction.Description, last.Description);
            Assert.AreEqual(transaction.Amount, last.Amount);
            Assert.AreEqual(transaction.AccountName, last.AccountName);
        }
    }
}

