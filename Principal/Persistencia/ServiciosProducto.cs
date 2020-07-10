using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class ServiciosProducto : AbstractService<PRODUCTO>
    {
        public override int AddEntity(PRODUCTO entity)
        {
            PRODUCTO producto = GetEntity(entity.idProducto);
            if (producto == null)
            {
                em.PRODUCTO.Add(entity);
                return em.SaveChanges();
            }
            else
            {
                throw new ArgumentException("EL PRODUCTO YA SE ENCUENTRA REGISTRADO");
            }
        }

        public override int UpdateEntity(PRODUCTO entity)
        {
            throw new NotImplementedException();
        }

        public override List<PRODUCTO> GetEntities()
        {
            return em.PRODUCTO.ToList<PRODUCTO>();
        }

        public override PRODUCTO GetEntity(object key)
        {
            return em.PRODUCTO.Where(a => a.idProducto == (int)key).FirstOrDefault<PRODUCTO>();
        }

        public override void DeleteEntity(object key)
        {
            PRODUCTO producto = GetEntity(key);
            if (producto != null)
            {
                em.PRODUCTO.Remove(producto);
                em.SaveChanges();
            }
            else
            {
                throw new ArgumentException("EL PRODUCTO NO SE ENCUENTRA REGISTRADO");
            }
        }
    }
}
