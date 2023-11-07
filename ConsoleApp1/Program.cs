using StringParser;

namespace P
{
   
    class P
    {
        static void Main()
        {
            string str = "sin(x) + cos(x)";

            Performer performer = new(str);
            performer.Parse();

            const double x = 0;
            double res = performer.CalcAt(x);

            Console.WriteLine(res);
            
        }
    }
}