//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CapaDatos
{
    using System;
    using System.Collections.Generic;
    
    public partial class HISTORIAL_COMPRAS
    {
        public int ID_COMPRA_USUARIO { get; set; }
        public int CODIGO_PRODUCTO { get; set; }
        public int NUMERO_CANTIDAD { get; set; }
        public int NUMERO_CANTIDAD_ANNADIDA { get; set; }
        public int ID_CARRITO { get; set; }
        public string CORREO_ELECTRONICO { get; set; }
        public string ESTADO_PRODUCTO { get; set; }
    
        public virtual CARRITO CARRITO { get; set; }
        public virtual USUARIO USUARIO { get; set; }
        public virtual PRODUCTO_ROPA PRODUCTO_ROPA { get; set; }
    }
}
