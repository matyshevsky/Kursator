using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.FixingDomain.Interfaces
{
    public interface INbpProvider
    {
        Task<IEnumerable<Fixing>> GetFixings();
    }
}
