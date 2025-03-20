using Binance.Net.Clients;
using Binance.Net.Interfaces.Clients;
using Binance.Net.Objects.Models.Spot.Socket;
using CryptoExchange.Net.Authentication;
using Kucoin.Net.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchange.Api
{
    internal class BinanceSpotApi : ISpotApi
    {
        private readonly IBinanceRestClient _client;
        private readonly IBinanceSocketClient _socketClient;
        private int? _subscriptionId;

        public BinanceSpotApi()
        {
            _client = new BinanceRestClient();
            _socketClient = new BinanceSocketClient();
        }

        private ExchangeRate CreateExchangeRate(Binance.Net.Interfaces.IBinanceTick data)
        {
            return new ExchangeRate {
                LastPrice = data.LastPrice,
                LowPriceH24 = data.LowPrice,
                HighPriceH24 =data.HighPrice,
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
            if (_subscriptionId != null)
            {
                result.Error = "Уже подписаны";
                return result;
            }
            var subscription = await _socketClient.SpotApi.ExchangeData.SubscribeToTickerUpdatesAsync(symbol, data =>
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

        private void HandleTickerUpdate(string symbol, Action<ExchangeRate> onPriceUpdate, Binance.Net.Interfaces.IBinanceTick data)
        {
            onPriceUpdate?.Invoke(CreateExchangeRate(data));
        }
    }

}
