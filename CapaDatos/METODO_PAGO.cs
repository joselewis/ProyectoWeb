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
    
    public partial class METODO_PAGO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public METODO_PAGO()
        {
            this.DINERO_PAGO = new HashSet<DINERO_PAGO>();
            this.ORDEN_COMPRA = new HashSet<ORDEN_COMPRA>();
        }
    
        public long NUMERO_TARJETA { get; set; }
        public decimal NUMERO_EXPIRA_1 { get; set; }
        public decimal NUMERO_EXPIRA_2 { get; set; }
        public decimal CODIGO_TARJETA { get; set; }
        public string CORREO_ELECTRONICO { get; set; }
        public bool TARJETA_ACTICA { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DINERO_PAGO> DINERO_PAGO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDEN_COMPRA> ORDEN_COMPRA { get; set; }
        public virtual USUARIO USUARIO { get; set; }
    }
}
