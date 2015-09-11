using System.Linq;
using NUnit.Framework;

namespace BuxferSharp.FunctionalTests
{
    [TestFixture]
    [Category("Budgets")]
    public class BudgetsTest
    {
        [Test]
        public void GetBudgets_NoArgs_AllBudgets()
        {
            var target = TestHelper.CreateClient();
            var actual = target.GetBudgets();

            Assert.AreNotEqual(0, actual.TotalCount);
            Assert.AreNotEqual(0, actual.Entities.Count());
            Assert.AreEqual(actual.TotalCount, actual.Entities.Count);

            foreach (var budget in actual.Entities)
            {
                Assert.IsNotNull(budget.Id);
                Assert.IsNotNull(budget.Name);
                Assert.IsNotNull(budget.Period);
                Assert.AreEqual(budget.Balance, budget.Limit - budget.Spent);
            }
        }
    }
}

