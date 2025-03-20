namespace StockExchange
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridViewRates = new DataGridView();
            Exchange = new DataGridViewTextBoxColumn();
            Symbol = new DataGridViewTextBoxColumn();
            LastPrice = new DataGridViewTextBoxColumn();
            LowPriceH24 = new DataGridViewTextBoxColumn();
            HighPriceH24 = new DataGridViewTextBoxColumn();
            comboBoxSymbolOne = new ComboBox();
            buttonStart = new Button();
            comboBoxSymbolTwo = new ComboBox();
            textBox1 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridViewRates).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewRates
            // 
            dataGridViewRates.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            dataGridViewRates.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewRates.Columns.AddRange(new DataGridViewColumn[] { Exchange, Symbol, LastPrice, LowPriceH24, HighPriceH24 });
            dataGridViewRates.Location = new Point(268, 12);
            dataGridViewRates.Name = "dataGridViewRates";
            dataGridViewRates.Size = new Size(509, 287);
            dataGridViewRates.TabIndex = 0;
            dataGridViewRates.CellContentClick += dataGridViewRates_CellContentClick;
            // 
            // Exchange
            // 
            Exchange.HeaderText = "Exchange";
            Exchange.Name = "Exchange";
            Exchange.ReadOnly = true;
            Exchange.Width = 83;
            // 
            // Symbol
            // 
            Symbol.HeaderText = "Symbol";
            Symbol.Name = "Symbol";
            Symbol.ReadOnly = true;
            Symbol.Width = 72;
            // 
            // LastPrice
            // 
            LastPrice.HeaderText = "LastPrice";
            LastPrice.Name = "LastPrice";
            LastPrice.ReadOnly = true;
            LastPrice.Width = 79;
            // 
            // LowPriceH24
            // 
            LowPriceH24.HeaderText = "LowPriceH24";
            LowPriceH24.Name = "LowPriceH24";
            LowPriceH24.ReadOnly = true;
            LowPriceH24.Width = 101;
            // 
            // HighPriceH24
            // 
            HighPriceH24.HeaderText = "HighPriceH24";
            HighPriceH24.Name = "HighPriceH24";
            HighPriceH24.ReadOnly = true;
            HighPriceH24.Width = 105;
            // 
            // comboBoxSymbolOne
            // 
            comboBoxSymbolOne.FormattingEnabled = true;
            comboBoxSymbolOne.Location = new Point(27, 23);
            comboBoxSymbolOne.Name = "comboBoxSymbolOne";
            comboBoxSymbolOne.Size = new Size(121, 23);
            comboBoxSymbolOne.TabIndex = 1;
            // 
            // buttonStart
            // 
            buttonStart.Location = new Point(175, 23);
            buttonStart.Name = "buttonStart";
            buttonStart.Size = new Size(75, 23);
            buttonStart.TabIndex = 2;
            buttonStart.Text = "Start";
            buttonStart.UseVisualStyleBackColor = true;
            buttonStart.Click += buttonStart_Click;
            // 
            // comboBoxSymbolTwo
            // 
            comboBoxSymbolTwo.FormattingEnabled = true;
            comboBoxSymbolTwo.Location = new Point(27, 134);
            comboBoxSymbolTwo.Name = "comboBoxSymbolTwo";
            comboBoxSymbolTwo.Size = new Size(121, 23);
            comboBoxSymbolTwo.TabIndex = 3;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(27, 326);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.Size = new Size(750, 112);
            textBox1.TabIndex = 4;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(textBox1);
            Controls.Add(comboBoxSymbolTwo);
            Controls.Add(buttonStart);
            Controls.Add(comboBoxSymbolOne);
            Controls.Add(dataGridViewRates);
            Name = "MainForm";
            Text = "MainForm";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewRates).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewRates;
        private ComboBox comboBoxSymbolOne;
        private Button buttonStart;
        private ComboBox comboBoxSymbolTwo;
        private DataGridViewTextBoxColumn Exchange;
        private DataGridViewTextBoxColumn Symbol;
        private DataGridViewTextBoxColumn LastPrice;
        private DataGridViewTextBoxColumn LowPriceH24;
        private DataGridViewTextBoxColumn HighPriceH24;
        private TextBox textBox1;
    }
}