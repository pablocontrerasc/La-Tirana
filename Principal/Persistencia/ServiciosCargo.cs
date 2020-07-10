using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class ServiciosCargo : AbstractService<CARGO>
    {
        public override int AddEntity(CARGO entity)
        {
            throw new NotImplementedException();
        }

        public override List<CARGO> GetEntities()
        {
            return em.CARGO.ToList<CARGO>();
        }

        public override CARGO GetEntity(object key)
        {
            return em.CARGO.Where(q => q.id == (int)key).FirstOrDefault<CARGO>();
        }

        public override int UpdateEntity(CARGO entity)
        {
            throw new NotImplementedException();
        }

        public override void DeleteEntity(object key)
        {
            throw new NotImplementedException();
        }
    }
}
