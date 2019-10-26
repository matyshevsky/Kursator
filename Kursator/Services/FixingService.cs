using Domain;
using Kursator.Interfaces;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kursator.Services
{
    public class FixingService : IFixingService
    {
        private readonly INbpProvider _nbpProvider;
        private static readonly string[] WorldwideCurrency =
        {
            "eur","chf","usd","huf","gbp"
        };

        public FixingService(INbpProvider nbpProvider)
        {
            _nbpProvider = nbpProvider;
        }

        public async Task<IEnumerable<Fixing>> GetWorldwideFixings()
        {
            return (await _nbpProvider.GetFixings()).Where(c => WorldwideCurrency.Contains(c.CurrencyCode.ToLower())).ToList();
        }

        public async Task<decimal> ConvertCurrencies(string firstCurrency, string secondCurrency, decimal value)
        {
            var cache = (await _nbpProvider.GetFixings()).ToDictionary(c => c.CurrencyCode);
            return cache[firstCurrency].ConvertTo(cache[secondCurrency], value);
        }
    }
}
