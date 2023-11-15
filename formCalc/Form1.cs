using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace formCalc
{
    public partial class Form1 : Form
    {
        // private int maxSymbols;
        private bool inputState;
        private (int x, int y) normalSize = (310, 400);
        private Button[] numbButton;
        private string[] operations = { "sin", "cos", "tg", "ctg", "ln", "exp", "ζ", "Г", "π" };
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
                    case "dx":
                        button.Click += (sender, e) => txBxInput.Text += ")dx"; break;
                    case "√":
                        button.Click += (sender, e) => txBxInput.Text += "sqrt("; break;
                    case "x²":
                        button.Click += (sender, e) => txBxInput.Text += "( ^ )"; break;
                    case "Результат":
                        button.Click += (sender, e) => buttonResEvent(); break;
                    case "Func":
                        button.Click += (sender, e) => buttonFuncEvent(); break;
                    default:
                        button.Click += (sender, e) => txBxInput.Text += (operButtons.Contains(button.Text) ? $" {button.Text.ToLower()} " : button.Text.ToLower()); break;
                }
            }

        }



        private void txBxInput_TextChanged(object sender, EventArgs e)
        {

        }


        private void buttonGraph_Click(object sender, EventArgs e)
        {
            buttonCalc.Enabled = true;
            buttonGraph.Enabled = false;
            txBxInput.Left += label1.Width;
            label1.Visible = true;
            button10.Visible = true;
            button11.Visible = true;
            groupBoxGraph.Visible = true;
            Size = new Size(normalSize.x + 500, normalSize.y + 200);
        }

        private void buttonCalc_Click(object sender, EventArgs e)
        {
            buttonCalc.Enabled = false;
            buttonGraph.Enabled = true;
            button10.Visible = false;
            button11.Visible = false;
            txBxInput.Left -= label1.Width;
            label1.Visible = false;
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
            MessageBox.Show("Нет ты хуй!");
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void buttonGraphCreate_Click(object sender, EventArgs e)
        {
            groupBoxGraph.Visible = false;
            buttonGraphReset.Visible = true;
            chart1.Visible = true;
            var chrt = new graph(double.Parse(txBxXmin.Text), double.Parse(txBxXmax.Text), double.Parse(txBxStep.Text), "sin");
            chrt.graphCreate(ref chart1);


        }

        private void buttonGraphReset_Click(object sender, EventArgs e)
        {
            groupBoxGraph.Visible = true;
            chart1.Visible = false;
            buttonGraphReset.Visible = false;
        }
    }
    partial class graph : Control
    {
        private double xmin;
        private double xmax;
        private double step;
        private string func;

        public graph(double xmin, double xmax, double step, string func)
        {
            this.xmin = xmin;
            this.xmax = xmax;
            this.step = step;
            this.func = func;
        }

        public void graphCreate(ref Chart chrt)
        {
            double x = xmin;
            chrt.Series.Clear();
            chrt.Series.Add("Sin");
            chrt.Series[0].ChartType = SeriesChartType.Spline;
            chrt.Series[0].BorderWidth = 3;
            while (x <= xmax)
            {
                chrt.Series[0].Points.AddXY(x, Math.Sin(x));
                x += step;
            }
        }
    }
}
