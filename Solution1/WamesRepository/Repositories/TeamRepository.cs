using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WamesRepository
{
    public class TeamRepository : Repository<Team>, ITeamRepository
    {
        public TeamRepository(DbContext context) : base(context)
        {

        }

        public IEnumerable<Team> GetTeamByGameTitle(string title)
        {
            throw new NotImplementedException();
        }
    }
}
