using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;

namespace Tienda.OrdenCompra
{
    public partial class TodasOrdenesCompra : System.Web.UI.Page
    {
        DateTime Fecha;

        protected void Page_Load(object sender, EventArgs e)
        {
            ExtraerInfoHistorial();
            CrearHistorialCompra();
        }

        void ExtraerInfoHistorial()
        {
            String Rol = Session["TIPO_USUARIO"].ToString();
            String CorreoUsuario = Session["CORREO_ELECTRONICO"].ToString();

            string cs = @"DATA SOURCE = JOSELEWIS; INITIAL CATALOG = TIENDA_VIERNES; USER = JoseLewis10; PASSWORD = joselewis10";
            SqlConnection con = new SqlConnection(@"DATA SOURCE = JOSELEWIS; INITIAL CATALOG = TIENDA_VIERNES; USER = JoseLewis10; PASSWORD = joselewis10");

            try
            {
                if (Rol == "Normal")
                {
                    using (SqlConnection connection = new SqlConnection(cs))
                    {
                        DataSet ds = new DataSet();

                        SqlCommand cmd = new SqlCommand("SP_HISTORIAL_USUARIO", connection);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@ID", CorreoUsuario);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                        adapter.Fill(ds);
                        adapter.SelectCommand = cmd;

                        var dt = ds.Tables[0];

                        foreach (DataRow dtRow in dt.Rows)
                        {
                            Fecha = Convert.ToDateTime(dtRow["FECHA_ORDEN"].ToString());
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                LblError.Visible = true;
                LblError.Text = ex.Message;
            }
        }

        void CrearHistorialCompra()
        {
            string Historial = "<br/>" +
                                    "<div class='accordion' id='accordionPanelsStayOpenExample'>" +
                                        "<div class='accordion-item' style='margin-left: 50px; margin-right: 50px;'>" +
                                            "<h2 class='accordion-header'  >" +
                                                "<button class='accordion-button collapsed' type='button' data-bs-toggle='collapse' data-bs-target='#panelsStayOpen-collapseThree' aria-expanded='false' aria-controls='panelsStayOpen-collapseThree'>" +
                                                Fecha +
                                                "</button>" +
                                            "</h2>" +
                                            "<div id='panelsStayOpen-collapseThree' class='accordion-collapse collapse'>" +
                                                "<div class='accordion-body'>" +
                                                "<strong>" +
                                                "This is the third item's accordion body." +
                                                "</strong>" +
                                                " It is hidden by default, until the collapse plugin adds the appropriate classes that we use to style each element. These classes control the overall appearance, as well as the showing and hiding via CSS transitions." +
                                                "</strong>" +
                                                "</div>" +
                                            "</div>" +
                                        "</div>" +
                                    "</div>";
                               
            Cosa.InnerHtml = Historial;   
        }
    }
}