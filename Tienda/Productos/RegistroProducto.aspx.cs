using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
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
            if (!Page.IsPostBack)
            {
                CargarDropDownTipoPrenda();
                CargarDropDownGenero();
            }
        }

        void CargarDropDownTipoPrenda()
        {
            DropDwonListTipoPrenda.DataSource = ClassTipoPrenda.ListadoPrendas;
            DropDwonListTipoPrenda.DataValueField = "CATEGORIA_NUMERO";
            DropDwonListTipoPrenda.DataTextField = "CATEGORIA_PRENDA";
            DropDwonListTipoPrenda.DataBind();
        }

        void CargarDropDownGenero()
        {
            DropDownListGenero.DataSource = ClassGeneroRopa.ListadoGenero;
            DropDownListGenero.DataValueField = "NUMERO_GENERO";
            DropDownListGenero.DataTextField = "GENERO_PRENDA";
            DropDownListGenero.DataBind();
        }

        void RegistrarProducto()
        {
            try 
            {
                using (TIENDA_VIERNESEntities1 ContextoDB = new TIENDA_VIERNESEntities1())
                {
                    PRODUCTO_ROPA oProductoRopa = new PRODUCTO_ROPA();
                    CLASIFICAR_ROPA oClasificar = new CLASIFICAR_ROPA();
                    GENERO_ROPA oGenero = new GENERO_ROPA();

                    oProductoRopa.CODIGO_PRODUCTO = Convert.ToInt32(CajaCodigoProducto.Text);
                    oProductoRopa.TIPO_PRENDA = CajaTipoPrenda.Text;
                    oProductoRopa.PRECIO_PRODUCTO = Convert.ToInt32(CajaPrecioProducto.Text);
                    oProductoRopa.CANTIDAD_PRODUCTO = Convert.ToInt32(CajaCantidadProducto.Text);
                    oProductoRopa.NUMERO_CANTIDAD_PRODUCTO = Convert.ToInt32(CajaCantidadProducto.Text);
                    oProductoRopa.DESCRIPCION_PRODUCTO = CajaDescripcionProducto.Text;
                    oProductoRopa.TALLA_PRENDA = CajaTallaPrenda.Text.ToUpper();
                    oProductoRopa.MARCA = CajaMarcaProducto.Text;
                    oProductoRopa.PRODUCTO_ACTIVO = CheckBoxProductoActivo.Checked;
                    oProductoRopa.IMAGEN = ImagenProducto.FileBytes;

                    oClasificar.CODIGO_PRODUCTO = Convert.ToInt32(CajaCodigoProducto.Text);
                    oClasificar.CATEGORIA_NUMERO = Convert.ToInt32(DropDwonListTipoPrenda.SelectedValue);
                    oClasificar.CATEGORIA_PRENDA = DropDwonListTipoPrenda.SelectedItem.Text;

                    oGenero.CODIGO_PRODUCTO = Convert.ToInt32(CajaCodigoProducto.Text);
                    oGenero.NUMERO_GENERO = Convert.ToInt32(DropDownListGenero.SelectedValue);
                    oGenero.GENERO_PRENDA = DropDownListGenero.SelectedItem.Text;

                    ContextoDB.PRODUCTO_ROPA.Add(oProductoRopa);
                    ContextoDB.CLASIFICAR_ROPA.Add(oClasificar);
                    ContextoDB.SaveChanges();

                    ProductoIngresado = 1;
                }    
            }
            catch (Exception ex) 
            {
                lblAlamacenado.Visible = true;
                lblAlamacenado.Text = ex.Message;
            }
        }

        void ValidacionIngresoProducto()
        {
            try
            {
                if (ProductoIngresado == 1)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "sr1", "Swal.fire('Producto ingresado correctamente.')", true);
                    Response.Redirect("../Mantenimientos/MantenimientoProducto.aspx");
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "sr1", "Swal.fire('No se ha podido añadir el producto')", true);
                    Response.Redirect("../Productos/RegistrarProducto.aspx");
                }
            }
            catch(Exception ex)
            {
                lblAlamacenado.Visible = true;
                lblAlamacenado.Text = ex.Message;
            }
        }

        protected void Btn_Registar_Producto_Click(object sender, EventArgs e)
        {
            try
            {
                if (CajaCodigoProducto.Text != null &&
                    CajaCantidadProducto.Text != null &&
                    CajaDescripcionProducto .Text != null &&
                    CajaMarcaProducto.Text != null &&
                    CajaPrecioProducto.Text != null &&
                    CajaTallaPrenda.Text != null &&
                    CajaTipoPrenda.Text != null &&
                    ImagenProducto.FileBytes != null &&
                    CheckBoxProductoActivo != null && 
                    DropDownListGenero != null &&
                    DropDwonListTipoPrenda != null
                    )
                {
                    RegistrarProducto();
                    ValidacionIngresoProducto();
                }
                else
                {
                    lblAlamacenado.Visible = true;
                    lblAlamacenado.Text = "No se ha podido añadir el producto";
                }
            }
            catch( Exception ex )
            {
                lblAlamacenado.Visible = true;
                lblAlamacenado.Text = ex.Message;
            }
        }
    }
}