using Microsoft.AspNetCore.Mvc;

using SimpleOrderApp.Application.CurrencyRates.Commands.UpdateCurrencyRates;
using SimpleOrderApp.WebApi.Base;

namespace SimpleOrderApp.WebApi.Controllers
{
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = false)]
    [Route("api/currency-rates")]
    public class CurrencyRatesController : BaseApiController
    {
        [HttpPut]
        public async Task UpdateCurrencyRates(UpdateCurrencyRatesCommand command,
            CancellationToken token)
        {
            await Mediator.Send(command, token);
        }
    }
}
