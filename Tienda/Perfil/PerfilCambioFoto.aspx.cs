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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        void ActualizarFotoPerfil()
        {
            //try
            //{
            //    using (TIENDA_VIERNESEntities ContextoDB = new TIENDA_VIERNESEntities())
            //    {
            //        String IdAdmin = Session["CORREO_ELECTRONICO"].ToString();

            //        USUARIO oUsuario = ContextoDB.USUARIOS.First(x => x.CORREO_ELECTRONICO == IdAdmin);

            //        oUsuario.IMAGEN_USUARIO = CajaNuevaFoto.FileBytes;

            //        ContextoDB.SaveChanges();
            //        .EditIndex = -1;
            //        CargarAdministradores();
            //    }
            //}
            //catch(Exception ex)
            //{
            //    lblCamposNulo.Visible = true;
            //    lblCamposNulo.Text = ex.Message;
            //}

            //"UPDATE USUARIOS SET IMAGEN_USUARIO = NULL WHERE CORREO_ELECTRONICO = '
            //"UPDATE USUARIOS SET IMAGEN_USUARIO ='" + NuevaImagenUsuario + "'" + "WHERE CORREO_ELECTRONICO ='" + SessionUsuario + "'";
        }

        protected void NuevaFotoPerfil_Click(object sender, EventArgs e)
        {

        }
    }
}