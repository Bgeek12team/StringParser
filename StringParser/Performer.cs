using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringParser
{
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
            StringParse sp = new StringParse(str);

        }

        public double Perform(double x)
        {
            return x  * 2;
        }
    }

}
