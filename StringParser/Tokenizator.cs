using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringParser
{
    public class Token
    {
        public const string variable = "x";
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

        public TYPE Type { get => this._type; }

        private string _token;

        public string TokenString { get => this._token; }

        private Token(string str, TYPE type)
        {
            this._token = str;
            this._type = type;
        }

        public static Token[] Tokenize(string str)
        {
            List<Token> tokens = new();

            int lastToken = 0;
            for(int i = 0; i < str.Length; i++)
            {
                if (str[i] == ' ')
                {
                    continue;
                }
                string parsableString = str.Substring(lastToken, i - lastToken);
                if (TryParseToken(parsableString, out Token token)) {
                    tokens.Add(token);
                    lastToken = i;
                }
            }

            for (int i = 0; i < tokens.Count; i++)
            {
                if (tokens[i].TokenString == "-")
                {
                    if (i == 0 || tokens[i - 1].Type == TYPE.L_BRACE)
                        tokens[i]._type = TYPE.UNARY_OPERATOR;
                }
            }

            return tokens.ToArray();
        }

        private static bool TryParseToken(string str, out Token token)
        {
            str = str.Trim().ToLower();
            if (int.TryParse(str, out int res))
            {
                token = new Token(str, TYPE.INT_NUM);
                return true;
            }
            if (double.TryParse(str, out double resD))
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

            }
            token = null;
            return false;
        }

        public override string ToString()
        {
            return $"{_token} : {_type}";
        }
    }
}
