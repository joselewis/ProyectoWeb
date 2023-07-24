using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;
using static System.Data.Entity.Infrastructure.Design.Executor;

namespace Tienda.Perfil
{
    public partial class PerfilUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarPerfilUsuario();
            CargarFotoPerfil();
        }

        void CargarPerfilUsuario()
        {
            Nombre.InnerHtml = "<h6>" + Session["NOMBRE"].ToString() + "</h6>";
            NombreUsuario.InnerHtml = "<h6>" + Session["NOMBRE_USUARIO"].ToString() + "</h6>";
            Correo.InnerHtml = "<h6>" + Session["CORREO_ELECTRONICO"].ToString() + "</h6>";
            Telefono.InnerHtml = "<h6>" + Session["TELEFONO_USUARIO"].ToString() + "</h6>";
        }

        void CargarFotoPerfil()
        {
            //String Usuario = Session["CORREO_ELECTRONICO"].ToString();
            //String SessionFoto = Session["IMAGEN_USUARIO"].ToString();

            try
            {
                String CorreoUsuario = Session["CORREO_ELECTRONICO"].ToString();

                SqlConnection con = new SqlConnection(@"DATA SOURCE = LAPTOP-VEC1I0DC; INITIAL CATALOG = TIENDA_VIERNES; USER = JoseLewis10; PASSWORD = joselewis10");
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "SELECT IMAGEN_USUARIO FROM USUARIOS WHERE CORREO_ELECTRONICO = '" + CorreoUsuario + "'";
                cmd.ExecuteNonQuery();

                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                DataListFotoPerfil.DataSource = dt;
                DataListFotoPerfil.DataBind();
                con.Close();
            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = ex.Message;
            }
        }

        protected void AnnadirTarjeta_Click(object sender, EventArgs e)
        {
            Response.Redirect("../MetodoPago/MetodoPago2.aspx");
        }

        protected void CambiarFoto_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Perfil/PerfilCambioFoto.aspx");
        }
    }
}