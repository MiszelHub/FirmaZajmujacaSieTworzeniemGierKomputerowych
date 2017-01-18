using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WamesRepository
{
    public class HeadQuartersRepository : Repository<headquarters>, IHeadQuartersReposotory
    {
        public HeadQuartersRepository(wamesEntities context):base(context)
        {

        }
    }
}
