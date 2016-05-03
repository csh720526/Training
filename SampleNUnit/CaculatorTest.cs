using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Sample;

namespace SampleNUnit
{
    [TestFixture]
    [Category("NUnit")]
    public class CaculatorTest
    {
        [OneTimeSetUp]
        [OneTimeTearDown]
        [Test]
        public void Caulator_Add_Test()
        {
            // Arrange
            int a = 1;
            int b = 2;
            int expected = 3;

            Caculator caulator = new Caculator();

            // Act
            var rslt = caulator.Add(a, b);

            // Assert
            Assert.That(rslt, Is.EqualTo(expected));
        }

        [Test]
        [TestCaseSource(typeof(CaculatorTestData))]
        public int Caculator_Add_MultiInput_Test(int a, int b)
        {
            // Arrange
            Caculator caulator = new Caculator();

            // Act
            var rslt = caulator.Add(a, b);

            // Assert
            return rslt;
        }

        [Test]
        public void Caculator_Divide_Test()
        {
            // Arrange
            int a = 5;
            int b = 2;
            int expected = 2;

            Caculator caulator = new Caculator();

            // Act
            var rslt = caulator.Divide(a, b);

            // Assert
            Assert.That(rslt == expected);
        }

        [Test]
        public void Caculator_Divide_Disivor_IsZro_Test()
        {
            // Arrange
            int a = 5;
            int b = 0;
            string errMsg = "b is zero";

            Caculator caulator = new Caculator();

            // Act & Assert
            var ex = Assert.Throws<DivideByZeroException>(() => caulator.Divide(a, b));

            // Other Assert
            Assert.That(ex.Message.Equals(errMsg));
        }
    }
}
