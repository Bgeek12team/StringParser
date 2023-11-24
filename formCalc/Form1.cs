using StringParser;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Threading.Tasks;
namespace formCalc
{
    public partial class Form1 : Form
    {
        // private int maxSymbols;
        private bool inputState;
        private (int x, int y) normalSize = (400, 600);
        private Button[] numbButton;
        private graph chrt;
        private string[] operations = { "sin", "cos", "tg", "ctg", "ln", "exp", "ζ", "Γ", "pifunc" };
        private ExpressionParser expressionParser;
        public Form1()
        {
            InitializeComponent();
            Size = new Size(normalSize.x, normalSize.y);
            numbButton = numbArrayFill();
            groupBoxGraph.Visible = false;
            inputState = true;
            assignEvents();
        }

        private Button[] numbArrayFill()
        {
            List<Button> buttons = new List<Button>();
            foreach (var button in groupBox1.Controls.OfType<Button>()) { buttons.Add(button); }
            IEnumerable<Button> tButtin = buttons.Where(button => button.Tag == "num");
            return tButtin.ToArray();
        }

        private void assignEvents()
        {

            string[] operButtons = { "+", "-", ":", "*", "/" };
            foreach (var button in groupBox1.Controls.OfType<Button>())
            {
                switch (button.Text)
                {
                    case "<-":
                        button.Click += (sender, e) => buttonDelEvent(); break;
                    case "√":
                        button.Click += (sender, e) => txBxInput.Text += "sqrt("; break;
                    case "x²":
                        button.Click += (sender, e) => txBxInput.Text += "( ^ )"; break;
                    case "Результат":
                        button.Click += (sender, e) => buttonResEvent(); break;
                    case "Func":
                        button.Click += (sender, e) => buttonFuncEvent(); break;
                    default:
                        button.Click += (sender, e) => txBxInput.Text += (operButtons.Contains(button.Text) ? $" {button.Text} " : button.Text); break;
                }
            }

        }
        private void buttonGraph_Click(object sender, EventArgs e)
        {
            buttonCalc.Enabled = true;
            buttonGraph.Enabled = false;
            txBxInput.Left += label1.Width;
            label1.Visible = true;
            groupBoxGraph.Visible = true;
            Size = new Size(normalSize.x + 1000, normalSize.y + 200);
        }

        private void buttonCalc_Click(object sender, EventArgs e)
        {
            buttonCalc.Enabled = false;
            buttonGraph.Enabled = true;
            txBxInput.Left -= label1.Width;
            label1.Visible = false;
            groupBoxIntg.Visible = false;
            groupBoxGraph.Visible = false;
            Size = new Size(normalSize.x, normalSize.y);
        }
        private void buttonFuncEvent()
        {
            if (inputState)
            {
                inputState = false;
                buttonFunc.Text = "Num";
                foreach (var oper in operations)
                    numbButton[Array.IndexOf(operations, oper)].Text = oper;
            }
            else
            {
                buttonFunc.Text = "Func";
                inputState = true;
                for (int i = 0; i < 9; i++)
                    numbButton[i].Text = Convert.ToString(10 - (i + 1));
            }
        }
        private void buttonResEvent()
        {
            //MessageBox.Show("Нет ты хуй!"); зачем боже
        }
        private void buttonDelEvent()
        {
            if (txBxInput.Text != String.Empty)
            {
                if (txBxInput.Text[txBxInput.Text.Length - 1] == ' ')
                    txBxInput.Text = txBxInput.Text.Remove(txBxInput.Text.Length - 1);
                txBxInput.Text = txBxInput.Text.Remove(txBxInput.Text.Length - 1);
            }
        }

        private void buttonGraphCreate_Click(object sender, EventArgs e)
        {
            expressionParser = new ExpressionParser(txBxInput.Text);
            try 
            { 
                expressionParser.Parse();
            } 
            catch {
                MessageBox.Show("Некорректный ввод!");
                return;
            };
            groupBoxGraph.Visible = false;
            groupBoxIntg.Visible = true;
            buttonGraphReset.Visible = true;
            buttonIntg.Visible = true;
            chart1.Visible = true;
            buttonIntg.Visible = true;
            buttonScaleDown.Visible = true;
            buttonScaleUp.Visible = true;
            buttonDown.Visible = true;
            buttonUp.Visible = true;
            chrt = new graph(double.Parse(txBxXmin.Text), double.Parse(txBxXmax.Text), double.Parse(txBxStep.Text),
                txBxInput.Text, expressionParser.CalcAt);
            chrt.graphCreate(chart1);

        }

        private void buttonGraphReset_Click(object sender, EventArgs e)
        {
            groupBoxGraph.Visible = true;
            chart1.Visible = false;
            buttonIntg.Visible = false;
            buttonScaleDown.Visible = false;
            buttonScaleUp.Visible = false;
            buttonDown.Visible = false;
            buttonUp.Visible = false;
            buttonGraphReset.Visible = false;
            groupBoxIntg.Visible = false;
        }

        private void txBxXmin_TextChanged(object sender, EventArgs e)
        {
            txBxStep.Text = calcStep().ToString();
        }

