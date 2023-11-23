using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringParser
{
    /// <summary>
    /// Класс, позволяющий обрабатывать математические выражения
    /// </summary>
    public class ExpressionParser
    {
        /// <summary>
        /// Обрабатываемая строка
        /// </summary>
        private string _parsableString;
        /// <summary>
        /// Итоговая функция
        /// </summary>
        private ExtentedToken _function;
        /// <summary>
        /// Конструктор, создающий обработчик на основе данной строки
        /// </summary>
        /// <param name="s"></param>
        public ExpressionParser(string s)
        {
            this._parsableString = s;
        }
        /// <summary>
        /// Функция, обрабатывающая строку, созадющая из строки
        /// выражение, значение которого можно вычислить
        /// </summary>
        public void Parse()
        {
            Token[] allTokens = Token.Tokenize(_parsableString);
            IList<ExtentedToken> resTokens = RecursiveParse(allTokens);
            _function = ExtentedToken.ConvertFromExpression(resTokens);
        }
        /// <summary>
        /// Функция, считающее значение обработанного выражения при данном х
        /// </summary>
        /// <param name="x">Значение переменной х</param>
        /// <returns>Значение обработанного выражения при данном х</returns>
        public double CalcAt(double x)
        {
            return _function.Val(x);
        }

        /// <summary>
        /// Функция для рекурсивного парсинга последовательности токенов
        /// </summary>
        /// <param name="tokens">Последовательность токенов</param>
        /// <returns>Последовательность ExtentedToken</returns>
        private IList<ExtentedToken> RecursiveParse(IList<Token> tokens)
        {
            var res = new List<ExtentedToken>();

            for (int i = 0; i < tokens.Count; i++)
            {
                if (tokens[i].Type != Token.TYPE.FUNCTION
                    && tokens[i].Type != Token.TYPE.UNARY_OPERATOR)
                {
                    res.Add(ExtentedToken.ConvertFromToken(tokens[i]));
                    continue;
                }
                else
                {
                    Token[] function = Functionaze(tokens[i]);
                    Token[] arg = GetArg(i, tokens);
                    ExtentedToken outer = ExtentedToken.ConvertFromExpression(function);
                    ExtentedToken inner;
                    if (!ContainsBinaryOperator(arg))
                        inner = ExtentedToken.ConvertFromExpression(arg);
                    else
                        inner = ExtentedToken.ConvertFromExpression(RecursiveParse(arg));
                    res.Add(ExtentedToken.Merge(inner, outer));
                    i += arg.Length;
                }
            }

            return res;
        }
        /// <summary>
        /// Функция, добавляющая к токену функции аргумент
        /// </summary>
        /// <param name="function">Токен функции</param>
        /// <returns>Массив токенов, состоящий из функции, скобок и перменной</returns>
        private static Token[] Functionaze(Token function)
        {
            return Token.Tokenize(function.TokenString + "(x)");
        }
        /// <summary>
        /// Проверяет, содержится ли в последовательности токенов 
        /// бинарный оператор
        /// </summary>
        /// <param name="tokens">Последовательность токенов</param>
        /// <returns>содержится ли в последовательности токенов 
        /// бинарный оператор</returns>
        private static bool ContainsBinaryOperator(IEnumerable<Token> tokens)
        {
            foreach(var token in tokens)
            {
                if (token.Type == Token.TYPE.BINARY_OPERATOR)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// Находит аргумент функции в последовательности токенов
        /// </summary>
        /// <param name="funcIndex">Индекс функции</param>
        /// <param name="tokens">Последовательность токенов</param>
        /// <returns>Аргумент функции в последовательности токенов</returns>
        private static Token[] GetArg(int funcIndex, IList<Token> tokens)
        {
            List<Token> result = new List<Token>();
            int balance = 0;
            for(int i = funcIndex + 1; i < tokens.Count; i++)
            {
                if (tokens[i].Type == Token.TYPE.L_BRACE)
                    balance++;
                else if (tokens[i].Type == Token.TYPE.R_BRACE)
                    balance--;
                result.Add(tokens[i]);
                if (balance == 0)
                    break;
            }

            return result.ToArray() ;
        }

    }
}
