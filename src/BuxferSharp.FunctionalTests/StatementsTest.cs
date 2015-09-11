using NUnit.Framework;

namespace BuxferSharp.FunctionalTests
{
    [TestFixture]
    [Category("Statements")]
    public class StatementsTest
    {
        [Test]
        public void UploadStatement_EmptyText_UploadedFalse()
        {
            var target = TestHelper.CreateClient();
            var statement = new Statement();
            statement.AccountId = TestHelper.AccountId;

            var actual = target.UploadStatement(statement);

            Assert.IsFalse(actual);
        }

        [Test]
        public void UploadStatement_ValidText_UploadedTrue()
        {
            var target = TestHelper.CreateClient();
            var statement = new Statement();
            statement.AccountId = TestHelper.AccountId;
            statement.Text = @"
<OFX>
   <SIGNONMSGSRSV1>
      <SONRS>
         <STATUS>
            <CODE>0</CODE>
            <SEVERITY>INFO</SEVERITY>
         </STATUS>
         <DTSERVER>20150910120000[-3:BRT]</DTSERVER>
         <LANGUAGE>POR</LANGUAGE>
         <FI>
            <ORG>Test</ORG>
            <FID>1</FID>
         </FI>
      </SONRS>
   </SIGNONMSGSRSV1>
   <BANKMSGSRSV1>
      <STMTTRNRS>
         <TRNUID>1</TRNUID>
         <STATUS>
            <CODE>0</CODE>
            <SEVERITY>INFO</SEVERITY>
         </STATUS>
         <STMTRS>
            <CURDEF>BRL</CURDEF>
            <BANKACCTFROM>
               <BANKID>1</BANKID>
               <BRANCHID/>
               <ACCTID>/</ACCTID>
               <ACCTTYPE>SAVINGS</ACCTTYPE>
            </BANKACCTFROM>
            <BANKTRANLIST>
               <DTSTART>120000[-3:BRT]</DTSTART>
               <DTEND>120000[-3:BRT]</DTEND>
            </BANKTRANLIST>
            <LEDGERBAL>
               <BALAMT>1,00</BALAMT>
               <DTASOF>20150910120000[-3:BRT]</DTASOF>
            </LEDGERBAL>
         </STMTRS>
      </STMTTRNRS>
   </BANKMSGSRSV1>
</OFX>";
   
            var actual = target.UploadStatement(statement);

            Assert.IsTrue(actual);
        }
    }
}

