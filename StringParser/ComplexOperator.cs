using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringParser
{
    public class ComplexOperator
    {
        Queue<Func<double, double>> invokeList
            = new Queue<Func<double, double>> { };

        public Queue<Func<double, double>> InvokationList
        {
            get { return invokeList; }
        }

        private FUNCTIONTYPE fType = FUNCTIONTYPE.UNARY;
        public FUNCTIONTYPE Type
        {
            get { return fType; }
        }

        public ComplexOperator()
        {
            invokeList.Enqueue((x) => x);
        }

        public ComplexOperator(Func<double, double> func)
        {
            invokeList.Enqueue(func);
        }
        public ComplexOperator(double c)
        {
            invokeList.Enqueue((x) => c);
        }

        public ComplexOperator(ICollection<Func<double, double>> invokeList)
        {
            this.invokeList = (Queue<Func<double, double>>)invokeList;
        }

        public ComplexOperator(Queue<Func<double, double>> invokeList)
        {
            this.invokeList = invokeList;
        }

        public ComplexOperator(BinaryFunction bf)
        {
            invokeList.Enqueue((x) => bf.CalcAt(x));
        }


        public ComplexOperator Add(Func<double, double> func)
        {
            Queue<Func<double, double>> stack
                = new Queue<Func<double, double>>(invokeList);
            stack.Enqueue(func);
            return new ComplexOperator(stack);
        }

        public ComplexOperator Add(UnaryFunction func)
        {
            Queue<Func<double, double>> stack
                = new Queue<Func<double, double>>(invokeList);
            stack.Enqueue(func.Func);
            return new ComplexOperator(stack);
        }
        public static ComplexOperator operator +(ComplexOperator cf, Func<double, double> f)
        {
            return cf.Add(f);
        }

        public static ComplexOperator operator +(ComplexOperator cf, UnaryFunction f)
        {
            return cf.Add(f);
        }

        public double CalcAt(double x)
        {
            double res = x;
            foreach (var func in invokeList)
            {
                res = func(res);
            }
            return res;
        }
    }
}
