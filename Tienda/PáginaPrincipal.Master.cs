using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;
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
            
            if (!Page.IsPostBack)
            {
                ContadorProductosCarrito();

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
            try
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
                                              "</li>" +

                                              "<a class='nav-link' href='../Programador/Programador.aspx'>" +
                                              "Información" +
                                              "</a>" +
                                              "</li>"
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
                                              "</ul></li></ul></div>" +

                                              "<a class='nav-link' href='../Deposito/DepositoTarjeta.aspx'>" +
                                              "Depositar" +
                                              "</a>" +
                                              "</li>";
                                              break;
                }

                Titulo_Admin.InnerHtml += LinksMenuPrincipal;

            }
            catch(Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "sr1", "Swal.fire('Su sesión ha expirado, por favor vuelva a iniciar sesión')" + ex, true);
                Response.Redirect("../../Login/Login.aspx");
            }
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
                String Rol = Session["TIPO_USUARIO"].ToString();

                if (Rol == "Normal")
                {
                    String CorreoUsuario = Session["CORREO_ELECTRONICO"].ToString();

                    string cs = @"DATA SOURCE = JOSELEWIS; INITIAL CATALOG = TIENDA_VIERNES; USER = JoseLewis10; PASSWORD = joselewis10";
                    SqlConnection con = new SqlConnection(@"DATA SOURCE = JOSELEWIS; INITIAL CATALOG = TIENDA_VIERNES; USER = JoseLewis10; PASSWORD = joselewis10");
                    string Command = "SELECT SUM(NUMERO_CANTIDAD_ANNADIDA) FROM PRODUCTO_ROPA " +
                                        " INNER JOIN DETALLE_CARRITO ON DETALLE_CARRITO.CODIGO_PRODUCTO = PRODUCTO_ROPA.CODIGO_PRODUCTO " +
                                        " INNER JOIN USUARIOS ON USUARIOS.CORREO_ELECTRONICO = DETALLE_CARRITO.CORREO_ELECTRONICO WHERE USUARIOS.CORREO_ELECTRONICO ='" + CorreoUsuario + "'";

                    SqlConnection SqlServer = new SqlConnection(cs);
                    con.Open();
                    SqlCommand cmd = new SqlCommand(Command, con);

                    ContadorCarrito.Text = Convert.ToString(cmd.ExecuteScalar());

                    con.Close();
                }
                else
                {
                    lblError.Visible = false;
                    //lblError.Text = "Ha ocurrido un error";
                }
                
            }
            catch(Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = ex.Message;
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