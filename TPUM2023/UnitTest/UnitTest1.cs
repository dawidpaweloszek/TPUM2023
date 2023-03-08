using TPUM;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAdd()
        {
            Calculator calculator = new Calculator();
            int sum = calculator.Add(2, 2);
            Assert.AreEqual(4, sum);
        }
    }
}