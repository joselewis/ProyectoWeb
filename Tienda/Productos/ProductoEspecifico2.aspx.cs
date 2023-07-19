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
        int AumentarCantidadProducto = 0;
        int Cantidad = 0;

        string cs = @"DATA SOURCE = JOSELEWIS; INITIAL CATALOG = TIENDA_VIERNES; USER = JoseLewis10; PASSWORD = joselewis10";

        //Arreglar toda la pantalla del producto
        SqlConnection con = new SqlConnection(@"DATA SOURCE = JOSELEWIS; INITIAL CATALOG = TIENDA_VIERNES; USER = JoseLewis10; PASSWORD = joselewis10");

        int id;

        int AnnadirAlCarrito = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            //VerProductoEspecifico();
            MostrarImagen();
            CargarInfoProducto();

            if (!Page.IsPostBack)
            {
                //AumentarCantidad();
            }
        }

        void MostrarImagen()
        {
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

        //void VerProductoEspecifico()
        //{
        //    try
        //    {
        //        if (Request.QueryString["id"] == null)
        //        {
        //            Response.Redirect("PaginaPrincipal/PaginaPrincipal.aspx");
        //        }
        //        else
        //        {
        //            id = Convert.ToInt32(Request.QueryString["id"].ToString());

        //            con.Open();
        //            SqlCommand cmd = con.CreateCommand();
        //            cmd.CommandType = CommandType.Text;
        //            cmd.CommandText = "SELECT * FROM PRODUCTO_ROPA WHERE CODIGO_PRODUCTO = " + id;
        //            cmd.ExecuteNonQuery();

        //            con.Open();

        //            DataTable dt = new DataTable();
        //            SqlDataAdapter da = new SqlDataAdapter(cmd);
        //            da.Fill(dt);
        //            d1.DataSource = dt;
        //            d1.DataBind();

        //            con.Close();
        //        }
        //    }
        //    catch(Exception ex) 
        //    {
        //        lblError.Visible = true;
        //        lblError.Text = ex.Message;
        //    }
        //}

        //void AnnadirProducto()
        //{
        //    try
        //    {
        //        using (TIENDA_VIERNESEntities ContextoBD = new TIENDA_VIERNESEntities())
        //        {
        //            CARRITO oCarrito = new CARRITO();

        //            string CorreoUsuario = (string)Page.Session["CORREO_ELECTRONICO"];

        //            oCarrito.CORREO_ELECTRONICO = CorreoUsuario;
        //            oCarrito.CODIGO_PRODUCTO = Convert.ToInt32(id);
        //            oCarrito.CANTIDAD = Convert.ToInt32(CajaCantidadProducto.Text);
        //            oCarrito.CARRITO_ACTIVO = true;

        //            ContextoBD.CARRITO.Add(oCarrito);
        //            ContextoBD.SaveChanges();
        //        }

        //        AnnadirAlCarrito = 1;
        //    }
        //    catch (Exception ex)
        //    {
        //        lblError.Visible = true;
        //        lblError.Text = ex.Message;
        //    }
        //}

        //void ValidacionIngresoMetodoPago()
        //{
        //    try
        //    {
        //        if (AnnadirAlCarrito == 1)
        //        {
        //            Response.Redirect("/PaginaPrincipal.aspx");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        lblError.Visible = true;
        //        lblError.Text = ex.Message;
        //    }
        //}

        void AumentarCantidad()
        {
            try
            {
                using (TIENDA_VIERNESEntities ContextoBD = new TIENDA_VIERNESEntities())
                {
                    PRODUCTO_ROPA Ropa = new PRODUCTO_ROPA();

                    for (int i = Ropa.CANTIDAD_PRODUCTO; i <= Ropa.CANTIDAD_PRODUCTO; i++)
                    {
                        AumentarCantidadProducto++;
                        
                    }
                }
            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = ex.Message;
            }
        }

        protected void BotonAnnadirCarrito_Click(object sender, EventArgs e)
        {
            //AnnadirProducto();
            //ValidacionIngresoMetodoPago();
        }

        protected void BotonAnnadirCarrito_Click1(object sender, EventArgs e)
        {

        }

        protected void BotonMenosCantidad_Click(object sender, ImageClickEventArgs e)
        {
            
        }

        protected void BotonMasCantidad_Click(object sender, ImageClickEventArgs e)
        {
            AumentarCantidad();
        }
    }
}