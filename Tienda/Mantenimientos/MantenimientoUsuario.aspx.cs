using CapaDatos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;

namespace Tienda.Mantenimientos
{
    public partial class MantenimientoUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarUsuarios();
            }
        }

        void CargarUsuarios()
        {
            using (TIENDA_VIERNESEntities ContextoDB = new TIENDA_VIERNESEntities())
            {
                var ListadoUsuarios = ContextoDB.USUARIOS.Where(s => s.TIPO_USUARIO == "Normal").ToList();

                if (ListadoUsuarios.Count >= 0)
                {
                    GridUsuarios.DataSource = ListadoUsuarios;
                    GridUsuarios.DataBind();
                }
                else
                {
                    USUARIO objUsuario = new USUARIO();
                    ListadoUsuarios.Add(objUsuario);
                    GridUsuarios.DataSource = ListadoUsuarios;
                    GridUsuarios.DataBind();
                    GridUsuarios.Rows[0].Cells.Clear();
                    GridUsuarios.Rows[0].Cells.Add(new TableCell());
                    GridUsuarios.Rows[0].Cells[0].ColumnSpan = 5;
                    GridUsuarios.Rows[0].Cells[0].Text = "No hay usuarios registrados";
                    GridUsuarios.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                }
            }
        }

        int Validar()
        {
            int respuesta = 0;

            if (String.IsNullOrEmpty((GridUsuarios.FooterRow.FindControl("txt_footer_Usuario") as TextBox).Text))
            {
                lblCamposNulos.Visible = true;
            }
            else
            {
                respuesta = 1;
            }
            return (respuesta);
        }
  
        protected void GridUsuario_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            //Permite cancelar la edición
            GridUsuarios.EditIndex = -1;
            CargarUsuarios();
        }

        protected void GridUsuario_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //Permite ingresar un nuevo registro mediante el footer del gridview
            int ValidarFooter = Validar();

            if (e.CommandName.Equals("AddNew") && ValidarFooter == 1)
            {
                USUARIO objUsuario = new USUARIO();

                objUsuario.NOMBRE_USUARIO = (GridUsuarios.FooterRow.FindControl("txt_footer_Usuario") as TextBox).Text.Trim();
                objUsuario.NOMBRE = (GridUsuarios.FooterRow.FindControl("txt_footer_Nombre_Usuario") as TextBox).Text.Trim();
                objUsuario.APELLIDO_1_USUARIO = (GridUsuarios.FooterRow.FindControl("txt_footer_Apellido_Usuario_1") as TextBox).Text.Trim();
                objUsuario.APELLIDO_2_USUARIO = (GridUsuarios.FooterRow.FindControl("txt_footer_Apellido_Usuario_2") as TextBox).Text.Trim();
                objUsuario.TELEFONO_USUARIO = (GridUsuarios.FooterRow.FindControl("txt_footer_Telefono_Usuario") as TextBox).Text.Trim();
                objUsuario.CONTRASENNA = (GridUsuarios.FooterRow.FindControl("txt_footer_Contrasenna_Usuario") as TextBox).Text.Trim();
                objUsuario.TIPO_USUARIO = (GridUsuarios.FooterRow.FindControl("txt_footer_Tipo_Usuario") as TextBox).Text.Trim();
                objUsuario.CORREO_ELECTRONICO = (GridUsuarios.FooterRow.FindControl("txt_footer_Correo_Usuario") as TextBox).Text.Trim();

                using (TIENDA_VIERNESEntities ContextoDB = new TIENDA_VIERNESEntities())
                {
                    ContextoDB.USUARIOS.Add(objUsuario);
                    ContextoDB.SaveChanges();
                    GridUsuarios.EditIndex = -1;
                    CargarUsuarios();
                }
            }
            lblCamposNulos.Visible = false;
        }

        protected void GridUsuario_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //Permite eliminar un usuario
            String Usuario = Convert.ToString(GridUsuarios.DataKeys[e.RowIndex].Value);

            using (TIENDA_VIERNESEntities ContextoBD = new TIENDA_VIERNESEntities())
            {
                USUARIO obj = ContextoBD.USUARIOS.First(X => X.CORREO_ELECTRONICO == Usuario);
                ContextoBD.USUARIOS.Remove(obj);
                ContextoBD.SaveChanges();
                lblCamposNulos.Text = "Eliminado correctamente";
                CargarUsuarios();
            }
        }

        protected void GridUsuario_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //Permite eliminar un producto
            GridUsuarios.EditIndex = e.NewEditIndex;
            CargarUsuarios();
        }

        protected void GridUsuario_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //Permite actualizar los datos de un usuario
            GridViewRow row = GridUsuarios.Rows[e.RowIndex];

            TextBox txtIdUsuario = row.FindControl("Txt_IdUsuario") as TextBox;
            TextBox txtNombreUsuario = row.FindControl("Txt_Nombre_Usuario") as TextBox;
            TextBox txtContrasenna = row.FindControl("Txt_Contrasenna_Usuario") as TextBox;
            TextBox txtTelefono = row.FindControl("Txt_Telefono_Usuario") as TextBox;
            TextBox txtNombreAdmin = row.FindControl("Txt_Nombre") as TextBox;
            TextBox txtApellido1 = row.FindControl("Txt_Apellido_Usuario_1") as TextBox;
            TextBox txtApellido2 = row.FindControl("Txt_Apellido_Usuario_2") as TextBox;
            TextBox txtCorreo = row.FindControl("Txt_Correo_Usuario") as TextBox;
            TextBox txtTipoUsuario = row.FindControl("Txt_Tipo_Usuario") as TextBox;

            if (txtIdUsuario != null &&
                txtNombreUsuario != null &&
                txtContrasenna != null &&
                txtTelefono != null &&
                txtNombreAdmin != null &&
                txtApellido1 != null &&
                txtApellido2 != null &&
                txtCorreo != null &&
                txtTipoUsuario != null)
            {
                using (TIENDA_VIERNESEntities ContextoDB = new TIENDA_VIERNESEntities())
                {
                    String IdUsuario = Convert.ToString(GridUsuarios.DataKeys[e.RowIndex].Value);


                    USUARIO obj = ContextoDB.USUARIOS.First(x => x.CORREO_ELECTRONICO == IdUsuario);

                    obj.NOMBRE_USUARIO = txtIdUsuario.Text;
                    obj.CORREO_ELECTRONICO = txtCorreo.Text;
                    obj.TELEFONO_USUARIO = txtTelefono.Text;
                    obj.NOMBRE_USUARIO = txtNombreUsuario.Text;
                    obj.APELLIDO_1_USUARIO = txtApellido1.Text;
                    obj.APELLIDO_2_USUARIO = txtApellido2.Text;
                    obj.CONTRASENNA = txtContrasenna.Text;
                    obj.TIPO_USUARIO = txtTipoUsuario.Text;

                    ContextoDB.SaveChanges();
                    lblCamposNulos.Text = "Administrador actualizado";
                    GridUsuarios.EditIndex = -1;
                    CargarUsuarios();
                }
            }
        }

        protected void GridUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ButtonExportarUsuarioExcel_Click(object sender, EventArgs e)
        {
            //Permite exportar los datos del gridview usuarios a formato excel
            try
            {
                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = "application/ms-excel";
                Response.AddHeader("content-disposition", "attachment; filename = Usuarios.xls");
                Response.Charset = "";
                StringWriter sw = new StringWriter();
                HtmlTextWriter htw = new HtmlTextWriter(sw);
                GridUsuarios.RenderControl(htw);
                Response.Output.Write(sw.ToString());
                Response.End();

            }    //interop            
            catch (Exception ex)
            {
                lblCamposNulos.Text = ex.Message;
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {

        }
    }
}