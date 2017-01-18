using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WamesRepository
{
    public class GenreRepository : Repository<genre>, IGenresRepository
    {
        public GenreRepository(wamesEntities wamesContext) : base(wamesContext)
        {
        }

        public IEnumerable<genre> GetAllGenres()
        {
            var querry = context.Database.SqlQuery<genre>("GetAllGenres");

            return querry;
            
        }
    }
}
