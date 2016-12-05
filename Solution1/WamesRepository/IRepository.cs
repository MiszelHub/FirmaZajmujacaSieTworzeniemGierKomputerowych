using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WamesRepository
{
    public interface IRepository<T> where T: class
    {
        void AddEntityToDatabase(T Entity);
        void AddRangeOfEntities(IEnumerable<T> range);
        IEnumerable<T> GetAllEtitiesFromDataBase();
        void RemoveEntityFromDataBase(T entity);
        void RemoveRangeOfEntitiesFromDB(IEnumerable<T> entities);
        IEnumerable<T> FindInDataBase(Func<T,bool> predicate);

    }
}
