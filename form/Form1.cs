using System.Text;

namespace form
{
    public partial class Form1 : Form
    {
        private int maxSymbols;
        public Form1()
        {
            InitializeComponent();
            maxSymbols = 16;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txBxInput.Text += "1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txBxInput.Text += "2";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txBxInput.Text += "3";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txBxInput.Text += "4";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            txBxInput.Text += "5";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            txBxInput.Text += "6";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            txBxInput.Text += "7";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            txBxInput.Text += "8";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            txBxInput.Text += "9";
        }

        private void buttonMult_Click(object sender, EventArgs e)
        {
            txBxInput.Text += " * ";
        }

        private void buttonFrac_Click(object sender, EventArgs e)
        {
            txBxInput.Text += "( / )";
        }
        private void buttonDiv_Click(object sender, EventArgs e)
        {
            txBxInput.Text += " : ";
        }

        private void buttonDeg_Click(object sender, EventArgs e)
        {
            txBxInput.Text += " √( ";
        }

        private void buttonRoot_Click(object sender, EventArgs e)
        {
            txBxInput.Text += "( ^2)";
            
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            txBxInput.Text += " + ";
        }

        private void button0_Click(object sender, EventArgs e)
        {
            txBxInput.Text += "0";
        }

        private void buttonRes_Click(object sender, EventArgs e)
        {
            
        }

        private void txBxInput_TextChanged(object sender, EventArgs e)
        {
            autoScaleUp();
            autoScaleDown(15);
        }

        private void buttonDiff_Click(object sender, EventArgs e)
        {
            txBxInput.Text += " - ";
        }
        /// <summary>
        /// Метод, позволяющий увеличивать текстовое поле в зависимости от размера входной строки
        /// </summary>
        private void autoScaleUp()
        {
            
            if (txBxInput.Text.Length > maxSymbols)
            {
                txBxInput.Size = new Size(txBxInput.Width + (15 * (txBxInput.Text.Trim().Length - maxSymbols)), txBxInput.Height);
                maxSymbols += txBxInput.Text.Trim().Length - maxSymbols;
            }
        }
        /// <summary>
        /// Метод, позволяющий уменьшать текстовое поле в зависимости от размера входной строки
        /// </summary>
        /// <param name="zoomScale"></param>
        private void autoScaleDown(int zoomScale)
        {
            if (txBxInput.Text.Length > 16)
            {
                txBxInput.Size = new Size(txBxInput.Width - zoomScale, txBxInput.Height);
                maxSymbols -= 1;
            }
        }
        private void buttonDel_Click(object sender, EventArgs e)
        {
            int zoomScale = 15;
            if (txBxInput.Text[txBxInput.Text.Length - 1] == ' ')
            {
                txBxInput.Text = txBxInput.Text[..^1];
                zoomScale += 15;
                maxSymbols -= 1;
            }
            autoScaleDown(zoomScale);
            txBxInput.Text = txBxInput.Text[..^1];
            

        }

        private void buttonGraph_Click(object sender, EventArgs e)
        {
            buttonCalc.Enabled = true;
            buttonGraph.Enabled = false;
            txBxInput.Left += label1.Width;
            label1.Visible = true;
        }

        private void buttonCalc_Click(object sender, EventArgs e)
        {
            buttonCalc.Enabled = false;
            buttonGraph.Enabled = true;
            txBxInput.Left -= label1.Width;
            label1.Visible = false;
        }
    }
}