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

            //Хуйня, вырубай2
            //Миша сапожник

            Console.WriteLine(cf.CalcAt(5));
        }
        public void getMark()
        {
            Console.WriteLine("Вы призвали Маркелова");
        }
    }
}