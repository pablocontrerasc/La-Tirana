using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class ServiciosEmpleado : AbstractService<EMPLEADO>
    {
        public override int AddEntity(EMPLEADO entity)
        {
            EMPLEADO empleado = GetEntity(entity.CodVendedor);
            if (empleado == null)
            {
                em.EMPLEADO.Add(entity);
                return em.SaveChanges();
            }
            else
            {
                throw new ArgumentException("EL EMPLEADO YA SE ENCUENTRA REGISTRADO");
            }
        }

        public override int UpdateEntity(EMPLEADO entity)
        {
            EMPLEADO empleado = GetEntity(entity.CodVendedor);
            if (empleado == null)
            {
                throw new ArgumentException("EL EMPLEADO NO SE ENCUENTRA REGISTRADO");
            }
            else
            {
                empleado.Nombre = entity.Nombre;
                empleado.Apellido = entity.Apellido;
                empleado.Usuario = entity.Usuario;
                empleado.Contrasena = entity.Contrasena;
                empleado.idCargo = entity.idCargo;
             
                return em.SaveChanges();
            }
        }

        public override List<EMPLEADO> GetEntities()
        {
            return em.EMPLEADO.ToList<EMPLEADO>();
        }

        public override EMPLEADO GetEntity(object key)
        {
            return em.EMPLEADO.Where(a => a.CodVendedor == (int)key).FirstOrDefault<EMPLEADO>();
        }

        public override void DeleteEntity(object key)
        {
            EMPLEADO empleado = GetEntity(key);
            if (empleado != null)
            {
                em.EMPLEADO.Remove(empleado);
                em.SaveChanges();
            }
            else
            {
                throw new ArgumentException("EL EMPLEADO NO SE ENCUENTRA REGISTRADO ");
            }
        }

    }
}
