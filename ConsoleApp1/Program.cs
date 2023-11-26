using expressionParser;
using StringParser;

namespace P
{
   
    class P
    {
        static void Main()
        {
            ExpressionParser ex = new ExpressionParser("(sin(x)) ^ 2 + (cos(x)) ^ 2");
            ex.Parse();
            Console.WriteLine(ex.CalcAt(1));
            Console.WriteLine(ex.CalcAt(2));
            Console.WriteLine(ex.CalcAt(3));

            Console.WriteLine(Ariphmetics.Integrate(x => Math.Pow(Math.Tan(x), 2), 1, 10, 1000000));
        }
        public void getMark()
        {
            Console.WriteLine("Вы призвали Маркелова");
        }
    }
}