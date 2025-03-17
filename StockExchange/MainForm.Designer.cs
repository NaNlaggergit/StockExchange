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
            comboBoxSymbolOne = new ComboBox();
            buttonStart = new Button();
            comboBoxSymbolTwo = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dataGridViewRates).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewRates
            // 
            dataGridViewRates.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewRates.Columns.AddRange(new DataGridViewColumn[] { Exchange, Symbol, LastPrice });
            dataGridViewRates.Location = new Point(232, 12);
            dataGridViewRates.Name = "dataGridViewRates";
            dataGridViewRates.Size = new Size(402, 287);
            dataGridViewRates.TabIndex = 0;
            dataGridViewRates.CellContentClick += dataGridViewRates_CellContentClick;
            // 
            // Exchange
            // 
            Exchange.HeaderText = "Exchange";
            Exchange.Name = "Exchange";
            Exchange.ReadOnly = true;
            // 
            // Symbol
            // 
            Symbol.HeaderText = "Symbol";
            Symbol.Name = "Symbol";
            Symbol.ReadOnly = true;
            // 
            // LastPrice
            // 
            LastPrice.HeaderText = "LastPrice";
            LastPrice.Name = "LastPrice";
            LastPrice.ReadOnly = true;
            // 
            // comboBoxSymbolOne
            // 
            comboBoxSymbolOne.FormattingEnabled = true;
            comboBoxSymbolOne.Location = new Point(51, 46);
            comboBoxSymbolOne.Name = "comboBoxSymbolOne";
            comboBoxSymbolOne.Size = new Size(121, 23);
            comboBoxSymbolOne.TabIndex = 1;
            // 
            // buttonStart
            // 
            buttonStart.Location = new Point(363, 204);
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
            comboBoxSymbolTwo.Location = new Point(51, 98);
            comboBoxSymbolTwo.Name = "comboBoxSymbolTwo";
            comboBoxSymbolTwo.Size = new Size(121, 23);
            comboBoxSymbolTwo.TabIndex = 3;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(comboBoxSymbolTwo);
            Controls.Add(buttonStart);
            Controls.Add(comboBoxSymbolOne);
            Controls.Add(dataGridViewRates);
            Name = "MainForm";
            Text = "MainForm";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewRates).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewRates;
        private ComboBox comboBoxSymbolOne;
        private Button buttonStart;
        private DataGridViewTextBoxColumn Exchange;
        private DataGridViewTextBoxColumn Symbol;
        private DataGridViewTextBoxColumn LastPrice;
        private ComboBox comboBoxSymbolTwo;
    }
}