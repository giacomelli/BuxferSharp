using NUnit.Framework;
using TestSharp;

namespace BuxferSharp.FunctionalTests
{
    [TestFixture]
    [Category("Auth")]
    public class AuthTest
    {
        [Test]
        public void Authenticator_InvalidCredentials_Exception()
        {
            var target = new BuxferClient("john@doe.com", "dohdoh");

            ExceptionAssert.IsThrowing(new BuxferException("Email or username does not match an existing account."), () =>
            {
                target.GetTransactions();
            });
        }
    }
}

