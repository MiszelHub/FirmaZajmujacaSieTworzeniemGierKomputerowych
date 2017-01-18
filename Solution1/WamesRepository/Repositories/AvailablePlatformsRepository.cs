using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WamesRepository
{
    public class AvailablePlatformsRepository : Repository<availablePlatforms>, IAvailablePlatformsRepository
    {
        public AvailablePlatformsRepository(wamesEntities context):base(context)
        {

        }
    }
}
