using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web; 
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Reflection.Emit;

namespace Tienda.Productos.ProductoEspecifico
{
    public partial class ProductoEspecifico : System.Web.UI.Page
    {
        int id;
        int IdCarrito;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                SacarIdCarrito();
                MostrarImagen();
                CargarInfoProducto();
                //CargarCantidaProducto();
                DesplegarCuentaDDL();
                MostrarBoton();   
            }
        }

        void MostrarImagen()
        {
            string cs = @"DATA SOURCE = JOSELEWIS; INITIAL CATALOG = TIENDA_VIERNES; USER = JoseLewis10; PASSWORD = joselewis10";
            SqlConnection con = new SqlConnection(@"DATA SOURCE = JOSELEWIS; INITIAL CATALOG = TIENDA_VIERNES; USER = JoseLewis10; PASSWORD = joselewis10");

            try
            {
                using (SqlConnection connection = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand("SPSACARIMAGEN", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter paramId = new SqlParameter()
                    {
                        ParameterName = "@ID",
                        Value = Request.QueryString["ID"],
                    };

                    cmd.Parameters.Add(paramId);
                    
                    con.Open();

                    byte[] bytes = (byte[])cmd.ExecuteScalar();
                    string strBase64 = Convert.ToBase64String(bytes);

                    ImagenProductoEspec.ImageUrl = "data:Image/jpg;base64," + strBase64;

                    con.Close();
                }  
            }
            catch (Exception ex) 
            {
                lblError.Visible = true;
                lblError.Text = ex.Message;
            }
        }

        void CargarInfoProducto()
        {
            try
            {
                string cs = @"DATA SOURCE = JOSELEWIS; INITIAL CATALOG = TIENDA_VIERNES; USER = JoseLewis10; PASSWORD = joselewis10";
                SqlConnection con = new SqlConnection(@"DATA SOURCE = JOSELEWIS; INITIAL CATALOG = TIENDA_VIERNES; USER = JoseLewis10; PASSWORD = joselewis10");

                using (SqlConnection connection = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand("SPSACARIMAGEN", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter paramId = new SqlParameter()
                    {
                        ParameterName = "@ID",
                        Value = Request.QueryString["ID"],
                    };

                    cmd.Parameters.Add(paramId);

                    SqlDataReader dr;

                    con.Open();

                    dr = cmd.ExecuteReader();

                    if (dr.HasRows == true)
                    {
                        dr.Read();
                        LabelDescripcion.Text = dr["DESCRIPCION_PRODUCTO"].ToString();
                        LabelPrecio.Text = dr["PRECIO_PRODUCTO"].ToString();
                        LabelCantidad.Text = dr["CANTIDAD_PRODUCTO"].ToString();
                        LabelNombre.Text = dr["TIPO_PRENDA"].ToString();

                        dr.Close();
                    }
                    else
                    {
                        lblError.Visible = true;
                        lblError.Text = "Ha ocurrido un problema";
                    }
                }
            }
            catch(Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = ex.Message;
            }
        }

        void DesplegarCuentaDDL()
        {
            id = Convert.ToInt32(Request.QueryString["id"].ToString());

            try
            {
                string cs = @"DATA SOURCE = JOSELEWIS; INITIAL CATALOG = TIENDA_VIERNES; USER = JoseLewis10; PASSWORD = joselewis10";
                SqlConnection con = new SqlConnection(@"DATA SOURCE = JOSELEWIS; INITIAL CATALOG = TIENDA_VIERNES; USER = JoseLewis10; PASSWORD = joselewis10");
                string Command = "SELECT CANTIDAD_PRODUCTO FROM PRODUCTO_ROPA WHERE CODIGO_PRODUCTO = '" + id + "'";

                SqlCommand SqlCommand = new SqlCommand(Command, con);

                con.Open();

                SqlDataAdapter Adapter = new SqlDataAdapter(SqlCommand);

                SqlDataReader dr = SqlCommand.ExecuteReader();

                if (dr.Read())
                {
                    int Cantidad = Convert.ToInt32(dr["CANTIDAD_PRODUCTO"].ToString());
                    
                    //DropDownCantidadProducto.Items.Insert(0, new ListItem("-Cantidad-", "0"));

                    for (int i = 1; i <= Cantidad; i++)
                    {
                        DropDownCantidadProducto.Items.Add(new ListItem(i.ToString(), i.ToString()));
                    }
                }
                con.Close();
            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = ex.Message;
            }
        }

        void SacarIdCarrito()
        {
            String Rol = Session["TIPO_USUARIO"].ToString();

            try
            {
                if (Rol == "Normal")
                {
                    String CorreoUsuario = Session["CORREO_ELECTRONICO"].ToString();

                    string cs = @"DATA SOURCE = JOSELEWIS; INITIAL CATALOG = TIENDA_VIERNES; USER = JoseLewis10; PASSWORD = joselewis10";
                    SqlConnection con = new SqlConnection(@"DATA SOURCE = JOSELEWIS; INITIAL CATALOG = TIENDA_VIERNES; USER = JoseLewis10; PASSWORD = joselewis10");

                    string Command = "SELECT ID_CARRITO FROM CARRITO WHERE CARRITO.CORREO_ELECTRONICO = '" + CorreoUsuario + "'";

                    SqlConnection SqlServer = new SqlConnection(cs);
                    con.Open();

                    SqlCommand cmd = new SqlCommand(Command, con);

                    SqlDataAdapter Adapter = new SqlDataAdapter(cmd);

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        int Id = Convert.ToInt32(dr["ID_CARRITO"]);
                        IdCarrito = Convert.ToInt32(Id.ToString());
                    }

                    con.Close();
                }
            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = ex.Message;
            }
        }

        void AnnadirAlCarrito()
        {
            try
            {
                using (TIENDA_VIERNESEntities1 ContextoDB = new TIENDA_VIERNESEntities1())
                {
                    DETALLE_CARRITO oDetalleCarrito = new DETALLE_CARRITO();

                    string CorreoUsuario = (string)Page.Session["CORREO_ELECTRONICO"];

                    id = Convert.ToInt32(Request.QueryString["id"].ToString());

                    oDetalleCarrito.CORREO_ELECTRONICO = CorreoUsuario;
                    oDetalleCarrito.CODIGO_PRODUCTO = id;
                    oDetalleCarrito.NUMERO_CANTIDAD = Convert.ToInt32(DropDownCantidadProducto.SelectedValue);
                    oDetalleCarrito.NUMERO_CANTIDAD_ANNADIDA = Convert.ToInt32(DropDownCantidadProducto.SelectedItem.Text);
                    oDetalleCarrito.ID_CARRITO = Convert.ToInt32(IdCarrito);
                    oDetalleCarrito.ESTADO_PRODUCTO = "EsperaDePago";

                    ContextoDB.DETALLE_CARRITO.Add(oDetalleCarrito);
                    ContextoDB.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = ex.Message;
            }
        }

        void MostrarBoton()
        {
            ADMINISTRADORE oAdministrador = new ADMINISTRADORE();
            String Rol = Session["TIPO_USUARIO"].ToString();

            if (Rol == "Administrador")
            {
                BotonAnnadirCarrito.Visible = false;
            }
            else
            {
                BotonAnnadirCarrito.Visible = true;
            }
        }

        void CrearCarrito()
        {
            try
            {
                using (TIENDA_VIERNESEntities1 ContextoDB = new TIENDA_VIERNESEntities1())
                {
                    CARRITO oCarrito = new CARRITO();

                    String CorreoUsuario = Session["CORREO_ELECTRONICO"].ToString();

                    oCarrito.CORREO_ELECTRONICO = CorreoUsuario;
                    oCarrito.CARRITO_ACTIVO = true;
                    oCarrito.ESTADO_CARRITO = "Iniciando";

                    ContextoDB.CARRITOes.Add(oCarrito);
                    ContextoDB.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = ex.Message;
            }
        }

        void ValidarCreacionCarrito()
        {
            String Rol = Session["TIPO_USUARIO"].ToString();
            id = Convert.ToInt32(Request.QueryString["id"].ToString());

            try
            {
                if (Rol == "Normal")
                {
                    String CorreoUsuario = Session["CORREO_ELECTRONICO"].ToString();

                    string cs = @"DATA SOURCE = JOSELEWIS; INITIAL CATALOG = TIENDA_VIERNES; USER = JoseLewis10; PASSWORD = joselewis10";
                    SqlConnection con = new SqlConnection(@"DATA SOURCE = JOSELEWIS; INITIAL CATALOG = TIENDA_VIERNES; USER = JoseLewis10; PASSWORD = joselewis10");

                    string Command = "SELECT CARRITO_ACTIVO FROM CARRITO WHERE CARRITO.CORREO_ELECTRONICO = '" + CorreoUsuario + "'";

                    SqlConnection SqlServer = new SqlConnection(cs);
                    con.Open();

                    SqlCommand cmd = new SqlCommand(Command, con);

                    SqlDataAdapter Adapter = new SqlDataAdapter(cmd);

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows == true)
                    {
                        dr.Read();
                        LblEstadoCarrito.Text = dr["CARRITO_ACTIVO"].ToString();

                        SacarIdCarrito();
                        AnnadirAlCarrito();
                        Response.Redirect("../Productos/ProductoEspecifico2.aspx?id=" + id);

                        dr.Close();
                    }
                    else
                    {
                        if (LblEstadoCarrito.Text != "True")
                        {
                            CrearCarrito();
                            SacarIdCarrito();
                            AnnadirAlCarrito();
                            Response.Redirect("../Productos/ProductoEspecifico2.aspx?id=" + id);
                        }
                        else
                        {
                            
                            lblError.Visible = true;
                            lblError.Text = "Ha ocurrido un error al agregar este producto";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = ex.Message;
            }
        }

        protected void BotonAnnadirCarrito_Click1(object sender, EventArgs e)
        {
            try
            {
                ValidarCreacionCarrito();
            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = ex.Message;
            }
        }
    }
}