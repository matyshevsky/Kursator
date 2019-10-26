using Domain;
using Kursator.Interfaces;
using Library.Exceptions;
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
            var cache = (await _nbpProvider.GetFixings()).ToDictionary(c => c.CurrencyCode.ToUpper());
            return cache.Get(firstCurrency.ToUpper()).ConvertTo(cache.Get(secondCurrency.ToUpper()), value);
        }
    }

    public static class FixingDictionaryExtensions
    {
        public static Fixing Get(this IDictionary<string, Fixing> source, string key)
        {
            try
            {
                return source[key];
            }
            catch (KeyNotFoundException)
            {
                throw new FixingNotFoundException(key);
            }
        }
    }

}
