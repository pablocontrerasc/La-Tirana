//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Persistencia
{
    using System;
    using System.Collections.Generic;
    
    public partial class BOLETA
    {
        public int idBoleta { get; set; }
        public Nullable<int> NroOperacion { get; set; }
        public Nullable<int> MontoTotal { get; set; }
        public Nullable<int> CantidadProducto { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public Nullable<int> idFormaPago { get; set; }
        public Nullable<int> idVendedor { get; set; }
        public Nullable<int> idProducto { get; set; }
        public Nullable<int> NroBoleta { get; set; }
    
        public virtual EMPLEADO EMPLEADO { get; set; }
        public virtual FORMA_PAGO FORMA_PAGO { get; set; }
        public virtual DETALLE_COMPRA DETALLE_COMPRA { get; set; }
        public virtual PRODUCTO PRODUCTO { get; set; }
    }
}
