using NUnit.Framework;
using System;
using TestSharp;

namespace BuxferSharp.FunctionalTests
{
	[TestFixture ()]
	public class BuxferClientTest
	{
		[Test ()]
		public void Login_InvalidCredentials_Exception ()
		{
			var target = new BuxferClient ();
		
			ExceptionAssert.IsThrowing (new BuxferException ("Email or username does not match an existing account."), () => {
				target.Login ("john@doe.com", "dohdoh");
			});
		}

		[Test ()]
		public void Login_ValidCredentials_Authenticated ()
		{
			var target = new BuxferClient ();
			target.Login ("giacomelli@gmail.com", "");

			Assert.IsTrue (target.Authenticated);
		}
	}
}

