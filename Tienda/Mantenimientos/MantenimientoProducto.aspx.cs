using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;

namespace Tienda.Mantenimientos
{
    public partial class MantenimientoProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarProductos();
                BotonVisible();

            }
        }

        void CargarProductos()
        {
            using (TIENDA_VIERNESEntities ContextoDB = new TIENDA_VIERNESEntities())
            {
                var ListadoProductos = ContextoDB.PRODUCTO_ROPA.ToList();

                if (ListadoProductos.Count >= 0)
                {
                    GridProductos.DataSource = ListadoProductos;
                    GridProductos.DataBind();
                }
                else
                {
                    PRODUCTO_ROPA objProducto = new PRODUCTO_ROPA();

                    ListadoProductos.Add(objProducto);
                    GridProductos.DataSource = ListadoProductos;
                    GridProductos.DataBind();
                    GridProductos.Rows[0].Cells.Clear();
                    GridProductos.Rows[0].Cells.Add(new TableCell());
                    GridProductos.Rows[0].Cells[0].ColumnSpan = 5;
                    GridProductos.Rows[0].Cells[0].Text = "No hay administradores registrados";
                    GridProductos.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                }
            }
        }

        int Validar()
        {
            int respuesta = 0;

            if (String.IsNullOrEmpty((GridProductos.FooterRow.FindControl("txt_footer_Codigo_Producto") as TextBox).Text))
            {
                LblError.Visible = true;
            }
            else
            {
                respuesta = 1;
            }
            return (respuesta);
        }

        protected void GridProductos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridProductos.EditIndex = -1;
            CargarProductos();
        }

        protected void GridProductos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
        }

        protected void GridProductos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int CodigoProducto = Convert.ToInt32(GridProductos.DataKeys[e.RowIndex].Value);
            int CodigoClasificarProducto = Convert.ToInt32(GridProductos.DataKeys[e.RowIndex].Value);

            using (TIENDA_VIERNESEntities ContextoDB = new TIENDA_VIERNESEntities())
            {
                PRODUCTO_ROPA objProducto = ContextoDB.PRODUCTO_ROPA.First(x => x.CODIGO_PRODUCTO == CodigoProducto);
                CLASIFICAR_ROPA objCategoriaProducto = ContextoDB.CLASIFICAR_ROPA.First(x => x.CODIGO_PRODUCTO == CodigoClasificarProducto);

                ContextoDB.CLASIFICAR_ROPA.Remove(objCategoriaProducto);
                ContextoDB.PRODUCTO_ROPA.Remove(objProducto);
                ContextoDB.SaveChanges();
                LblError.Text = "Eliminado correctamente";

                Response.Redirect("../Mantenimientos/MantenimientoProducto.aspx");
            }
        }

        protected void GridProductos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridProductos.EditIndex = e.NewEditIndex;
            CargarProductos();
        }

        protected void GridProductos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                GridViewRow row = GridProductos.Rows[e.RowIndex];

                TextBox txtTipoPrenda = row.FindControl("Txt_Tipo_Prenda") as TextBox;
                TextBox txtPrecioProducto = row.FindControl("Txt_Precio_Producto") as TextBox;
                TextBox txtCantidadProducto = row.FindControl("Txt_Cantidad_Disponible") as TextBox;
                TextBox txtDescripcionProducto = row.FindControl("Txt_Descrip_Producto") as TextBox;
                TextBox txtTallaPrenda = row.FindControl("Txt_Talla_Producto") as TextBox;
                TextBox txtMarcaProducto = row.FindControl("Txt_Marca_Producto") as TextBox;
                TextBox txtProductoActivo = row.FindControl("Txt_Producto_Activo") as TextBox;

                if (txtTipoPrenda != null &&
                   txtPrecioProducto != null &&
                   txtCantidadProducto != null &&
                   txtDescripcionProducto != null &&
                   txtTallaPrenda != null &&
                   txtMarcaProducto != null &&
                   txtProductoActivo != null
                   )
                {
                    using (TIENDA_VIERNESEntities ContextoDB = new TIENDA_VIERNESEntities())
                    {
                        int CodigoProducto = Convert.ToInt32(GridProductos.DataKeys[e.RowIndex].Value);

                        PRODUCTO_ROPA objProducto = ContextoDB.PRODUCTO_ROPA.First(x => x.CODIGO_PRODUCTO == CodigoProducto);

                        objProducto.TIPO_PRENDA = txtTipoPrenda.Text;
                        objProducto.PRECIO_PRODUCTO = Convert.ToInt32(txtPrecioProducto.Text);
                        objProducto.CANTIDAD_PRODUCTO = Convert.ToInt32(txtCantidadProducto.Text);
                        objProducto.DESCRIPCION_PRODUCTO = txtDescripcionProducto.Text;
                        objProducto.TALLA_PRENDA = txtTallaPrenda.Text;
                        objProducto.MARCA = txtMarcaProducto.Text;
                        objProducto.PRODUCTO_ACTIVO = Convert.ToBoolean(txtProductoActivo.Text);

                        ContextoDB.SaveChanges();
                        LblError.Visible = true;
                        LblError.Text = "Producto actualizado";
                        GridProductos.EditIndex = -1;
                        CargarProductos();
                    }
                }
            }
            catch(Exception ex)
            {
                LblError.Visible = true;
                LblError.Text = ex.Message;
            }
        }

        protected void GridProductos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ButtonExportarProductoExcel_Click(object sender, EventArgs e)
        {

        }

        void BotonVisible()
        {
            try
            {
                if (GridProductos.Rows.Count >= 1)
                {
                    ButtonExportarProductoExcel.Visible = true;
                }
                else
                {
                    ButtonExportarProductoExcel.Visible = false;
                }
            }
            catch (Exception ex)
            {
                LblError.Visible = true;
                LblError.Text = ex.Message;
            }
        }
    }
}