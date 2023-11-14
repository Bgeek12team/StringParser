

namespace StringParser
{
   
    class P
    {
        static void Main()
        {
            string str = "pifunc(x) ";
            string eQstr = " ln( (x+2) * (x+3) ) / 2 ";

            const double x = 2;

            /*
            
            
            ExtentedToken inner = ExtentedToken.ConvertFromExpression(s);
            ExtentedToken outer = ExtentedToken.ConvertFromExpression(f);
            var extentedToken = ExtentedToken.Merge(outer, inner);
            Console.WriteLine(extentedToken.Val(x));
            Console.WriteLine(inner.Val(15));
            */
            ExpressionParser expressionParser = new(str);
            expressionParser.Parse();
            Console.WriteLine(expressionParser.CalcAt(x));

            Console.WriteLine(expressionParser.CalcAt(2 *x));

            Console.WriteLine(expressionParser.CalcAt(4 * x));

            ExpressionParser expressionParser2 = new(eQstr);
            expressionParser2.Parse();
            Console.WriteLine(expressionParser2.CalcAt(x));

            Console.WriteLine(expressionParser2.CalcAt(x + 1));

            Console.WriteLine(expressionParser2.CalcAt(x + 2));
            
        }
    }
}