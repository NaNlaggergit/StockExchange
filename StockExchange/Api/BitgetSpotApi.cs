using Bitget.Net.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchange.Api
{
    using Binance.Net.Clients;
    using Binance.Net.Interfaces.Clients;
    using Bitget.Net.Interfaces.Clients;
    using Bybit.Net.Clients;
    using Bybit.Net.Interfaces.Clients;
    using CryptoExchange.Net.Authentication;
    using Kucoin.Net.Clients;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace StockExchange.Api
    {
        internal class BitgetSpotApi : ISpotApi
        {
            private readonly IBitgetRestClient _client;
            private readonly IBitgetSocketClient _socketClient;
            private int? _subscriptionId;

            public BitgetSpotApi()
            {
                _client = new BitgetRestClient();
                _socketClient = new BitgetSocketClient();
            }

            private ExchangeRate CreateExchangeRate(Bitget.Net.Objects.Models.BitgetTickerUpdate data)
            {
                return new ExchangeRate { LastPrice = data.LastPrice };
            }

            private ExchangeRate CreateExchangeRate(Bitget.Net.Objects.Models.BitgetTicker data)
            {
                return new ExchangeRate { LastPrice = data.ClosePrice };
            }

            public async Task<ExchangeRate> GetPriceAsync(string symbol)
            {
                var result = await _client.SpotApi.ExchangeData.GetTickerAsync(symbol);

                if (result.Success)
                {
                    return CreateExchangeRate(result.Data);
                }

                return null;
            }

            public async Task SubscribeToPriceUpdatesAsync(string symbol, Action<ExchangeRate> onPriceUpdate)
            {
                var subscription = await _socketClient.SpotApi.SubscribeToTickerUpdatesAsync(symbol, data =>
                {
                    HandleTickerUpdate(symbol, onPriceUpdate, data.Data);
                });

                if (subscription.Success)
                {
                    _subscriptionId = subscription.Data.Id;
                }
            }

            public async Task UnsubscribeFromPriceUpdatesAsync()
            {
                if (_subscriptionId.HasValue)
                {
                    await _socketClient.UnsubscribeAsync(_subscriptionId.Value);
                    _subscriptionId = null;
                }
            }
            private void HandleTickerUpdate(string symbol, Action<ExchangeRate> onPriceUpdate, Bitget.Net.Objects.Models.BitgetTickerUpdate data)
            {
                onPriceUpdate?.Invoke(CreateExchangeRate(data));
            }
        }

    }

}
