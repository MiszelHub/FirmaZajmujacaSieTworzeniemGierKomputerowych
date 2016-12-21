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
        employees GetEmployeesFromDepartment(string DepartmentName, string HqName);
    }
}
