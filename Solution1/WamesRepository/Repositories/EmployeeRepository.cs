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

        public IEnumerable<employees> GetEmployeesByPositionName(string position)
        {
            throw new NotImplementedException();
        }

        public employees GetEmployeesFromDepartment(string DepartmentName, string hq)
        {
            
            
            var querry = context.Database.SqlQuery<employees>("GetEmployeesFromDepartment").Single();
            
            return querry;
        }

        public IEnumerable<employees> GetEmployeesFromHeadQuarters(string hq)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<employees> GetEmployeesFromTeam(string team)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<employees> GetEmployeesFromTheDepartmentWithSalaryHigherThanAverage(decimal salary)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<employees> GetEmployeesWithSalaryHigherThanAverage(decimal salary)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<employees> GetTopEarningEmployeeByPosition(string position)
        {
            throw new NotImplementedException();
        }
    }
}
