using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WamesRepository
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly WamesModel wamesContext;

        public UnitOfWork(WamesModel wamesContext)
        {
            this.wamesContext = wamesContext;
            Employees = new EmployeeRepository(wamesContext);
        }
        public IEmployeeRepository Employees { get; private set; }

        public void Dispose()
        {
            wamesContext.Dispose();
        }

        public void ProcesChanges()
        {
            wamesContext.SaveChanges();
        }
    }
}
