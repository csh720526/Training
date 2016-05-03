using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sample;

namespace SampleUnitTest
{
    [TestClass]
    public class CaculatorTest
    {
        [TestMethod]
        public void Caculator_Add_Test()
        {
            // Arrange
            int a = 1;
            int b = 2;
            int expected = 3;

            Caculator caulator = new Caculator();

            // Act
            var rslt = caulator.Add(a, b);

            // Assert
            Assert.AreEqual(expected, rslt);
        }

        [TestMethod]
        public void Caculator_Divide_Test()
        {
            // Arrange
            int a = 0;
            int b = 5;
            int expected = 0;

            Caculator caulator = new Caculator();

            // Act
            var rslt = caulator.Divide(a, b);

            // Assert
            Assert.AreEqual(expected, rslt);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException), "b is zero")]
        public void Caculator_Divide_Disivor_IsZro_Test()
        {
            // Arrange
            int a = 5;
            int b = 0;

            Caculator caulator = new Caculator();

            // Act
            var rslt = caulator.Divide(a, b);

            // Assert

        }
    }
}
