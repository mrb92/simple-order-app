using Microsoft.Extensions.Configuration;
using Refit;

using SimpleOrderApp.Domain.Dtos;
using SimpleOrderApp.Domain.Interfaces;

namespace SimpleOrderApp.Infrastructure.ExternalApiIntegration
{
    public class ExternalApiIntegrationService : IExternalApiIntegrationService
    {
        private readonly string _currencyApiKey;

        public ExternalApiIntegrationService(IConfiguration configuration)
        {
            _currencyApiKey = configuration["ExternalApis:CurrencyApiKey"];
        }

        public async Task<CurrencyRatesDto> GetLiveData(CurrencyRatesInputDto inputData, CancellationToken token)
        {
            var currencyApi = RestService.For<IExternalCurrenyApiIntegration>("https://api.apilayer.com");

            return await currencyApi.GetLiveData(inputData.Source, inputData.Currencies, _currencyApiKey, token);
        }
    }
}
