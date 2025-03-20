using StockExchange.Api;
using StockExchange.Api.StockExchange.Api;
using System.Diagnostics;
using System.Threading.Tasks;

namespace StockExchange
{
    public partial class MainForm : Form
    {
        private readonly List<ISpotApi> _exchangeClients;
        private bool _isUpdating;
        private List<Task> _unsubscribeTasks = new List<Task>();
        private List<Task> _subscribeTasks = new List<Task>();

        public MainForm()
        {
            InitializeComponent();
            _exchangeClients = new List<ISpotApi>
            {
                new BinanceSpotApi(),
                new KucoinSpotApi(),
                new BybitSpotApi(),
                new BitgetSpotApi()
            };
            comboBoxSymbolOne.Items.AddRange(new[] { "BTC", "ETH", "BNB" });
            comboBoxSymbolTwo.Items.AddRange(new[] { "USDT" });
            comboBoxSymbolOne.SelectedIndex = 0;
            comboBoxSymbolTwo.SelectedIndex = 0;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("sdfdfgd");
            if (_isUpdating)
            {
                unsubscribe();
            }
            else
            {
                subscribe();
            }
        }

        private async void unsubscribe()
        {
            _isUpdating = false;
            buttonStart.Enabled = false;
            foreach (var client in _exchangeClients)
            {
                await client.UnsubscribeFromPriceUpdatesAsync();
            }
            buttonStart.Text = "Start";
            buttonStart.Enabled = true;
        }

        private async void subscribe()
        {
            _isUpdating = true;
            buttonStart.Enabled = false;
            var selectedFirst = comboBoxSymbolOne.SelectedItem.ToString();
            var selectedSecond = comboBoxSymbolTwo.SelectedItem.ToString();
            dataGridViewRates.Rows.Clear();
            var tasks = new List<Task<Result>>();
            foreach (var client in _exchangeClients)
            {
                var newSymbol = ConcatSymbol(selectedFirst, selectedSecond, client.GetType().Name);
                var task = client.SubscribeToPriceUpdatesAsync(newSymbol, exchangeRate =>
                {   
                    this.Invoke((MethodInvoker)delegate
                    {
                        UpdateDataGridView(client.GetType().Name, newSymbol, exchangeRate);
                    });
                });

                tasks.Add(task);
            }
            await Task.WhenAll(tasks.ToArray());
            for (int i=0; i<tasks.Count;i++) 
            {
                if (!tasks[i].Result.IsSuccess)
                {
                    textBox1.AppendText($"{_exchangeClients[i].GetType().Name}:\r\n" + tasks[i].Result.Error + "\r\n");
                }
            }
            buttonStart.Text = "Stop";
            buttonStart.Enabled = true;
        }

        private void UpdateDataGridView(string exchange, string symbol, ExchangeRate data)
        {
            foreach (DataGridViewRow row in dataGridViewRates.Rows)
            {
                if (row.Cells["Exchange"].Value != null && row.Cells["Exchange"].Value?.ToString() == exchange)
                {
                    row.Cells["LastPrice"].Value = data.LastPrice?.ToString("N2");
                    row.Cells["LowPriceH24"].Value = data.LowPriceH24?.ToString("N2");
                    row.Cells["HighPriceH24"].Value = data.HighPriceH24?.ToString("N2");
                    return;
                }
            }
            dataGridViewRates.Rows.Add(exchange, symbol, data.LastPrice?.ToString("N2"), data.LowPriceH24?.ToString("N2"),
                data.HighPriceH24?.ToString("N2"));
        }
        private string ConcatSymbol(string firstSymbol, string secondSymbol, string exchange)
        {
            string newSymbol;
            if (exchange == "KucoinSpotApi")
            {
                newSymbol = firstSymbol + '-' + secondSymbol;
            }
            else
            {
                newSymbol = firstSymbol + secondSymbol;
            }
            return newSymbol;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void dataGridViewRates_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
