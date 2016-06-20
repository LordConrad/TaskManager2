using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
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
        public IHttpActionResult GetExchangeRates([FromBody]ExchangeRateParameterViewModel model)
        {
            DateTime date;
            if (DateTime.TryParse(model.Date, out date))
            {
                var result = _exchangeService.GetExchangeRatesByDate(date);
                if (result == null)
                {
                    return InternalServerError(new ExternalException("nbrb.by server returns error"));
                }
                return Ok(result);
            }
            return InternalServerError(new ArgumentException("Can't parse date"));
        }
    }
}
