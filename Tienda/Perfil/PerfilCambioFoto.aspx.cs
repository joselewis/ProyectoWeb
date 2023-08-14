using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;

namespace Tienda.Perfil
{
    public partial class PerfilCambioFoto : System.Web.UI.Page
    {
        int EliminaFoto = 0;
        int ValidarCambioFoto = 0;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        void EliminarFotoAntigua()
        {
            try
            {
                String SessionUsuario = Session["CORREO_ELECTRONICO"].ToString();

                SqlConnection con = new SqlConnection(@"DATA SOURCE = JOSELEWIS; INITIAL CATALOG = TIENDA_VIERNES; USER = JoseLewis10; PASSWORD = joselewis10");
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "UPDATE USUARIOS SET IMAGEN_USUARIO = NULL WHERE CORREO_ELECTRONICO = '" + SessionUsuario + "'";
                cmd.ExecuteNonQuery();

                EliminaFoto = 1;
            }
            catch (Exception ex)
            {
                lblCamposNulo.Visible = true;
                lblCamposNulo.Text = ex.Message;
            }
        }

        void ActualizarFotoPerfil()
        {
            try
            {
                using (TIENDA_VIERNESEntities1 ContextoDB = new TIENDA_VIERNESEntities1())
                {
                    String Usuario = Session["CORREO_ELECTRONICO"].ToString();

                    USUARIO oUsuario = ContextoDB.USUARIOS.First(x => x.CORREO_ELECTRONICO == Usuario);

                    oUsuario.IMAGEN_USUARIO = CajaNuevaFoto.FileBytes;

                    ContextoDB.SaveChanges();

                    ValidarCambioFoto = 1;
                }
            }
            catch (Exception ex)
            {
                lblCamposNulo.Visible = true;
                lblCamposNulo.Text = ex.Message;
            }

            //"UPDATE USUARIOS SET IMAGEN_USUARIO = NULL WHERE CORREO_ELECTRONICO = '
            //"UPDATE USUARIOS SET IMAGEN_USUARIO ='" + NuevaImagenUsuario + "'" + "WHERE CORREO_ELECTRONICO ='" + SessionUsuario + "'";
        }

        void ValidarCambio()
        {
            try
            {
                if (ValidarCambioFoto == 1 && EliminaFoto == 1)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "sr1", "Swal.fire('Foto actualizada correctamente')", true);
                    Response.Redirect("../Perfil/PerfilUsuario.aspx");
                }
                else
                {
                    lblCamposNulo.Visible = true;
                    lblCamposNulo.Text = "Ha ocurrido un error";
                }
            }
            catch (Exception ex)
            {
                lblCamposNulo.Visible = true;
                lblCamposNulo.Text += ex.Message;
            }
        }

        protected void NuevaFotoPerfil_Click(object sender, EventArgs e)
        {
            EliminarFotoAntigua();
            ActualizarFotoPerfil();
            ValidarCambio();
        }
    }
}