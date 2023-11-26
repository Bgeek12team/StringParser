using expressionParser;
using StringParser;
using System.Data.Common;

namespace ParserTests
{
    [TestClass]
    public class UnitTest1
    {
        public void TestMethod()
        {

        }

    }
    [TestClass]
    public class UnitTestRomich
    {
        /// <summary>
        /// Тест, проверяющий тригонометрическое тождество
        /// sin(x)^2 + cos(x)^2 = 1
        /// </summary>
        [TestMethod]
        public void TestIdentity()
        {
            ExpressionParser ex = new ExpressionParser("(sin(x)) ^ 2 + (cos(x)) ^ 2");
            ex.Parse();

            Assert.AreEqual(ex.CalcAt(0), 1);
        }
        /// <summary>
        /// Тест, проверяющий хуй знает что, вот попадется вам такой ряд на матане
        /// и сидите проверяйте его даламбером на сходимость пол часа
        /// и потом 1 получите и посмотрим как вы запоётё
        /// </summary>
        [TestMethod]
        public void TestRecursiveParse()
        {
            ExpressionParser ex = new ExpressionParser("(ln(ln(ln(6*sqrt(cos(x))))))");
            ex.Parse();

            Assert.AreEqual(ex.CalcAt(2*Math.PI), -0.5392283891321652);
        }
        /// <summary>
        /// Assert.AreEqual failed. Expected:<не число>. Actual:<не число>.
        /// Больше мне нечего сказать
        /// </summary>
        [TestMethod]
        public void TestRecursiveParse1()
        {
            ExpressionParser ex = new ExpressionParser("(ln(ln(ln(x))))");
            ex.Parse();

            Assert.AreEqual(ex.CalcAt(0).ToString(), "не число");
        }
        /// <summary>
        /// Тест, проверяющий значение гамма-функции в нуле
        /// </summary>
        [TestMethod]
        public void TestGammaInZero()
        {
            Assert.AreEqual(Ariphmetics.Gamma(0, 2), double.PositiveInfinity);
        }
        /// <summary>
        /// Тест, проверяющий значение гамма-функции в -∞
        /// Арифметикс гамма насрал мне на лицо:
        /// Assert.AreEqual failed. Expected:<не число>. Actual:<не число>.
        /// 
        /// </summary>
        [TestMethod]
        public void TestGammaInNegativeNumber()
        {
            Assert.AreEqual(Ariphmetics.Gamma(double.NegativeInfinity, 2).ToString(), "не число");
        }
        [TestMethod]
        public void TestPiFunc()
        {
            Assert.AreEqual(Ariphmetics.Pi(100), 25);
        }
        [TestMethod]
        public void TestPiFuncZero()
        {
            Assert.AreEqual(Ariphmetics.Pi(0), 0);
        }
        [TestMethod]
        public void TestPiFuncInfinity()
        {
            Assert.AreEqual(Ariphmetics.Pi(10000), 1229);
        }
    }

}