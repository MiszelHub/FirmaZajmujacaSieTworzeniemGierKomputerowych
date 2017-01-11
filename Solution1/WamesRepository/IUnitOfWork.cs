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
        IHeadQuartersReposotory HeadQuarters { get; }
        IDepartmentsRepository Departments { get; }
        IGamesRepository Games { get; }
        IGenresRepository Genres { get; }
        ITeamRepository Teams { get; }
        IPositionRepository Positions { get; }
        IAvailablePlatformsRepository AvailablePlatforms { get; }

        void ProcesChanges();
        void BeginTransaction(Action action);
    }
}
