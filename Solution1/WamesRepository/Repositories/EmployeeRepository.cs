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
        public EmployeeRepository(wamesEntities wamesContext) : base(wamesContext)
        {
        }

        public void DeleteEmployeeByHisId(int id)
        {
            RemoveEntityFromDataBase(GetEntityByID(id));
            
        }

        public IEnumerable<employees> GetEmployeesByPositionName(string position)
        {
            return context.GetEmployeesByPositionName(position);
        }

        public employees GetEmployeesFromDepartment(string DepartmentName, string hq)
        {
            
            
            var querry = context.Database.SqlQuery<employees>("GetEmployeesFromDepartment").Single();
            
            return querry;
        }

        public IEnumerable<employees> GetEmployeesFromHeadQuarters(string hq)
        {
            return context.GetEmployeesFromHeadQuarters(hq);
        }


        public IEnumerable<employees> GetEmployeesFromTeam(int teamId)
        {
            return context.GetEmployeesFromTheTeam(teamId);
        }

        public IEnumerable<employees> GetEmployeesFromTheDepartmentWithSalaryHigherThanAverage(string departmentName)
        {
            return context.GetEmployeesFromTheDepartmentWithSalaryHigherThenAverage(departmentName);
        }


        public IEnumerable<employees> GetTopEarningEmployeeByPosition(string position)
        {
            return context.GetTopEarningEmployeeByPosition(position);
        }
    }
}
