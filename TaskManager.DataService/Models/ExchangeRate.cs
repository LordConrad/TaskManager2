using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManager.DataService.Models
{
    public class ExchangeRate
    {
        public string CurrencyName { get; set; }
        public string CurrencyAbbreviation { get; set; }
        public string CurrencyCode { get; set; }
        public string Scale { get; set; }
        public string Rate { get; set; }

    }
}