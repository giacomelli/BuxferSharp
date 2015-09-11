using System;
using System.Linq;
using NUnit.Framework;

namespace BuxferSharp.FunctionalTests
{
    [TestFixture]
    [Category("Reminders")]
    public class RemindersTest
    {
        [Test]
        public void GetReminders_NoArgs_AllReminders()
        {
            var target = TestHelper.CreateClient();
            var actual = target.GetReminders();

            Assert.AreEqual(actual.TotalCount, actual.Entities.Count);

            foreach (var reminder in actual.Entities)
            {
                Assert.IsNotNull(reminder.AccountId);
                Assert.AreNotEqual(0, reminder.Amount);
                Assert.IsNotNull(reminder.Id);
                Assert.IsNotNull(reminder.Description);

                if (reminder.NotificationTime.HasValue)
                {
                    Assert.IsTrue(reminder.NotificationTime.Value.TotalMinutes > 0);
                }

                Assert.IsNotNull(reminder.Period);
                Assert.AreNotEqual(DateTime.MinValue, reminder.StartDate);
            }
        }
    }
}

