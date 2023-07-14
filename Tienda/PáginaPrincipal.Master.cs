using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;

namespace Tienda
{
    public partial class PáginaPrincipal : System.Web.UI.MasterPage
    {
        int Contador = 12;

        protected void Page_Load(object sender, EventArgs e)
        {
            MenuPrincipal();
            ContadorProductosCarrito();

            //Filtra el tipo de usuario para redirigirlo según su tipo
            if (!Page.IsPostBack)
            {
                String Rol = Session["TIPO_USUARIO"].ToString();

                switch (Rol)
                {
                    case "Normal":
                        txtNombreUsuarioSesion.Text = Session["NOMBRE_USUARIO"].ToString();
                        break;
                    case "Administrador":
                        txtNombreAdminSesion.Text = Session["NOMBRE_USUARIO_ADMIN"].ToString();
                        break;
                }
            }
        }

        protected void MenuPrincipal()
        {
            String Rol = Session["TIPO_USUARIO"].ToString();
            String PaginaInicio = "";
            String LinksMenuPrincipal = "";

            switch (Rol)
            {
                case "Normal":
                    PaginaInicio = "Usuario/PaginaPrincipalUsuario.aspx";
                    LinksMenuPrincipal +=
                                         "<a class='nav-link' href='../Perfil/PerfilUsuario.aspx'>" +
                                          "Perfil" +
                                          "</a>" +
                                          "</li>"

                                          //"<a class='nav-link' href='ProductosPrueba.aspx'>" +
                                          //"<div class='sb-nav-link-icon'>" +
                                          //"<i class='fas fa-chart-area'>" +
                                          //"</i>" +
                                          //"</div>" +
                                          //"Carrito" +
                                          //"</a>"
                                          ;
                    break;

                case "Administrador":
                    LinksMenuPrincipal +=
                                          "<div class='collapse navbar-collapse' id='navbarSupportedContent' >" +
                                          "<ul class='navbar-nav me-auto mb-2 mb-lg-0 ms-lg-4' runat='server' id='Titulo_Admin'>" +
                                          "<li class='nav-item dropdown'>" +
                                          "<a class='nav-link dropdown-toggle' id='navbarDropdown' href='#' role='button' data-bs-toggle='dropdown' aria-expanded='false'>Mantenimientos</a>" +
                                          "<ul class='dropdown-menu' aria-labelledby='navbarDropdown'>" +
                                          //"<li><a class='dropdown-item' href='../Productos/Productos.aspx'>Ver productos</a></ li >" +
                                          "<li><a class='dropdown-item' href='../Mantenimientos/MantenimientoAdmin.aspx''>Administrador</a></li>" +
                                          "<li><a class='dropdown-item' href='../Mantenimientos/MantenimientoProducto.aspx''>Producto</a></li>" +
                                          "<li><a class='dropdown-item' href='../Mantenimientos/MantenimientoUsuario.aspx'>Usuario</a></li>" +
                                          "</ul></li></ul></div>" +

                                          "<div class='collapse navbar-collapse' id='navbarSupportedContent' >" +
                                          "<ul class='navbar-nav me-auto mb-2 mb-lg-0 ms-lg-4' runat='server' id='Titulo_Admin'>" +
                                          "<li class='nav-item dropdown'>" +
                                          "<a class='nav-link dropdown-toggle' id='navbarDropdown' href='#' role='button' data-bs-toggle='dropdown' aria-expanded='false'>Registrar</a>" +
                                          "<ul class='dropdown-menu' aria-labelledby='navbarDropdown'>" +
                                          "<li><a class='dropdown-item' href='../Productos/RegistroProducto.aspx'>Registrar Producto</a></ li >" +
                                          "</ul></li></ul></div>";

                    break;
            }

            Titulo_Admin.InnerHtml += LinksMenuPrincipal;

        }

        protected void btnBusqueda_Click(object sender, EventArgs e)
        {

        }

        protected void ButtonVerCarrito_Click(object sender, EventArgs e)
        {
            Response.Redirect("../CarritoCompras/CarritoCompras.aspx");
        }

        void ContadorProductosCarrito()
        {
            try
            {
                if (Contador != 0)
                {
                    ContadorCarrito.Visible = true;
                    ContadorCarrito.Text = Contador.ToString();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "sr1", "Swal.fire('Algo salió mal')", true);
            }
        }

        protected void BtnCerrarSesion_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Session.Clear();
                Response.Redirect("../Login/Login.aspx");
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "sr1", "Swal.fire('No se ha podido cerrar sesión')" + ex, true);
            }
        }
    }
}