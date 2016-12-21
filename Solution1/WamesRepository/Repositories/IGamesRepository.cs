using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WamesRepository
{
    public interface IGamesRepository :IRepository<games>
    {
        IEnumerable<games> GetGamesForSpecifiedPlatform(string platform);
    }
}
