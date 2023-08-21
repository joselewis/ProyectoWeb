using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
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
                LabelUsuarioCarrito();
                SumarPrecio();
                CargarBoton();
            }
        }

        void CargarCarrito()
        {
            try
            {
                String Rol = Session["TIPO_USUARIO"].ToString();

                if (Rol == "Normal")
                {
                    String CorreoUsuario = Session["CORREO_ELECTRONICO"].ToString();

                    string cs = @"DATA SOURCE = JOSELEWIS; INITIAL CATALOG = TIENDA_VIERNES; USER = JoseLewis10; PASSWORD = joselewis10";
                    SqlConnection con = new SqlConnection(@"DATA SOURCE = JOSELEWIS; INITIAL CATALOG = TIENDA_VIERNES; USER = JoseLewis10; PASSWORD = joselewis10");
                    string Command = "SELECT TIPO_PRENDA, PRECIO_PRODUCTO, CANTIDAD_PRODUCTO, TALLA_PRENDA, MARCA, NUMERO_CANTIDAD, ID_CARRITO  FROM PRODUCTO_ROPA " +
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
            }
            catch(Exception ex)
            {
                LblError.Visible = true;
                LblError.Text = ex.Message;
            }
        }

        void LabelUsuarioCarrito()
        {
            try
            {
                String Rol = Session["TIPO_USUARIO"].ToString();

                if (GridViewCarrito.Rows.Count < 1 && Rol == "Normal")
                {
                    LblCarritoVacio.Visible = true;
                    LblCarritoVacio.Text = "No hay productos añadidos al carrito";
                }
                else
                {
                    LblCarritoVacio.Visible = false;
                    LblCarritoVacio.Text = "Un administrador no puede utilizar el carrito de compras";
                }
            }
            catch(Exception ex)
            {
                LblError.Visible = true;
                LblError.Text = ex.Message;
            }
        }

        protected void GridViewCarrito_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                using (TIENDA_VIERNESEntities1 ContextoDB = new TIENDA_VIERNESEntities1())
                {
                    int CarritoId = Convert.ToInt32(GridViewCarrito.DataKeys[e.RowIndex].Value);

                    CARRITO objCarrito = ContextoDB.CARRITO.First(x => x.ID_CARRITO == CarritoId);

                    ContextoDB.CARRITO.Remove(objCarrito);
                    ContextoDB.SaveChanges();
                    CargarCarrito();

                    Response.Redirect("../CarritoCompras/CarritoCompras.aspx");
                }
            }
            catch (Exception ex)
            {
                LblError.Visible = true;
                LblError.Text = ex.Message;
            }
        }

        void SumarPrecio()
        {
            String Rol = Session["TIPO_USUARIO"].ToString();

            try
            {
                if (Rol == "Normal")
                {
                    String CorreoUsuario = Session["CORREO_ELECTRONICO"].ToString();

                    string cs = @"DATA SOURCE = JOSELEWIS; INITIAL CATALOG = TIENDA_VIERNES; USER = JoseLewis10; PASSWORD = joselewis10";
                    SqlConnection con = new SqlConnection(@"DATA SOURCE = JOSELEWIS; INITIAL CATALOG = TIENDA_VIERNES; USER = JoseLewis10; PASSWORD = joselewis10");

                    string Command = "SELECT SUM(PRECIO_PRODUCTO * NUMERO_CANTIDAD) AS TOTAL FROM PRODUCTO_ROPA INNER JOIN CARRITO ON CARRITO.CODIGO_PRODUCTO = PRODUCTO_ROPA.CODIGO_PRODUCTO " +
                                     "INNER JOIN USUARIOS ON USUARIOS.CORREO_ELECTRONICO = CARRITO.CORREO_ELECTRONICO WHERE USUARIOS.CORREO_ELECTRONICO = '" + CorreoUsuario + "'";

                    SqlConnection SqlServer = new SqlConnection(cs);
                    con.Open();
                    SqlCommand cmd = new SqlCommand(Command, con);

                    if (GridViewCarrito.Rows.Count >= 1)
                    {
                        LblTotal.Visible = true;
                        LblTotal.Text = "Total: ";
                        LblPrecioTotal.Visible = true;
                        LblPrecioTotal.Text = Convert.ToString(cmd.ExecuteScalar());
                    }
                    else
                    {
                        LblTotal.Visible = true;
                        LblTotal.Text = "Total: 0";
                    }


                    con.Close();
                }
            }
            catch(Exception ex)
            {
                LblError.Visible = true;
                LblError.Text = ex.Message;
            }
        }

        void CargarBoton()
        {
            try
            {
                String Rol = Session["TIPO_USUARIO"].ToString();

                if (GridViewCarrito.Rows.Count >= 1 && Rol == "Normal")
                {
                    ButtonPagar.Visible = true;
                }
                else
                {
                    ButtonPagar.Visible = false;
                }
            }
            catch(Exception ex)
            {
                LblError.Visible = true;
                LblError.Text = ex.Message;
            }
        }

        protected void ButtonPagar_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("../OrdenCompra/OrdenCompra.aspx");
            }
            catch(Exception ex)
            {
                LblError.Visible = true;
                LblError.Text = ex.Message;
            }
        }
    }
}