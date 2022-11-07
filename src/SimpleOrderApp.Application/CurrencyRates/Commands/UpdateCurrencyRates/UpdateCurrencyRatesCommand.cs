using MediatR;
using Microsoft.EntityFrameworkCore;

using SimpleOrderApp.Application.Common.Interfaces;
using SimpleOrderApp.Common.Services;
using SimpleOrderApp.Domain.Dtos;
using SimpleOrderApp.Domain.Entities;
using SimpleOrderApp.Domain.Entities.Referentials;
using SimpleOrderApp.Domain.Interfaces;

namespace SimpleOrderApp.Application.CurrencyRates.Commands.UpdateCurrencyRates
{
    public class UpdateCurrencyRatesCommand : IRequest
    {
    }

    public class UpdateCurrencyRatesCommandHandler : IRequestHandler<UpdateCurrencyRatesCommand>
    {
        private readonly IExternalApiIntegrationService _externalApiIntegrationService;
        private readonly IApplicationDbContext _context;
        private readonly ITimeService _timeService;

        public UpdateCurrencyRatesCommandHandler(IExternalApiIntegrationService externalApiIntegrationService,
            IApplicationDbContext context,
            ITimeService timeService)
        {
            _externalApiIntegrationService = externalApiIntegrationService;
            _context = context;
            _timeService = timeService;
        }

        public async Task<Unit> Handle(UpdateCurrencyRatesCommand request, CancellationToken token)
        {
            var sourceCurrencyShortName = "EUR";
            var currencies = await _context.ReadSet<RefCurrency>().ToListAsync(token);
            var sourceCurrency = currencies.FirstOrDefault(c => c.ShortName == sourceCurrencyShortName);
            currencies.Remove(sourceCurrency);

            var inputData = new CurrencyRatesInputDto
            {
                Currencies = string.Join(",", currencies.Select(c => c.ShortName).ToList()),
                Source = sourceCurrency.ShortName
            };

            var apiResult = await _externalApiIntegrationService.GetLiveData(inputData, token);

            if (!apiResult.Quotes.Any())
                return Unit.Value;

            var exchangeRates = apiResult.Quotes.ToList();

            var currencyRates = new List<CurrencyRate>();

            foreach (var exchangeRate in exchangeRates)
            {
                var destinationCurrencyShortName = exchangeRate.Key.Remove(0, sourceCurrencyShortName.Length);
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

            await _context.SaveChangesExAsync(token);

            return Unit.Value;
        }
    }
}
