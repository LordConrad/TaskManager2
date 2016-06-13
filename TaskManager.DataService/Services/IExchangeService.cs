using System;
using System.Collections.Generic;
using TaskManager.DataService.Models;

namespace TaskManager.DataService.Services
{
    public interface IExchangeService
    {
        IEnumerable<ExchangeRate> GetExchangeRatesByDate(DateTime date);
    }
}