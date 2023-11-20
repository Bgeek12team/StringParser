using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringParser
{
    /// <summary>
    /// Класс токен, представляющий собой значимое выражение
    /// </summary>
    internal class Token
    {
        const double EULER_MASCHERONI = 0.57721566490153286060;
        /// <summary>
        /// Константа, принимаемая за независимую переменную
        /// </summary>
        public const string variable = "x";
        /// <summary>
        /// Типы токенов
        /// </summary>
        public enum TYPE
        {
            BINARY_OPERATOR, // оператор бинарный
            UNARY_OPERATOR, // унарный оператор (унарный минус)
            INT_NUM, // целое число
            FLOAT_NUM, // число с плав запятой
            FUNCTION, // функция
            L_BRACE, //левая скобка
            R_BRACE, //правая скобка
            COMMA, // запятая для аргументов функций (может пригодится)
            VARIABLE // переменная x
        }

       
        private TYPE _type;
        /// <summary>
        /// Тип текущего токена
        /// </summary>
        public TYPE Type { get => this._type; }

        private string _token;
        /// <summary>
        /// Строка, отображающая токен
        /// </summary>
        public string TokenString { get => this._token; }
        /// <summary>
        /// Конструктор, создающий токен на основе строки и ее типа
        /// </summary>
        /// <param name="str"></param>
        /// <param name="type"></param>
        private Token(string str, TYPE type)
        {
            this._token = str;
            this._type = type;
        }
        /// <summary>
        /// Функция, извлекающая из строки массив токенов
        /// </summary>
        /// <param name="str">Обрабатываемая строка</param>
        /// <returns>Массив токенов, представляющий строку</returns>
        public static Token[] Tokenize(string str)
        {
            List<Token> tokens = new List<Token>();

            int lastToken = 0;
            for(int i = 0; i < str.Length; i++)
            {
                if (str[i] == ' ')
                {
                    continue;
                }
                if (Char.IsDigit(str[i]))
                {
                    ParseNum(str, ref lastToken, ref i, tokens);
                }
                CheckIfE(str, ref i);
                CheckIfPi(str, ref i);
                string parsableString = str.Substring(lastToken, i - lastToken);

                if (TryParseToken(parsableString, out Token token)) {
                    tokens.Add(token);
                    lastToken = i;
                }
            }
            string rem = str.Substring(lastToken);
            if (TryParseToken(rem, out Token token2))
            {
                tokens.Add(token2);
            }

            CheckForUnary(tokens);

            return tokens.ToArray();
        }
        private static void CheckIfPi(string str, ref int i)
        {
            if (i >= str.Length - 1)
                return;
            if (str[i] == 'p' && str[i+1] == 'i')
            {
                if (i >= str.Length - 7)
                    return;
                if (str.Substring(i, 6) == "pifunc")
                {
                    i += 6;
                    return;
                }
                return;
            }
        }
        private static void CheckIfE(string str, ref int i)
        {
            if (i >= str.Length - 1)
                return;
            if (str[i] == 'e')
            {
                if (i >= str.Length - 3)
                    return;
                if (str[i+1] == 'x' && str[i+2] == 'p')
                {
                    i += 2;
                    return;
                }
                return;
            }
        }
        /// <summary>
        /// Преобразует необходимые бинарные минусы в унарные 
        /// в данном списке токенов
        /// </summary>
        /// <param name="tokens">Список рассматриваемых токенов</param>
        private static void CheckForUnary(List<Token> tokens)
        {
            for (int i = 0; i < tokens.Count; i++)
            {
                if (tokens[i].TokenString == "-")
                {
                    if (i == 0 || tokens[i - 1].Type == TYPE.L_BRACE)
                        tokens[i]._type = TYPE.UNARY_OPERATOR;
                }
            }
        }
       /// <summary>
       /// Осуществляет обработку чисел
       /// </summary>
       /// <param name="str">Обрабатываемая строка</param>
       /// <param name="lastToken">Индекс последнего токена в строке</param>
       /// <param name="i">Изменяемый индекс i в строке</param>
       /// <param name="tokens">Список обрабаываемых токенов</param>
        private static void ParseNum(string str, ref int lastToken, ref int i, List<Token> tokens)
        {
            string remainderBeforeDigit = str.Substring(lastToken, i - lastToken);

            if (TryParseToken(remainderBeforeDigit, out Token token3))
            {
                tokens.Add(token3);
                lastToken = i;
            }

            int pointCounter = 0;
            while (pointCounter < 2)
            {
                i++;
                if (i >= str.Length)
                    break;
                if (Char.IsDigit(str[i]))
                {
                    continue;
                }
                else if (str[i] == '.')
                    pointCounter++;
                else
                    break;
            }
        }
        /// <summary>
        /// Осуществляет, если он возможен, приведение строки к Токену
        /// </summary>
        /// <param name="str">Обрабатываемая строка</param>
        /// <param name="token">Выходной токен - результат приведения</param>
        /// <returns>
        /// True: приведение возможно
        /// False: приведение невозможно
        /// </returns>
        private static bool TryParseToken(string str, out Token token)
        {
            str = str.Trim().ToLower();
            if (int.TryParse(str, out int res))
            {
                token = new Token(str, TYPE.INT_NUM);
                return true;
            }
            if (double.TryParse(str.Replace('.', ','), out double resD))
            {
                token = new Token(str, TYPE.FLOAT_NUM);
                return true;
            }
            switch (str)
            {
                case "+":
                    token = new Token("+", TYPE.BINARY_OPERATOR);
                    return true;
                case "-":
                    token = new Token("-", TYPE.BINARY_OPERATOR);
                    return true;
                case "/":
                    token = new Token("/", TYPE.BINARY_OPERATOR);
                    return true;
                case "*":
                    token = new Token("*", TYPE.BINARY_OPERATOR);
                    return true;
                case "^":
                    token = new Token("^", TYPE.BINARY_OPERATOR);
                    return true;
                case "%":
                    token = new Token("%", TYPE.BINARY_OPERATOR);
                    return true;
                case "√":
                case "sqrt":
                    token = new Token("sqrt", TYPE.FUNCTION);
                    return true;
                case "ln":
                    token = new Token("ln", TYPE.FUNCTION);
                    return true;
                case "sin":
                    token = new Token("sin", TYPE.FUNCTION);
                    return true;
                case "cos":
                    token = new Token("cos", TYPE.FUNCTION);
                    return true;
                case "tg":
                    token = new Token("tg", TYPE.FUNCTION);
                    return true;
                case "ctg":
                    token = new Token("ctg", TYPE.FUNCTION);
                    return true;
                case "exp":
                    token = new Token("exp", TYPE.FUNCTION);
                    return true;
                case "fact":
                    token = new Token("fact", TYPE.FUNCTION);
                    return true;
                case "(":
                    token = new Token("(", TYPE.L_BRACE);
                    return true;
                case ")":
                    token = new Token(")", TYPE.R_BRACE);
                    return true;
                case variable:
                    token = new Token("x", TYPE.VARIABLE);
                    return true;
                case "e":
                    token = new Token(Math.E.ToString(), TYPE.FLOAT_NUM);
                    return true;
                case "γ":
                    token = new Token(EULER_MASCHERONI.ToString(), TYPE.FLOAT_NUM);
                    return true;
                case "π":
                case "pi":
                    token = new Token(Math.PI.ToString(), TYPE.FLOAT_NUM);
                    return true;
                case "Γ":
                case "gamma":
                    token = new Token("gamma", TYPE.FUNCTION);
                    return true;
                case "pifunc":
                    token = new Token("pifunc", TYPE.FUNCTION);
                    return true;
                case "ζ":
                case "zeta":
                    token = new Token("zeta", TYPE.FUNCTION);
                    return true;



            }
            token = null;
            return false;
        }
        /// <summary>
        /// Возвращает строковое представление токена
        /// </summary>
        /// <returns>Тип токена и строку, его представляющую</returns>
        public override string ToString()
        {
            return $"{_token} : {_type}";
        }
    }
}
