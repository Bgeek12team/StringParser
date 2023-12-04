using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringParser
{
    /// <summary>
    /// Модуль, обеспечивающий некоторые особые математические
    /// возможности по работе с функциями
    /// </summary>
    public static class Ariphmetics
    {
        /// <summary>
        /// Возвращает значение интеграла даной функции на данном отрезке
        /// полученный методом Симпсона
        /// </summary>
        /// <param name="f">Интегрируемая функция</param>
        /// <param name="start">Начало интегрируемого отрезка</param>
        /// <param name="end">Конец интегрируемого отрезка</param>
        /// <param name="numSteps">Количество шагов при интеграции</param>
        /// <returns>Значение интеграла даной функции на данном отрезке</returns>
        public static double Integrate(Func<double, double> f, double start, double end,
            int numSteps)
        {
            double stepSize = (end - start) / numSteps;
            double result = 0.0;

            for (int i = 0; i < numSteps; i++)
            {
                double x0 = start + i * stepSize;
                double x1 = start + (i + 1) * stepSize;
                double xMid = (x0 + x1) / 2.0;

                result += stepSize / 6 * (f(x0) + 4 * f(xMid) + f(x1));
            }

            return result;
        }
        /// <summary>
        /// Вычисляет факториал от данного числа
        /// </summary>
        /// <param name="a">Данное числа</param>
        /// <returns>Факториал данного числа</returns>
        public static double Factorial(double a)
        {
            double res = 1;
            for (double i = 2; i <= a; i++)
                res *= i;
            return res;
        }

        /// <summary>
        /// Вычисляет значение дзета-функции от данного числа
        /// </summary>
        /// <param name="a">Данное числа</param>
        /// <returns>Значение дзета-функции данного числа</returns>
        public static double Zeta(double s)
        {
            double result = 0;
            double precision = 0.0000001;
            long n = 1;
            if (s > 1)
            {
                while (true)
                {
                    double temp = 1 / Math.Pow(n, s);
                    result += temp;

                    if (temp <= precision)
                        break;
                    n++;
                }
            }
            else
            {
                return double.PositiveInfinity;
            }
            return result;
        }

        /// Метод, находящий количество простых чисел, меньших либо равных
        /// действительному числу
        /// </summary>
        /// <param name="x">действительное число</param>
        /// <returns>возвращает кол-во простых чисел</returns>
        public static double Pi(double x)
        {
            return GetPrimeNumbersCount((int)x);
        }
        public static int GetPrimeNumbersCount(int n)
        {
            int count = 0;
            bool[] isNotPrime = new bool[n + 1];
            for (int j = 2; j * j <= n; j++)
                if (!isNotPrime[j])
                    for (int i = j * j; i <= n; i += j)
                        isNotPrime[i] = true;
            int start = 2;
            for (int i = start; i <= n; i++)
                if (!isNotPrime[i])
                    count++;
            return count;
        }
        /// <summary>
        /// Вычисляет значение гамма-функции от данного числа, с заданной
        /// точностью(метод Аппроксимация Ланцоша)
        /// </summary>
        /// <param name="a">Данное число в границах [1:171]</param>
        /// <param name="r">кол-во знаков после запятой</param>
        /// <returns>Значение гамма-функции данного числа</returns>
        public static double Gamma(double a, int r)
        {
            double[] coeff = {
            76.18009172947146, -86.50532032941677, 24.01409824083091,
            -1.231739572450155, 0.001208650973866179, -0.000005395239384953}; // массив коэффициентов при g = 5
            double y = a;
            double temp = a + 5.5;
            temp -= (a + 0.5) * Math.Log(temp);
            double ser = 1.000000000190015;// первый коэффициент
            for (int i = 0; i <= coeff.Length - 1; ++i)
                ser += coeff[i] / ++y;
            return Math.Round(Math.Exp(-temp + Math.Log(2.5066282746310005) + Math.Log(ser / a)),r);
        }
    }
}
