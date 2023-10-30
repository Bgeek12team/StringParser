using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringParser
{
    public class Operation
    {
        private ACTIONS op;
        private string s;
        public Operation(string s)
        {
            this.s = s;
        }

        private static Func<double, double> ParseOperation(OPERATIONS op)
        {
            switch (op)
            {
                case OPERATIONS.SIN:
                    return (x) => Math.Sin(x);
                case OPERATIONS.COS:
                    return (x) => Math.Cos(x);
                case OPERATIONS.TAN:
                    return (x) => Math.Tan(x);
                case OPERATIONS.COT:
                    return (x) => Math.Pow(Math.Tan(x), -1);
                case OPERATIONS.EXP:
                    return (x) => Math.Exp(x);
                case OPERATIONS.LOG:
                    return (x) => Math.Log(x);
                case OPERATIONS.SQRT:
                    return (x) => Math.Sqrt(x);
                case OPERATIONS.FACT:
                    return (x) => Fact(x);
                case OPERATIONS.ZETA:
                    return (x) => Zeta(x);
            }
            throw new Exception("компилятор иди нахуй");
        }

        private static int Zeta(double x)
        {
            return 1;
        }
        private static int Fact(double x)
        {
            int res = 1;
            for (int i = 1; i <= x; i++)
                res *= i;
            return res;
        }
    }
}
