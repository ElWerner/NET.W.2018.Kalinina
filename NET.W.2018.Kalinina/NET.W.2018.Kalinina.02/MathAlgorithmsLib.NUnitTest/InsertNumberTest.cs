using System;
using NUnit.Framework;

namespace MathAlgorithmsLib.NUnitTest
{
    [TestFixture]
    public class InsertNumberTest
    {
        [Test]
        public void InsertNumber_Source15Inserted15From0To0_15Expected()
        {
            int expected = 15;
            int actual = MathAlgorithms.InsertNumber(15, 15, 0, 0);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void InsertNumber_Source8Inserted15From0To0_9Expected()
        {
            int expected = 9;
            int actual = MathAlgorithms.InsertNumber(8, 15, 0, 0);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void InsertNumber_Source8Inserted15From3To8_120Expected()
        {
            int expected = 120;
            int actual = MathAlgorithms.InsertNumber(8, 15, 3, 8);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void InsertNumber_Source8Inserted15FromM7ToM5_ArgumentOutOfRangeExceptionExpected()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => MathAlgorithms.InsertNumber(8, 15, -7, -5));
        }

        [Test]
        public void InsertNumber_Source15Inserted15From35To0_ArgumentOutOfRangeExceptionExpected()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => MathAlgorithms.InsertNumber(15, 15, 0, 35));
        }

    }
}
