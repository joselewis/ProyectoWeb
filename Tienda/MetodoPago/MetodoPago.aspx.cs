using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;

namespace Tienda.MetodoPago
{
    public partial class MetodoPago : System.Web.UI.Page
    {
        int Creacion_Metodo_Pago = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            CargarMetodoPago();
        }

        //void CrearMetodoPago()
        //{
        //    try
        //    {   
        //        using (TIENDA_VIERNESEntities ContextoDB = new TIENDA_VIERNESEntities())
        //        {
        //            METODO_PAGO oMetodoPago = new METODO_PAGO();

        //            string CorreoUsuario = Session["CORREO_ELECTRONICO"].ToString();

        //            oMetodoPago.NUMERO_TARJETA = Convert.ToInt64(CajaNumeroTarjeta.Text);
        //            oMetodoPago.NUMERO_EXPIRA_1 = Convert.ToInt32(CajaMesTarjeta.Text);
        //            oMetodoPago.NUMERO_EXPIRA_2 = Convert.ToInt32(CajaAnnoTarjeta.Text);
        //            oMetodoPago.TARJETA_ACTICA = CheckBoxActiva.Checked;
        //            oMetodoPago.CORREO_ELECTRONICO = CorreoUsuario;

        //            ContextoDB.METODO_PAGO.Add(oMetodoPago);
        //            ContextoDB.SaveChanges();

        //            Creacion_Metodo_Pago = 1;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        lblCamposPagoNulo.Visible = true;
        //        lblCamposPagoNulo.Text = ex.Message;
        //    }
        //}

        void ValidacionIngresoMetodoPago()
        {
            try
            {   
                if (Creacion_Metodo_Pago == 1)
                {
                    Response.Redirect("/CarritoCompras.aspx");
                }
            }
            catch (Exception ex)
            {
                lblCamposPagoNulo.Visible = true;
                lblCamposPagoNulo.Text = "Complete los campos solocitados " + ex.Message;
            }
        }

        void CargarMetodoPago()
        {
            try
            {
                using (TIENDA_VIERNESEntities1 ContextoDB = new TIENDA_VIERNESEntities1())
                {
                    string CorreoUsuario = (string)Page.Session["CORREO_ELECTRONICO"];

                    var ListadoMetodoPago = ContextoDB.METODO_PAGO.Where(s => s.TARJETA_ACTICA == true && s.CORREO_ELECTRONICO == CorreoUsuario).ToList();

                    if (ListadoMetodoPago.Count > 0)
                    {
                        GridMetodoPago.Visible = true;
                        GridMetodoPago.DataSource = ListadoMetodoPago;
                        GridMetodoPago.DataBind();
                    }
                    else
                    {
                        METODO_PAGO objPago = new METODO_PAGO();
                        ListadoMetodoPago.Add(objPago);

                        GridMetodoPago.DataSource = ListadoMetodoPago;
                        GridMetodoPago.DataBind();
                        GridMetodoPago.Rows[0].Cells.Clear();
                        GridMetodoPago.Rows[0].Cells.Add(new TableCell());
                        GridMetodoPago.Rows[0].Cells[0].ColumnSpan = 5;
                        GridMetodoPago.Rows[0].Cells[0].Text = "No hay métodos de pago registrados";
                        GridMetodoPago.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                    }
                    GridMetodoPago.EditIndex = -1;
                }
            }
            catch (Exception ex)
            {
                lblCamposPagoNulo.Visible = true;
                lblCamposPagoNulo.Text = ex.Message;
            }
        }

        protected void GridMetodoPago_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }

        protected void GridMetodoPago_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("AddNew"))
                {
                    METODO_PAGO objPago = new METODO_PAGO();
                    USUARIO objUsuario = new USUARIO();

                    String Usuario = Request.QueryString["CORREO_ELECTRONICO"];
                    String SessionUsuario = Session["CORREO_ELECTRONICO"].ToString();

                    objPago.CORREO_ELECTRONICO = SessionUsuario;
                    objPago.NUMERO_TARJETA = int.Parse((GridMetodoPago.FooterRow.FindControl("txt_footer_Numero_Tarjeta") as TextBox).Text.Trim());
                    objPago.NUMERO_EXPIRA_1 = int.Parse((GridMetodoPago.FooterRow.FindControl("txt_footer_Tarjeta_Mes") as TextBox).Text.Trim());
                    objPago.NUMERO_EXPIRA_2 = int.Parse((GridMetodoPago.FooterRow.FindControl("txt_footer_Tarjeta_Anno") as TextBox).Text.Trim());
                    objPago.TARJETA_ACTICA = bool.Parse((GridMetodoPago.FooterRow.FindControl("txt_CheckBox_Pago") as CheckBox).Text.Trim());

                    using (TIENDA_VIERNESEntities1 ContextoDB = new TIENDA_VIERNESEntities1())
                    {
                        ContextoDB.METODO_PAGO.Add(objPago);
                        ContextoDB.SaveChanges();
                        GridMetodoPago.EditIndex = -1;
                        CargarMetodoPago();
                    }
                }
                else
                {
                    lblCamposPagoNulo.Visible = true;
                    lblCamposPagoNulo.Text = "Error al registar el método de pago";
                }
            }
            catch (Exception ex)
            {
                lblCamposPagoNulo.Visible = true;
                lblCamposPagoNulo.Text = ex.Message;
            }
        }

        protected void GridMetodoPago_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                METODO_PAGO objPago = new METODO_PAGO();

                string usuario = Request.QueryString["USUARIO"];

                objPago.NUMERO_TARJETA = Int64.Parse((GridMetodoPago.DataKeys[e.RowIndex].Value.ToString()));

                using (TIENDA_VIERNESEntities1 ContextoDB = new TIENDA_VIERNESEntities1())
                {
                    METODO_PAGO aux = ContextoDB.METODO_PAGO.Find(objPago.NUMERO_TARJETA);

                    ContextoDB.METODO_PAGO.Remove(aux);
                    ContextoDB.SaveChanges();
                    CargarMetodoPago();
                    lblCamposPagoNulo.Visible = true;
                    lblCamposPagoNulo.Text = "Eliminado correctamente";
                }
            }
            catch (Exception ex)
            {
                lblCamposPagoNulo.Visible = true;
                lblCamposPagoNulo.Text = ex.Message;
            }
        }

        protected void GridMetodoPago_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void GridMetodoPago_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void GridMetodoPago_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //protected void NuevoPago_Click()
        //{
        //    try
        //    {
        //        if (CajaAnnoTarjeta.Text != null &&
        //            CajaMesTarjeta.Text != null &&
        //            CajaNumeroTarjeta.Text != null &&
        //            CheckBoxActiva.Checked
        //            )
        //        {
        //            CrearMetodoPago();
        //            ValidacionIngresoMetodoPago();
        //        }
        //        else
        //        {
        //            lblCamposPagoNulo.Visible = true;
        //            lblCamposPagoNulo.Text = "Se ha producido un error";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        lblCamposPagoNulo.Visible = true;
        //        lblCamposPagoNulo.Text = ex.Message;
        //    }
        //}
    }
}