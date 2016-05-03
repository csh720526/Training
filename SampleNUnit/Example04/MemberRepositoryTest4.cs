using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Sample.Example04;
using SampleNUnit.Example04.DbSet;

namespace SampleNUnit.Example04
{
    [TestFixture]
    [Category("Example04")]
    public class MemberRepositoryTest4
    {
        [Test]
        public void MemberRepository_GetMember_Test()
        {
            // Arrage
            string phone = "+886911506909";
            var members = new List<MemberEntity>()
            {
                new MemberEntity() { Email = "2423@sdklfj.com", Phone = "+886922838383" },
                new MemberEntity() { Email = "csh720526@gmail.com", Phone = "+886911506909" }
            }.AsQueryable();

            var mockRep = new MockRepository(MockBehavior.Loose);

            var ctxMock = mockRep.Create<JKOSContext>();
            var dbSetMock = mockRep.Create<DbSet<MemberEntity>>();

            dbSetMock.As<IQueryable<MemberEntity>>()
                .Setup(d => d.Provider)
                .Returns(members.Provider);

            dbSetMock.As<IQueryable<MemberEntity>>()
                .Setup(d => d.Expression)
                .Returns(members.Expression);

            dbSetMock.As<IQueryable<MemberEntity>>()
                .Setup(d => d.ElementType)
                .Returns(members.ElementType);

            dbSetMock.As<IQueryable<MemberEntity>>()
                .Setup(m => m.GetEnumerator())
                .Returns(members.GetEnumerator());

            //dbSetMock.As<IDbAsyncEnumerable<MemberEntity>>()
            //    .Setup(m => m.GetAsyncEnumerator())
            //    .Returns(new TestDbAsyncEnumerator<MemberEntity>(members.GetEnumerator()));

            //dbSetMock.As<IQueryable<MemberEntity>>()
            //    .Setup(m => m.Provider)
            //    .Returns(new TestDbAsyncQueryProvider<MemberEntity>(members.Provider));

            ctxMock.SetupGet(c => c.Member)
                .Returns(dbSetMock.Object)
                .Verifiable();


            using (var qMem = new MemberRepository(ctxMock.Object))
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
