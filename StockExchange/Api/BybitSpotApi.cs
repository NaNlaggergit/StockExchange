using Bybit.Net.Clients;
using Bybit.Net.Interfaces.Clients;

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
            return new ExchangeRate
            {
                LastPrice = data.LastPrice,
                LowPriceH24 = data.LowPrice24h,
                HighPriceH24 = data.HighPrice24h,
            };
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

        public async Task<Result> SubscribeToPriceUpdatesAsync(string symbol, Action<ExchangeRate> onPriceUpdate)
        {
            Result result = new Result();
            if (_subscriptionId != null)
            {
                result.Error = "Уже подписанны";
                return result;
            }
            var subscription = await _socketClient.V5SpotApi.SubscribeToTickerUpdatesAsync(symbol, data =>
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
        private void HandleTickerUpdate(string symbol, Action<ExchangeRate> onPriceUpdate, Bybit.Net.Objects.Models.V5.BybitSpotTickerUpdate data)
        {
            onPriceUpdate?.Invoke(CreateExchangeRate(data));
        }
    }

}

