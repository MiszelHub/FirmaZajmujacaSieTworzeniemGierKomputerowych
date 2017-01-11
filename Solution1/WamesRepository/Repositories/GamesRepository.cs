using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WamesRepository
{
    public class GamesRepository : Repository<games>, IGamesRepository
    {
        public GamesRepository(DbContext context):base(context)
        {

        }

        public IEnumerable<games> GetGamesByGenre(string genre)
        {
            var param = new SqlParameter("@Genre", genre);

            var querry = context.Database.SqlQuery<games>("GetGamesByGenre @Genre", param);
            return querry;
        }

        public IEnumerable<games> GetGamesForSpecifiedPlatform(string platform)
        {
            var param = new SqlParameter("GamePlatform", platform);

            var querry = context.Database.SqlQuery<games>("GetGamesForSpecifiedPlatform @GamePlatform", param);
            return querry;
        }

        public IEnumerable<games> GetGamesMadeByTeam(string team)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<games> GetGamesWithPriceBelowGivenPrice(decimal value)
        {
            throw new NotImplementedException();
        }
    }
}
