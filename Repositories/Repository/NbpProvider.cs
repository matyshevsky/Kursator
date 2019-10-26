using Domain.FixingDomain;
using Domain.FixingDomain.Interfaces;
using Library;
using Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static System.Globalization.CultureInfo;

namespace Repositories.Repository
{
    public class NbpProvider : ApiClient, INbpProvider
    {
        public NbpProvider(Uri baseEndpoint) : base(baseEndpoint)
        {
        }

        public async Task<IEnumerable<Fixing>> GetFixings()
        {
            var requestUrl = CreateRequestUri(string.Format(InvariantCulture,"exchangerates/tables/A/"));
            var result = await GetAsync<List<ExchangeTable>>(requestUrl);
            return result.ConvertToEnumerableDomain();
        }
    }
}
