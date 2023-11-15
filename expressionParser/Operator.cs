using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringParser
{

    /// <summary>
    /// Класс оператор - последовательности обыкновенных токенов,
    /// не содержащей бинарных операторов, значение которой можно вычислить
    /// для данного х
    /// </summary>
    internal class Operator
    {
        const double PRECISION = 0.0001;
        static int DIGITS_AFTER_ZERO = 5;
        /// <summary>
        /// Список токенов, лежащий в основе оператора
        /// </summary>
        private List<Token> _baseTokens;
        /// <summary>
        /// Словарь строковых отображений функций и их делегаты
        /// </summary>
        private Dictionary<string, Func<double, double>> doubleFunctions = new Dictionary<string, Func<double, double>>()
        {
            {"ln", (a) => Math.Log(a) },
            {"exp", (a) => Math.Exp(a) },
            {"sin", (a) => Math.Sin(a) },
            {"cos", (a) => Math.Cos(a) },
            {"tg", (a) => Math.Tan(a) },
            {"ctg", (a) => Math.Pow(Math.Tan(a), -1) },
            {"fact", (a) => Ariphmetics.Factorial(a) },
            {"sqrt", (a) => Math.Sqrt(a) },
            {Token.variable.ToString(), (a) => a },
            {"-", (a) => -a },
            {"zeta", (a) => Ariphmetics.Zeta(a) },
            {"pifunc", (a) => Ariphmetics.Pi(a) },
            {"gamma", (a) => Ariphmetics.Gamma(a, DIGITS_AFTER_ZERO) }
        };

        /// <summary>
        /// Конструктор, создающий экземпляр объекта на основе последовательности токенов
        /// </summary>
        /// <param name="tokens">Последовательность токенов</param>
        public Operator(IEnumerable<Token> tokens)
        {
            this._baseTokens = tokens.ToList();
        }
        /// <summary>
        /// Вычисляет значение оператора для данного х
        /// </summary>
        /// <param name="x">Данный х</param>
        /// <returns>Значение оператора при данном х</returns>
        /// <exception cref="Exception">Исключение, возникающее, когда последовательность
        /// токенов невозможно преобразовать в целое выражение</exception>
        public double CactAt(double x)
        {
            Stack<Token> stack = new Stack<Token>();
            foreach (Token token in _baseTokens)
                if (token.Type != Token.TYPE.R_BRACE &&
                    token.Type != Token.TYPE.L_BRACE)
                {
                    stack.Push(token);
                    continue;
                }
            
            double res;
            if (stack.Peek().Type == Token.TYPE.FLOAT_NUM)
                res = double.Parse(stack.Pop().TokenString.Replace('.', ','));
            else if (stack.Peek().Type == Token.TYPE.INT_NUM)
                res = int.Parse(stack.Pop().TokenString); 
            else if (stack.Peek().Type == Token.TYPE.VARIABLE)
                res = x;
            else
                throw new Exception("Невозможно распарсить строку!");

            foreach (Token token in stack)
            {
                res = doubleFunctions[token.TokenString].Invoke(res);
            }
            return res;
        }
        /// <summary>
        /// Возвращает строковое представление оператора, 
        /// включающее в себя его токены
        /// </summary>
        /// <returns>Строковое представление оператора, 
        /// включающее в себя его токены</returns>
        public override string ToString()
        {
            StringBuilder res = new StringBuilder("{");
            foreach(var token in _baseTokens)
            {
                res.Append(token.ToString() + ";");
            }
            res.Append("}");
            return res.ToString();
        }
    }
}
