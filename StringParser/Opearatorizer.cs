using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringParser
{
    public class ExtentedToken
    {
        public enum TYPE
        {
            BIN_OP,
            OP,
            LEFT_B,
            RIGHT_B,
        }

        private TYPE _type;

        public TYPE Type
        {
            get => _type;
        }

        private int _priority;
        public int Priority
        {
            get => _priority;
        }

        public delegate double CalcAt(double x);

        public CalcAt Val;

        public string _stringVal;

        public string StringVal
        {
            get => _stringVal;
        }

        private ExtentedToken(CalcAt function)
        {
            this.Val = function;
            _type = TYPE.OP;
            _stringVal = function.ToString();
        }

        private ExtentedToken(Operator op) // для OP
        {
            _type = TYPE.OP;
            Val = new(op.CactAt);
            _stringVal = op.ToString();
        }

        private ExtentedToken(int priority, string s) // для BIN_OP
        {
            _type = TYPE.BIN_OP;
            _priority = priority;
            _stringVal = s;
        }

        private ExtentedToken(Token token, int balance) //для скобок
        {
            _type = (TYPE)((int)token.Type-3);
            _stringVal = token.TokenString;
            _priority = balance;
        }
        public static ExtentedToken[] ToExtentedTokenArr(string str)
        {
            Token[] tokens = Token.Tokenize(str);
            
            List<ExtentedToken> operators = new List<ExtentedToken>();

            List<Token> operatorList = new();

            int level = 0;
            for(int i = 0; i < tokens.Length; i++)
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

        private static int DefinePriority(Token token)
        {
            switch(token.TokenString)
            {
                case "+":
                case "-":
                    return 1;
                case "/":
                case "*":
                    return 3;
                case "^":
                    return 5;
            }
            return -1;
        }

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
            }
            throw new Exception("!!");

        }
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
