using StringParser;


namespace ParserTests
{
    [TestClass]
    public class UnitTest
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

            Assert.AreEqual(ex.CalcAt(2 * Math.PI), -0.5392283891321652);
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
        /// <summary>
        /// Метод проверяющий вычесление интеграла от (sin(x))^2 в границах (0,10)
        /// </summary>
        [TestMethod]
        public void IntegrateSin()
        {
            ExpressionParser ex = new ExpressionParser("(sin(x))^2");
            ex.Parse();
            Func<double, double> func = ex.CalcAt;
            double result = Ariphmetics.Integrate(func, 0, 10, 100);
            Assert.AreEqual(Math.Round(result, 2), 4.77);
        }
        /// <summary>
        /// Метод проверяющий вычесление интеграла от (sin(x))^2 в границах (0,)
        /// </summary>
        [TestMethod]
        public void IntegrateSin2()
        {
            ExpressionParser ex = new ExpressionParser("(sin(x))^2");
            ex.Parse();
            Func<double, double> func = ex.CalcAt;
            double result = Ariphmetics.Integrate(func, 0, 0, 100);
            Assert.AreEqual(result, 0);
        }
        /// <summary>
        /// Метод проверяющий вычесление интеграла от (cos(x))^2 в границах (0,10)
        /// </summary>
        [TestMethod]
        public void IntegrateCos()
        {
            ExpressionParser ex = new ExpressionParser("(cos(x))^2");
            ex.Parse();
            Func<double, double> func = ex.CalcAt;
            double result = Ariphmetics.Integrate(func, 0, 10, 100);
            Assert.AreEqual(Math.Round(result, 2), 5.23);
        }
        /// <summary>
        /// Метод проверяющий вычесление интеграла от (cos(x))^5 в границах (1,100)
        /// </summary>
        [TestMethod]
        public void IntegrateCos1()
        {
            ExpressionParser ex = new ExpressionParser("(cos(x))^5");
            ex.Parse();
            Func<double, double> func = ex.CalcAt;
            double result = Ariphmetics.Integrate(func, 1, 100, 100);
            Assert.AreEqual(Math.Round(result, 2), -0.96);
        }
        /// <summary>
        /// Метод проверяющий вычесление интеграла от (cos(x))^0 в границах (1,100)
        /// </summary>
        [TestMethod]
        public void IntegrateCos2()
        {
            ExpressionParser ex = new ExpressionParser("(cos(x))^0");
            ex.Parse();
            Func<double, double> func = ex.CalcAt;
            double result = Ariphmetics.Integrate(func, 1, 100, 100);
            Assert.AreEqual(Math.Round(result, 2), 99);
        }
        /// <summary>
        /// Метод проверяющий натурального логарифма в границах от (1,10)
        /// </summary>
        [TestMethod]
        public void IntegrateLn1()
        {
            ExpressionParser ex = new ExpressionParser("ln(x)");
            ex.Parse();
            Func<double, double> func = ex.CalcAt;
            double result = Ariphmetics.Integrate(func, 1, 10, 100);
            Assert.AreEqual(Math.Round(result, 2), 14.03);
        }
        /// <summary>
        /// Метод проверяющий натурального логарифма в границах от (1,100000)
        /// </summary>
        [TestMethod]
        public void IntegrateLn2()
        {
            ExpressionParser ex = new ExpressionParser("(ln(x))^4");
            ex.Parse();
            Func<double, double> func = ex.CalcAt;
            double result = Ariphmetics.Integrate(func, 1, 100000, 100);
            Assert.AreEqual(Math.Round(result), 1280288600);
        }
        /// <summary>
        /// Метод проверяющий вычисление интеграла от 0
        /// </summary>
        [TestMethod]
        public void IntegrateZero()
        {
            ExpressionParser ex = new ExpressionParser("0");
            ex.Parse();
            Func<double, double> func = ex.CalcAt;
            double result = Ariphmetics.Integrate(func, 0, 100000, 100);
            Assert.AreEqual(Math.Round(result), 0);
        }
        /// <summary>
        /// Метод проверяющий вычисление интеграла от 1
        /// </summary>
        [TestMethod]
        public void IntegrateOne()
        {
            ExpressionParser ex = new ExpressionParser("1");
            ex.Parse();
            Func<double, double> func = ex.CalcAt;
            double result = Ariphmetics.Integrate(func, 1, 100000, 100);
            Assert.AreEqual(Math.Round(result), 99999);
        }
        /// <summary>
        /// Метод проверяющий интеграла sqrt(x)
        /// </summary>
        [TestMethod]
        public void IntegrateSqrt()
        {
            ExpressionParser ex = new ExpressionParser("sqrt(x)");
            ex.Parse();
            Func<double, double> func = ex.CalcAt;
            double result = Ariphmetics.Integrate(func, 1, 100, 100);
            Assert.AreEqual(Math.Round(result), 666);
        }
        /// <summary>
        /// Метод проверяющий интеграла sqrt(x),границы (0, 25123)
        /// </summary>
        [TestMethod]
        public void IntegrateSqrt1()
        {
            ExpressionParser ex = new ExpressionParser("sqrt(x)");
            ex.Parse();
            Func<double, double> func = ex.CalcAt;
            double result = Ariphmetics.Integrate(func, 0, 25123, 100);
            Assert.AreEqual(Math.Round(result), 2654589);
        }
        /// <summary>
        /// Метод проверяющий нахождение факториала числа 10
        /// </summary>
        [TestMethod]
        public void Factorial()
        {
            Assert.AreEqual(Ariphmetics.Factorial(10), 3628800);
        }
        /// <summary>
        /// Метод проверяющий нахождение факториала числа -10
        /// </summary>
        [TestMethod]
        public void Factorial1()
        {
            Assert.AreEqual(Ariphmetics.Factorial(-10), 1);
        }
        /// <summary>
        /// Метод проверяющий нахождение факториала числа 0
        /// </summary>
        [TestMethod]
        public void FactorialZero()
        {
            Assert.AreEqual(Ariphmetics.Factorial(0), 1);
        }
        /// <summary>
        /// Метод проверяющий вычисление дзета функции от 5
        /// </summary>
        [TestMethod]
        public void ZetaTests()
        {
            Assert.AreEqual(Math.Round(Ariphmetics.Zeta(5), 2), 1.04);
        }
        /// <summary>
        /// Метод проверяющий вычисление дзета функции от 100000
        /// </summary>
        [TestMethod]
        public void ZetaTests1()
        {
            Assert.AreEqual(Math.Round(Ariphmetics.Zeta(100000)), 1);
        }
        /// <summary>
        /// Метод проверяющий вычисление дзета функции от 1.01
        /// </summary>
        [TestMethod]
        public void ZetaTestsDouble()
        {
            Assert.AreEqual(Math.Round(Ariphmetics.Zeta(1.01)), 15);
        }

        /// <summary>
        /// Метод проверяющий вычисление дзета функции от 1.01
        /// </summary>
        [TestMethod]
        public void ZetaTestsNegative()
        {
            Assert.AreEqual(Math.Round(Ariphmetics.Zeta(1.01)), 15);
        }


    }

}