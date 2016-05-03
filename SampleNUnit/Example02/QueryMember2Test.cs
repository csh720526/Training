using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using MySql.Data.MySqlClient;
using NUnit.Framework;
using Sample.Example02;

namespace SampleNUnit.Example02
{
    [TestFixture]
    [Category("Example02")]
    public class QueryMember2Test
    {
        [Test]
        public void Query_Email_Test()
        {
            // Arrange
            string phone = "+886911506909";
            string exceptedMail = "csh720526@gmail.com";

            var conMock = new Mock<IDbConnection>();
            var cmdMock = new Mock<IDbCommand>();
            var readerMock = new Mock<IDataReader>();
            var parameterMock = new Mock<IDbDataParameter>();
            var dbParaCollectionMock = new Mock<IDataParameterCollection>();

            dbParaCollectionMock.Setup(dbp => dbp.Add(It.IsAny<IDbDataParameter>()))
                .Verifiable();

            parameterMock.SetupSet(p => p.Value = phone)
                .Verifiable();

            readerMock.Setup(r => r.Read())
                .Returns(true)
                .Verifiable();

            readerMock.SetupGet(r => r["Email"])
                .Returns(exceptedMail)
                .Verifiable();

            cmdMock.Setup(c => c.ExecuteReader())
                .Returns(readerMock.Object)
                .Verifiable();
            cmdMock.Setup(c => c.CreateParameter())
                .Returns(parameterMock.Object)
                .Verifiable();
            cmdMock.SetupGet(c => c.Parameters)
                .Returns(dbParaCollectionMock.Object)
                .Verifiable();

            conMock.Setup(c => c.Open());
            conMock.Setup(c => c.CreateCommand())
                .Returns(cmdMock.Object)
                .Verifiable();

            readerMock.Setup(c => c.Close())
                .Verifiable();
            cmdMock.Setup(c => c.Dispose())
                .Verifiable();
            conMock.Setup(c => c.Close())
                .Verifiable();

            //MySqlConnection con = 
            //    new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["con"].ConnectionString);

            //var qMem = new QueryMember2(con);
            var qMem = new QueryMember2(conMock.Object);

            // Act
            var mail = qMem.QueryEmail(phone);

            // Assert
            Assert.That(mail, Is.EqualTo(exceptedMail));

            conMock.Verify();
            readerMock.Verify();
            cmdMock.Verify();

        }
    }
}
