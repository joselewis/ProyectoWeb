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
    
    public partial class DINERO_PAGO
    {
        public int ID_DINERO { get; set; }
        public int CANTIDAD_DISPONIBLE { get; set; }
        public Nullable<long> NUMERO_TARJETA { get; set; }
    
        public virtual METODO_PAGO METODO_PAGO { get; set; }
    }
}