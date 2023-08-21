using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
                using (TIENDA_VIERNESEntities1 ContextoDB = new TIENDA_VIERNESEntities1())
                {
                    USUARIOS oUsuario = new USUARIOS();

                    oUsuario.NOMBRE_USUARIO = ReCajaNomUsuario.Text;
                    oUsuario.NOMBRE = ReCajaNombre.Text;
                    oUsuario.APELLIDO_1_USUARIO = ReCajaApellido1.Text;
                    oUsuario.APELLIDO_2_USUARIO = ReCajaApellido2.Text;
                    oUsuario.CORREO_ELECTRONICO = ReCajaCorreo.Text;
                    oUsuario.CONTRASENNA = ReCajaContrasenna.Text;
                    oUsuario.TELEFONO_USUARIO = ReCajaTelefono.Text;
                    oUsuario.TIPO_USUARIO = "Normal";
                    oUsuario.IMAGEN_USUARIO = ReCajaImagenPerfilUsuario.FileBytes;
                    oUsuario.CUENTA_ACTIVA = true;

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
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Cuenta creada, por favor inicie sesión')", true);
                Response.Redirect("../Login/Login.aspx");
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Tiene que ingresar todos los campos solicitados')", true);
            }
        }

        protected void BotonRegistrarUsuario_Click(object sender, EventArgs e)
         {
            try
            {
                if (
                    ReCajaNombre.Text != null &&
                    ReCajaApellido1.Text != null &&
                    ReCajaApellido2.Text != null &&
                    ReCajaContrasenna.Text != null &&
                    ReCajaCorreo.Text != null && 
                    ReCajaNomUsuario != null &&
                    ReCajaTelefono.Text != null
                    )
                {
                    Registrar_Usuario();
                    ValidarCreacionCuenta();
                }
                else
                {
                    lblCamposPagoNulo.Visible = true;
                    lblCamposPagoNulo.Text = "Tiene que ingresar todos los campos solicitados";
                }
            }
            catch (Exception ex)
            {
                lblCamposPagoNulo.Visible = true;
                lblCamposPagoNulo.Text = ex.Message;
            }   
        }
    }
}