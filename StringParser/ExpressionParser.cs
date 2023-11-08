using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringParser
{
    public class ExpressionParser
    {
        private string _parsableString;

        private ExtentedToken _function;

        public ExpressionParser(string s)
        {
            this._parsableString = s;
        }

        public void Parse()
        {
            Token[] allTokens = Token.Tokenize(_parsableString);
            IList<ExtentedToken> resTokens = RecursiveParse(allTokens);
            _function = ExtentedToken.ConvertFromExpression(resTokens);
        }

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
                    {
                        inner = ExtentedToken.ConvertFromExpression(arg);
                    }
                    else
                    {
                        inner = ExtentedToken.ConvertFromExpression(RecursiveParse(arg));
                    }
                    res.Add(ExtentedToken.Merge(inner, outer));
                    i += arg.Length;
                }
            }

            return res;
        }

        private static Token[] Functionaze(Token function)
        {
            return Token.Tokenize(function.TokenString + "(x)");
        }

        private static bool ContainsBinaryOperator(IEnumerable<Token> tokens)
        {
            foreach(var token in tokens)
            {
                if (token.Type == Token.TYPE.BINARY_OPERATOR)
                    return true;
            }
            return false;
        }

        private static Token[] GetArg(int funcIndex, IList<Token> tokens)
        {
            List<Token> result = new List<Token>();
            int balance = 0;
            for(int i = funcIndex + 1; i < tokens.Count; i++)
            {
                if (tokens[i].Type == Token.TYPE.L_BRACE)
                {
                    balance++;
                }
                else if (tokens[i].Type == Token.TYPE.R_BRACE)
                {
                    balance--;
                }
                result.Add(tokens[i]);
                if (balance == 0)
                    break;
            }

            return result.ToArray() ;
        }

        public double CalcAt(double x)
        {
            return _function.Val(x);
        }
    }
}
