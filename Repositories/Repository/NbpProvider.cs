using Domain;
using Library;
using Repositories.Entities;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repositories.Repository
{
    public class NbpProvider : ApiClient, INbpProvider
    {
        public NbpProvider(Uri baseEndpoint) : base(baseEndpoint)
        {
        }

        public async Task<IEnumerable<Fixing>> GetFixings()
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "exchangerates/tables/A/"));
            var result = await GetAsync<List<ExchangeTable>>(requestUrl);

            var rates = result.First().Rates.Select(c => new Fixing
            {
                CurrencyCode = c.Code,
                Currency = c.Currency,
                Rate = Convert.ToDecimal(c.Mid)
            });

            return rates;
        }
    }
}
