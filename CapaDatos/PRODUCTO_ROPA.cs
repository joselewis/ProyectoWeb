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
        public int ID_PRODUCTO { get; set; }
        public int CODIGO_PRODUCTO { get; set; }
        public string TIPO_PRENDA { get; set; }
        public int PRECIO_PRODUCTO { get; set; }
        public int CANTIDAD_PRODUCTO { get; set; }
        public string DESCRIPCION_PRODUCTO { get; set; }
        public string TALLA_PRENDA { get; set; }
        public byte[] IMAGEN { get; set; }
        public string MARCA { get; set; }
        public bool PRODUCTO_ACTIVO { get; set; }
    }
}