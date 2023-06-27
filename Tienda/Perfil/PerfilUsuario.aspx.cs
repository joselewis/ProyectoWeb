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
    public partial class PerfilUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarPerfilUsuario();
        }

        void CargarPerfilUsuario()
        {
            Nombre.InnerHtml = "<h6>" + Session["NOMBRE"].ToString() + "</h6>";
            NombreUsuario.InnerHtml = "<h6>" + Session["NOMBRE_USUARIO"].ToString() + "</h6>";
            Correo.InnerHtml = "<h6>" + Session["CORREO_ELECTRONICO"].ToString() + "</h6>";
            Telefono.InnerHtml = "<h6>" + Session["TELEFONO_USUARIO"].ToString() + "</h6>";
        }

        #region "Método para ir a los métodos de pago"
        protected void IrMetodoPago_Click(object sender, EventArgs e)
        {
            Response.Redirect("/MetodoPago.aspx");
        }
        #endregion
    }
    
}