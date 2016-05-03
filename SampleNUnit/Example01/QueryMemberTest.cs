using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Sample.Example01;

namespace SampleNUnit.Example01
{
    [TestFixture]
    [Category("Example01")]
    public class QueryMemberTest
    {
        private string con;

        [SetUp]
        public void Init()
        {
            con = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        }

        [Test]
        public void Query_Email_Test()
        {
            //Arrange
            string phone = "+886911506909";
            string expectedMail = "csh720526@gmail.com";
            QueryMember qMem = new QueryMember(con);

            //Act
            var email = qMem.QueryEmail(phone);

            //Assert
            Assert.That(email, Is.EqualTo(expectedMail));
        }
    }
}
