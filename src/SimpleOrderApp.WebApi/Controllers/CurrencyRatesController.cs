using Microsoft.AspNetCore.Mvc;

using SimpleOrderApp.Application.CurrencyRates.Commands.UpdateCurrencyRates;
using SimpleOrderApp.WebApi.Base;

namespace SimpleOrderApp.WebApi.Controllers
{
    /// <summary>
    /// Currency Rates Controller
    /// </summary>
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = false)]
    [Route("api/currency-rates")]
    public class CurrencyRatesController : BaseApiController
    {
        /// <summary>
        /// Updates the Currency Rates
        /// </summary>
        /// <param name="command"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task UpdateCurrencyRates(UpdateCurrencyRatesCommand command,
            CancellationToken token)
        {
            await Mediator.Send(command, token);
        }
    }
}
