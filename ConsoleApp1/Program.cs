using StringParser;

namespace P
{
   
    class P
    {
        static void Main()
        {

            const int x = 3;
            string str = "ln(sqrt(x)) + 5 / 7";

            
            foreach (var op in ExtentedToken.ToExtentedTokenArr(str))
            {
                Console.WriteLine(op.ToString());
            }
            
        }
    }
}