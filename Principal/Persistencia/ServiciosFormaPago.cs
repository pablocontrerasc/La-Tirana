using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class ServiciosFormaPago : AbstractService<FORMA_PAGO>
    {

        public override int AddEntity(FORMA_PAGO entity)
        {
            throw new NotImplementedException();
        }

        public override List<FORMA_PAGO> GetEntities()
        {
            return em.FORMA_PAGO.ToList<FORMA_PAGO>();
        }

        public override FORMA_PAGO GetEntity(object key)
        {
            return em.FORMA_PAGO.Where(q => q.id == (int)key).FirstOrDefault<FORMA_PAGO>();
        }

        public override int UpdateEntity(FORMA_PAGO entity)
        {
            throw new NotImplementedException();
        }

        public override void DeleteEntity(object key)
        {
            throw new NotImplementedException();
        }
    }
}
