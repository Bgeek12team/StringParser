using System.Collections;

namespace StringParser
{
    public enum ACTIONS
    {
        PLUS, MINUS, MULTIPLY, DIVIDE, POW//потрогал библиотеку классов
    }

    public enum OPERATIONS
    {
        SIN, COS, TAN, COT, EXP, LOG,
        SQRT, FACT
    }
    
    public enum FUNCTIONTYPE
    {
        UNARY, BINARY
    }

    public class StringParse
    {
        private string s;

        Stack<ACTIONS> actionsStack;

        public Stack<ACTIONS> ActionsStack
        {
            get { return actionsStack; }
        }

        Stack<string> operationsStack;

        public Stack<string> OperationsStack
        {
            get { return operationsStack; }
        }

        public StringParse(string s)
        {
            this.s = s.Trim().ToLower() ;
        }
        public List<string> GetPostFix()
        {
            var actionsConsequence = new List<string>();
            //...
            actionsConsequence.Add("2");
            actionsConsequence.Add("sin(cos(x) + tan(x))");
            actionsConsequence.Add(ACTIONS.MULTIPLY.ToString());
            //...
            return actionsConsequence;
        }
        public void FillStacks()
        {
            operationsStack = new();
            actionsStack = new();

            actionsStack.Push(ACTIONS.MULTIPLY);
            operationsStack.Push("2");
            operationsStack.Push("sin(cos(x) + tan(x))");
        }


    }

    public class OperationTEMP
    {
        private Func<double, double> func;
        private string s;
        public OperationTEMP(string s)
        {
            this.s = s;
        }

        public Func<double, double> Parse()
        {
            Stack<Func<double, double>> temp = new();
            throw new Exception();

        }
        private void Parse(Stack<Func<double, double>> temp, int end, int start)
        {
            if (end <= start)
            {
                throw new Exception($"Пустые скобки!");
            }

            StringParse sp = new(s.Substring(start, end - start));
            foreach(var subStr in sp.GetPostFix())
            {

            }

            for (int i = 0; i < (int)OPERATIONS.FACT; i++)
            {
                string op = ((OPERATIONS)i).ToString().ToLower();
                for (int j = start; j < end; j++)
                {
                    if (s.Substring(j, op.Length) == op)
                    {
                        int startBracket = j + op.Length - 1, endBracket = -1;
                        for (int k = end; k > j; k--)
                        {
                            if (s[k] == ')')
                            {
                                endBracket = k;
                                break;
                            }
                        }
                        if (endBracket == -1)
                        {
                            throw new Exception($"Закрывающая скобка для операции {op} не найдена");
                        }

                        temp.Push(ParseOperation((OPERATIONS)i));
                        Parse(temp, startBracket + 1, endBracket - 1);
                        return;
                    }
                    else if (double.TryParse(s.Substring(j, op.Length), out double res)) 
                    {
                        temp.Push((x) => res);
                        break;
                    }
                }
            }
            throw new Exception("Парсинг невозможен!");
        }

        private Func<double, double> ParseOperation(OPERATIONS op)
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
            }
            throw new Exception("компилятор иди нахуй");
        }

        private int Fact(double x)
        {
            int res = 1;
            for (int i = 1; i <= x; i++)
                res *= i;
            return res;
        }
    }

    public class Performer
    {
        private string str;
        private Func<double, double> resFunction;
        public Performer(string str)
        {
            this.str = str;
            Parse();
        }

        private void Parse()
        {
            Stack<Operator> operators = new();
            Stack<Function> functions = new();

            Operator cur = new Operator(str);
            operators.Push(cur);



        }

        public double Perform(double x)
        {
            return resFunction.Invoke(x);
        }
    }
}