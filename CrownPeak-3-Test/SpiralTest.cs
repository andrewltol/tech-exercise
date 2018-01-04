using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CrownPeak_3;

namespace CrownPeak_3_Test
{
    [TestClass]
    public class SpiralTest : SpiralCountdown
    {
        private int _writeCount = 0;

        public SpiralTest() : base(0) { }

        public SpiralTest(int spiralNumber) : base(spiralNumber) { }

        protected override void OutputNumberAsString(int number)
        {
            ++_writeCount;
        }

        [TestMethod]
        public void RowColumnCountsAsExpected()
        {
            var spiral = new SpiralTest(24);
            spiral.CalculateSpiralDimensions();
            Assert.AreEqual(5, spiral.Rows);
            Assert.AreEqual(5, spiral.Columns);

            spiral = new SpiralTest(40);
            spiral.CalculateSpiralDimensions();
            Assert.AreEqual(6, spiral.Rows);
            Assert.AreEqual(7, spiral.Columns);

            spiral = new SpiralTest(0);
            spiral.CalculateSpiralDimensions();
            Assert.AreEqual(1, spiral.Rows);
            Assert.AreEqual(1, spiral.Columns);

            spiral = new SpiralTest(1);
            spiral.CalculateSpiralDimensions();
            Assert.AreEqual(1, spiral.Rows);
            Assert.AreEqual(2, spiral.Columns);

            spiral = new SpiralTest(100);
            spiral.CalculateSpiralDimensions();
            Assert.AreEqual(10, spiral.Rows);
            Assert.AreEqual(11, spiral.Columns);
        }

        [DataTestMethod]
        [DataRow(-1)]
        [DataRow(-500)]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AbortInvalidValues(int value)
        {
            var spiral = new SpiralTest(value);
            spiral.CalculateSpiralDimensions();
        }

        [DataTestMethod]
        [DataRow(20)]
        [DataRow(100)]
        [DataRow(1000)]
        public void NumberSpiralsOutward(int value)
        {
            var spiral = new SpiralTest(value);
            spiral.CalculateSpiralDimensions();
            spiral.DetermineNumberLocations();

            // Confirm pattern through first group of values.  Assume patterns holds afterwards.
            int originX = (spiral.Columns - 1) / 2;
            int originY = (spiral.Rows - 1) / 2;
            Assert.AreEqual(0, spiral._spiralValue[originX, originY]);
            Assert.AreEqual(1, spiral._spiralValue[originX + 1, originY]);
            Assert.AreEqual(2, spiral._spiralValue[originX + 1, originY + 1]);
            Assert.AreEqual(3, spiral._spiralValue[originX, originY + 1]);
            Assert.AreEqual(4, spiral._spiralValue[originX - 1, originY + 1]);
            Assert.AreEqual(5, spiral._spiralValue[originX - 1, originY]);
            Assert.AreEqual(6, spiral._spiralValue[originX - 1, originY - 1]);
            Assert.AreEqual(7, spiral._spiralValue[originX, originY - 1]);
            Assert.AreEqual(8, spiral._spiralValue[originX + 1, originY - 1]);
            Assert.AreEqual(9, spiral._spiralValue[originX + 2, originY - 1]);
            Assert.AreEqual(10, spiral._spiralValue[originX + 2, originY]);
            Assert.AreEqual(11, spiral._spiralValue[originX + 2, originY + 1]);
            Assert.AreEqual(12, spiral._spiralValue[originX + 2, originY + 2]);
            Assert.AreEqual(13, spiral._spiralValue[originX + 1, originY + 2]);
            Assert.AreEqual(14, spiral._spiralValue[originX, originY + 2]);
            Assert.AreEqual(15, spiral._spiralValue[originX - 1, originY + 2]);
            Assert.AreEqual(16, spiral._spiralValue[originX - 2, originY + 2]);
            Assert.AreEqual(17, spiral._spiralValue[originX - 2, originY + 1]);
            Assert.AreEqual(18, spiral._spiralValue[originX - 2, originY]);
            Assert.AreEqual(19, spiral._spiralValue[originX - 2, originY - 1]);
            Assert.AreEqual(20, spiral._spiralValue[originX - 2, originY - 2]);
        }

        [DataTestMethod]
        [DataRow(20)]
        [DataRow(100)]
        [DataRow(1000)]
        public void SpiralWroteAllNumbers(int value)
        {
            var spiral = new SpiralTest(value);
            spiral.CalculateAndPrintSpiral();

            // Check that there were enough write commands to write all numbers, including zero.
            Assert.IsTrue(spiral._writeCount == value + 1);
        }
    }
}

/* Example spiral
 * 
 *          72  73  74  75  76  77  78  79  80  81
 *          71  42  43  44  45  46  47  48  49  82
 *          70  41  20  21  22  23  24  25  50  83
 *          69  40  19  6   7   8   9   26  51  84
 *          68  39  18  5   0   1   10  27  52  85
 *          67  38  17  4   3   2   11  28  53  86
 *          66  37  16  15  14  13  12  29  54  87
 *          65  36  35  34  33  32  31  30  55  88
 *          64  63  62  61  60  59  58  57  56  89
 *      100 99  98  97  96  95  94  93  92  91  90
 */