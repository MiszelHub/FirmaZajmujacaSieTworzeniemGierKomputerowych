using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WamesRepository
{
   
    public class DepartmentsRepository : Repository<departments>, IDepartmentsRepository
    {
        public DepartmentsRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<departments> GetDepartmentsFormHeadQuarters(string HqName)
        {
            var param = new SqlParameter("@HqName", HqName);
            
            var querry = context.Database.SqlQuery<departments>("GetDepartmentsFromHeadQuarters", param);
            return querry;
        }
    }
}
