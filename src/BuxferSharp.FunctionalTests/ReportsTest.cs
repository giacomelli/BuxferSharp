using System.Linq;
using NUnit.Framework;

namespace BuxferSharp.FunctionalTests
{
    [TestFixture]
    [Category("Reports")]
    public class ReportsTest
    {
        [Test]
        public void GetReports_NoArgs_Reports()
        {
            var target = TestHelper.CreateClient();
            var actual = target.GetReports();

            Assert.AreNotEqual(0, actual.TotalCount);
            Assert.AreEqual(1, actual.Entities.Count());
            var report = actual.Entities[0];

            Assert.AreNotEqual(0, report.Items.Count);

            foreach (var item in report.Items)
            {
                Assert.IsNotNull(item.Tag);
                Assert.IsNotNull(item.Tag.Id);
                Assert.IsNotNull(item.Tag.Name);
                Assert.AreNotEqual(item.Tag.Id, item.Tag.Name);
                Assert.AreNotEqual(0, item.Amount);
            }
        }
    }
}

