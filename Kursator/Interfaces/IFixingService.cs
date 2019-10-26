using Domain.FixingDomain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kursator.Interfaces
{
    public interface IFixingService
    {
        Task<IEnumerable<Fixing>> GetWorldwideFixings();
        Task<decimal> ConvertCurrencies(string firstCurrency, string secondCurrency, decimal value);
    }
}
