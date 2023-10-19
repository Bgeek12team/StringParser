using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringParser
{
    public abstract class Token
    {
        protected const char VARIABLE = 'x';
        public abstract string ProcessingString { get; }

        public abstract int Start { get; }

        public abstract int End { get; }

        public abstract bool IsFinal { get; }
    }

    public class Operator : Token
    {
        private string _str;

        public override string ProcessingString 
        {
            get => _str; 
        }

        private int start;

        public override int Start
        {
            get => start;
        }

        private int end;

        public override int End
        {
            get => end;
        }
        public override bool IsFinal
        {
            get => false;
        }

        public Operator(string s)
        {
            this._str = s;
            start = 0;
            end = s.Length;
        }

        public Operator(string str, int start, int end)
        {
            this._str = str;
            this.start = start;
            this.end = end;
        }
    }

    public class FinalOperator : Token
    {
        private string _str;

        public override string ProcessingString
        {
            get => _str;
        }

        private int start;

        public override int Start
        {
            get => start;
        }

        private int end;

        public override int End
        {
            get => end;
        }
        public override bool IsFinal
        {
            get => true;
        }

        public FinalOperator(string str, int start, int end)
        {
            this._str = str;
            this.start = start;
            this.end = end;
        }

        public UnaryFunction ExctractFunction()
        {
            if (double.TryParse(_str, out double result))
            {
                return new UnaryFunction(result);
            }
            else if (_str == VARIABLE.ToString())
                return new UnaryFunction();
            throw new 
                Exception($"Unable to parse token {_str}");
        }

    }
}
