using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WamesRepository
{
    public interface IUnitOfWork :IDisposable
    {
        IEmployeeRepository Employees { get;}
        void ProcesChanges();
    }
}
