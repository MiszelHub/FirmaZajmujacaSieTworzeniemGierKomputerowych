using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WamesRepository
{
    public interface IEmployeeRepository :IRepository<employees>
    {
        void DeleteEmployeeByHisId(int id);
        employees GetEmployeesFromDepartment(string DepartmentName, string hq);
        IEnumerable<employees> GetEmployeesByPositionName(string position);
        IEnumerable<employees> GetEmployeesFromTheDepartmentWithSalaryHigherThanAverage(string departmentName);
        IEnumerable<employees> GetEmployeesFromTeam(int teamid);
        IEnumerable<employees> GetTopEarningEmployeeByPosition(string position);
        IEnumerable<employees> GetEmployeesFromHeadQuarters(string hq);
    }
}
