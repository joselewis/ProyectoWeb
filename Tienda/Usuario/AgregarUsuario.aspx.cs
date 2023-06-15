using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;

namespace Tienda.Usuario
{
    public partial class AgregarUsuario : System.Web.UI.Page
    {
        int Creacion_Cuenta = 0;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        void Registrar_Usuario()
        {
            try
            {
                using (TIENDA_VIERNESEntities ContextoDB = new TIENDA_VIERNESEntities())
                {
                    USUARIO oUsuario = new USUARIO();

                    oUsuario.NOMBRE_USUARIO = ReCajaNomUsuario.Text;
                    oUsuario.NOMBRE = ReCajaNombre.Text;
                    oUsuario.APELLIDO_1_USUARIO = ReCajaApellido1.Text;
                    oUsuario.APELLIDO_2_USUARIO = ReCajaApellido2.Text;
                    oUsuario.CORREO_ELECTRONICO = ReCajaCorreo.Text;
                    oUsuario.CONTRASENNA = ReCajaContrasenna.Text;
                    oUsuario.TELEFONO_USUARIO = ReCajaTelefono.Text;
                    oUsuario.TIPO_USUARIO = "Normal";

                    ContextoDB.USUARIOS.Add(oUsuario);
                    ContextoDB.SaveChanges();
                    Creacion_Cuenta = 1;
                }
            }
            catch (Exception ex)
            {
                lblCamposPagoNulo.Visible = true;
                lblCamposPagoNulo.Text = ex.Message;
            }
        }

        void ValidarCreacionCuenta()
        {
            if (Creacion_Cuenta == 1)
            {
                Response.Redirect("../Login/Login.aspx");
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error al crear la cuenta')", true);
            }
        }

        protected void BotonRegistrarUsuario_Click(object sender, EventArgs e)
        {
            Registrar_Usuario();
            ValidarCreacionCuenta();
        }
    }
}