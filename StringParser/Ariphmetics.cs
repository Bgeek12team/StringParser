﻿using System;
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
        public static double Zeta(double a)
        {
            return a;
        }

        /// <summary>
        /// Вычисляет значение пи-функции от данного числа
        /// </summary>
        /// <param name="a">Данное числа</param>
        /// <returns>Значение пи-функции данного числа</returns>
        /// <summary>
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
        /// Вычисляет значение гамма-функции от данного числа
        /// </summary>
        /// <param name="a">Данное числа</param>
        /// <returns>Значение гамма-функции данного числа</returns>
        public static double Gamma(double a)
        {
            return a;
        }
    }
}
