using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace WamesRepository
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        protected wamesEntities context;

        public Repository(wamesEntities context)
        {
            this.context = context; 
        }
        public void AddEntityToDatabase(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException();
           
            context.Set<T>().Add(entity);
            
        }

        public void AddRangeOfEntities(IEnumerable<T> entities)
        {
            if (entities == null)
                throw new ArgumentNullException();

            context.Set<T>().AddRange(entities);
            
        }

        public IEnumerable<T> FindInDataBase(Func<T, bool> predicate)
        {
          return context.Set<T>().Where(predicate);
        }

        public IEnumerable<T> GetAllEtitiesFromDataBase()
        {

            return context.Set<T>().ToList();
        }

        public T GetEntityByID(int id)
        {
            return context.Set<T>().Find(id);
        }

        public void RemoveEntityFromDataBase(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException();

            context.Set<T>().Remove(entity);
        }

        public void RemoveRangeOfEntitiesFromDB(IEnumerable<T> entities)
        {
            if (entities == null)
                throw new ArgumentNullException();

            context.Set<T>().RemoveRange(entities);
        }
    }
}
