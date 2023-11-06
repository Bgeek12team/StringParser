using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringParser
{

    
    public class Operator
    {
        private Dictionary<string, Func<double, double>> doubleFunctions = new()
        {
            {"ln", (a) => Math.Log(a) },
            {"exp", (a) => Math.Exp(a) },
            {"sin", (a) => Math.Sin(a) },
            {"cos", (a) => Math.Cos(a) },
            {"tg", (a) => Math.Tan(a) },
            {"ctg", (a) => Math.Pow(Math.Tan(a), -1) },
            {"fact", (a) => Factorial((int)a) },
            {"sqrt", (a) => Math.Sqrt(a) },
            {Token.variable.ToString(), (a) => a },
            {"-", (a) => -a }
        };


        private static int Factorial(int a)
        {
            int res = 1;
            for (int i = 2; i <= a; i++)
                res *= i;
            return res;
        }

        private List<Token> _baseTokens;
        public Operator(IEnumerable<Token> tokens)
        {
            this._baseTokens = tokens.ToList();
        }
        public double CactAt(double x)
        {
            Stack<Token> stack = new Stack<Token>();
            foreach (Token token in _baseTokens)
            {
                if (token.Type != Token.TYPE.R_BRACE &&
                    token.Type != Token.TYPE.L_BRACE)
                {
                    stack.Push(token);
                    continue;
                }
            }

            if (stack.Peek().Type == Token.TYPE.FLOAT_NUM)
            {
                double res = double.Parse(stack.Pop().TokenString);
                foreach (Token token in stack)
                {
                    res = doubleFunctions[token.TokenString].Invoke(res);
                }
                return res;
            }
            if (stack.Peek().Type == Token.TYPE.INT_NUM)
            {
                double res = int.Parse(stack.Pop().TokenString);
                foreach (Token token in stack)
                {
                    res = doubleFunctions[token.TokenString].Invoke(res);
                }
                return res;
            } 
            if (stack.Peek().Type == Token.TYPE.VARIABLE)
            {
                double res = x;
                foreach (Token token in stack)
                {
                    res = doubleFunctions[token.TokenString].Invoke(res);
                }
                return res;
            }
            else
            {
                throw new Exception("Невозможно распарсить строку!");
            }
        }

        public override string ToString()
        {
            StringBuilder res = new("{");
            foreach(var token in _baseTokens)
            {
                res.Append(token.ToString() + ";");
            }
            res.Append("}");
            return res.ToString();
        }
    }
}
