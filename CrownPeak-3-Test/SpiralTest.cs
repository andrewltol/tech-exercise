using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CrownPeak_3;

namespace CrownPeak_3_Test
{
    [TestClass]
    public class SpiralTest
    {
        [TestMethod]
        public void RowColumnCountsAsExpected()
        {
            var spiral = new SpiralCountdown(24);
            Assert.AreEqual(5, spiral.Rows);
            Assert.AreEqual(5, spiral.Columns);

            spiral = new SpiralCountdown(40);
            Assert.AreEqual(6, spiral.Rows);
            Assert.AreEqual(7, spiral.Columns);

            spiral = new SpiralCountdown(0);
            Assert.AreEqual(1, spiral.Rows);
            Assert.AreEqual(1, spiral.Columns);

            spiral = new SpiralCountdown(1);
            Assert.AreEqual(1, spiral.Rows);
            Assert.AreEqual(2, spiral.Columns);
        }

        [DataTestMethod]
        [DataRow(-1)]
        [DataRow(-500)]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AbortInvalidValues(int value)
        {
            var spiral = new SpiralCountdown(value);
        }
    }
}

/*
 *          20  21  22  23  24  25
 *      40  19  6   7   8   9   26
 *      39  18  5   0   1   10  27
 *      38  17  4   3   2   11  28
 *      37  16  15  14  13  12  29
 *      36  35  34  33  32  31  30
 */