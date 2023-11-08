using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StringParser
{
    public class Performer
    {
        private ExtentedToken _function;

        private ExtentedToken[] _tokens;

        public Performer(string s)
        {
            _tokens = ExtentedToken.ToExtentedTokenArr(s);
        }

        public Performer(IEnumerable<ExtentedToken> tokens)
        {
            this._tokens = tokens.ToArray();
        }

        public Performer(ExtentedToken token)
        {
            _function = token;
            _tokens = new ExtentedToken[] {token};
        }

        public void Parse()
        {
            ExtentedToken[] postfixTokens = ConvertToPostfix(_tokens);
            ExtractDelegate(postfixTokens);
        }

        public double CalcAt(double x)
        {
            return _function.Val(x);
        }

        private ExtentedToken[] ConvertToPostfix(ExtentedToken[] infixTokens)
        {
            List<ExtentedToken> postfixExpression = new List<ExtentedToken>();
            Stack<ExtentedToken> operatorStack = new Stack<ExtentedToken>();

            foreach (var c in infixTokens)
            {
                if (c.Type == ExtentedToken.TYPE.OP)
                {
                    postfixExpression.Add(c);
                }
                else if (c.Type == ExtentedToken.TYPE.LEFT_B)
                {
                    operatorStack.Push(c);
                }
                else if (c.Type == ExtentedToken.TYPE.RIGHT_B)
                {
                    while (operatorStack.Count > 0 && operatorStack.Peek().Type != ExtentedToken.TYPE.LEFT_B)
                    {
                        postfixExpression.Add(operatorStack.Pop());
                    }
                    operatorStack.Pop(); 
                }
                else
                {
                    while (operatorStack.Count > 0 && operatorStack.Peek().Priority >= c.Priority)
                    {
                        postfixExpression.Add(operatorStack.Pop());
                    }
                    operatorStack.Push(c);
                }
            }

            while (operatorStack.Count > 0)
            {
                postfixExpression.Add(operatorStack.Pop());
            }

            return postfixExpression.ToArray();
        }

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
