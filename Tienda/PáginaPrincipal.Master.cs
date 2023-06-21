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
        protected void Page_Load(object sender, EventArgs e)
        {
            MenuPrincipal();

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
                    PaginaInicio = "../Usuario/PaginaPrincipalUsuario.aspx";
                    LinksMenuPrincipal +=
                                          "<a class='nav-link' href='PerfilUsuario.aspx'>" +
                                          "<div class='sb-nav-link-icon'>" +
                                          "<i class='fas fa-chart-area'>" +
                                          "</i>" +
                                          "</div>" +
                                          "Perfil" +
                                          "</a>" +

                                          "<a class='nav-link' href='CarritoCompras.aspx'>" +
                                          "<div class='sb-nav-link-icon'>" +
                                          "<i class='fas fa-chart-area'>" +
                                          "</i>" +
                                          "</div>" +
                                          "Carrito" +
                                          "</a>"
                                          ;

                    /*<li class="nav-item"><a class="nav-link active" aria-current="page" href="#!">Home</a></li>
                        <li class="nav-item"><a class="nav-link" href="#!">About</a></li>
                        <li class="nav-item dropdown">
                            <a class="nav-link dropdown-toggle" id="navbarDropdown" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false">Shop</a>
                            <ul class="dropdown-menu" aria-labelledby="navbarDropdown">
                                <li><a class="dropdown-item" href="#!">All Products</a></li>
                                <li><hr class="dropdown-divider" /></li>
                                <li><a class="dropdown-item" href="#!">Popular Items</a></li>
                                <li><a class="dropdown-item" href="#!">New Arrivals</a></li>
                            </ul>
                        </li>*/
                    break;

                case "Administrador":
                    LinksMenuPrincipal += "<a class='nav-link' href='PerfilAdministrador.aspx'>" +
                                          "<div class='sb-nav-link-icon'>" +
                                          "<i class='fas fa-chart-area'>" +
                                          "</i>" +
                                          "</div>" +
                                          "Perfil admin" +
                                          "</a>" +

                                          "<a class='nav-link' href='RegistrarAdministrador.aspx'>" +
                                          "<div class='sb-nav-link-icon'>" +
                                          "<i class='fas fa-chart-area'>" +
                                          "</i>" +
                                          "</div>" +
                                          "Registro admin" +
                                          "</a>" +

                                          "<a class='nav-link' href='../Productos/RegistroProducto/RegistroProducto.aspx'>" +
                                          "<div class='sb-nav-link-icon'>" +
                                          "<i class='fas fa-chart-area'>" +
                                          "</i>" +
                                          "</div>" +
                                          "Registro productos" +
                                          "</a>" +

                                          "<a class='nav-link' href='MantenimientoAdmin.aspx'>" +
                                          "<div class='sb-nav-link-icon'>" +
                                          "<i class='fas fa-chart-area'>" +
                                          "</i>" +
                                          "</div>" +
                                          "Admin" +
                                          "</a>" +

                                          "<a class='nav-link' href='MantenimientoProductos.aspx'>" +
                                          "<div class='sb-nav-link-icon'>" +
                                          "<i class='fas fa-chart-area'>" +
                                          "</i>" +
                                          "</div>" +
                                          "Productos" +
                                          "</a>" +

                                          "<a class='nav-link' href='MantenimientoUsuarios.aspx'>" +
                                          "<div class='sb-nav-link-icon'>" +
                                          "<i class='fas fa-chart-area'>" +
                                          "</i>" +
                                          "</div>" +
                                          "Usuarios" +
                                          "</a>";

                    break;
            }

            Titulo_Admin.InnerHtml += LinksMenuPrincipal;
        }

        protected void btnBusqueda_Click(object sender, EventArgs e)
        {

        }
    }
}