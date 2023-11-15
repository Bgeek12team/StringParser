﻿using StringParser;
using System.Linq;

namespace form
{
    public partial class Form1 : Form
    {
        // private int maxSymbols;
        private bool inputState;
        private (int x, int y) normalSize = (310, 400);
        private Button[] numbButton;
        private string[] operations = {"sin", "cos", "tg", "ctg", "ln", "exp"};
        public Form1()
        {
            InitializeComponent();
            Size = new Size(normalSize.x, normalSize.y);
            numbButton = numbArrayFill();
            inputState = true;
            assignEvents();
        }

        private Button[] numbArrayFill()
        {
            List<Button> buttons = new List<Button>();
            foreach (var button in groupBox1.Controls.OfType<Button>()) { buttons.Add(button); }
            IEnumerable<Button> tButtin = buttons.Where(button => button.Tag == "numb");
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
            button11.Visible = true;
            button10.Visible = true;
            Size = new Size(normalSize.x + 390, normalSize.y);
        }

        private void buttonCalc_Click(object sender, EventArgs e)
        {
            buttonCalc.Enabled = false;
            buttonGraph.Enabled = true;
            button11.Visible = false;
            button10.Visible = false;
            txBxInput.Left -= label1.Width;
            label1.Visible = false;
            Size = new Size(normalSize.x, normalSize.y);
        }
        private void buttonFuncEvent()
        {
            if (inputState)
            {
                inputState = false;
                buttonFunc.Text = "Numb";
                foreach (var oper in operations)
                    numbButton[Array.IndexOf(operations, oper)].Text = oper;
            } 
            else 
            {
                buttonFunc.Text = "Func";
                inputState = true;
                for (int i = 0; i < 6; i++)
                    numbButton[i].Text = Convert.ToString(10 - (i + 1));
            }
        }
        private void buttonResEvent()
        {
            Performer performer = new(txBxInput.Text);
            MessageBox.Show("Нет ты хуй!");
        }
        private void buttonDelEvent()
        {
            if (txBxInput.Text[txBxInput.Text.Length - 1] == ' ')
                txBxInput.Text = txBxInput.Text[..^1];
            txBxInput.Text = txBxInput.Text[..^1];
        }
    }
}