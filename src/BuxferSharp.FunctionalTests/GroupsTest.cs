using NUnit.Framework;

namespace BuxferSharp.FunctionalTests
{
    [TestFixture]
    [Category("Groups")]
    public class GroupsTest
    {
        [Test]
        public void GetGroups_NoArgs_AllGroups()
        {
            var target = TestHelper.CreateClient();
            var actual = target.GetGroups();

            Assert.AreEqual(actual.TotalCount, actual.Entities.Count);

            foreach (var group in actual.Entities)
            {
                Assert.IsNotNull(group.Id);
                Assert.IsNotNull(group.Name);
                Assert.IsNotNull(group.Members);

                foreach (var member in group.Members)
                {
                    Assert.IsNotNull(member.Id);
                    Assert.IsNotNull(member.Name);
                }
            }
        }
    }
}

