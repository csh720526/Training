using System;
using System.Collections.Generic;
using System.Data;
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
    public class MemberRepositoryTest3
    {
        [Test]
        public void MemberRepository_GetMember_Test()
        {
            // Arrage
            string phone = "+886911506909";

            var mockRep = new MockRepository(MockBehavior.Loose);

            var conMock = mockRep.Create<IDbConnection>();
            var cmdMock = mockRep.Create<IDbCommand>();
            var readerMock = mockRep.Create<IDataReader>();
            var parameterMock = mockRep.Create<IDbDataParameter>();
            var dbParaCollectionMock = mockRep.Create<IDataParameterCollection>();

            dbParaCollectionMock.Setup(dbp => dbp.Add(It.IsAny<IDbDataParameter>()))
                .Verifiable();

            parameterMock.SetupSet(p => p.Value = phone)
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
            cmdMock.Setup(c => c.Dispose())
                .Verifiable();

            conMock.SetupGet(c => c.State)
                .Returns(ConnectionState.Open);
            conMock.Setup(c => c.Open())
                .Verifiable();
            conMock.Setup(c => c.CreateCommand())
                .Returns(cmdMock.Object)
                .Verifiable();

            using (var qMem = new MemberRepository(conMock.Object))
            {
                // Act
                var reader = qMem.GetMember(phone);

                // Assert
                Assert.That(reader, Is.Not.Null);
            }

            mockRep.Verify();
        }
    }
}
