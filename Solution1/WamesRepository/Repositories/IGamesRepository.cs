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
        IEnumerable<games> GetGamesByGenre(string genre);
        IEnumerable<games> GetGamesMadeByTeam(string team);
        IEnumerable<games> GetGamesWithPriceBelowGivenPrice(decimal value);
    }
}
