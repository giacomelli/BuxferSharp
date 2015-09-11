using System;
using BuxferSharp.Serialization;
using NUnit.Framework;
using TestSharp;

namespace BuxferSharp.UnitTests.Serialization
{
    /// <summary>
    /// Sms Text format: <description> [+]<amount> [tags:<tags>] [acct:<account>] [date:<date>] [status:<status>]
    /// </summary>
    [TestFixture]
    public class Test
    {
        [Test]
        public void SerializeToSmsText_NoDescription_Exception()
        {
            var target = new TransactionSerializer(new Transaction());
            ExceptionAssert.IsThrowing(new ArgumentException("Description must be defined"), () =>
            {
                target.SerializeToSmsText();
            });
        }

        [Test]
        public void SerializeToSmsText_AmountZero_Exception()
        {
            var target = new TransactionSerializer(new Transaction() { Description = "test" });
            ExceptionAssert.IsThrowing(new ArgumentException("Amount must be defined"), () =>
            {
                target.SerializeToSmsText();
            });
        }

        [Test]
        public void SerializeToSmsText_NotExpenseOrIncome_Exception()
        {
            var target = new TransactionSerializer(new Transaction() { Description = "test", Amount = 1, Type = TransactionType.Loan });
            ExceptionAssert.IsThrowing(new ArgumentException("Only expense or income transactions can be serialized to SMS text"), () =>
            {
                target.SerializeToSmsText();
            });
        }

        [Test]
        public void SerializeToSmsText_TransactionWithOnlyDescriptionAndAmount_Text()
        {
            var transaction = CreateValidTransaction();
            var target = new TransactionSerializer(transaction);
            var actual = target.SerializeToSmsText();

            Assert.AreEqual("Test transaction with some accents | Transação de teste com alguns acentos 123.45", actual);
        }

        [Test]
        public void SerializeToSmsText_TransactionIncome_TextWithPlusAmount()
        {
            var transaction = CreateValidTransaction();
            transaction.Type = TransactionType.Income;

            var target = new TransactionSerializer(transaction);           
            var actual = target.SerializeToSmsText();

            Assert.AreEqual("Test transaction with some accents | Transação de teste com alguns acentos +123.45", actual);
        }

        [Test]
        public void SerializeToSmsText_TransactionWithTags_TextWithTags()
        {
            var transaction = CreateValidTransaction();
            transaction.TagNames = "tagOne,tagTwo,tagTrês";
            var target = new TransactionSerializer(transaction);           
            var actual = target.SerializeToSmsText();

            Assert.AreEqual("Test transaction with some accents | Transação de teste com alguns acentos 123.45 tags:tagOne,tagTwo,tagTrês", actual);
        }

        [Test]
        public void SerializeToSmsText_TransactionWithAccount_TextWithAccount()
        {
            var transaction = CreateValidTransaction();
            transaction.AccountName = "Bancão";
            var target = new TransactionSerializer(transaction);           
            var actual = target.SerializeToSmsText();

            Assert.AreEqual("Test transaction with some accents | Transação de teste com alguns acentos 123.45 acct:Bancão", actual);
        }

        [Test]
        public void SerializeToSmsText_TransactionWithDate_TextWithDate()
        {
            var transaction = CreateValidTransaction();
            transaction.Date = new DateTime(2015, 6, 22, 0, 0, 0, DateTimeKind.Utc);
            var target = new TransactionSerializer(transaction);            
            var actual = target.SerializeToSmsText();

            Assert.AreEqual("Test transaction with some accents | Transação de teste com alguns acentos 123.45 date:2015-06-22", actual);
        }

        [Test]
        public void SerializeToSmsText_TransactionWithStatus_TextWithStatus()
        {
            var transaction = CreateValidTransaction();
            transaction.Status = TransactionStatus.Pending;
            var target = new TransactionSerializer(transaction);            
            var actual = target.SerializeToSmsText();

            Assert.AreEqual("Test transaction with some accents | Transação de teste com alguns acentos 123.45 status:pending", actual);
        }

        [Test]
        public void SerializeToSmsText_TransactionWithAllData_TextWithAllData()
        {
            var transaction = CreateValidTransaction();
            transaction.TagNames = "tagOne,tagTwo,tagTrês";
            transaction.AccountName = "Bancão";
            transaction.Date = new DateTime(2015, 6, 22, 0, 0, 0, DateTimeKind.Utc);
            transaction.Status = TransactionStatus.Pending;
            var target = new TransactionSerializer(transaction);           
            var actual = target.SerializeToSmsText();

            Assert.AreEqual("Test transaction with some accents | Transação de teste com alguns acentos 123.45 tags:tagOne,tagTwo,tagTrês acct:Bancão date:2015-06-22 status:pending", actual);
        }

        private Transaction CreateValidTransaction()
        {
            return new Transaction()
            {
                Description = "Test transaction with some accents | Transação de teste com alguns acentos",
                Amount = 123.45m,
                Type = TransactionType.Expense
            };
        }
    }
}

