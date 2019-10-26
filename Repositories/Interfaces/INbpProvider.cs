using Domain;
using Repositories.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface INbpProvider
    {
        Task<IEnumerable<Fixing>> GetFixings();
    }
}
