using Binance.Net.Clients;
using Binance.Net.Interfaces.Clients;
using Bitget.Net.Clients;
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
    internal class BybitSpotApi : ISpotApi
    {
        private readonly IBybitRestClient _client;
        private readonly IBybitSocketClient _socketClient;
        private int? _subscriptionId;

        public BybitSpotApi()
        {
            _client = new BybitRestClient();
            _socketClient = new BybitSocketClient();
        }

        private ExchangeRate CreateExchangeRate(Bybit.Net.Objects.Models.V5.BybitSpotTicker data)
        {
            return new ExchangeRate { LastPrice = data.LastPrice };
        }

        private ExchangeRate CreateExchangeRate(Bybit.Net.Objects.Models.V5.BybitSpotTickerUpdate data)
        {
            return new ExchangeRate { LastPrice = data.LastPrice };
        }

        public async Task<ExchangeRate> GetPriceAsync(string symbol)
        {
            var result = await _client.V5Api.ExchangeData.GetSpotTickersAsync(symbol);
            if (result.Success)
            {
                return CreateExchangeRate(result.Data.List.First());
            }

            return null;
        }

        public async Task SubscribeToPriceUpdatesAsync(string symbol, Action<ExchangeRate> onPriceUpdate)
        {
            var subscription = await _socketClient.V5SpotApi.SubscribeToTickerUpdatesAsync(symbol, data =>
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
        private void HandleTickerUpdate(string symbol, Action<ExchangeRate> onPriceUpdate, Bybit.Net.Objects.Models.V5.BybitSpotTickerUpdate data)
        {
            onPriceUpdate?.Invoke(CreateExchangeRate(data));
        }
    }

}

