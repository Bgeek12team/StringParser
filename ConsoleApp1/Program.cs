using StringParser;

namespace P
{
   
    class P
    {
        static void Main()
        {
            string str = " ln ( sqrt( x^2 + 5*x + 6)  ) ";
            string eQstr = " ln( (x+2) * (x+3) ) / 2";

            const double x = 0;

            //ExtentedToken inner = ExtentedToken.ConvertFromExpression(str);
            //ExtentedToken outer = ExtentedToken.ConvertFromExpression("ln(x)");
            //var extentedToken = ExtentedToken.Merge(inner, outer);
            //Console.WriteLine(extentedToken.Val(x));

            ExpressionParser expressionParser = new(str);
            expressionParser.Parse();
            Console.WriteLine(expressionParser.CalcAt(x));

            Console.WriteLine(expressionParser.CalcAt(x + 1));

            Console.WriteLine(expressionParser.CalcAt(x + 2));

            ExpressionParser expressionParser2 = new(eQstr);
            expressionParser2.Parse();
            Console.WriteLine(expressionParser2.CalcAt(x));

            Console.WriteLine(expressionParser2.CalcAt(x + 1));

            Console.WriteLine(expressionParser2.CalcAt(x + 2));

        }
    }
}