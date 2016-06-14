using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaskManager.DataService.Models;
using TaskManager.DataService.Services;
using TaskManager.DataService.Utilities;
using TaskManager.DataService.ViewModels;

namespace TaskManager.DataService.Controllers
{
    [CacheControl(MaxAge = 3)]
    public class ExchangeController : ApiController
    {
        private readonly IExchangeService _exchangeService;

        public ExchangeController()
        {
            _exchangeService = new ExchangeService();
        }

        [HttpPost]
        [Route("api/GetExchangeRates")]
        public IEnumerable<ExchangeRate> GetExchangeRates([FromBody]ExchangeRateParameterViewModel model)
        {
            DateTime date;
            if (DateTime.TryParse(model.Date, out date))
            {
                return _exchangeService.GetExchangeRatesByDate(date);
            }
            return null;
        }
    }
}
