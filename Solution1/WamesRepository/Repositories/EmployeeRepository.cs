using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
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
            RemoveEntityFromDataBase(GetEntityByID(id));
            
        }

        public employees GetEmployeesFromDepartment(string DepartmentName, string HqName)
        {
            
            
            var querry = context.Database.SqlQuery<employees>("GetEmployeesFromDepartment").Single();
            
            return querry;
        }
    }
}
