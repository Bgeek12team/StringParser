using System;
using System.Collections.Generic;
using System.Linq;
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
            Queue<ExtentedToken> queue = new();
            Stack<ExtentedToken> stack = new();

            foreach (var token in infixTokens)
            {
                if (token.Type == ExtentedToken.TYPE.OP)
                {
                    queue.Enqueue(token);
                    continue;
                }
                if (token.Type == ExtentedToken.TYPE.BIN_OP)
                {
                    if (stack.Count == 0 || stack.Peek().Type == ExtentedToken.TYPE.LEFT_B)
                    {
                        stack.Push(token);
                        continue;
                    }
                    if (token.Priority > stack.Peek().Priority)
                    {
                        stack.Push(token);
                        continue;
                    }
                    else
                    {
                        ExtentedToken elem;
                        do
                        {
                            elem = stack.Pop();
                            queue.Enqueue(elem);
                        }
                        while (stack.Count != 0 && (elem.Type != ExtentedToken.TYPE.LEFT_B || elem.Priority > stack.Peek().Priority));
                        stack.Push(token);
                        continue;
                    }
                }
                if (token.Type == ExtentedToken.TYPE.LEFT_B)
                {
                    stack.Push(token);
                    continue;
                }
                if (token.Type == ExtentedToken.TYPE.RIGHT_B)
                {
                    var elem = stack.Pop();
                    while (elem.Type != ExtentedToken.TYPE.LEFT_B)
                    {
                        queue.Enqueue(elem);
                        if (stack.Count == 0)
                            break;
                        elem = stack.Pop();
                    }
                    //
                    continue;
                }

            }

            foreach (var elem in stack)
                queue.Enqueue(elem);

            return queue.ToArray();
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
