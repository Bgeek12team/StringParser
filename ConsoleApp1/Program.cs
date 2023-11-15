

namespace StringParser
{
   
    class P
    {
        static void Main()
        {
            string str = "pifunc(x) ";
            string eQstr = "pifunc(x) - sin(ln(x))";

            const double x = 2000000;

            /*
            
            
            ExtentedToken inner = ExtentedToken.ConvertFromExpression(s);
            ExtentedToken outer = ExtentedToken.ConvertFromExpression(f);
            var extentedToken = ExtentedToken.Merge(outer, inner);
            Console.WriteLine(extentedToken.Val(x));
            Console.WriteLine(inner.Val(15));
            */
            ExpressionParser expressionParser = new(eQstr);
            expressionParser.Parse();
            Console.WriteLine(expressionParser.CalcAt(x));

            Console.WriteLine(expressionParser.CalcAt(2 *x));

            Console.WriteLine(expressionParser.CalcAt(4 * x));

            Console.WriteLine(Ariphmetics.Integrate(expressionParser.CalcAt,
                100, 10000, 10000));
            ExpressionParser expressionParser2 = new(eQstr);
            expressionParser2.Parse();
            Console.WriteLine(expressionParser2.CalcAt(x));

            Console.WriteLine(expressionParser2.CalcAt(x + 1));

            Console.WriteLine(expressionParser2.CalcAt(x + 2));
            
        }
    }
}