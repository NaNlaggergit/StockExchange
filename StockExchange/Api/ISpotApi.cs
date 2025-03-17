namespace StockExchange.Api
{
    internal interface ISpotApi
    {
        Task<ExchangeRate> GetPriceAsync(string symbol);
        Task SubscribeToPriceUpdatesAsync(string symbol, Action<ExchangeRate> onPriceUpdate);
        Task UnsubscribeFromPriceUpdatesAsync();
    }
}
