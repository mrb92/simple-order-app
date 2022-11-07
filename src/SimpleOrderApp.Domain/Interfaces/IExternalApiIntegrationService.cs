using SimpleOrderApp.Domain.Dtos;

namespace SimpleOrderApp.Domain.Interfaces
{
    public interface IExternalApiIntegrationService
    {
        Task<CurrencyRatesDto> GetLiveData(CurrencyRatesInputDto inputData, CancellationToken token);
    }
}
