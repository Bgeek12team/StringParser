using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace StringParser
{
    /// <summary>
    /// Класс, представляющий собой расширенный токен - 
    /// произвольное выражение, значение которого можно вычислить,
    /// а также либо скобки либо бинарный оператор
    /// </summary>
    public class ExtentedToken
    {
        /// <summary>
        /// Тип токена, функция, которую он выполняет
        /// </summary>
        public enum TYPE
        {
            BIN_OP,
            OP,
            LEFT_B,
            RIGHT_B,
        }
        //
        private TYPE _type;
        /// <summary>
        /// Тип расширенного токена
        /// </summary>
        public TYPE Type
        {
            get => _type;
        }

        private int _priority;
        /// <summary>
        /// Приоритет бинарной операции в случае, если токен ее отображает
        /// </summary>
        public int Priority
        {
            get => _priority;
        }
        /// <summary>
        /// Значение токена при данном х
        /// </summary>
        public Func<double, double> Val;
        
        private string _stringVal;
        /// <summary>
        /// Строковое значение токена
        /// </summary>
        public string StringVal
        {
            get => _stringVal;
        }
        /// <summary>
        /// Конструктор токена-оператора
        /// </summary>
        /// <param name="function">Функция, лежащая в основе оператора</param>
        private ExtentedToken(Func<double, double> function) // OP
        {
            this.Val = function;
            _type = TYPE.OP;
            _stringVal = function.ToString();
        }
        /// <summary>
        /// Конструктор токена-оператора
        /// </summary>
        /// <param name="op">Оператор, лежащий в основе токена</param>
        private ExtentedToken(Operator op) // для OP
        {
            _type = TYPE.OP;
            Val = new(op.CactAt);
            _stringVal = op.ToString();
        }
        /// <summary>
        /// Конструктор для токена-бинарного оператора
        /// </summary>
        /// <param name="priority">Приоритет бинарного оператора</param>
        /// <param name="s">строка, представляющая бинарный оператор</param>
        private ExtentedToken(int priority, string s) // для BIN_OP
        {
            _type = TYPE.BIN_OP;
            _priority = priority;
            _stringVal = s;
        }
        /// <summary>
        /// Конструктор для токена-скобки
        /// </summary>
        /// <param name="token">Токен-скобка</param>
        /// <param name="balance">Уровень вложенности скобки</param>
        private ExtentedToken(Token token, int balance) //для скобок
        {
            _type = (TYPE)((int)token.Type-3);
            _stringVal = token.TokenString;
            _priority = balance;
        }
        /// <summary>
        /// Превращает данный токен в расширенный
        /// </summary>
        /// <param name="token">Данный токен</param>
        /// <returns>Расширенный токен</returns>
        public static ExtentedToken ConvertFromToken(Token token)
        {
            if (token.Type == Token.TYPE.R_BRACE || token.Type == Token.TYPE.L_BRACE)
                return new ExtentedToken(token, 0);
            else if (token.Type == Token.TYPE.BINARY_OPERATOR)
                return new ExtentedToken(DefinePriority(token), token.TokenString);
            else 
                return new ExtentedToken(new Operator(new List<Token>() { token }));
        }
        /// <summary>
        /// Превращает последовательность выражение, состоящее из алгребраической коомбинации
        /// сложных функций и констант в расширенный токен
        /// </summary>
        /// <param name="expression">Выражение в виде строки/param>
        /// <returns>Токен - отражение выражения</returns>
        public static ExtentedToken ConvertFromExpression(string expression)
        {
            ExtentedToken[] tokens = ToExtentedTokenArr(expression);
            return ConvertFromExpression(tokens);
        }
        /// <summary>
        /// Превращает последовательность выражение, состоящее из алгребраической коомбинации
        /// токенов - сложных функций и констант в расширенный токен
        /// </summary>
        /// <param name="expression">Выражение в виде последовательности токенов/param>
        /// <returns>Токен - отражение выражения</returns>
        public static ExtentedToken ConvertFromExpression(IEnumerable<Token> expression)
        {
            ExtentedToken[] tokens = ToExtentedTokenArr(expression);
            return ConvertFromExpression(tokens);
        }
        /// <summary>
        /// Превращает последовательность выражение, состоящее из алгребраической коомбинации
        /// расширенных токенов типа сложных функций и констант в расширенный токен
        /// </summary>
        /// <param name="expression">Выражение в виде последовательности расширенных токенов/param>
        /// <returns>Токен - отражение выражения</returns>
        public static ExtentedToken ConvertFromExpression(IEnumerable<ExtentedToken> expression)
        {
            Performer performer = new(expression);
            performer.Parse();
            return new((x) => performer.CalcAt(x));
        }
        /// <summary>
        /// Превращает последовательность токенов в массив расширенных токенов
        /// </summary>
        /// <param name="expression">последовательность токенов</param>
        /// <returns>массив расширенных токенов</returns>
        public static ExtentedToken[] ToExtentedTokenArr(IEnumerable<Token> expression)
        {
            Token[] tokens = expression.ToArray();

            List<ExtentedToken> operators = new List<ExtentedToken>();

            List<Token> operatorList = new();

            int level = 0;
            for (int i = 0; i < tokens.Length; i++)
            {

                if (tokens[i].Type == Token.TYPE.L_BRACE)
                {
                    level++;
                    operators.Add(new ExtentedToken(tokens[i], level));
                    continue;
                }
                if (tokens[i].Type == Token.TYPE.R_BRACE)
                {
                    level--;
                    operators.Add(new ExtentedToken(tokens[i], level));
                    continue;
                }
                if (tokens[i].Type == Token.TYPE.UNARY_OPERATOR ||
                    tokens[i].Type == Token.TYPE.FUNCTION ||
                    tokens[i].Type == Token.TYPE.INT_NUM ||
                    tokens[i].Type == Token.TYPE.VARIABLE ||
                    tokens[i].Type == Token.TYPE.FLOAT_NUM)
                {

                    int targetLevel = level;
                    operatorList.Add(tokens[i]);

                    if (tokens[i].Type == Token.TYPE.FUNCTION || tokens[i].Type == Token.TYPE.UNARY_OPERATOR)
                    {
                        // Парсинг внутренней
                        do
                        {
                            if (i < tokens.Length - 1)
                                i++;
                            else
                                break;
                            if (tokens[i].Type == Token.TYPE.L_BRACE)
                            {
                                level++;
                                operatorList.Add(tokens[i]);
                            }
                            if (tokens[i].Type == Token.TYPE.R_BRACE)
                            {
                                level--;
                                operatorList.Add(tokens[i]);
                            }
                            if (tokens[i].Type == Token.TYPE.UNARY_OPERATOR ||
                                tokens[i].Type == Token.TYPE.FUNCTION ||
                                tokens[i].Type == Token.TYPE.INT_NUM ||
                                tokens[i].Type == Token.TYPE.VARIABLE ||
                                tokens[i].Type == Token.TYPE.FLOAT_NUM)
                            {
                                operatorList.Add(tokens[i]);
                            }
                            if (level == targetLevel)
                                break;
                        } while (true);
                    }

                    Token[] opList = new Token[operatorList.Count];
                    operatorList.CopyTo(opList);
                    operators.Add(new ExtentedToken(new Operator(opList)));
                    operatorList.Clear();
                }
                if (tokens[i].Type == Token.TYPE.BINARY_OPERATOR)
                {
                    operators.Add(new ExtentedToken(DefinePriority(tokens[i]), tokens[i].TokenString));
                }
            }
            return operators.ToArray();

        }
        /// <summary>
        /// Превращает строку в последовательность токенов
        /// </summary>
        /// <param name="str">Строка</param>
        /// <returns>Массив токено</returns>
        public static ExtentedToken[] ToExtentedTokenArr(string str)
        {
            Token[] tokens = Token.Tokenize(str);
            return ToExtentedTokenArr(tokens);
            
        }
        /// <summary>
        /// Объединяет два токена, вызывая внутренний как аргумент внешнего
        /// </summary>
        /// <param name="origin">Внутренний токен</param>
        /// <param name="child">Внешний токен, в который в качестве аргумента передается внешний</param>
        /// <returns>Токен, объединивший внутренний и внешний</returns>
        public static ExtentedToken Merge(ExtentedToken origin, ExtentedToken child)
        {
            return new((x) => child.Val(origin.Val(x)));
        }
        /// <summary>
        /// Определяет приоритет токена-операции
        /// </summary>
        /// <param name="token">Токен</param>
        /// <returns>Приоритет операции в токене</returns>
        private static int DefinePriority(Token token)
        {
            return token.TokenString switch
            {
                "+" or "-" => 1,
                "/" or "*" => 3,
                "^" => 5,
                "%" => 7,
                _ => -1,
            };
        }
        /// <summary>
        /// Объединяет два токена в один на основе бинарной операции между ними
        /// </summary>
        /// <param name="first">Первый токен-операнд</param>
        /// <param name="second">Второй токен-операнд</param>
        /// <param name="operation">Бинарная операция между токенами</param>
        /// <returns>Токен, объединяющий два других на основе бинарной операции</returns>
        /// <exception cref="Exception">Исключение, возникающее в случае, если 
        /// токены невозможно объединить</exception>
        public static ExtentedToken Unify(ExtentedToken first, ExtentedToken second, ExtentedToken operation)
        {
            if (operation.Type != TYPE.BIN_OP 
                || first.Type != TYPE.OP || second.Type != TYPE.OP)
                throw new Exception("!!");

            switch (operation.StringVal) 
            {
                case "+":
                    return new ExtentedToken((x) => first.Val(x) + second.Val(x));
                case "-":
                    return new ExtentedToken((x) => first.Val(x) - second.Val(x));
                case "*":
                    return new ExtentedToken((x) => first.Val(x) * second.Val(x));
                case "/":
                    return new ExtentedToken((x) => first.Val(x) / second.Val(x));
                case "^":
                    return new ExtentedToken((x) => Math.Pow(first.Val(x), second.Val(x)));
                case "%":
                    return new ExtentedToken((x) => ((long)first.Val(x) % (long)second.Val(x)));
            }
            throw new Exception("!!");

        }
        /// <summary>
        /// Возвращает строку, отобращающую данный токен
        /// </summary>
        /// <returns>Строка, отображающая данный токен</returns>
        public override string ToString()
        {
            if (_type == TYPE.BIN_OP)
            {
                return $"BINARY OPERATOR : {_stringVal} : PRIORITY {_priority}";
            } 
            else if (_type == TYPE.LEFT_B)
            {
                return $"LEFT BRACE : {_stringVal} : {_priority}";
            }
            else if (_type == TYPE.RIGHT_B)
            {
                return $"RIGHT BRACE : {_stringVal} : {_priority}";
            }
            else
            {
                return $"OPERATOR : {_stringVal} : {Val.ToString()}";
            }
        }
    }
}
