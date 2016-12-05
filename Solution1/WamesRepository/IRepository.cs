using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WamesRepository
{
    interface IRepository<T>
    {
        void Add(T Entity);

    }
}
