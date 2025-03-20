using Binance.Net.Clients;
using Binance.Net.Interfaces.Clients;
using CryptoExchange.Net.Objects.Sockets;
using Kucoin.Net.Clients;
using Kucoin.Net.Interfaces.Clients;
using Kucoin.Net.Objects.Models.Spot.Socket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchange.Api
{
    internal class KucoinSpotApi : ISpotApi
    {
        private readonly IKucoinRestClient _client;
        private readonly IKucoinSocketClient _socketClient;
        private int? _subscriptionId;

        public KucoinSpotApi()
        {
            _client = new KucoinRestClient();
            _socketClient = new KucoinSocketClient();
        }

        private ExchangeRate CreateExchangeRate(Kucoin.Net.Objects.Models.Spot.KucoinTick data)
        {
            return new ExchangeRate
            {
                LastPrice = data.LastPrice,
            };
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

        public async Task<Result> SubscribeToPriceUpdatesAsync(string symbol, Action<ExchangeRate> onPriceUpdate)
        {
            Result result=new Result();
            if(_subscriptionId != null)
            {
                result.Error = "Уже подписанны";
                return result;
            }

            var subscription = await _socketClient.SpotApi.SubscribeToTickerUpdatesAsync(symbol, data =>
            {
                HandleTickerUpdate(symbol, onPriceUpdate, data.Data);
            });

            if (subscription.Success)
            {
                result.IsSuccess = true;
                _subscriptionId = subscription.Data.Id;
                return result;
            }

            else
            {
                result.Error = subscription.Error.Message;
                _subscriptionId = null;
                return result;
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

        private void HandleTickerUpdate(string symbol, Action<ExchangeRate> onPriceUpdate, Kucoin.Net.Objects.Models.Spot.KucoinTick data)
        {
            onPriceUpdate?.Invoke(CreateExchangeRate(data));
        }
    }

}
