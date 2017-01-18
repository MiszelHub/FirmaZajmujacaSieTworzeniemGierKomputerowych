using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WamesRepository
{
    public class PositionRepository : Repository<positions>, IPositionRepository
    {
        public PositionRepository(wamesEntities context):base(context)
        {

        }
    }
}
