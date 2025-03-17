using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchange.Api
{
    // Класс для обобщения данных из разных бирж 
    internal class ExchangeRate
    {
        public decimal? LastPrice { get; set; }
    }
}
