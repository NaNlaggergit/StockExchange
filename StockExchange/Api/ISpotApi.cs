namespace StockExchange.Api
{
    internal interface ISpotApi
    {
        Task<ExchangeRate> GetPriceAsync(string symbol);
        Task<Result> SubscribeToPriceUpdatesAsync(string symbol, Action<ExchangeRate> onPriceUpdate);
        Task UnsubscribeFromPriceUpdatesAsync();
    }
}
