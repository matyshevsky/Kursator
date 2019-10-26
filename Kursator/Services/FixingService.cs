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
            "eur","chf","usd","pln","gbp"
        };

        public FixingService(INbpProvider nbpProvider)
        {
            _nbpProvider = nbpProvider;
        }

        public async Task<IEnumerable<Fixing>> GetWorldwideFixings()
        {
            var result = await _nbpProvider.GetFixings(); 
            var toReurn = result.Where(c => WorldwideCurrency.Contains(c.CurrencyCode.ToLower())).ToList();
            return toReurn;
        }
    }
}
