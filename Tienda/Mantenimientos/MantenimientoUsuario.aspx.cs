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
            try
            {
                using (TIENDA_VIERNESEntities1 ContextoDB = new TIENDA_VIERNESEntities1())
                {
                    var ListadoUsuarios = ContextoDB.USUARIOS.Where(s => s.TIPO_USUARIO == "Normal").ToList();

                    if (ListadoUsuarios.Count >= 0)
                    {
                        GridUsuarios.DataSource = ListadoUsuarios;
                        GridUsuarios.DataBind();
                    }
                    else
                    {
                        USUARIOS objUsuario = new USUARIOS();
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
            catch(Exception ex)
            {
                lblCamposNulos.Visible = true;
                lblCamposNulos.Text = ex.Message;
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
            try
            {
                //Permite cancelar la edición
                GridUsuarios.EditIndex = -1;
                CargarUsuarios();
            }
            catch(Exception ex)
            {
                lblCamposNulos.Visible = true;
                lblCamposNulos.Text = ex.Message;
            }
        }

        protected void GridUsuario_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                //Permite ingresar un nuevo registro mediante el footer del gridview
                int ValidarFooter = Validar();

                if (e.CommandName.Equals("AddNew") && ValidarFooter == 1)
                {
                    USUARIOS objUsuario = new USUARIOS();

                    objUsuario.NOMBRE_USUARIO = (GridUsuarios.FooterRow.FindControl("txt_footer_Usuario") as TextBox).Text.Trim();
                    objUsuario.NOMBRE = (GridUsuarios.FooterRow.FindControl("txt_footer_Nombre_Usuario") as TextBox).Text.Trim();
                    objUsuario.APELLIDO_1_USUARIO = (GridUsuarios.FooterRow.FindControl("txt_footer_Apellido_Usuario_1") as TextBox).Text.Trim();
                    objUsuario.APELLIDO_2_USUARIO = (GridUsuarios.FooterRow.FindControl("txt_footer_Apellido_Usuario_2") as TextBox).Text.Trim();
                    objUsuario.TELEFONO_USUARIO = (GridUsuarios.FooterRow.FindControl("txt_footer_Telefono_Usuario") as TextBox).Text.Trim();
                    objUsuario.CORREO_ELECTRONICO = (GridUsuarios.FooterRow.FindControl("txt_footer_Correo_Usuario") as TextBox).Text.Trim();

                    using (TIENDA_VIERNESEntities1 ContextoDB = new TIENDA_VIERNESEntities1())
                    {
                        ContextoDB.USUARIOS.Add(objUsuario);
                        ContextoDB.SaveChanges();
                        GridUsuarios.EditIndex = -1;
                        CargarUsuarios();
                    }
                }
                lblCamposNulos.Visible = false;
            }
            catch (Exception ex)
            {
                lblCamposNulos.Visible = true;
                lblCamposNulos.Text = ex.Message;
            }
        }

        protected void GridUsuario_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                String Usuario = Convert.ToString(GridUsuarios.DataKeys[e.RowIndex].Value);

                using (TIENDA_VIERNESEntities1 ContextoBD = new TIENDA_VIERNESEntities1())
                {
                    USUARIOS obj = ContextoBD.USUARIOS.First(X => X.CORREO_ELECTRONICO == Usuario);
                    ContextoBD.USUARIOS.Remove(obj);
                    ContextoBD.SaveChanges();
                    lblCamposNulos.Text = "Eliminado correctamente";
                    CargarUsuarios();
                }
            }
            catch(Exception ex)
            {
                lblCamposNulos.Visible = true;
                lblCamposNulos.Text = ex.Message;
            }
        }

        protected void GridUsuario_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                GridUsuarios.EditIndex = e.NewEditIndex;
                CargarUsuarios();
            }
            catch(Exception ex)
            {
                lblCamposNulos.Visible = true;
                lblCamposNulos.Text = ex.Message;
            }
        }

        protected void GridUsuario_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                GridViewRow row = GridUsuarios.Rows[e.RowIndex];

                TextBox txtIdUsuario = row.FindControl("Txt_IdUsuario") as TextBox;
                TextBox txtNombreUsuario = row.FindControl("Txt_Nombre_Usuario") as TextBox;
                TextBox txtTelefono = row.FindControl("Txt_Telefono_Usuario") as TextBox;
                TextBox txtNombreAdmin = row.FindControl("Txt_Nombre") as TextBox;
                TextBox txtApellido1 = row.FindControl("Txt_Apellido_Usuario_1") as TextBox;
                TextBox txtApellido2 = row.FindControl("Txt_Apellido_Usuario_2") as TextBox;
                TextBox txtCorreo = row.FindControl("Txt_Correo_Usuario") as TextBox;
                TextBox txtCuentaActiva = row.FindControl("Txt_Cuenta_Activa") as TextBox;

                if (txtIdUsuario != null &&
                    txtNombreUsuario != null &&
                    txtTelefono != null &&
                    txtNombreAdmin != null &&
                    txtApellido1 != null &&
                    txtApellido2 != null &&
                    txtCorreo != null &&
                    txtCuentaActiva != null)
                {
                    using (TIENDA_VIERNESEntities1 ContextoDB = new TIENDA_VIERNESEntities1())
                    {
                        String IdUsuario = Convert.ToString(GridUsuarios.DataKeys[e.RowIndex].Value);


                        USUARIOS obj = ContextoDB.USUARIOS.First(x => x.CORREO_ELECTRONICO == IdUsuario);

                        obj.NOMBRE_USUARIO = txtIdUsuario.Text;
                        obj.CORREO_ELECTRONICO = txtCorreo.Text;
                        obj.TELEFONO_USUARIO = txtTelefono.Text;
                        obj.NOMBRE_USUARIO = txtNombreUsuario.Text;
                        obj.APELLIDO_1_USUARIO = txtApellido1.Text;
                        obj.APELLIDO_2_USUARIO = txtApellido2.Text;
                        obj.CUENTA_ACTIVA = Convert.ToBoolean(txtCuentaActiva.Text);

                        ContextoDB.SaveChanges();
                        lblCamposNulos.Text = "Administrador actualizado";
                        GridUsuarios.EditIndex = -1;
                        Response.Redirect("../Mantenimientos/MantenimientoUsuario.aspx");
                    }
                }
            }
            catch(Exception ex)
            {
                lblCamposNulos.Visible = true;
                lblCamposNulos.Text = ex.Message;
            }
        }

        protected void GridUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ButtonExportarUsuarioExcel_Click(object sender, EventArgs e)
        { 
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

            }              
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