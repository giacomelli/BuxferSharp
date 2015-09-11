using System.Linq;
using NUnit.Framework;

namespace BuxferSharp.FunctionalTests
{
    [TestFixture]
    [Category("Contacts")]
    public class ContactsTest
    {
        [Test]
        public void GetContacts_NoArgs_AllContacts()
        {
            var target = TestHelper.CreateClient();
            var actual = target.GetContacts();

            Assert.AreEqual(actual.TotalCount, actual.Entities.Count);

            foreach (var contact in actual.Entities)
            {
                Assert.IsNotNull(contact.Id);
                Assert.IsNotNull(contact.Name);
            }
        }
    }
}

