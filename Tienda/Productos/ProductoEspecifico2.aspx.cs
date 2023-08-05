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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                MostrarImagen();
                CargarInfoProducto();
                //CargarCantidaProducto();
                DesplegarCuentaDDL();
                MostrarBoton();
            }
        }

        void MostrarImagen()
        {
            string cs = @"DATA SOURCE = LAPTOP-VEC1I0DC; INITIAL CATALOG = TIENDA_VIERNES; USER = JoseLewis10; PASSWORD = joselewis10";
            SqlConnection con = new SqlConnection(@"DATA SOURCE = LAPTOP-VEC1I0DC; INITIAL CATALOG = TIENDA_VIERNES; USER = JoseLewis10; PASSWORD = joselewis10");

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
                string cs = @"DATA SOURCE = LAPTOP-VEC1I0DC; INITIAL CATALOG = TIENDA_VIERNES; USER = JoseLewis10; PASSWORD = joselewis10";
                SqlConnection con = new SqlConnection(@"DATA SOURCE = LAPTOP-VEC1I0DC; INITIAL CATALOG = TIENDA_VIERNES; USER = JoseLewis10; PASSWORD = joselewis10");

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

        //void CargarCantidaProducto()
        //{
        //    SqlConnection con = new SqlConnection(@"DATA SOURCE = LAPTOP-VEC1I0DC; INITIAL CATALOG = TIENDA_VIERNES; USER = JoseLewis10; PASSWORD = joselewis10");
        //    id = Convert.ToInt32(Request.QueryString["id"].ToString());

        //    try
        //    {
        //        using (con)
        //        {
        //            using (SqlCommand cmd = new SqlCommand("SP_SACAR_CANTIDAD", con))
        //            {
        //                cmd.CommandType = CommandType.StoredProcedure;

        //                SqlParameter paramId = new SqlParameter()
        //                {
        //                    ParameterName = "@ID",
        //                    Value = Request.QueryString["ID"],
        //                };

        //                cmd.Parameters.Add(paramId);

        //                con.Open();

        //                using (SqlDataReader dr = cmd.ExecuteReader())
        //                {
        //                    PRODUCTO_ROPA oProducto = new PRODUCTO_ROPA();

        //                    if (dr.HasRows)
        //                    {
        //                        DropDownCantidadProducto.DataSource = dr;
        //                        DropDownCantidadProducto.DataValueField = "NUMERO_CANTIDAD_PRODUCTO";
        //                        DropDownCantidadProducto.DataTextField = "CANTIDAD_PRODUCTO";

        //                        DropDownCantidadProducto.DataBind();
        //                        DropDownCantidadProducto.Items.Insert(0, new ListItem("-Select-", "0"));
        //                    }
        //                }
        //                con.Close();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        lblError.Visible = true;
        //        lblError.Text = ex.Message;
        //    }
        //}

        void DesplegarCuentaDDL()
        {
            id = Convert.ToInt32(Request.QueryString["id"].ToString());

            try
            {
                string cs = @"DATA SOURCE = LAPTOP-VEC1I0DC; INITIAL CATALOG = TIENDA_VIERNES; USER = JoseLewis10; PASSWORD = joselewis10";
                SqlConnection con = new SqlConnection(@"DATA SOURCE = LAPTOP-VEC1I0DC; INITIAL CATALOG = TIENDA_VIERNES; USER = JoseLewis10; PASSWORD = joselewis10");
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

        void AnnadirAlCarrito()
        {
            try
            {
                using (TIENDA_VIERNESEntities ContextoDB = new TIENDA_VIERNESEntities())
                {
                    CARRITO oCarrito = new CARRITO();

                    string CorreoUsuario = (string)Page.Session["CORREO_ELECTRONICO"];

                    id = Convert.ToInt32(Request.QueryString["id"].ToString());

                    oCarrito.CORREO_ELECTRONICO = CorreoUsuario;
                    oCarrito.CODIGO_PRODUCTO = id;
                    oCarrito.CARRITO_ACTIVO = true;
                    oCarrito.NUMERO_CANTIDAD = Convert.ToInt32(DropDownCantidadProducto.SelectedValue);
                    oCarrito.NUMERO_CANTIDAD_ANNADIDA = Convert.ToInt32(DropDownCantidadProducto.SelectedItem.Text);

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

        protected void BotonAnnadirCarrito_Click1(object sender, EventArgs e)
        {
            try
            {
                AnnadirAlCarrito();

                id = Convert.ToInt32(Request.QueryString["id"].ToString());

                Response.Redirect("../Productos/ProductoEspecifico2.aspx?id=" + id);
            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = ex.Message;
            }
        }
    }
}