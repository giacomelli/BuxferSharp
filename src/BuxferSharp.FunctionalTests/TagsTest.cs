using System.Linq;
using NUnit.Framework;

namespace BuxferSharp.FunctionalTests
{
    [TestFixture]
    [Category("Tags")]
    public class TagsTest
    {
        [Test]
        public void GetTags_NoArgs_AllTags()
        {
            var target = TestHelper.CreateClient();
            var actual = target.GetTags();

            Assert.AreNotEqual(0, actual.TotalCount);
            Assert.AreNotEqual(0, actual.Entities.Count());
            Assert.AreEqual(actual.TotalCount, actual.Entities.Count);

            foreach (var tag in actual.Entities)
            {
                Assert.IsNotNull(tag.Id);
                Assert.IsNotNull(tag.Name);
            }
        }
    }
}

