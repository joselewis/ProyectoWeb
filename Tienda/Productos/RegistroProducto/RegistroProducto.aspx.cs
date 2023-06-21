using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;

namespace Tienda.Productos.RegistroProducto
{
    public partial class RegistroProducto : System.Web.UI.Page
    {

        int ProductoIngresado = 0;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        void RegistrarProducto()
        {
            try 
            {
                using (TIENDA_VIERNESEntities ContextoDB = new TIENDA_VIERNESEntities())
                {
                    PRODUCTO_ROPA oProductoRopa = new PRODUCTO_ROPA();

                    oProductoRopa.CODIGO_PRODUCTO = Convert.ToInt32(CajaCodigoProducto.Text);
                    oProductoRopa.TIPO_PRENDA = CajaTipoPrenda.Text;
                    oProductoRopa.PRECIO_PRODUCTO = Convert.ToInt32(CajaPrecioProducto.Text);
                    oProductoRopa.CANTIDAD_PRODUCTO = Convert.ToInt32(CajaCantidadProducto.Text);
                    oProductoRopa.DESCRIPCION_PRODUCTO = CajaDescripcionProducto.Text;
                    oProductoRopa.TALLA_PRENDA = CajaTallaPrenda.Text;
                    oProductoRopa.MARCA = CajaMarcaProducto.Text;
                    oProductoRopa.PRODUCTO_ACTIVO = CheckBoxProductoActivo.Checked;
                    oProductoRopa.IMAGEN = ImagenProducto.FileBytes;

                    ContextoDB.PRODUCTO_ROPA.Add(oProductoRopa);
                    ContextoDB.SaveChanges();

                    ProductoIngresado = 1;
                }    
            } 
            catch (Exception ex) 
            {
                lblAlamacenado.Text = ex.Message;
            }
        }

        void ValidacionIngresoProducto()
        {
            if (ProductoIngresado == 1)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "sr1", "Swal.fire('Producto ingresado correctamente.')", true);
                Response.Redirect("/Mantenimientos/MantenimientoProductos.aspx");
            }
        }

        protected void Btn_Registar_Producto_Click(object sender, EventArgs e)
        {
            RegistrarProducto();
            ValidacionIngresoProducto();
        }
    }
}