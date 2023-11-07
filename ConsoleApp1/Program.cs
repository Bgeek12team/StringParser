using StringParser;

namespace P
{
   
    class P
    {
        static void Main()
        {
            string str = " 5 * sin(cos(x))";

            const double x = 0;

            ExtentedToken inner = ExtentedToken.ConvertFromExpression(str);
            ExtentedToken outer = ExtentedToken.ConvertFromExpression("ln(x)");
            var extentedToken = ExtentedToken.Merge(inner, outer);
            Console.WriteLine(extentedToken.Val(x));
            
        }
    }
}