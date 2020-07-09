using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public abstract class AbstractService<T>
    {
        public abstract int AddEntity(T entity);
        public abstract int UpdateEntity(T entity);
        public abstract T GetEntity(object key);
        public abstract List<T> GetEntities();
        public abstract void DeleteEntity(object key);
    }
}
