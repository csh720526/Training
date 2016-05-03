using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Sample.Example04;

namespace SampleNUnit.Example04
{
    [TestFixture]
    [Category("Example04")]
    public class QueryMemberTest4
    {
        [Test]
        public void Query_Email_Test()
        {
            // Arrage
            string phone = "+886911506909";
            string expectedMail = "csh720526@gmail.com";

            var repMock = new Mock<IMemberRepository>();


            repMock.Setup(r => r.GetMember(It.IsAny<string>()))
                .Returns(new MemberEntity() { Email = expectedMail })
                .Verifiable();

            QueryMember4 qMem = new QueryMember4(repMock.Object);
            
            // Act & Assert
            Assert.That(() => qMem.QueryEmail(phone), Is.EqualTo(expectedMail));

            repMock.Verify();
            
        }
    }
}
