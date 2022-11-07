using Refit;
using SimpleOrderApp.Domain.Dtos;

namespace SimpleOrderApp.Infrastructure.ExternalApiIntegration
{
    public interface IExternalCurrenyApiIntegration
    {
        [Get("/currency_data/live")]
        Task<CurrencyRatesDto> GetLiveData(string source, string currencies, [Header("apikey")] string apikey, CancellationToken token);
    }
}
