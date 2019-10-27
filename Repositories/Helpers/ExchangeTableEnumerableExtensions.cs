using Domain.FixingDomain;
using Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repositories.Repository
{
    public static class ExchangeTableEnumerableExtensions
    {
        public static IEnumerable<Fixing> ConvertToEnumerableDomain(this IEnumerable<ExchangeTable> source)
        {
            if (source.Count() == 0)
                return new List<Fixing>();
            return source.First().Rates.Select(c => new Fixing
            {
                CurrencyCode = c.Code,
                Currency = c.Currency,
                Rate = Convert.ToDecimal(c.Mid)
            });
        }
    }

}
