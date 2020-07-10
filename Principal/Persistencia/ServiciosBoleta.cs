using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class ServiciosBoleta : AbstractService<BOLETA>
    {
        public override int AddEntity(BOLETA entity)
        {
            BOLETA boleta = GetEntity(entity.idBoleta);
            if (boleta == null)
            {
                em.BOLETA.Add(entity);
                return em.SaveChanges();
            }
            else
            {
                throw new ArgumentException("LA BOLETA YA SE ENCUENTRA REGISTRADA");
            }
        }

        public override int UpdateEntity(BOLETA entity)
        {
            throw new NotImplementedException();
        }

        public override List<BOLETA> GetEntities()
        {
            return em.BOLETA.ToList<BOLETA>();
        }

        public override BOLETA GetEntity(object key)
        {
            return em.BOLETA.Where(a => a.idBoleta == (int)key).FirstOrDefault<BOLETA>();
        }

        public override void DeleteEntity(object key)
        {
            BOLETA boleta = GetEntity(key);
            if (boleta != null)
            {
                em.BOLETA.Remove(boleta);
                em.SaveChanges();
            }
            else
            {
                throw new ArgumentException("LA BOLETA NO SE ENCUENTRA REGISTRADA");
            }
        }
    }
}
