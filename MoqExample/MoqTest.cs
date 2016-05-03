using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using MoqExample.Example;
using NUnit.Framework;

namespace MoqExample
{
    [TestFixture]
    [Category("MoqTest")]
    public class MoqTest
    {
        [Test]
        public void DummyTest()
        {
            // Arrage
            var logMock = new Mock<ILog>();
            int testValue = 4534324;
            string excepted =
                BitConverter.ToString(Encoding.ASCII.GetBytes(testValue.ToString()))
                .Replace("-", "");

            StringUtility u = new StringUtility(logMock.Object);

            // Act
            var rslt = u.ToHex(testValue);

            // Assert
            Assert.That(rslt, Is.EqualTo(excepted));
        }

        [Test]
        public void StubTest()
        {
            // Arrage
            var logMock = new Mock<ILog>();
            var utilityMock = new Mock<StringUtility>(logMock.Object);

            int testValue = 4534324;
            int testValue2 = 2222222;

            string excepted =
                BitConverter.ToString(Encoding.ASCII.GetBytes(testValue.ToString()))
                .Replace("-", "");
            string excepted2 =
                BitConverter.ToString(Encoding.ASCII.GetBytes(testValue2.ToString()))
                .Replace("-", "");

            utilityMock.Setup(m => m.ToHex(It.Is<int>(i => i == testValue)))
                .Returns(excepted);

            utilityMock.Setup(m => m.ToHex(It.Is<int>(i => i == testValue2)))
                .Returns(excepted2);
            

            var u = utilityMock.Object;

            // Act
            var rslt = u.ToHex(testValue);
            var rslt2 = u.ToHex(testValue2);

            // Assert
            Assert.That(rslt, Is.EqualTo(excepted));
            Assert.That(rslt2, Is.EqualTo(excepted2));
        }

        [Test]
        public void SpyTest()
        {
            // Arrage
            var logMock = new Mock<ILog>();

            int testValue = 0;

            StringUtility u = new StringUtility(logMock.Object);

            // Act & Assert
            Assert.That(() => u.ToHex(testValue), Throws.InstanceOf<ArgumentException>());
            
            logMock.Verify(log => log.Write(It.IsAny<string>()),
                Times.Once);
        }
        
        [Test]
        public void FakeTest()
        {
            // Arrage
            IRemoteService srv = new FakeRemotService();
            string phone = "+886911506909";
            string expected = "csh720526@gmail.com";

            // Act
            var rslt = srv.GetEmail(phone);

            // Assert
            Assert.That(rslt, Is.EqualTo(expected));

        }
    }
}
