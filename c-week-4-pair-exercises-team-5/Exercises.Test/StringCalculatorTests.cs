using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercises.Test
{
    [TestClass]
    public class StringCalculatorTests
    {
        StringCalculator sc;

        [TestInitialize]
        public void TestInit()
        {
            sc = new StringCalculator();
        }

        [TestMethod]
        public void ZeroNumbers()
        {
            Assert.AreEqual(0, sc.Add(""));
        }

        [TestMethod]
        public void OneNumber()
        {
            Assert.AreEqual(1, sc.Add("1"));
        }

        [TestMethod]
        public void TwoNumbers()
        {
            Assert.AreEqual(3, sc.Add("1,2"));
        }

        [TestMethod]
        public void UnlimitedNumbers()
        {
            Assert.AreEqual(24, sc.Add("5,7,12"));
            Assert.AreEqual(17, sc.Add("6,2,1,8"));
            Assert.AreEqual(17, sc.Add("3,5,9"));
        }

        [TestMethod]
        public void MultipleDelimiters()
        {
            Assert.AreEqual(10, sc.Add("5\n3,2"));
            Assert.AreEqual(14, sc.Add("3\n5\n2,4"));
            Assert.AreEqual(14, sc.Add("3\n5\n2,6"));
        }

        [TestMethod]
        public void CustomDelimiter()
        {
            Assert.AreEqual(3, sc.Add("//;\n1;2"));
            Assert.AreEqual(13, sc.Add("//!\n4!9"));
        }
    }
}
