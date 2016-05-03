using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SampleNUnit
{
    public class CaculatorTestData : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new TestCaseData(1, 2)
                .Returns(3)
                .SetName("Caculator_Add_First_Test");

            yield return new TestCaseData(3, 5)
                .Returns(8)
                .SetName("Caculator_Add_Second_Test");

            yield return new TestCaseData(11, 83)
                .Returns(94)
                .SetName("Caculator_Add_Third_Test");
        }
    }
}
