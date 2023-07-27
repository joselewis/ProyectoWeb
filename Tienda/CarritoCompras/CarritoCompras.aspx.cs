using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;

namespace Tienda.CarritoCompras
{
    public partial class CarritoCompras : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarCarrito();
            }
        }

        void CargarCarrito()
        {
            String CorreoUsuario = Session["CORREO_ELECTRONICO"].ToString();
            string cs = @"DATA SOURCE = LAPTOP-VEC1I0DC; INITIAL CATALOG = TIENDA_VIERNES; USER = JoseLewis10; PASSWORD = joselewis10";
            SqlConnection con = new SqlConnection(@"DATA SOURCE = LAPTOP-VEC1I0DC; INITIAL CATALOG = TIENDA_VIERNES; USER = JoseLewis10; PASSWORD = joselewis10");
            string Command = "SELECT TIPO_PRENDA, PRECIO_PRODUCTO, CANTIDAD_PRODUCTO, TALLA_PRENDA, MARCA, NUMERO_CANTIDAD  FROM PRODUCTO_ROPA " +
                             "INNER JOIN CARRITO ON CARRITO.CODIGO_PRODUCTO = PRODUCTO_ROPA.CODIGO_PRODUCTO " +
                             "INNER JOIN USUARIOS ON USUARIOS.CORREO_ELECTRONICO = CARRITO.CORREO_ELECTRONICO WHERE USUARIOS.CORREO_ELECTRONICO ='" + CorreoUsuario + "'";

            SqlCommand SqlCommand = new SqlCommand(Command, con);

            con.Open();

            SqlDataAdapter Adapter = new SqlDataAdapter(SqlCommand);

            DataTable dt = new DataTable();

            Adapter.Fill(dt);
            GridViewCarrito.DataSource = dt;
            GridViewCarrito.DataBind();
            con.Close();

        }

        protected void GridViewCarrito_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int CodigoProducto = Convert.ToInt32(GridViewCarrito.DataKeys[e.RowIndex].Value);
                int IdCarrito = Convert.ToInt32(GridViewCarrito.DataKeys[e.RowIndex].Value);
                int UsuarioCorreo = Convert.ToInt32(GridViewCarrito.DataKeys[e.RowIndex].Value);

                using (TIENDA_VIERNESEntities ContextoDB = new TIENDA_VIERNESEntities())
                {
                    PRODUCTO_ROPA objProducto = ContextoDB.PRODUCTO_ROPA.First(x => x.CODIGO_PRODUCTO == CodigoProducto);
                    USUARIO objUsuario = ContextoDB.USUARIOS.First(x => x.CORREO_ELECTRONICO == Convert.ToString(UsuarioCorreo));
                    CARRITO objCarrito = ContextoDB.CARRITOes.First(x => x.CORREO_ELECTRONICO == Convert.ToString(UsuarioCorreo));

                    ContextoDB.USUARIOS.Remove(objUsuario);
                    ContextoDB.PRODUCTO_ROPA.Remove(objProducto);
                    ContextoDB.CARRITOes.Remove(objCarrito);
                    ContextoDB.SaveChanges();
                    LblError.Visible = true;
                    LblError.Text = "Eliminado correctamente";

                    Response.Redirect("../../CarritoCompras/CarritoCompras.aspx");
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