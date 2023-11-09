using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StringParser
{
    /// <summary>
    /// Класс, позволяющий обработать выражение, состоящее из последовательности
    /// расширенных токенов, являющейся алгебраической коомбинацией сложных функций и констант,
    /// и вычислять его значение
    /// </summary>
    internal class Performer
    {
        /// <summary>
        /// Токен - представляющий собой итоговую функцию
        /// </summary>
        private ExtentedToken _function;
        /// <summary>
        /// Массив исходных токенов
        /// </summary>
        private ExtentedToken[] _tokens;
        /// <summary>
        /// Создает экземпляр класса от последовательности токенов
        /// </summary>
        /// <param name="tokens">Последовательность токенов</param>
        public Performer(IEnumerable<ExtentedToken> tokens)
        {
            this._tokens = tokens.ToArray();
        }
        /// <summary>
        /// Обрабатывает выражение, превращая ее в выражение, значение которого можно вычислить
        /// </summary>
        public void Parse()
        {
            ExtentedToken[] postfixTokens = ConvertToPostfix(_tokens);
            ExtractDelegate(postfixTokens);
        }
        /// <summary>
        /// Вычисляет значение выражения при данном х
        /// </summary>
        /// <param name="x">Данный х</param>
        /// <returns>Значение выражения при данном х</returns>
        public double CalcAt(double x)
        {
            return _function.Val(x);
        }
        /// <summary>
        /// Превращает инфиксную последовательности токенов в постфиксную
        /// </summary>
        /// <param name="infixTokens">Инфиксная последовательность токенов</param>
        /// <returns>Эквивалентная постфиксная последовательность токенов</returns>
        private ExtentedToken[] ConvertToPostfix(ExtentedToken[] infixTokens)
        {
            List<ExtentedToken> postfixExpression = new List<ExtentedToken>();
            Stack<ExtentedToken> operatorStack = new Stack<ExtentedToken>();

            foreach (var token in infixTokens)
            {
                if (token.Type == ExtentedToken.TYPE.OP)
                {
                    postfixExpression.Add(token);
                }
                else if (token.Type == ExtentedToken.TYPE.LEFT_B)
                {
                    operatorStack.Push(token);
                }
                else if (token.Type == ExtentedToken.TYPE.RIGHT_B)
                {
                    while (operatorStack.Count > 0 && operatorStack.Peek().Type != ExtentedToken.TYPE.LEFT_B)
                    {
                        postfixExpression.Add(operatorStack.Pop());
                    }
                    operatorStack.Pop(); 
                }
                else
                {
                    while (operatorStack.Count > 0 && operatorStack.Peek().Priority >= token.Priority)
                    {
                        postfixExpression.Add(operatorStack.Pop());
                    }
                    operatorStack.Push(token);
                }
            }

            while (operatorStack.Count > 0)
                postfixExpression.Add(operatorStack.Pop());
            

            return postfixExpression.ToArray();
        }
        /// <summary>
        /// Превращает токены в постфиксной записи в итоговую функцию
        /// </summary>
        /// <param name="postfixTokens">Токены в постфиксной записи</param>
        private void ExtractDelegate(ExtentedToken[] postfixTokens)
        {
            Stack<ExtentedToken> stack = new();
            foreach(var token in postfixTokens)
            {
                if (token.Type == ExtentedToken.TYPE.OP)
                    stack.Push(token);
                else
                {
                    var elem1 = stack.Pop();
                    var elem2 = stack.Pop();
                    stack.Push(ExtentedToken.Unify(elem2, elem1, token));
                }
            }
            _function = stack.Pop();
        }
    }
}
