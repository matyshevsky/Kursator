using Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kursator.Interfaces
{
    public interface IFixingService
    {
        Task<IEnumerable<Fixing>> GetWorldwideFixings();
    }
}
