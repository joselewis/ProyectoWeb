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
    
    public partial class CARRITO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CARRITO()
        {
            this.DETALLE_CARRITO = new HashSet<DETALLE_CARRITO>();
            this.HISTORIAL_COMPRAS = new HashSet<HISTORIAL_COMPRAS>();
        }
    
        public int ID_CARRITO { get; set; }
        public string CORREO_ELECTRONICO { get; set; }
        public bool CARRITO_ACTIVO { get; set; }
        public string ESTADO_CARRITO { get; set; }
    
        public virtual USUARIO USUARIO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DETALLE_CARRITO> DETALLE_CARRITO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HISTORIAL_COMPRAS> HISTORIAL_COMPRAS { get; set; }
    }
}