        private void txBxXmax_TextChanged(object sender, EventArgs e)
        {
            txBxStep.Text = calcStep().ToString();
        }
        private double calcStep()
        {
            double step = 
                double.TryParse(txBxXmax.Text, out double tValue) && double.TryParse(txBxXmin.Text, out double tValue2) ? (double.Parse(txBxXmax.Text) - double.Parse(txBxXmin.Text)) / 200 : 0;
            chrt.Step = step;
            return step;
        }

        private void buttonDown_Click(object sender, EventArgs e)
        {
            chrt.graphOfSetLeft(chart1);
        }

        private void buttonUp_Click(object sender, EventArgs e)
        {
            chrt.graphOfSetRight(chart1);
        }

        private void buttonScaleUp_Click(object sender, EventArgs e)
        {
            chrt.graphUpScale(chart1);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            chrt.graphDownScale(chart1);
        }

        private void buttonRes_Click(object sender, EventArgs e)
        {
            expressionParser = new ExpressionParser(txBxInput.Text);

            try { expressionParser.Parse(); }
            catch
            {
                MessageBox.Show("Некорректный ввод!");
                return;
            };
            txBxInput.Text = expressionParser.CalcAt(0).ToString();
        }

        private void buttonIntg_Click(object sender, EventArgs e) 
        { 
            MessageBox.Show(txBxStartIntg.Text == String.Empty || txBxEndIntg.Text == String.Empty ? "Некорректный ввод!" : Ariphmetics.Integrate(expressionParser.CalcAt, double.Parse(txBxStartIntg.Text), double.Parse(txBxEndIntg.Text), 100).ToString()); 
        }

        private void buttonAboutProgramm_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Данная программа разработана студентами группы Б.ПИН.РИС.2206 для обработки математических выражений," +
                "состоящих из произвольной последовательности сложных математических функций различной степени вложенности," +
                "бинарных операторов, унарных минусов, математических констант и скобок,5" +
                "а также построения их графиков. \nТребования к записи выражения:\n" +
                "1. Аргументы функции должны быть заключены в скорбки\n" +
                "2. Каждой открытой скобке должна соответсвовать одна закрытая скобка, и наоборот.\n" +
                "3. Для избежания неоднозначного толкования значений бинарных операторов рекомендуется " +
                "заключать сложные операнды в скобки.\n" +
                "4. Для построения графика доступна только переменная x.\n" +
                "5. При использовании переменной в режиме калькулятора её значение будет принято за 0.\n" +
                "6. Допускается использование только функций и операторов, которые находятся на форме.\n" +
                "однако существуют альтернативные записи для:\n" +
                "гамма-функции - gamma(x) \n" +
                "квадратного корня - sqrt(x) \n" +
                "дзета-функции - zeta(x) \n" +
                "константы пи - pi. \n" +
                "7. Десятичные дроби разделяются точкой.\n" +
                "При несоблюдении вышеописанных требований точность результата и его наличие НЕ гарантируется.\n" +
                "При попытке построить график в точках, где функция не определена либо уходит за пределы [-10^27: 10^27], " +
                "такие точки отображены не будут.");
        }
    }
    partial class graph
    {
        private double xmin;
        private double xmax;
        private double step;
        public double Step { get; set; }

        private string func;
        private double scale;
        private Func<double, double> function;
        private int steps;

        public graph(double xmin, double xmax, double step, string func, Func<double, double> function)
        {
            this.xmin = xmin;
            this.xmax = xmax;
            this.step = step;
            this.func = func;
            scale = Math.Abs((xmax - xmin) / 20);
            this.function = function;
            this.steps = (int)((xmax - xmin) / step);
        }

        public void graphCreate(Chart chrt)
        {
            graphReplace(chrt, 0,0);
        }
        public void graphOfSetLeft(Chart chrt)
        {
            graphReplace(chrt, scale, scale);
        }
        public void graphOfSetRight(Chart chrt)
        {
            graphReplace(chrt, -scale, -scale);
        }
        public void graphUpScale(Chart chrt)
        {
            graphReplace(chrt, -scale, scale);
        }
        public void graphDownScale(Chart chrt)
        {
            graphReplace(chrt, scale, -scale);
        }
        private void graphReplace(Chart chrt, double scaleXmin, double scaleXmax)
        {
            xmin -= scaleXmin;
            xmax -= scaleXmax;
            step = (xmax - xmin) / steps;
            double value;
            double x = xmin;
            chrt.Series[0].Points.Clear();
            int range = (int)((xmax - xmin) / step) + 1;
            if (range < 0)
                return;
            double[] values = new double[range];
            Parallel.For(0, range, i =>
            {
                try
                {
                    double res = function(xmin + i*step);
                    value = !double.IsInfinity(res) ? res : throw new Exception();
                    values[i] = value;
                }
                catch (Exception){ }
            });

            for(int i = 0; i < range; i++)
            {
                if (values[i] < 1E+27 && values[i] > -1E+27)
                    chrt.Series[0].Points.AddXY(xmin + i * step, values[i]);
            }
            /*
            while (x <= xmax)
            {
                try
                {
                    double res = function(x);
                    value = !double.IsInfinity(res) ? res : throw new Exception();
                }
                catch (Exception)
                {
                    x += step;
                    continue;
                }
                chrt.Series[0].Points.AddXY(x, Math.Round(value, 8));
                x += step;
            }
            */
            
        }
    }
}
