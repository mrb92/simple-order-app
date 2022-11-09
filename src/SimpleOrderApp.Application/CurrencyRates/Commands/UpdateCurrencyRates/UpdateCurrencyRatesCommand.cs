using MediatR;
using Microsoft.EntityFrameworkCore;

using SimpleOrderApp.Application.Common;
using SimpleOrderApp.Application.Common.Interfaces;
using SimpleOrderApp.Common.Services;
using SimpleOrderApp.Domain.Dtos;
using SimpleOrderApp.Domain.Entities;
using SimpleOrderApp.Domain.Entities.Referentials;
using SimpleOrderApp.Domain.Interfaces;

namespace SimpleOrderApp.Application.CurrencyRates.Commands.UpdateCurrencyRates
{
    /// <summary>
    /// Update Currency Rates Command
    /// </summary>
    public class UpdateCurrencyRatesCommand : IRequest
    {
    }

    /// <summary>
    /// Update Currency Rates Command Handler
    /// </summary>
    public class UpdateCurrencyRatesCommandHandler : IRequestHandler<UpdateCurrencyRatesCommand>
    {
        private readonly IExternalApiIntegrationService _externalApiIntegrationService;
        private readonly IApplicationDbContext _context;
        private readonly ITimeService _timeService;

        ///
        public UpdateCurrencyRatesCommandHandler(IExternalApiIntegrationService externalApiIntegrationService,
            IApplicationDbContext context,
            ITimeService timeService)
        {
            _externalApiIntegrationService = externalApiIntegrationService;
            _context = context;
            _timeService = timeService;
        }

        ///
        public async Task<Unit> Handle(UpdateCurrencyRatesCommand request, CancellationToken token)
        {
            var sourceCurrencyName = Constants.DefaultCurrency;

            var appCurrencies = await _context.ReadSet<RefCurrency>().ToListAsync(token);

            if (appCurrencies == null || !appCurrencies.Any())
                throw new ApplicationException("No currencies found");

            var sourceCurrency = appCurrencies.FirstOrDefault(c => c.ShortName == sourceCurrencyName);

            if (sourceCurrency == null)
                throw new ApplicationException("The default currency was not found");

            var destinationCurrencies = GetDestinationCurrencies(appCurrencies, sourceCurrency);

            var apiResult = await GetCurrencyRates(sourceCurrency, destinationCurrencies, token);

            if (!apiResult.Quotes.Any())
                return Unit.Value;

            await UpdateDbWithNewExchangeRates(destinationCurrencies, sourceCurrency, apiResult, token);

            await _context.SaveChangesExAsync(token);

            return Unit.Value;
        }

        private async Task<CurrencyRatesDto> GetCurrencyRates(RefCurrency? sourceCurrency,
            List<RefCurrency> destinationCurrencies,
            CancellationToken token)
        {
            var apiInputData = new CurrencyRatesInputDto
            {
                Currencies = string.Join(",", destinationCurrencies.Select(c => c.ShortName).ToList()),
                Source = sourceCurrency.ShortName
            };

            var apiResult = await _externalApiIntegrationService.GetLiveData(apiInputData, token);

            return apiResult;
        }

        private List<RefCurrency> GetDestinationCurrencies(List<RefCurrency> currencies, RefCurrency sourceCurrency)
        {
            currencies.Remove(sourceCurrency);

            return currencies;
        }

        private async Task UpdateDbWithNewExchangeRates(
            List<RefCurrency> currencies,
            RefCurrency? sourceCurrency,
            CurrencyRatesDto currencyRatesDto,
            CancellationToken token)
        {
            var exchangeRates = currencyRatesDto.Quotes.ToList();

            var currencyRates = new List<CurrencyRate>();

            foreach (var exchangeRate in exchangeRates)
            {
                var destinationCurrencyShortName = exchangeRate.Key.Remove(0, sourceCurrency.ShortName.Length);
                var destinationCurrency = currencies.FirstOrDefault(c => c.ShortName == destinationCurrencyShortName);

                currencyRates.Add(new CurrencyRate
                {
                    EffectiveDate = _timeService.Now,
                    ExchangeRate = exchangeRate.Value,
                    FromCurrencyId = sourceCurrency.Id,
                    ToCurrencyId = destinationCurrency.Id
                });
            }

            await _context.Set<CurrencyRate>().AddRangeAsync(currencyRates, token);
        }
    }
}
