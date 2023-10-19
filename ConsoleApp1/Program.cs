using StringParser;

namespace P
{
   
    class P
    {
        static void Main()
        {
            ComplexOperator cf = new ComplexOperator();
            cf += (x) => x + 5;
            cf += (x) => Math.Pow(x,2);

            Console.WriteLine(cf.CalcAt(5));
        }
    }
}