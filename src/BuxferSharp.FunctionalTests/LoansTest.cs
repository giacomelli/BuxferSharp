using System.Linq;
using NUnit.Framework;

namespace BuxferSharp.FunctionalTests
{
    [TestFixture]
    [Category("Loans")]
    public class LoansTest
    {
        [Test]
        public void GetLoans_NoArgs_AllLoans()
        {
            var target = TestHelper.CreateClient();
            var actual = target.GetLoans();

            Assert.AreEqual(actual.TotalCount, actual.Entities.Count);

            foreach (var loan in actual.Entities)
            {
                Assert.IsNotNull(loan.Description);
                Assert.IsNotNull(loan.Description);
            }
        }
    }
}

