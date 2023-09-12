using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;

namespace Tienda.CarritoCompras
{
    public partial class CarritoDeCompras : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarCarrito();
                LabelUsuarioCarrito();
                SumarPrecio();
                //SacarIdCarrito();
                //ValidarCreacionCarrito();
                MostrarBoton();
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

                    string Command = "SELECT ID_DETALLE_CARRITO, MARCA, TIPO_PRENDA, TALLA_PRENDA, NUMERO_CANTIDAD_ANNADIDA, PRECIO_PRODUCTO FROM DETALLE_CARRITO " +
                                     "INNER JOIN PRODUCTO_ROPA ON PRODUCTO_ROPA.CODIGO_PRODUCTO = DETALLE_CARRITO.CODIGO_PRODUCTO " +
                                     "INNER JOIN USUARIOS ON USUARIOS.CORREO_ELECTRONICO = DETALLE_CARRITO.CORREO_ELECTRONICO " +
                                     "WHERE USUARIOS.CORREO_ELECTRONICO ='" + CorreoUsuario + "'";

                    SqlCommand SqlCommand = new SqlCommand(Command, con);

                    con.Open();

                    SqlDataAdapter Adapter = new SqlDataAdapter(SqlCommand);

                    DataTable dt = new DataTable();

                    Adapter.Fill(dt);
                    GridViewCarrito.DataSource = dt;
                    GridViewCarrito.DataBind();
                    con.Close();
                }
                else
                {
                    LblError.Visible = true;
                    LblError.Text = "Ha ocurrido un error";
                }
            }
            catch (Exception ex)
            {
                LblError.Visible = true;
                LblError.Text = ex.Message;
            }
        }

        void MostrarBoton()
        {
            try
            {
                if(GridViewCarrito.Rows.Count <= 0)
                {
                    ButtonPagar.Visible = false;
                }
                else
                {
                    ButtonPagar.Visible = true;
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

                    string Command = "SELECT SUM(PRECIO_PRODUCTO * NUMERO_CANTIDAD_ANNADIDA) AS TOTAL FROM PRODUCTO_ROPA " +
                                     "INNER JOIN DETALLE_CARRITO ON DETALLE_CARRITO.CODIGO_PRODUCTO = PRODUCTO_ROPA.CODIGO_PRODUCTO " +
                                     "INNER JOIN USUARIOS ON USUARIOS.CORREO_ELECTRONICO = DETALLE_CARRITO.CORREO_ELECTRONICO WHERE USUARIOS.CORREO_ELECTRONICO = '" + CorreoUsuario + "'";

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
            catch (Exception ex)
            {
                LblError.Visible = true;
                LblError.Text = ex.Message;
            }
        }

        //void SacarIdCarrito()
        //{
        //    String Rol = Session["TIPO_USUARIO"].ToString();

        //    try
        //    {
        //        if (Rol == "Normal")
        //        {
        //            String CorreoUsuario = Session["CORREO_ELECTRONICO"].ToString();

        //            string cs = @"DATA SOURCE = JOSELEWIS; INITIAL CATALOG = TIENDA_VIERNES; USER = JoseLewis10; PASSWORD = joselewis10";
        //            SqlConnection con = new SqlConnection(@"DATA SOURCE = JOSELEWIS; INITIAL CATALOG = TIENDA_VIERNES; USER = JoseLewis10; PASSWORD = joselewis10");

        //            string Command = "SELECT ID_DETALLE_CARRITO FROM DETALLE_CARRITO WHERE DETALLE_CARRITO.CORREO_ELECTRONICO = '" + CorreoUsuario + "'";

        //            SqlConnection SqlServer = new SqlConnection(cs);
        //            con.Open();

        //            SqlCommand cmd = new SqlCommand(Command, con);

        //            SqlDataAdapter Adapter = new SqlDataAdapter(cmd);

        //            SqlDataReader dr = cmd.ExecuteReader();

        //            if (dr.Read())
        //            {
        //                int Id = Convert.ToInt32(dr["ID_DETALLE_CARRITO"]);
        //                LblIdCarrito.Text = Id.ToString();
        //            }

        //            con.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LblError.Visible = true;
        //        LblError.Text = ex.Message;
        //    }
        //}

        protected void GridViewCarrito_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                using (TIENDA_VIERNESEntities1 ContextoDB = new TIENDA_VIERNESEntities1())
                {
                    int DetalleCarritoId = Convert.ToInt32(GridViewCarrito.DataKeys[e.RowIndex].Value);

                    DETALLE_CARRITO objCarrito = ContextoDB.DETALLE_CARRITO.First(x => x.ID_DETALLE_CARRITO == DetalleCarritoId);

                    ContextoDB.DETALLE_CARRITO.Remove(objCarrito);
                    ContextoDB.SaveChanges();
                    CargarCarrito();

                    Response.Redirect("../CarritoCompras/CarritoDeCompras.aspx");
                }
            }
            catch (Exception ex)
            {
                LblError.Visible = true;
                LblError.Text = ex.Message;
            }
        }

        //void CrearCarrito()
        //{
        //    try
        //    {
        //        using (TIENDA_VIERNESEntities1 ContextoDB = new TIENDA_VIERNESEntities1())
        //        {
        //            CARRITO oCarrito = new CARRITO();

        //            String CorreoUsuario = Session["CORREO_ELECTRONICO"].ToString();

        //            oCarrito.CORREO_ELECTRONICO = CorreoUsuario;
        //            oCarrito.CARRITO_ACTIVO = true;
        //            oCarrito.ESTADO_CARRITO = "Procesando";
                    
        //            ContextoDB.CARRITOes.Add(oCarrito);
        //            ContextoDB.SaveChanges();
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        LblError.Visible = true;
        //        LblError.Text = ex.Message;
        //    }
        //}

        //void ValidarCreacionCarrito()
        //{
        //    String Rol = Session["TIPO_USUARIO"].ToString();

        //    try
        //    {
        //        if (Rol == "Normal")
        //        {
        //            String CorreoUsuario = Session["CORREO_ELECTRONICO"].ToString();

        //            string cs = @"DATA SOURCE = JOSELEWIS; INITIAL CATALOG = TIENDA_VIERNES; USER = JoseLewis10; PASSWORD = joselewis10";
        //            SqlConnection con = new SqlConnection(@"DATA SOURCE = JOSELEWIS; INITIAL CATALOG = TIENDA_VIERNES; USER = JoseLewis10; PASSWORD = joselewis10");

        //            string Command = "SELECT CARRITO_ACTIVO FROM CARRITO WHERE CARRITO.CORREO_ELECTRONICO = '" + CorreoUsuario + "'";

        //            SqlConnection SqlServer = new SqlConnection(cs);
        //            con.Open();

        //            SqlCommand cmd = new SqlCommand(Command, con);

        //            SqlDataAdapter Adapter = new SqlDataAdapter(cmd);

        //            SqlDataReader dr = cmd.ExecuteReader();

        //            if (dr.HasRows == true)
        //            {
        //                dr.Read();
        //                LblEstadoCarrito.Text = dr["CARRITO_ACTIVO"].ToString();

        //                dr.Close();
        //            }
        //            else
        //            {
        //                if(GridViewCarrito.Rows.Count > 0)
        //                {
        //                    CrearCarrito();
        //                }
        //                else
        //                {
        //                    LblError.Visible = false;
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LblError.Visible = true;
        //        LblError.Text = ex.Message;
        //    }   
        //}

        protected void ButtonPagar_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("../OrdenCompra/OrdenCompra.aspx");
            }
            catch (Exception ex)
            {
                LblError.Visible = true;
                LblError.Text = ex.Message;
            }
        }
    }
}