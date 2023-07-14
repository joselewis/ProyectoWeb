using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;

namespace Tienda.MetodoPago
{
    public partial class MetodoPago2 : System.Web.UI.Page
    {
        int Creacion_Metodo_Pago = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarMetodoPago();
            }
        }

        void CrearMetodoPago()
        {
            try
            {
                using (TIENDA_VIERNESEntities ContextoDB = new TIENDA_VIERNESEntities())
                {
                    String Usuario = Session["CORREO_ELECTRONICO"].ToString();

                    METODO_PAGO oPago = new METODO_PAGO();

                    oPago.NUMERO_TARJETA = Convert.ToInt64(CajaNumeroTarjeta.Text);
                    oPago.NUMERO_EXPIRA_1 = Convert.ToInt32(CajaMesTarjeta.Text);
                    oPago.NUMERO_EXPIRA_2 = Convert.ToInt32(CajaAnnoTarjeta.Text);
                    oPago.CODIGO_TARJETA = Convert.ToInt32(CajaCódigoTarjeta.Text);
                    oPago.TARJETA_ACTICA = CheckBoxTarjetaActiva.Checked;
                    oPago.CORREO_ELECTRONICO = Usuario;

                    ContextoDB.METODO_PAGO.Add(oPago);
                    ContextoDB.SaveChanges();

                    Creacion_Metodo_Pago = 1;
                }
            }
            catch(Exception ex) 
            {
                lblCamposPagoNulo.Visible = true;
                lblCamposPagoNulo.Text = ex.Message;
            }
        }

        void ValidacionIngresoMetodoPago()
        {
            try
            {
                if (Creacion_Metodo_Pago == 1)
                {
                    Response.Redirect("../MetodoPago/MetodoPago2.aspx");
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
                using (TIENDA_VIERNESEntities ContextoDB = new TIENDA_VIERNESEntities())
                {
                    string CorreoUsuario = (string)Page.Session["CORREO_ELECTRONICO"];

                    var ListadoMetodoPago = ContextoDB.METODO_PAGO.Where(s => s.TARJETA_ACTICA == true && s.CORREO_ELECTRONICO == CorreoUsuario).ToList();

                    if (ListadoMetodoPago.Count > 0)
                    {
                        LabelMetodoPagoRegistrado.Visible = true;
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

        protected void GridMetodoPago_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //try
            //{
            //    if (e.CommandName.Equals("AddNew"))
            //    {
            //        METODO_PAGO objPago = new METODO_PAGO();
            //        USUARIO objUsuario = new USUARIO();

            //        String Usuario = Request.QueryString["CORREO_ELECTRONICO"];
            //        String SessionUsuario = Session["CORREO_ELECTRONICO"].ToString();

            //        objPago.CORREO_ELECTRONICO = SessionUsuario;
            //        objPago.NUMERO_TARJETA = int.Parse((GridMetodoPago.FooterRow.FindControl("txt_footer_Numero_Tarjeta") as TextBox).Text.Trim());
            //        objPago.NUMERO_EXPIRA_1 = int.Parse((GridMetodoPago.FooterRow.FindControl("txt_footer_Tarjeta_Mes") as TextBox).Text.Trim());
            //        objPago.NUMERO_EXPIRA_2 = int.Parse((GridMetodoPago.FooterRow.FindControl("txt_footer_Tarjeta_Anno") as TextBox).Text.Trim());
            //        objPago.TARJETA_ACTICA = bool.Parse((GridMetodoPago.FooterRow.FindControl("txt_CheckBox_Pago") as CheckBox).Text.Trim());

            //        using (TIENDA_VIERNESEntities ContextoDB = new TIENDA_VIERNESEntities())
            //        {
            //            ContextoDB.METODO_PAGO.Add(objPago);
            //            ContextoDB.SaveChanges();
            //            GridMetodoPago.EditIndex = -1;
            //            CargarMetodoPago();
            //        }
            //    }
            //    else
            //    {
            //        lblCamposPagoNulo.Visible = true;
            //        lblCamposPagoNulo.Text = "Error al registar el método de pago";
            //    }
            //}
            //catch (Exception ex)
            //{
            //    lblCamposPagoNulo.Visible = true;
            //    lblCamposPagoNulo.Text = ex.Message;
            //}
        }

        protected void GridMetodoPago_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                METODO_PAGO objPago = new METODO_PAGO();

                string usuario = Request.QueryString["CORREO_ELECTRONICO"];

                objPago.NUMERO_TARJETA = Int64.Parse((GridMetodoPago.DataKeys[e.RowIndex].Value.ToString()));

                using (TIENDA_VIERNESEntities ContextoDB = new TIENDA_VIERNESEntities())
                {
                    METODO_PAGO aux = ContextoDB.METODO_PAGO.Find(objPago.NUMERO_TARJETA);

                    ContextoDB.METODO_PAGO.Remove(aux);
                    ContextoDB.SaveChanges();
                    CargarMetodoPago();
                    lblCamposPagoNulo.Visible = true;
                    lblCamposPagoNulo.Text = "Eliminado correctamente";

                    Response.Redirect("../MetodoPago/MetodoPago2.aspx");
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

        protected void GridMetodoPago_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }

        protected void GridMetodoPago_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ButtonAnnadirPago_Click(object sender, EventArgs e)
        {
            try
            {
                if (CajaAnnoTarjeta.Text != null &&
                    CajaCódigoTarjeta.Text != null &&
                    CajaMesTarjeta.Text != null &&
                    CajaNumeroTarjeta != null
                    )
                {
                    CrearMetodoPago();
                    ValidacionIngresoMetodoPago();
                }
                else
                {
                    lblCamposPagoNulo.Visible = true;
                    lblCamposPagoNulo.Text = "Ha ocurrido un error";
                }
            }
            catch(Exception ex)
            {
                lblCamposPagoNulo.Visible = true;
                lblCamposPagoNulo.Text = ex.Message;
            }
        }
    }
}