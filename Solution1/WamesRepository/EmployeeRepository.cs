using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WamesRepository
{
    public class EmployeeRepository : Repository<employees>, IEmployeeRepository
    {
        public EmployeeRepository(DbContext wamesContext) : base(wamesContext)
        {
        }

        public void DeleteEmployeeByHisId(int id)
        {
            var employeedoRemove = GetAllEtitiesFromDataBase().SingleOrDefault(x => x.employee_id == id);

            RemoveEntityFromDataBase(employeedoRemove);
            
        }

    }
}
