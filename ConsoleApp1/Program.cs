using StringParser;

namespace P
{
   
    class P
    {
        static void Main()
        {

            const int x = 3;
            string str = "-ln(x) + sqrt(exp(7) / ln(x) * (-2/5)";
            Token[] tokens = Token.Tokenize(str);
            foreach (var token in tokens)
                Console.WriteLine(token);

            List<Token> tokns = new List<Token>();
            List<Operator> operators = new List<Operator>();
            for(int i = 0; i < tokens.Length; i++)
            {
                if (tokens[i].Type != Token.TYPE.BINARY_OPERATOR)
                {
                    tokns.Add(tokens[i]);
                } 
                else
                {
                    Token[] resList = new Token[tokns.Count];
                    tokns.CopyTo(resList, 0);
                    operators.Add(new Operator(resList));
                    tokns.Clear();
                }
            }

            operators.Add(new Operator(tokns));
            tokns.Clear();

            Console.WriteLine();
            foreach (var op in operators)
            {
                Console.Write(op + "; res = ");
                Console.WriteLine(op.CactAt(x));
            }
        }
    }
}