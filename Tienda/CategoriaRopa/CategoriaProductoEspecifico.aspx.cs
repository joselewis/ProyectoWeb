using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;

namespace Tienda.CategoriaRopa
{
    public partial class CategoriaProductoEspecifico : System.Web.UI.Page
    {

        int AumentarCantidadProducto = 0;
        int Cantidad = 0;

        SqlConnection con = new SqlConnection(@"DATA SOURCE = LAPTOP-VEC1I0DC; INITIAL CATALOG = TIENDA_VIERNES; USER = JoseLewis10; PASSWORD = joselewis10");

        int id;

        int ValidarAnnadirAlCarrito = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            VerProductoEspecifico();

            if (!Page.IsPostBack)
            {
                
            }
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
                d2.DataSource = dt;
                d2.DataBind();

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

        

        protected void BotonAnnadirCarrito_Click1(object sender, EventArgs e)
        {
            
        }

        protected void BotonMenosCantidad_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void BotonMasCantidad_Click(object sender, ImageClickEventArgs e)
        {
            
        }
    }
}