using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Sample.Example03;

namespace SampleNUnit.Example03
{
    [TestFixture]
    [Category("Example03")]
    public class QueryMemberTest3
    {
        [Test]
        public void Query_Email_Test()
        {
            // Arrage
            string phone = "+886911506909";
            string exceptedMail = "csh720526@gmail.com";

            var repMock = new Mock<IMemberRepository>();
            var readerMock = new Mock<IDataReader>();

            readerMock.Setup(r => r.Read()).Returns(true);
            readerMock.SetupGet(r => r["Email"])
                .Returns("csh720526@gmail.com")
                .Verifiable();

            repMock.Setup(r => r.GetMember(It.IsAny<string>()))
                .Returns(readerMock.Object)
                .Verifiable();

            QueryMember3 qMem = new QueryMember3(repMock.Object);
            
            // Act & Assert
            Assert.That(() => qMem.QueryEmail(phone), Is.EqualTo(exceptedMail));

            repMock.Verify();
            readerMock.Verify();
            
        }
    }
}
