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
    
    public partial class PRODUCTO_ROPA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PRODUCTO_ROPA()
        {
            this.CLASIFICAR_ROPA = new HashSet<CLASIFICAR_ROPA>();
            this.GENERO_ROPA = new HashSet<GENERO_ROPA>();
            this.CARRITOes = new HashSet<CARRITO>();
        }
    
        public int ID_PRODUCTO { get; set; }
        public int CODIGO_PRODUCTO { get; set; }
        public string TIPO_PRENDA { get; set; }
        public int PRECIO_PRODUCTO { get; set; }
        public int NUMERO_CANTIDAD_PRODUCTO { get; set; }
        public int CANTIDAD_PRODUCTO { get; set; }
        public string DESCRIPCION_PRODUCTO { get; set; }
        public string TALLA_PRENDA { get; set; }
        public byte[] IMAGEN { get; set; }
        public string MARCA { get; set; }
        public bool PRODUCTO_ACTIVO { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLASIFICAR_ROPA> CLASIFICAR_ROPA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GENERO_ROPA> GENERO_ROPA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CARRITO> CARRITOes { get; set; }
    }
}
