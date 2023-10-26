using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringParser
{
    public abstract class Function
    {
        public abstract FUNCTIONTYPE Type { get; }

        public abstract double CalcAt(double x);

    }
    public class UnaryFunction : Function
    {

        private Func<double, double> _function;

        public Func<double, double> Func
        {
            get { return _function; }
        }

        public override FUNCTIONTYPE Type
        {
            get { return FUNCTIONTYPE.UNARY; }
        }
        public UnaryFunction()
        {
            this._function = (x) => x; 
        }

        public UnaryFunction(Func<double, double> func)
        {
            this._function = func;
        }

        public UnaryFunction(double k)
        {
            _function = (x) => k;
        }

        public override double CalcAt(double x)
        {
            return _function(x);
        }
    }

    public class BinaryFunction : Function
    {
        private Function left;

        public Function Left
        {
            get { return this.left; }
        }

        private Function rigth;

        public Function Right
        {
            get { return this.rigth; }

        }
        private ACTIONS operation;

        public override FUNCTIONTYPE Type
        {
            get { return FUNCTIONTYPE.BINARY; }
        }
        
        public BinaryFunction(Function f1, Function f2, ACTIONS op)
        {
            this.left = f1;
            this.rigth = f2;
            this.operation = op;
        }

        public override double CalcAt(double x)
        {
            switch (operation)
            {
                case ACTIONS.PLUS:
                    return left.CalcAt(x) + rigth.CalcAt(x);

                case ACTIONS.MINUS:
                    return left.CalcAt(x) - rigth.CalcAt(x);

                case ACTIONS.MULTIPLY:
                    return left.CalcAt(x) * rigth.CalcAt(x);

                case ACTIONS.DIVIDE:
                    return left.CalcAt(x) / rigth.CalcAt(x);

                case ACTIONS.POW:
                    return Math.Pow(left.CalcAt(x), rigth.CalcAt(x));

            }
            throw new Exception("компилятор иди нахуй");
        }
    }
}
