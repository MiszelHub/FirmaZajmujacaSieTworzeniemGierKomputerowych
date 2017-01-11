using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WamesRepository
{
    public interface ITeamRepository : IRepository<Team>
    {
        IEnumerable<Team> GetTeamByGameTitle(string title);
    }
}
