using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WamesRepository
{
    public interface IGenresRepository : IRepository<genre>
    {
        IEnumerable<genre> GetAllGenres();
    }
}
