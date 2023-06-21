using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;

namespace Tienda.Productos.ProductoEspecifico
{
    public partial class ProductoEspecifico : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"DATA SOURCE = JOSELEWIS; INITIAL CATALOG = TIENDA_VIERNES; USER = JoseLewis10; PASSWORD = joselewis10");

        int id;

        int AnnadirAlCarrito = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            VerProductoEspecifico();
        }

        void VerProductoEspecifico()
        {
            if (Request.QueryString["id"] == null)
            {
                Response.Redirect("PaginaPrincipal/PaginaPrincipal.aspx");
            }
            else
            {
                id = Convert.ToInt32(Request.QueryString["id"].ToString());

                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM PRODUCTO_ROPA WHERE CODIGO_PRODUCTO = " + id;
                cmd.ExecuteNonQuery();

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                d1.DataSource = dt;
                d1.DataBind();

                con.Close();
            }
        }

        protected void ImagenEspecifica_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView dr = (DataRowView)e.Row.DataItem;
                string imageUrl = "data:image/jpg;base64," + Convert.ToBase64String((byte[])dr["IMAGEN"]);
                (e.Row.FindControl("Image1") as Image).ImageUrl = imageUrl;
            }
        }

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

        protected void BotonAnnadirCarrito_Click(object sender, EventArgs e)
        {
            //AnnadirProducto();
            //ValidacionIngresoMetodoPago();
        }
    }
}