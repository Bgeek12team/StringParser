namespace formCalc
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.txBxInput = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button14 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.buttonRes = new System.Windows.Forms.Button();
            this.buttonFunc = new System.Windows.Forms.Button();
            this.buttonDel = new System.Windows.Forms.Button();
            this.button18 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonFrac = new System.Windows.Forms.Button();
            this.buttonDiv = new System.Windows.Forms.Button();
            this.buttonMult = new System.Windows.Forms.Button();
            this.buttonDiff = new System.Windows.Forms.Button();
            this.buttonDeg = new System.Windows.Forms.Button();
            this.buttonRoot = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.buttonCalc = new System.Windows.Forms.Button();
            this.buttonGraph = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.buttonGraphCreate = new System.Windows.Forms.Button();
            this.txBxXmin = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txBxXmax = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txBxStep = new System.Windows.Forms.TextBox();
            this.groupBoxGraph = new System.Windows.Forms.GroupBox();
            this.buttonGraphReset = new System.Windows.Forms.Button();
            this.buttonScaleDown = new System.Windows.Forms.Button();
            this.buttonIntg = new System.Windows.Forms.Button();
            this.buttonDown = new System.Windows.Forms.Button();
            this.buttonUp = new System.Windows.Forms.Button();
            this.buttonScaleUp = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.groupBoxGraph.SuspendLayout();
            this.SuspendLayout();
            // 
            // txBxInput
            // 
            this.txBxInput.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txBxInput.Location = new System.Drawing.Point(16, 15);
            this.txBxInput.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txBxInput.Name = "txBxInput";
            this.txBxInput.Size = new System.Drawing.Size(349, 50);
            this.txBxInput.TabIndex = 0;
            this.txBxInput.Text = "";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(144, 199);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(60, 49);
            this.button1.TabIndex = 1;
            this.button1.Tag = "num";
            this.button1.Text = "2";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(76, 199);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(60, 50);
            this.button2.TabIndex = 2;
            this.button2.Tag = "num";
            this.button2.Text = "1";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button14);
            this.groupBox1.Controls.Add(this.button13);
            this.groupBox1.Controls.Add(this.button12);
            this.groupBox1.Controls.Add(this.buttonRes);
            this.groupBox1.Controls.Add(this.buttonFunc);
            this.groupBox1.Controls.Add(this.buttonDel);
            this.groupBox1.Controls.Add(this.button18);
            this.groupBox1.Controls.Add(this.button10);
            this.groupBox1.Controls.Add(this.button11);
            this.groupBox1.Controls.Add(this.button9);
            this.groupBox1.Controls.Add(this.buttonAdd);
            this.groupBox1.Controls.Add(this.buttonFrac);
            this.groupBox1.Controls.Add(this.buttonDiv);
            this.groupBox1.Controls.Add(this.buttonMult);
            this.groupBox1.Controls.Add(this.buttonDiff);
            this.groupBox1.Controls.Add(this.buttonDeg);
            this.groupBox1.Controls.Add(this.buttonRoot);
            this.groupBox1.Controls.Add(this.button7);
            this.groupBox1.Controls.Add(this.button8);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.button6);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(16, 121);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(351, 378);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Панель ввода";
            // 
            // button14
            // 
            this.button14.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button14.Location = new System.Drawing.Point(277, 199);
            this.button14.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(60, 49);
            this.button14.TabIndex = 26;
            this.button14.Text = "γ";
            this.button14.UseVisualStyleBackColor = true;
            // 
            // button13
            // 
            this.button13.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button13.Location = new System.Drawing.Point(277, 144);
            this.button13.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(60, 49);
            this.button13.TabIndex = 25;
            this.button13.Text = "X";
            this.button13.UseVisualStyleBackColor = true;
            // 
            // button12
            // 
            this.button12.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button12.Location = new System.Drawing.Point(144, 256);
            this.button12.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(60, 49);
            this.button12.TabIndex = 24;
            this.button12.Text = "%";
            this.button12.UseVisualStyleBackColor = true;
            // 
            // buttonRes
            // 
            this.buttonRes.Location = new System.Drawing.Point(9, 313);
            this.buttonRes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonRes.Name = "buttonRes";
            this.buttonRes.Size = new System.Drawing.Size(328, 48);
            this.buttonRes.TabIndex = 23;
            this.buttonRes.Text = "Результат";
            this.buttonRes.UseVisualStyleBackColor = true;
            this.buttonRes.Click += new System.EventHandler(this.buttonRes_Click);
            // 
            // buttonFunc
            // 
            this.buttonFunc.Location = new System.Drawing.Point(212, 256);
            this.buttonFunc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonFunc.Name = "buttonFunc";
            this.buttonFunc.Size = new System.Drawing.Size(125, 48);
            this.buttonFunc.TabIndex = 22;
            this.buttonFunc.Text = "Func";
            this.buttonFunc.UseVisualStyleBackColor = true;
            // 
            // buttonDel
            // 
            this.buttonDel.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDel.Location = new System.Drawing.Point(279, 31);
            this.buttonDel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonDel.Name = "buttonDel";
            this.buttonDel.Size = new System.Drawing.Size(60, 49);
            this.buttonDel.TabIndex = 21;
            this.buttonDel.Text = "<-";
            this.buttonDel.UseVisualStyleBackColor = true;
            // 
            // button18
            // 
            this.button18.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button18.Location = new System.Drawing.Point(279, 87);
            this.button18.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(60, 49);
            this.button18.TabIndex = 20;
            this.button18.Text = "0";
            this.button18.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            this.button10.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button10.Location = new System.Drawing.Point(76, 31);
            this.button10.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(60, 49);
            this.button10.TabIndex = 19;
            this.button10.Text = "e";
            this.button10.UseVisualStyleBackColor = true;
            // 
            // button11
            // 
            this.button11.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button11.Location = new System.Drawing.Point(144, 31);
            this.button11.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(60, 49);
            this.button11.TabIndex = 18;
            this.button11.Text = "π";
            this.button11.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button9.Location = new System.Drawing.Point(212, 87);
            this.button9.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(60, 49);
            this.button9.TabIndex = 9;
            this.button9.Tag = "num";
            this.button9.Text = "9";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAdd.Location = new System.Drawing.Point(8, 256);
            this.buttonAdd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(60, 49);
            this.buttonAdd.TabIndex = 17;
            this.buttonAdd.Text = "+";
            this.buttonAdd.UseVisualStyleBackColor = true;
            // 
            // buttonFrac
            // 
            this.buttonFrac.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonFrac.Location = new System.Drawing.Point(8, 87);
            this.buttonFrac.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonFrac.Name = "buttonFrac";
            this.buttonFrac.Size = new System.Drawing.Size(60, 49);
            this.buttonFrac.TabIndex = 16;
            this.buttonFrac.Text = "/";
            this.buttonFrac.UseVisualStyleBackColor = true;
            // 
            // buttonDiv
            // 
            this.buttonDiv.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDiv.Location = new System.Drawing.Point(8, 144);
            this.buttonDiv.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonDiv.Name = "buttonDiv";
            this.buttonDiv.Size = new System.Drawing.Size(60, 49);
            this.buttonDiv.TabIndex = 15;
            this.buttonDiv.Text = ":";
            this.buttonDiv.UseVisualStyleBackColor = true;
            // 
            // buttonMult
            // 
            this.buttonMult.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonMult.Location = new System.Drawing.Point(8, 199);
            this.buttonMult.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonMult.Name = "buttonMult";
            this.buttonMult.Size = new System.Drawing.Size(60, 49);
            this.buttonMult.TabIndex = 14;
            this.buttonMult.Text = "*";
            this.buttonMult.UseVisualStyleBackColor = true;
            // 
            // buttonDiff
            // 
            this.buttonDiff.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDiff.Location = new System.Drawing.Point(76, 256);
            this.buttonDiff.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonDiff.Name = "buttonDiff";
            this.buttonDiff.Size = new System.Drawing.Size(60, 49);
            this.buttonDiff.TabIndex = 13;
            this.buttonDiff.Text = "-";
            this.buttonDiff.UseVisualStyleBackColor = true;
            // 
            // buttonDeg
            // 
            this.buttonDeg.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDeg.Location = new System.Drawing.Point(212, 31);
            this.buttonDeg.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonDeg.Name = "buttonDeg";
            this.buttonDeg.Size = new System.Drawing.Size(60, 49);
            this.buttonDeg.TabIndex = 11;
            this.buttonDeg.Text = "√";
            this.buttonDeg.UseVisualStyleBackColor = true;
            // 
            // buttonRoot
            // 
            this.buttonRoot.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonRoot.Location = new System.Drawing.Point(8, 31);
            this.buttonRoot.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonRoot.Name = "buttonRoot";
            this.buttonRoot.Size = new System.Drawing.Size(60, 49);
            this.buttonRoot.TabIndex = 12;
            this.buttonRoot.Text = "x²";
            this.buttonRoot.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button7.Location = new System.Drawing.Point(144, 87);
            this.button7.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(60, 49);
            this.button7.TabIndex = 10;
            this.button7.Tag = "num";
            this.button7.Text = "8";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button8.Location = new System.Drawing.Point(76, 87);
            this.button8.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(60, 49);
            this.button8.TabIndex = 8;
            this.button8.Tag = "num";
            this.button8.Text = "7";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button4.Location = new System.Drawing.Point(212, 144);
            this.button4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(60, 49);
            this.button4.TabIndex = 7;
            this.button4.Tag = "num";
            this.button4.Text = "6";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button5.Location = new System.Drawing.Point(144, 144);
            this.button5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(60, 49);
            this.button5.TabIndex = 5;
            this.button5.Tag = "num";
            this.button5.Text = "5";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button6.Location = new System.Drawing.Point(76, 144);
            this.button6.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(60, 49);
            this.button6.TabIndex = 6;
            this.button6.Tag = "num";
            this.button6.Text = "4";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Location = new System.Drawing.Point(212, 199);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(60, 49);
            this.button3.TabIndex = 4;
            this.button3.Tag = "num";
            this.button3.Text = "3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // buttonCalc
            // 
            this.buttonCalc.Enabled = false;
            this.buttonCalc.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCalc.Location = new System.Drawing.Point(16, 73);
            this.buttonCalc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonCalc.Name = "buttonCalc";
            this.buttonCalc.Size = new System.Drawing.Size(167, 41);
            this.buttonCalc.TabIndex = 4;
            this.buttonCalc.Text = "Калькулятор";
            this.buttonCalc.UseVisualStyleBackColor = true;
            this.buttonCalc.Click += new System.EventHandler(this.buttonCalc_Click);
            // 
            // buttonGraph
            // 
            this.buttonGraph.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonGraph.Location = new System.Drawing.Point(200, 73);
            this.buttonGraph.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonGraph.Name = "buttonGraph";
            this.buttonGraph.Size = new System.Drawing.Size(167, 41);
            this.buttonGraph.TabIndex = 5;
            this.buttonGraph.Text = "Графики";
            this.buttonGraph.UseVisualStyleBackColor = true;
            this.buttonGraph.Click += new System.EventHandler(this.buttonGraph_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(16, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 38);
            this.label1.TabIndex = 6;
            this.label1.Text = "y =";
            this.label1.Visible = false;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(375, 73);
            this.chart1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chart1.Name = "chart1";
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(1287, 362);
            this.chart1.TabIndex = 7;
            this.chart1.Text = "chart1";
            this.chart1.Visible = false;
            // 
            // buttonGraphCreate
            // 
            this.buttonGraphCreate.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonGraphCreate.Location = new System.Drawing.Point(8, 34);
            this.buttonGraphCreate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonGraphCreate.Name = "buttonGraphCreate";
            this.buttonGraphCreate.Size = new System.Drawing.Size(255, 48);
            this.buttonGraphCreate.TabIndex = 8;
            this.buttonGraphCreate.Text = "Построить график";
            this.buttonGraphCreate.UseVisualStyleBackColor = true;
            this.buttonGraphCreate.Click += new System.EventHandler(this.buttonGraphCreate_Click);
            // 
            // txBxXmin
            // 
            this.txBxXmin.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txBxXmin.Location = new System.Drawing.Point(93, 90);
            this.txBxXmin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txBxXmin.Name = "txBxXmin";
            this.txBxXmin.Size = new System.Drawing.Size(59, 35);
            this.txBxXmin.TabIndex = 9;
            this.txBxXmin.Text = "-10";
            this.txBxXmin.TextChanged += new System.EventHandler(this.txBxXmin_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(8, 94);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 26);
            this.label2.TabIndex = 10;
            this.label2.Text = "Xmin:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(8, 137);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 26);
            this.label3.TabIndex = 12;
            this.label3.Text = "Xmax:";
            // 
            // txBxXmax
            // 
            this.txBxXmax.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txBxXmax.Location = new System.Drawing.Point(93, 133);
            this.txBxXmax.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txBxXmax.Name = "txBxXmax";
            this.txBxXmax.Size = new System.Drawing.Size(59, 35);
            this.txBxXmax.TabIndex = 11;
            this.txBxXmax.Text = "10";
            this.txBxXmax.TextChanged += new System.EventHandler(this.txBxXmax_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(12, 181);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 26);
            this.label4.TabIndex = 14;
            this.label4.Text = "Шаг:";
            // 
            // txBxStep
            // 
            this.txBxStep.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txBxStep.Location = new System.Drawing.Point(93, 176);
            this.txBxStep.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txBxStep.Name = "txBxStep";
            this.txBxStep.Size = new System.Drawing.Size(59, 35);
            this.txBxStep.TabIndex = 13;
            this.txBxStep.Text = "0,1";
            // 
            // groupBoxGraph
            // 
            this.groupBoxGraph.Controls.Add(this.label4);
            this.groupBoxGraph.Controls.Add(this.txBxStep);
            this.groupBoxGraph.Controls.Add(this.label3);
            this.groupBoxGraph.Controls.Add(this.txBxXmax);
            this.groupBoxGraph.Controls.Add(this.label2);
            this.groupBoxGraph.Controls.Add(this.txBxXmin);
            this.groupBoxGraph.Controls.Add(this.buttonGraphCreate);
            this.groupBoxGraph.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxGraph.Location = new System.Drawing.Point(375, 73);
            this.groupBoxGraph.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxGraph.Name = "groupBoxGraph";
            this.groupBoxGraph.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxGraph.Size = new System.Drawing.Size(272, 241);
            this.groupBoxGraph.TabIndex = 15;
            this.groupBoxGraph.TabStop = false;
            this.groupBoxGraph.Text = "График";
            // 
            // buttonGraphReset
            // 
            this.buttonGraphReset.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonGraphReset.Location = new System.Drawing.Point(375, 442);
            this.buttonGraphReset.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonGraphReset.Name = "buttonGraphReset";
            this.buttonGraphReset.Size = new System.Drawing.Size(177, 57);
            this.buttonGraphReset.TabIndex = 16;
            this.buttonGraphReset.Text = "Перестроить";
            this.buttonGraphReset.UseVisualStyleBackColor = true;
            this.buttonGraphReset.Visible = false;
            this.buttonGraphReset.Click += new System.EventHandler(this.buttonGraphReset_Click);
            // 
            // buttonScaleDown
            // 
            this.buttonScaleDown.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonScaleDown.Location = new System.Drawing.Point(1121, 442);
            this.buttonScaleDown.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonScaleDown.Name = "buttonScaleDown";
            this.buttonScaleDown.Size = new System.Drawing.Size(61, 57);
            this.buttonScaleDown.TabIndex = 28;
            this.buttonScaleDown.Text = "-";
            this.buttonScaleDown.UseVisualStyleBackColor = true;
            this.buttonScaleDown.Visible = false;
            this.buttonScaleDown.Click += new System.EventHandler(this.button16_Click);
            // 
            // buttonIntg
            // 
            this.buttonIntg.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonIntg.Location = new System.Drawing.Point(560, 442);
            this.buttonIntg.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonIntg.Name = "buttonIntg";
            this.buttonIntg.Size = new System.Drawing.Size(345, 57);
            this.buttonIntg.TabIndex = 17;
            this.buttonIntg.Text = "Найти интеграл на отрезке";
            this.buttonIntg.UseVisualStyleBackColor = true;
            this.buttonIntg.Visible = false;
            // 
            // buttonDown
            // 
            this.buttonDown.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDown.Location = new System.Drawing.Point(913, 442);
            this.buttonDown.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonDown.Name = "buttonDown";
            this.buttonDown.Size = new System.Drawing.Size(61, 57);
            this.buttonDown.TabIndex = 25;
            this.buttonDown.Text = "<";
            this.buttonDown.UseVisualStyleBackColor = true;
            this.buttonDown.Visible = false;
            this.buttonDown.Click += new System.EventHandler(this.buttonDown_Click);
            // 
            // buttonUp
            // 
            this.buttonUp.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonUp.Location = new System.Drawing.Point(983, 442);
            this.buttonUp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonUp.Name = "buttonUp";
            this.buttonUp.Size = new System.Drawing.Size(61, 57);
            this.buttonUp.TabIndex = 26;
            this.buttonUp.Text = ">";
            this.buttonUp.UseVisualStyleBackColor = true;
            this.buttonUp.Visible = false;
            this.buttonUp.Click += new System.EventHandler(this.buttonUp_Click);
            // 
            // buttonScaleUp
            // 
            this.buttonScaleUp.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonScaleUp.Location = new System.Drawing.Point(1052, 442);
            this.buttonScaleUp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonScaleUp.Name = "buttonScaleUp";
            this.buttonScaleUp.Size = new System.Drawing.Size(61, 57);
            this.buttonScaleUp.TabIndex = 27;
            this.buttonScaleUp.Text = "+";
            this.buttonScaleUp.UseVisualStyleBackColor = true;
            this.buttonScaleUp.Visible = false;
            this.buttonScaleUp.Click += new System.EventHandler(this.buttonScaleUp_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1677, 561);
            this.Controls.Add(this.buttonScaleUp);
            this.Controls.Add(this.buttonUp);
            this.Controls.Add(this.buttonScaleDown);
            this.Controls.Add(this.buttonDown);
            this.Controls.Add(this.buttonGraphReset);
            this.Controls.Add(this.buttonIntg);
            this.Controls.Add(this.groupBoxGraph);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonGraph);
            this.Controls.Add(this.buttonCalc);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txBxInput);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.groupBoxGraph.ResumeLayout(false);
            this.groupBoxGraph.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox txBxInput;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button buttonDiff;
        private System.Windows.Forms.Button buttonDeg;
        private System.Windows.Forms.Button buttonRoot;
        private System.Windows.Forms.Button buttonDel;
        private System.Windows.Forms.Button button18;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonFrac;
        private System.Windows.Forms.Button buttonDiv;
        private System.Windows.Forms.Button buttonMult;
        private System.Windows.Forms.Button buttonCalc;
        private System.Windows.Forms.Button buttonGraph;
        private System.Windows.Forms.Button buttonFunc;
        private System.Windows.Forms.Button buttonRes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button buttonGraphCreate;
        private System.Windows.Forms.TextBox txBxXmin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txBxXmax;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txBxStep;
        private System.Windows.Forms.GroupBox groupBoxGraph;
        private System.Windows.Forms.Button buttonGraphReset;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button buttonScaleDown;
        private System.Windows.Forms.Button buttonIntg;
        private System.Windows.Forms.Button buttonDown;
        private System.Windows.Forms.Button buttonUp;
        private System.Windows.Forms.Button buttonScaleUp;
    }
}

