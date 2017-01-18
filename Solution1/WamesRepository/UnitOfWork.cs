using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WamesRepository
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly wamesEntities wamesContext;

        public UnitOfWork(wamesEntities wamesContext)
        {
            this.wamesContext = wamesContext;
            Employees = new EmployeeRepository(wamesContext);
            HeadQuarters = new HeadQuartersRepository(wamesContext);
            Departments = new DepartmentsRepository(wamesContext);
            Games = new GamesRepository(wamesContext);
            Genres = new GenreRepository(wamesContext);
            Teams = new TeamRepository(wamesContext);
            Positions = new PositionRepository(wamesContext);
            AvailablePlatforms = new AvailablePlatformsRepository(wamesContext);
        }

        public IDepartmentsRepository Departments { get; private set; }


        public IEmployeeRepository Employees { get; private set; }

        public IGamesRepository Games { get; private set; }

        public IHeadQuartersReposotory HeadQuarters { get; private set;}

        public IGenresRepository Genres { get; private set; }

        public ITeamRepository Teams { get; private set; }

        public IPositionRepository Positions { get; private set; }

        public IAvailablePlatformsRepository AvailablePlatforms { get; private set; }

        public void BeginTransaction(Action action)
        {
            using (var dbtransaction = wamesContext.Database.BeginTransaction())
            {
                action?.Invoke();
                ProcesChanges();
                dbtransaction.Commit();


            }
            
        }

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
